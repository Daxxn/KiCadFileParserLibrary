using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

using static System.Runtime.InteropServices.JavaScript.JSType;

namespace KiCadFileParserLibrary.KiCad.Footprints.SubModels
{
   [SExprNode("options")]
   public class PadOptions : IKiCadReadable
   {
      #region Local Props
      [SExprSubNode("clearance")]
      public CustomPadClearance Clearance { get; set; }

      [SExprSubNode("anchor")]
      public CustomPadAnchor Anchor { get; set; }
      #endregion

      #region Constructors
      public PadOptions() { }
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
         builder.AppendLine("(options");

         builder.Append('\t', indent + 1);
         builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("clearance", Clearance));

         builder.Append('\t', indent + 1);
         builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("anchor", Anchor));

         builder.Append('\t', indent);
         builder.AppendLine(")");
      }
      #endregion

      #region Full Props

      #endregion
   }
}
