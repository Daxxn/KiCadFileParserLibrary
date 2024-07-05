using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.Footprints.SubModels;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

namespace KiCadFileParserLibrary.KiCad.General.Graphics
{
   [SExprNode("dimension")]
   public class DimensionModel : GraphicBase
   {
      #region Local Props
      [SExprToken("locked")]
      public bool Locked { get; set; }

      [SExprSubNode("type")]
      public DimensionType Type { get; set; }

      [SExprSubNode("layer")]
      public string Layer { get; set; } = "";

      [SExprSubNode("height")]
      public double Height { get; set; }

      [SExprSubNode("uuid")]
      public string ID { get; set; } = "";

      public CoordinateModel? Points { get; set; }

      [SExprSubNode("leader_length")]
      public double LeaderLength { get; set; }

      public GrTextModel? Text { get; set; }

      public DimensionStyleModel? Style { get; set; }

      public DimensionFormatModel? Format { get; set; }
      #endregion

      #region Constructors
      public DimensionModel() { }
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
         builder.AppendLine("(dimension");

         builder.Append('\t', indent + 1);
         builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("type", Type));

         builder.Append('\t', indent + 1);
         builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("layer", Layer));

         builder.Append('\t', indent + 1);
         builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("uuid", ID));

         Points?.WriteNode(builder, indent + 1);

         builder.Append('\t', indent + 1);
         builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("height", Height));

         Text?.WriteNode(builder, indent + 1);

         Format?.WriteNode(builder, indent + 1);

         Style?.WriteNode(builder, indent + 1);

         builder.Append('\t', indent);
         builder.AppendLine(")");
      }
      #endregion

      #region Full Props

      #endregion
   }
}
