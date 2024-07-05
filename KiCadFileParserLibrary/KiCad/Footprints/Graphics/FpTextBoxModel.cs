using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.Footprints.SubModels;
using KiCadFileParserLibrary.KiCad.General;
using KiCadFileParserLibrary.KiCad.General.Graphics;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

namespace KiCadFileParserLibrary.KiCad.Footprints.Graphics
{
   [SExprNode("fp_text_box")]
   public class FpTextBoxModel : GraphicBase
   {
      #region Local Props
      [SExprToken("locked")]
      public bool Locked { get; set; }

      [SExprProperty(1, true)]
      public string Text { get; set; } = "";

      [SExprNode("start")]
      public XyModel Start { get; set; } = new();

      [SExprNode("end")]
      public XyModel End { get; set; } = new();

      public CoordinateModel? Points { get; set; }

      [SExprSubNode("angle")]
      public double? Angle { get; set; }

      [SExprSubNode("border")]
      public bool HasBorder { get; set; }

      [SExprSubNode("layer")]
      public string Layer { get; set; } = "";

      [SExprSubNode("uuid")]
      public string ID { get; set; } = "";

      public EffectsModel Effects { get; set; } = new();

      public StrokeModel? Stroke { get; set; }

      public RenderCacheModel? RenderCache { get; set; }
      #endregion

      #region Constructors
      public FpTextBoxModel() { }
      #endregion

      #region Methods
      public override void ParseNode(Node node)
      {
         if (node.Properties != null && node.Children != null)
         {
            var props = GetType().GetProperties();

            KiCadParseUtils.ParseProperties(props, node, this);
            KiCadParseUtils.ParseSubNodes(props, node, this);
            KiCadParseUtils.ParseNodes(props, node, this);
            KiCadParseUtils.ParseTokens(props, node, this);
         }
      }

      public override void WriteNode(StringBuilder builder, int indent, string? auxName = null)
      {
         builder.Append('\t', indent);
         builder.AppendLine($"(fp_text_box \"{Text}\"");

         Start.WriteNode(builder, indent + 1, "start");
         End.WriteNode(builder, indent + 1, "end");

         if (Angle != null)
         {
            builder.Append('\t', indent + 1);
            builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("angle", Angle));
         }

         Points?.WriteNode(builder, indent + 1);

         builder.Append('\t', indent + 1);
         builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("layer", Layer));

         builder.Append('\t', indent + 1);
         builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("uuid", ID));

         Effects?.WriteNode(builder, indent + 1);

         if (HasBorder)
         {
            builder.Append('\t', indent + 1);
            builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("border", HasBorder));
         }

         Stroke?.WriteNode(builder, indent + 1);

         if (Locked)
         {
            builder.Append('\t', indent + 1);
            builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("locked", Locked));
         }

         RenderCache?.WriteNode(builder, indent + 1);

         builder.Append('\t', indent);
         builder.AppendLine(")");
      }
      #endregion

      #region Full Props

      #endregion
   }
}
