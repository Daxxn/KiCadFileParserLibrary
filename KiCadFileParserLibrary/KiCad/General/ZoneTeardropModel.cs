using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

namespace KiCadFileParserLibrary.KiCad.General
{
   [SExprNode("teardrop")]
   public class ZoneTeardropModel : IKiCadReadable
   {
      #region Local Props
      [SExprSubNode("type")]
      public TeardropType Type { get; set; }
      #endregion

      #region Constructors
      public ZoneTeardropModel() { }
      #endregion

      #region Methods
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
         builder.AppendLine("(teardrop");

         builder.Append('\t', indent + 1);
         builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("type", Type));

         builder.Append('\t', indent);
         builder.AppendLine(")");
      }
      #endregion

      #region Full Props

      #endregion
   }
}
