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

namespace KiCadFileParserLibrary.KiCad.General
{
   [SExprNode("xy")]
   public class XyModel : IKiCadReadable
   {
      #region Local Props
      [SExprProperty(1)]
      public double X { get; set; }

      [SExprProperty(2)]
      public double Y { get; set; }
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
         builder.Append('\t', indent);
         builder.AppendLine($"({(auxName ?? "xy")} {Math.Round(X, 6)} {Math.Round(Y, 6)})");
      }
      #endregion

      #region Full Props

      #endregion
   }
}
