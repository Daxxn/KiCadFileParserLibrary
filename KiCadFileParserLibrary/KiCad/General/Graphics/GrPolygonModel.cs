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
   [SExprNode("gr_poly")]
   public class GrPolygonModel : GraphicBase
   {
      #region Local Props
      public CoordinateModel Points { get; set; } = new();

      [SExprSubNode("locked")]
      public bool Locked { get; set; }

      public StrokeModel? Stroke { get; set; }

      [SExprSubNode("width")]
      public double? Width { get; set; }

      [SExprSubNode("fill")]
      public bool Fill { get; set; }

      [SExprSubNode("layer")]
      public string? Layer { get; set; }

      [SExprSubNode("uuid")]
      public string? ID { get; set; }
      #endregion

      #region Constructors
      public GrPolygonModel() { }
      #endregion

      #region Methods
      public override void ParseNode(Node node)
      {
         if (node.Children != null)
         {
            var props = GetType().GetProperties();

            KiCadParseUtils.ParseNodes(props, node, this);
            KiCadParseUtils.ParseSubNodes(props, node, this);
         }
      }

      public override void WriteNode(StringBuilder builder, int indent, string? auxName = null)
      {
         builder.Append('\t', indent);
         builder.AppendLine($"(gr_poly");

         Points?.WriteNode(builder, indent + 1);

         if (Locked)
         {
            builder.Append('\t', indent + 1);
            builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("locked", Locked));
         }

         Stroke?.WriteNode(builder, indent + 1);

         if (Width != null)
         {
            builder.Append('\t', indent + 1);
            builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("width", Width));
         }

         builder.Append('\t', indent + 1);
         builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("fill", Fill));

         if (Layer != null)
         {
            builder.Append('\t', indent + 1);
            builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("layer", Layer));
         }

         if (ID != null)
         {
            builder.Append('\t', indent + 1);
            builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("uuid", ID));
         }

         builder.Append('\t', indent);
         builder.AppendLine(")");
      }
      #endregion

      #region Full Props

      #endregion
   }
}
