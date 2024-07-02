using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.Pcb;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

namespace KiCadFileParserLibrary.KiCad.General
{
   [SExprNode("style")]
   public class DimensionStyleModel : IKiCadReadable
   {
      #region Local Props
      [SExprSubNode("thickness")]
      public double? Thickness { get; set; }

      [SExprSubNode("arrow_length")]
      public double? ArrowLength { get; set; }

      [SExprSubNode("text_position_mode")]
      public TextPositionMode TextPosition { get; set; }

      [SExprSubNode("extension_height")]
      public double? ExtensionHeight { get; set; }

      [SExprSubNode("extension_offset")]
      public double? ExtensionOffset { get; set; }

      [SExprSubNode("text_frame")]
      public TextFrameType TextFrame { get; set; }

      [SExprToken("keep_text_aligned")]
      public bool? KeepTextAligned { get; set; }
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
      #endregion

      #region Full Props

      #endregion
   }
}
