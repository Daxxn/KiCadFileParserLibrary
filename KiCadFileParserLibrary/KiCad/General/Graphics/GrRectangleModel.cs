using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

namespace KiCadFileParserLibrary.KiCad.General.Graphics
{
   [SExprNode("gr_rect")]
   public class GrRectangleModel : GraphicBase
   {
      #region Local Props
      [SExprNode("start")]
      public XyModel Start { get; set; } = new();

      [SExprNode("end")]
      public XyModel End { get; set; } = new();

      [SExprSubNode("locked")]
      public bool Locked { get; set; }

      [SExprSubNode("layer")]
      public string Layer { get; set; } = "";

      public StrokeModel Stroke { get; set; } = new();

      [SExprSubNode("fill")]
      public FillType Fill { get; set; }

      [SExprSubNode("uuid")]
      public string ID { get; set; } = "";
      #endregion

      #region Constructors
      public GrRectangleModel() { }
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
         builder.AppendLine($"(gr_rect");

         Start.WriteNode(builder, indent + 1, "start");
         End.WriteNode(builder, indent + 1, "end");

         if (Locked)
         {
            builder.Append('\t', indent + 1);
            builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("locked", Locked));
         }

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
