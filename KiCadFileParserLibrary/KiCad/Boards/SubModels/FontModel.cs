using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.General;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

using MVVMLibrary;

namespace KiCadFileParserLibrary.KiCad.Boards.SubModels
{
   /// <summary>
   /// Font descriptor used in a PCB.
   /// </summary>
   [SExprNode("font")]
   public class FontModel : Model, IKiCadReadable
   {
      #region Local Props
      private string? _family = null;
      private XyModel _size = new();
      private double _thickness = 0;
      private bool _bold = false;
      private bool _italic = false;
      #endregion

      #region Constructors
      /// <inheritdoc/>
      public FontModel() { }
      #endregion

      #region Methods
      /// <inheritdoc/>
      public void ParseNode(Node node)
      {
         if (node.Children != null)
         {
            var props = GetType().GetProperties();
            KiCadParseUtils.ParseNodes(props, node, this);
            KiCadParseUtils.ParseSubNodes(props, node, this);
         }
      }

      /// <inheritdoc/>
      public override string ToString() => $"Font {Family} - {Size} - Thick: {Thickness} - Bold: {Bold} - Italic: {Italic}";

      //public void WriteNode(StringBuilder builder, int indent, string? auxName = null)
      //{
      //   builder.Append('\t', indent);
      //   builder.AppendLine($"(font");

      //   if (Family != null)
      //   {
      //      builder.Append('\t', indent + 1);
      //      builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("face", Family));
      //   }

      //   Size.WriteNode(builder, indent + 1, "size");

      //   builder.Append('\t', indent + 1);
      //   builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("thickness", Thickness));

      //   if (Bold)
      //   {
      //      builder.Append('\t', indent + 1);
      //      builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("bold", Bold));
      //   }

      //   if (Italic)
      //   {
      //      builder.Append('\t', indent + 1);
      //      builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("italic", Italic));
      //   }

      //   builder.Append('\t', indent);
      //   builder.AppendLine(")");
      //}
      #endregion

      #region Full Props
      /// <summary>
      /// Name of the font family.
      /// </summary>
      [SExprSubNode("face")]
      public string? Family
      {
         get => _family;
         set
         {
            _family = value;
            OnPropertyChanged();
         }
      }

      /// <summary>
      /// Size of the font.
      /// </summary>
      [SExprNode("size")]
      public XyModel Size
      {
         get => _size;
         set
         {
            _size = value;
            OnPropertyChanged();
         }
      }

      /// <summary>
      /// Thickness of the letters in the font.
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
      /// Bold setting.
      /// </summary>
      [SExprSubNode("bold")]
      public bool Bold
      {
         get => _bold;
         set
         {
            _bold = value;
            OnPropertyChanged();
         }
      }

      /// <summary>
      /// Italics setting.
      /// </summary>
      [SExprSubNode("italic")]
      public bool Italic
      {
         get => _italic;
         set
         {
            _italic = value;
            OnPropertyChanged();
         }
      }
      #endregion
   }
}
