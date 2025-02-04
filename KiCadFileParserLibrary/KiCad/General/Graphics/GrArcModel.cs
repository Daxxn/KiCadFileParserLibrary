using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

namespace KiCadFileParserLibrary.KiCad.General.Graphics
{
   [SExprNode("gr_arc")]
   public class GrArcModel : GraphicBase
   {
      #region Local Props
      [SExprNode("start")]
      public XyModel Start { get; set; } = new();

      [SExprNode("mid")]
      public XyModel Middle { get; set; } = new();

      [SExprNode("end")]
      public XyModel End { get; set; } = new();

      public StrokeModel Stroke { get; set; } = new();

      [SExprSubNode("layer")]
      public string Layer { get; set; } = "";

      [SExprSubNode("uuid")]
      public string ID { get; set; } = "";

      [SExprSubNode("locked")]
      public bool Locked { get; set; }
      #endregion

      #region Constructors
      public GrArcModel() { }
      #endregion

      #region Methods
      public override void ParseNode(Node node)
      {
         if (node.Children != null)
         {
            var props = GetType().GetProperties();

            KiCadParseUtils.ParseSubNodes(props, node, this);
            KiCadParseUtils.ParseNodes(props, node, this);
         }
      }

      public override void WriteNode(StringBuilder builder, int indent, string? auxName = null)
      {
         builder.Append('\t', indent);
         builder.AppendLine($"(gr_arc");

         Start.WriteNode(builder, indent + 1, "start");
         Middle.WriteNode(builder, indent + 1, "mid");
         End.WriteNode(builder, indent + 1, "end");

         if (Locked)
         {
            builder.Append('\t', indent + 1);
            builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("locked", Locked));
         }

         Stroke.WriteNode(builder, indent + 1);

         builder.Append('\t', indent + 1);
         builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("layer", Layer));

         builder.Append('\t', indent + 1);
         builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("uuid", ID));

         builder.Append('\t', indent);
         builder.AppendLine(")");
      }
      #endregion

      #region Full Props

      #endregion
   }
}
