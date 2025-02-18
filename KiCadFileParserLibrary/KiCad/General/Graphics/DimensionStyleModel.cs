using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

using MVVMLibrary;

namespace KiCadFileParserLibrary.KiCad.General.Graphics;

/// <summary>
/// Style data for a <see cref="DimensionModel">Dimension.</see>
/// </summary>
[SExprNode("style")]
public class DimensionStyleModel : Model, IKiCadReadable
{
   #region Local Props
   private bool _keepTextAlign;
   private double _thickness;
   private double _arrowLength;
   private TextPositionMode _textPosition;
   private double? _extensionHeight;
   private TextFrameType? _textFrame;
   private double? _extOffset;
   #endregion

   #region Constructors
   /// <inheritdoc/>
   public DimensionStyleModel() { }
   #endregion

   #region Methods
   /// <inheritdoc/>
   public void ParseNode(Node node)
   {
      if (node.Children is null) return;
      var props = GetType().GetProperties();

      KiCadParseUtils.ParseSubNodes(props, node, this);
      KiCadParseUtils.ParseTokens(props, node, this);
   }
   #endregion

   #region Full Props
   /// <summary>
   /// Keep text aligned with the dimension line.
   /// </summary>
   [SExprToken("keep_text_aligned")]
   public bool KeepTextAligned
   {
      get => _keepTextAlign;
      set
      {
         _keepTextAlign = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Thickness of dimension lines.
   /// </summary>
   [SExprSubNode("thickness")]
   public double Thickness
   {
      get => _thickness;
      set
      {
         _thickness = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// The size of dimension arrows.
   /// </summary>
   [SExprSubNode("arrow_length")]
   public double ArrowLength
   {
      get => _arrowLength;
      set
      {
         _arrowLength = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Text position.
   /// </summary>
   [SExprSubNode("text_position_mode")]
   [SExprFormatting(true, false)]
   public TextPositionMode TextPosition
   {
      get => _textPosition;
      set
      {
         _textPosition = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Extension height.
   /// </summary>
   [SExprSubNode("extension_height")]
   public double? ExtensionHeight
   {
      get => _extensionHeight;
      set
      {
         _extensionHeight = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Text frame option.
   /// </summary>
   [SExprSubNode("text_frame")]
   [SExprFormatting(true, true)]
   public TextFrameType? TextFrame
   {
      get => _textFrame;
      set
      {
         _textFrame = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Extension offset.
   /// </summary>
   [SExprSubNode("extension_offset")]
   public double? ExtensionOffset
   {
      get => _extOffset;
      set
      {
         _extOffset = value;
         OnPropertyChanged();
      }
   }
   #endregion
}
