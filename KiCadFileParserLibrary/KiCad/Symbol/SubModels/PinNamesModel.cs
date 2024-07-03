using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.General;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

namespace KiCadFileParserLibrary.KiCad.Symbol.SubModels
{
   [SExprNode("pin_names")]
   public class PinNamesModel : IKiCadReadable
   {
      #region Local Props
      [SExprToken("hide")]
      public SymbolVisibility Visible { get; set; }

      [SExprSubNode("offset")]
      public double? Offset { get; set; }
      #endregion

      #region Constructors
      public PinNamesModel() { }
      #endregion

      #region Methods
      public void ParseNode(Node node)
      {
         if (node.Children != null && node.Properties != null)
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
