using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

using MVVMLibrary;

namespace KiCadFileParserLibrary.KiCad.Boards
{
   [SExprNode("layer")]
   public class StackupLayer : Model, IKiCadReadable
   {
      #region Local Props
      private string? _name;
      private string? _type;
      private string? _color;
      private string? _material;
      private double? _thickness;
      private double? _epsilon;
      private double? _loss;
      private bool _locked;
      #endregion

      #region Constructors
      public StackupLayer() { }
      #endregion

      #region Methods
      public void ParseNode(Node node)
      {
         if (node.Properties != null && node.Children != null)
         {
            var props = GetType().GetProperties();

            KiCadParseUtils.ParseProperties(props, node, this);
            KiCadParseUtils.ParseSubNodes(props, node, this);

            var thickNode = node.GetNode("thickness");
            if (thickNode is null) return;
            if (thickNode.Properties!.Count > 2)
            {
               if (thickNode.Properties[2] == "locked")
               {
                  Locked = true;
               }
            }
         }
      }

      public void WriteNode(StringBuilder builder, int indent, string? auxName = null)
      {
         builder.Append('\t', indent);
         builder.AppendLine($"(layer \"{Name}\"");
         builder.Append('\t', indent + 1);
         builder.AppendLine($"(type \"{Type}\")");
         if (Color != null)
         {
            builder.Append('\t', indent + 1);
            builder.AppendLine($"(color \"{Color}\")");
         }
         if (Thickness != null)
         {
            builder.Append('\t', indent + 1);
            builder.Append($"(thickness {Thickness}");
            if (Locked)
            {
               builder.AppendLine($" locked)");
            }
            else
            {
               builder.AppendLine(")");
            }
         }
         if (Material != null)
         {
            builder.Append('\t', indent + 1);
            builder.AppendLine($"(material \"{Material}\")");
         }
         if (EpsilonR != null)
         {
            builder.Append('\t', indent + 1);
            builder.AppendLine($"(epsilon_r {EpsilonR})");
         }
         if (LossTangent != null)
         {
            builder.Append('\t', indent + 1);
            builder.AppendLine($"(loss_tangent {LossTangent})");
         }
         builder.Append('\t', indent);
         builder.AppendLine(")");
      }

      public override string ToString()
      {
         return $"Stackup-Layer - {Name} - Type: {Type} - Color: {Color} - Material: {Material} - Thickness: {Thickness} - eR: {EpsilonR} - Loss-Tan: {LossTangent} - Locked: {Locked}";
      }
      #endregion

      #region Full Props
      [SExprProperty(1)]
      public string? Name
      {
         get => _name;
         set
         {
            _name = value;
            OnPropertyChanged();
         }
      }

      [SExprSubNode("type")]
      public string? Type
      {
         get => _type;
         set
         {
            _type = value;
            OnPropertyChanged();
         }
      }

      [SExprSubNode("color")]
      public string? Color
      {
         get => _color;
         set
         {
            _color = value;
            OnPropertyChanged();
         }
      }

      [SExprSubNode("material")]
      public string? Material
      {
         get => _material;
         set
         {
            _material = value;
            OnPropertyChanged();
         }
      }

      [SExprSubNode("thickness")]
      public double? Thickness
      {
         get => _thickness;
         set
         {
            _thickness = value;
            OnPropertyChanged();
         }
      }

      [SExprSubNode("epsilon_r")]
      public double? EpsilonR
      {
         get => _epsilon;
         set
         {
            _epsilon = value;
            OnPropertyChanged();
         }
      }

      [SExprSubNode("loss_tangent")]
      public double? LossTangent
      {
         get => _loss;
         set
         {
            _loss = value;
            OnPropertyChanged();
         }
      }

      [SExprToken("locked")]
      public bool Locked
      {
         get => _locked;
         set
         {
            _locked = value;
            OnPropertyChanged();
         }
      }
      #endregion
   }
}
