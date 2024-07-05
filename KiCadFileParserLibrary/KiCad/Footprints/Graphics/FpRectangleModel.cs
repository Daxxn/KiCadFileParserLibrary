using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.General;
using KiCadFileParserLibrary.KiCad.General.Graphics;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

namespace KiCadFileParserLibrary.KiCad.Footprints.Graphics
{
   [SExprNode("fp_rect")]
   public class FpRectangleModel : GraphicBase
   {
      #region Local Props
      [SExprNode("start")]
      public XyModel Start { get; set; } = new();

      [SExprNode("end")]
      public XyModel End { get; set; } = new();

      [SExprSubNode("layer")]
      public string Layer { get; set; } = "";

      [SExprSubNode("width")]
      public double Width { get; set; } = 0;

      [SExprNode("stroke")]
      public StrokeModel Stroke { get; set; } = new();

      [SExprSubNode("fill")]
      public FillType Fill { get; set; }

      [SExprToken("locked")]
      public bool Locked { get; set; }

      [SExprSubNode("uuid")]
      public string ID { get; set; } = "";
      #endregion

      #region Constructors
      public FpRectangleModel() { }
      #endregion

      #region Methods
      public override void ParseNode(Node node)
      {
         if (node.Properties != null && node.Children != null)
         {
            var props = GetType().GetProperties();

            KiCadParseUtils.ParseSubNodes(props, node, this);
            KiCadParseUtils.ParseNodes(props, node, this);
            KiCadParseUtils.ParseTokens(props, node, this);
         }
      }

      public override void WriteNode(StringBuilder builder, int indent, string? auxName = null)
      {
         builder.Append('\t', indent);
         builder.AppendLine("(fp_rect");

         Start.WriteNode(builder, indent + 1, "start");
         End.WriteNode(builder, indent + 1, "end");

         Stroke.WriteNode(builder, indent + 1);

         builder.Append('\t', indent + 1);
         builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("fill", Fill));

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
