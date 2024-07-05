using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

namespace KiCadFileParserLibrary.KiCad.Boards
{
   [SExprNode("layer")]
   public class StackupLayer : IKiCadReadable
   {
      [SExprProperty(1)]
      public string? Name { get; set; }

      [SExprSubNode("type")]
      public string? Type { get; set; }

      [SExprSubNode("color")]
      public string? Color { get; set; }

      [SExprSubNode("material")]
      public string? Material { get; set; }

      [SExprSubNode("thickness")]
      public double? Thickness { get; set; }

      [SExprSubNode("epsilon_r")]
      public double? EpsilonR { get; set; }

      [SExprSubNode("loss_tangent")]
      public double? LossTangent { get; set; }

      [SExprToken("locked")]
      public bool Locked { get; set; }

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
   }
}
