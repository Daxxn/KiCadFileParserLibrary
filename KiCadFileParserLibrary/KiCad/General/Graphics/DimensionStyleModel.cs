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

namespace KiCadFileParserLibrary.KiCad.General.Graphics
{
   [SExprNode("style")]
   public class DimensionStyleModel : Model, IKiCadReadable
   {
      #region Local Props
      private bool _keepTextAlign;
      private double _thickness;
      private double _arrowLength;
      private TextPositionMode _textPosition;
      private double? _extensionHeight;
      private TextFrameType _textFrame;
      private double? _extOffset;
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

      [SExprSubNode("text_position_mode")]
      public TextPositionMode TextPosition
      {
         get => _textPosition;
         set
         {
            _textPosition = value;
            OnPropertyChanged();
         }
      }

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

      [SExprSubNode("text_frame")]
      public TextFrameType TextFrame
      {
         get => _textFrame;
         set
         {
            _textFrame = value;
            OnPropertyChanged();
         }
      }

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
}
