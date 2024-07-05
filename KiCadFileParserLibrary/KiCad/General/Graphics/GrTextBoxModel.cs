using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.Footprints.SubModels;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

namespace KiCadFileParserLibrary.KiCad.General.Graphics
{
   [SExprNode("gr_text_box")]
   public class GrTextBoxModel : GraphicBase
   {
      #region Local Props
      [SExprSubNode("locked")]
      public bool Locked { get; set; }

      [SExprProperty(1, true)]
      public string Text { get; set; } = "";

      [SExprSubNode("start")]
      public XyModel? Start { get; set; }

      [SExprSubNode("end")]
      public XyModel? End { get; set; }

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
      public GrTextBoxModel() { }
      #endregion

      #region Methods
      public override void ParseNode(Node node)
      {
         if (node.Children != null && node.Properties != null)
         {
            var props = GetType().GetProperties();

            KiCadParseUtils.ParseNodes(props, node, this);
            KiCadParseUtils.ParseSubNodes(props, node, this);
            KiCadParseUtils.ParseProperties(props, node, this);
         }
      }

      public override void WriteNode(StringBuilder builder, int indent, string? auxName = null)
      {
         builder.Append('\t', indent);
         builder.AppendLine($"(gr_text_box \"{Text}\"");

         if (Locked)
         {
            builder.Append('\t', indent + 1);
            builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("locked", Locked));
         }

         Start?.WriteNode(builder, indent + 1);
         End?.WriteNode(builder, indent + 1);

         Points?.WriteNode(builder, indent + 1);

         if (Angle != null)
         {
            builder.Append('\t', indent + 1);
            builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("angle", Angle));
         }

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

         RenderCache?.WriteNode(builder, indent + 1);

         builder.Append('\t', indent);
         builder.AppendLine(")");
      }
      #endregion

      #region Full Props

      #endregion
   }
}
