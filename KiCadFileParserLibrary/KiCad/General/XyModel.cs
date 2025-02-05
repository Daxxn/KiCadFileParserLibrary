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
   [SExprNode("xy")]
   public class XyModel : Model, IKiCadReadable
   {
      #region Local Props
      private double _x;
      private double _y;
      #endregion

      #region Constructors
      public XyModel() { }
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
         //if (auxName != null)
         //{
         //   builder.Append('\t', indent);
         //   builder.AppendLine($"({(auxName ?? "xy")} {Math.Round(X, 6)} {Math.Round(Y, 6)})");
         //}
         //else
         //{
         //   builder.Append($"({(auxName ?? "xy")} {Math.Round(X, 6)} {Math.Round(Y, 6)})");
         //}

         builder.Append('\t', indent);
         builder.AppendLine($"({(auxName ?? "xy")} {Math.Round(X, 6)} {Math.Round(Y, 6)})");
      }

      public override string ToString()
      {
         return $"XY - X: {X} - Y: {Y}";
      }
      #endregion

      #region Full Props
      [SExprProperty(1)]
      public double X
      {
         get => _x;
         set
         {
            _x = value;
            OnPropertyChanged();
         }
      }

      [SExprProperty(2)]
      public double Y
      {
         get => _y;
         set
         {
            _y = value;
            OnPropertyChanged();
         }
      }
      #endregion
   }
}
