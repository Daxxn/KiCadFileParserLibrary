using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.Footprints.Graphics;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

namespace KiCadFileParserLibrary.KiCad.General.Graphics
{
   [SExprNode("gr_text")]
   public class GrTextModel : GraphicBase
   {
      #region Local Props
      [SExprSubNode("locked")]
      public bool Locked { get; set; }

      [SExprProperty(1)]
      public string Text { get; set; } = "";

      //[SExprSubNode("layer")]
      //public string Layer { get; set; } = "";
      public FpTextLayerModel Layer { get; set; } = new();

      private bool Knockout { get; set; } = false;

      public LocationModel? Location { get; set; }

      [SExprSubNode("uuid")]
      public string ID { get; set; } = "";

      public EffectsModel? Effects { get; set; }

      public RenderCacheModel? RenderCache { get; set; }
      #endregion

      #region Constructors
      public GrTextModel() { }
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
            KiCadParseUtils.ParseListNodes(props, node, this);
         }
      }

      public override void WriteNode(StringBuilder builder, int indent, string? auxName = null)
      {
         builder.Append('\t', indent);
         builder.AppendLine($"(gr_text \"{Text}\"");

         if (Locked)
         {
            builder.Append('\t', indent + 1);
            builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("locked", Locked));
         }

         Location?.WriteNode(builder, indent + 1);

         Layer?.WriteNode(builder, indent + 1);
         //builder.Append('\t', indent + 1);
         //builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("layer", Layer));

         builder.Append('\t', indent + 1);
         builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("uuid", ID));

         Effects?.WriteNode(builder, indent + 1);

         RenderCache?.WriteNode(builder, indent + 1);

         builder.Append('\t', indent);
         builder.AppendLine(")");
      }
      #endregion

      #region Full Props

      #endregion
   }
}
