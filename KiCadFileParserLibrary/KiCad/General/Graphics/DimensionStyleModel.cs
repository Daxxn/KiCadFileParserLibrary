using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

namespace KiCadFileParserLibrary.KiCad.General.Graphics
{
   [SExprNode("style")]
   public class DimensionStyleModel : IKiCadReadable
   {
      #region Local Props
      [SExprToken("keep_text_aligned")]
      public bool KeepTextAligned { get; set; }

      [SExprSubNode("thickness")]
      public double Thickness { get; set; }

      [SExprSubNode("arrow_length")]
      public double ArrowLength { get; set; }

      [SExprSubNode("text_position_mode")]
      public TextPositionMode TextPosition { get; set; }

      [SExprSubNode("extension_height")]
      public double? ExtensionHeight { get; set; }

      [SExprSubNode("text_frame")]
      public TextFrameType TextFrame { get; set; }

      [SExprSubNode("extension_offset")]
      public double? ExtensionOffset { get; set; }
      #endregion

      #region Constructors
      public DimensionStyleModel() { }
      #endregion

      #region Methods
      public void ParseNode(Node node)
      {
         if (node.Children is null) return;
         var props = GetType().GetProperties();

         KiCadParseUtils.ParseSubNodes(props, node, this);
         KiCadParseUtils.ParseTokens(props, node, this);
      }

      public void WriteNode(StringBuilder builder, int indent, string? auxName = null)
      {
         builder.Append('\t', indent);
         builder.Append($"(style");

         if (KeepTextAligned)
         {
            builder.AppendLine(" keep_text_aligned");
         }
         else
         {
            builder.AppendLine();
         }

         builder.Append('\t', indent + 1);
         builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("thickness", Thickness));

         builder.Append('\t', indent + 1);
         builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("arrow_length", ArrowLength));

         builder.Append('\t', indent + 1);
         builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("text_position_mode", (int)TextPosition));

         if (ExtensionHeight != null)
         {
            builder.Append('\t', indent + 1);
            builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("extension_height", ExtensionHeight));
         }

         if (TextFrame != TextFrameType.NoFrame)
         {
            builder.Append('\t', indent + 1);
            builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("text_frame", (int)TextFrame));
         }

         if (ExtensionOffset != null)
         {
            builder.Append('\t', indent + 1);
            builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("extension_offset", ExtensionOffset));
         }

         builder.Append('\t', indent);
         builder.AppendLine($")");
      }
      #endregion

      #region Full Props

      #endregion
   }
}
