using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

namespace KiCadFileParserLibrary.KiCad.Boards.SubModels
{
   [SExprNode("general")]
   public class GeneralModel : IKiCadReadable
   {
      [SExprSubNode("thickness")]
      public double Thickness { get; set; }

      [SExprSubNode("legacy_teardrops")]
      public bool UseLegacyTeardrop { get; set; }

      public void ParseNode(Node node)
      {
         if (node.Children != null)
         {
            var props = GetType().GetProperties();
            KiCadParseUtils.ParseSubNodes(props, node, this);
         }
      }

      public void WriteNode(StringBuilder builder, int indent, string? auxName = null)
      {
         builder.Append('\t', indent);
         builder.AppendLine("(general");

         builder.Append('\t', indent + 1);
         builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("thickness", Thickness));

         builder.Append('\t', indent + 1);
         builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("legacy_teardrops", UseLegacyTeardrop));

         builder.Append('\t', indent);
         builder.AppendLine(")");
      }

      public override string ToString()
      {
         return $"General - Thick: {Thickness} - UseLegTD: {UseLegacyTeardrop}";
      }
   }
}
