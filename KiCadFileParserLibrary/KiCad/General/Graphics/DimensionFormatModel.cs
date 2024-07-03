using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

namespace KiCadFileParserLibrary.KiCad.General.Graphics
{
    [SExprNode("format")]
   public class DimensionFormatModel : IKiCadReadable
   {
      #region Local Props
      [SExprSubNode("prefix")]
      public string? Prefix { get; set; }

      [SExprSubNode("suffix")]
      public string? Suffix { get; set; }

      [SExprSubNode("units")]
      public UnitsType Units { get; set; }

      [SExprSubNode("units_format")]
      public UnitsFormat UnitsFormat { get; set; }

      [SExprSubNode("precision")]
      public int Precision { get; set; }

      [SExprSubNode("override_value")]
      public string? OverrideValue { get; set; }

      [SExprToken("suppress_zeros")]
      public bool SuppressZeros { get; set; }
      #endregion

      #region Constructors
      public DimensionFormatModel() { }
      #endregion

      #region Methods
      public void ParseNode(Node node)
      {
         if (node.Children != null)
         {
            var props = GetType().GetProperties();

            KiCadParseUtils.ParseSubNodes(props, node, this);
            KiCadParseUtils.ParseTokens(props, node, this);
         }
      }
      #endregion

      #region Full Props

      #endregion
   }
}
