using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.General;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

using MVVMLibrary;

namespace KiCadFileParserLibrary.KiCad.Footprints.SubModels
{
   [SExprNode("property")]
   public class PropertyModel : Model, IKiCadReadable
   {
      #region Local Props
      private string _key = "";
      private string _value = "";
      private LocationModel _location;
      private bool _unlocked;
      private bool _hide;
      private string _layer = "";
      private string _id = "";
      private EffectsModel _effects = new();
      #endregion

      #region Constructors
      public PropertyModel() { }
      #endregion

      #region Methods
      public void ParseNode(Node node)
      {
         if (node.Properties != null && node.Children != null)
         {
            var props = GetType().GetProperties();
            KiCadParseUtils.ParseProperties(props, node, this);
            KiCadParseUtils.ParseNodes(props, node, this);
            KiCadParseUtils.ParseSubNodes(props, node, this);
         }
      }

      public void WriteNode(StringBuilder builder, int indent, string? auxName = null)
      {
         builder.Append('\t', indent);
         builder.AppendLine($"(property \"{Key}\" \"{Value}\"");

         Location?.WriteNode(builder, indent + 1);

         if (Unlocked)
         {
            builder.Append('\t', indent + 1);
            builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("unlocked", Unlocked));
         }

         builder.Append('\t', indent + 1);
         builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("layer", Layer));

         if (Hide)
         {
            builder.Append('\t', indent + 1);
            builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("hide", Hide));
         }

         builder.Append('\t', indent + 1);
         builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("uuid", ID));

         Effects?.WriteNode(builder, indent + 1);

         builder.Append('\t', indent);
         builder.AppendLine(")");
      }
      #endregion

      #region Full Props
      [SExprProperty(1)]
      public string Key
      {
         get => _key;
         set
         {
            _key = value;
            OnPropertyChanged();
         }
      }

      [SExprProperty(2)]
      public string Value
      {
         get => _value;
         set
         {
            _value = value;
            OnPropertyChanged();
         }
      }

      public LocationModel Location
      {
         get => _location;
         set
         {
            _location = value;
            OnPropertyChanged();
         }
      }

      [SExprSubNode("unlocked")]
      public bool Unlocked
      {
         get => _unlocked;
         set
         {
            _unlocked = value;
            OnPropertyChanged();
         }
      }

      [SExprSubNode("hide")]
      public bool Hide
      {
         get => _hide;
         set
         {
            _hide = value;
            OnPropertyChanged();
         }
      }

      [SExprSubNode("layer")]
      public string Layer
      {
         get => _layer;
         set
         {
            _layer = value;
            OnPropertyChanged();
         }
      }

      [SExprSubNode("uuid")]
      public string ID
      {
         get => _id;
         set
         {
            _id = value;
            OnPropertyChanged();
         }
      }

      public EffectsModel Effects
      {
         get => _effects;
         set
         {
            _effects = value;
            OnPropertyChanged();
         }
      }
      #endregion
   }
}
