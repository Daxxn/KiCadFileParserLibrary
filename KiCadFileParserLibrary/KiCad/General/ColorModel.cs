using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

namespace KiCadFileParserLibrary.KiCad.General
{
   [SExprNode("color")]
   public class ColorModel : IKiCadReadable
   {
      #region Local Props
      [SExprProperty(1)]
      public double Red { get; set; }

      [SExprProperty(2)]
      public double Green { get; set; }

      [SExprProperty(3)]
      public double Blue { get; set; }

      [SExprProperty(4)]
      public double Alpha { get; set; }
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

      #endregion
   }
}
