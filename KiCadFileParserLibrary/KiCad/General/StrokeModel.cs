using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

using MVVMLibrary;

namespace KiCadFileParserLibrary.KiCad.General
{
   [SExprNode("stroke")]
   public class StrokeModel : Model, IKiCadReadable
   {
      #region Local Props
      private double _width;
      private StrokeType _type;
      private ColorModel? _color;
      #endregion

      #region Constructors
      public StrokeModel() { }
      #endregion

      #region Methods
      public void ParseNode(Node node)
      {
         if (node.Children != null)
         {
            var props = GetType().GetProperties();
            KiCadParseUtils.ParseSubNodes(props, node, this);
            KiCadParseUtils.ParseNodes(props, node, this);
         }
      }

      public void WriteNode(StringBuilder builder, int indent, string? auxName = null)
      {
         builder.Append('\t', indent);
         builder.AppendLine("(stroke");
         builder.Append('\t', indent + 1);
         builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("width", Width));
         builder.Append('\t', indent + 1);
         builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("type", Type));

         if (Color != null)
         {
            Color.WriteNode(builder, indent + 1);
         }

         builder.Append('\t', indent);
         builder.AppendLine(")");
      }
      #endregion

      #region Full Props
      [SExprSubNode("width")]
      public double Width
      {
         get => _width;
         set
         {
            _width = value;
            OnPropertyChanged();
         }
      }

      [SExprSubNode("type")]
      public StrokeType Type
      {
         get => _type;
         set
         {
            _type = value;
            OnPropertyChanged();
         }
      }

      public ColorModel? Color
      {
         get => _color;
         set
         {
            _color = value;
            OnPropertyChanged();
         }
      }
      #endregion
   }
}
