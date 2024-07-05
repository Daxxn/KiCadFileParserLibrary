using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.General;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

namespace KiCadFileParserLibrary.KiCad.Boards
{
   [SExprNode("arc")]
   public class TraceArcModel : IKiCadReadable
   {
      #region Local Props
      [SExprNode("start")]
      public LocationModel Start { get; set; } = new();

      [SExprNode("mid")]
      public LocationModel Middle { get; set; } = new();

      [SExprNode("end")]
      public LocationModel End { get; set; } = new();

      [SExprSubNode("width")]
      public double Width { get; set; }

      [SExprSubNode("layer")]
      public string Layer { get; set; } = "";

      [SExprSubNode("net")]
      public int Net { get; set; } = 0;

      [SExprSubNode("uuid")]
      public string? ID { get; set; }

      [SExprSubNode("locked")]
      public bool Locked { get; set; }
      #endregion

      #region Constructors
      public TraceArcModel() { }
      #endregion

      #region Methods
      public void ParseNode(Node node)
      {
         if (node.Properties != null && node.Children != null)
         {
            var props = GetType().GetProperties();

            KiCadParseUtils.ParseNodes(props, node, this);
            KiCadParseUtils.ParseSubNodes(props, node, this);
            KiCadParseUtils.ParseTokens(props, node, this);
         }
      }

      public void WriteNode(StringBuilder builder, int indent, string? auxName = null)
      {
         builder.Append('\t', indent);
         builder.AppendLine("(arc");

         Start?.WriteNode(builder, indent + 1, "start");
         Middle?.WriteNode(builder, indent + 1, "mid");
         End?.WriteNode(builder, indent + 1, "end");

         builder.Append('\t', indent + 1);
         KiCadWriteUtils.WriteSubNodeData("width", Width);

         if (Locked)
         {
            builder.Append('\t', indent + 1);
            KiCadWriteUtils.WriteSubNodeData("locked", Locked);
         }

         builder.Append('\t', indent + 1);
         KiCadWriteUtils.WriteSubNodeData("layer", Layer);

         builder.Append('\t', indent + 1);
         KiCadWriteUtils.WriteSubNodeData("net", Net);

         if (ID != null)
         {
            builder.Append('\t', indent + 1);
            KiCadWriteUtils.WriteSubNodeData("uuid", ID);
         }
         builder.Append('\t', indent);
         builder.AppendLine(")");
      }
      #endregion

      #region Full Props

      #endregion
   }
}
