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

namespace KiCadFileParserLibrary.KiCad.Boards.SubModels
{
   [SExprNode("font")]
   public class FontModel : IKiCadReadable
   {
      [SExprSubNode("face")]
      public string? Family { get; set; }

      [SExprNode("size")]
      public XyModel Size { get; set; } = new();

      [SExprSubNode("thickness")]
      public double Thickness { get; set; }

      [SExprSubNode("bold")]
      public bool Bold { get; set; }

      [SExprSubNode("italic")]
      public bool Italic { get; set; }

      public void ParseNode(Node node)
      {
         if (node.Children != null)
         {
            var props = GetType().GetProperties();
            KiCadParseUtils.ParseNodes(props, node, this);
            KiCadParseUtils.ParseSubNodes(props, node, this);
         }
      }

      public void WriteNode(StringBuilder builder, int indent, string? auxName = null)
      {
         builder.Append('\t', indent);
         builder.AppendLine($"(font");

         if (Family != null)
         {
            builder.Append('\t', indent + 1);
            builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("face", Family));
         }

         Size.WriteNode(builder, indent + 1, "size");

         builder.Append('\t', indent + 1);
         builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("thickness", Thickness));

         if (Bold)
         {
            builder.Append('\t', indent + 1);
            builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("bold", Bold));
         }

         if (Italic)
         {
            builder.Append('\t', indent + 1);
            builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("italic", Italic));
         }

         builder.Append('\t', indent);
         builder.AppendLine(")");
      }
   }
}
