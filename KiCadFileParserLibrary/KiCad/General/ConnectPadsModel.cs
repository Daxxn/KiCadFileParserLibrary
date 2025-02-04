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
   [SExprNode("connect_pads")]
   public class ConnectPadsModel : IKiCadReadable
   {
      #region Local Props
      [SExprToken("yes")]
      public bool Connected { get; set; }

      [SExprSubNode("clearance")]
      public double Clearance { get; set; }
      #endregion

      #region Constructors
      public ConnectPadsModel() { }
      #endregion

      #region Methods
      public void ParseNode(Node node)
      {
         if (node.Properties != null && node.Children != null)
         {
            var props = GetType().GetProperties();
            KiCadParseUtils.ParseSubNodes(props, node, this);
            KiCadParseUtils.ParseTokens(props, node, this);
         }
      }

      public void WriteNode(StringBuilder builder, int indent, string? auxName = null)
      {
         builder.Append('\t', indent);
         builder.Append("(connect_pads");

         if (Connected)
         {
            builder.AppendLine($" yes");
         }
         else
         {
            builder.AppendLine();
         }

         builder.Append('\t', indent + 1);
         builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("clearance", Clearance));

         builder.Append('\t', indent);
         builder.AppendLine(")");
      }
      #endregion

      #region Full Props

      #endregion
   }
}
