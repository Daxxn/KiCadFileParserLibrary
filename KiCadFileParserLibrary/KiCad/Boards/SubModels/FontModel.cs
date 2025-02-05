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
      public FontModel() { }
      #endregion

      #region Methods
      public void ParseNode(Node node)
      {
         if (node.Children != null)
         {
            var props = GetType().GetProperties();
            KiCadParseUtils.ParseNodes(props, node, this);
            KiCadParseUtils.ParseSubNodes(props, node, this);
         }
      }

      public void WriteNode(StringBuilder builder, int indent, string? auxName = null)
      {
         builder.Append('\t', indent);
         builder.AppendLine($"(font");

         if (Family != null)
         {
            builder.Append('\t', indent + 1);
            builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("face", Family));
         }

         Size.WriteNode(builder, indent + 1, "size");

         builder.Append('\t', indent + 1);
         builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("thickness", Thickness));

         if (Bold)
         {
            builder.Append('\t', indent + 1);
            builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("bold", Bold));
         }

         if (Italic)
         {
            builder.Append('\t', indent + 1);
            builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("italic", Italic));
         }

         builder.Append('\t', indent);
         builder.AppendLine(")");
      }
      #endregion

      #region Full Props
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
