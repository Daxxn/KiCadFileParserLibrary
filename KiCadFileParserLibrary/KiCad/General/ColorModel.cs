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

namespace KiCadFileParserLibrary.KiCad.General
{
   [SExprNode("color")]
   public class ColorModel : Model, IKiCadReadable
   {
      #region Local Props
      private double _red;
      private double _green;
      private double _blue;
      private double _alpha;
      #endregion

      #region Constructors
      public ColorModel() { }
      #endregion

      #region Methods
      public void ParseNode(Node node)
      {
         if (node.Properties != null)
         {
            var props = GetType().GetProperties();

            KiCadParseUtils.ParseProperties(props, node, this);
         }
      }

      public void WriteNode(StringBuilder builder, int indent, string? auxName = null)
      {
         builder.Append('\t', indent);
         builder.AppendLine($"(color {Red} {Green} {Blue} {Alpha})");
      }
      #endregion

      #region Full Props
      [SExprProperty(1)]
      public double Red
      {
         get => _red;
         set
         {
            _red = value;
            OnPropertyChanged();
         }
      }

      [SExprProperty(2)]
      public double Green
      {
         get => _green;
         set
         {
            _green = value;
            OnPropertyChanged();
         }
      }

      [SExprProperty(3)]
      public double Blue
      {
         get => _blue;
         set
         {
            _blue = value;
            OnPropertyChanged();
         }
      }

      [SExprProperty(4)]
      public double Alpha
      {
         get => _alpha;
         set
         {
            _alpha = value;
            OnPropertyChanged();
         }
      }
      #endregion
   }
}
