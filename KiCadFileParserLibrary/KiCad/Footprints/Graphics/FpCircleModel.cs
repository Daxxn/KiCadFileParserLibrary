using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.General;
using KiCadFileParserLibrary.KiCad.General.Graphics;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

namespace KiCadFileParserLibrary.KiCad.Footprints.Graphics
{
   [SExprNode("fp_circle")]
   public class FpCircleModel : GraphicBase
   {
      #region Local Props
      [SExprSubNode("layer")]
      public string Layer { get; set; } = "";

      [SExprSubNode("width")]
      public double Width { get; set; } = 0;

      [SExprSubNode("Fill")]
      public FillType Fill { get; set; } = FillType.None;

      [SExprSubNode("uuid")]
      public string ID { get; set; } = "";

      [SExprNode("center")]
      public XyModel Center { get; set; } = new();

      [SExprNode("end")]
      public XyModel End { get; set; } = new();

      public StrokeModel Stroke { get; set; } = new();
      #endregion

      #region Constructors
      public FpCircleModel() { }
      #endregion

      #region Methods
      public override void ParseNode(Node node)
      {
         if (node.Children != null && node.Properties != null)
         {
            var props = GetType().GetProperties();

            KiCadParseUtils.ParseNodes(props, node, this);
            KiCadParseUtils.ParseSubNodes(props, node, this);
            KiCadParseUtils.ParseTokens(props, node, this);
         }
      }

      public override void WriteNode(StringBuilder builder, int indent, string? auxName = null)
      {
         builder.Append('\t', indent);
         builder.AppendLine($"(fp_circle");

         Center.WriteNode(builder, indent + 1, "center");
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
