using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.KiCad.Symbol.Collections;
using KiCadFileParserLibrary.KiCad.Symbol.SubModels;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

namespace KiCadFileParserLibrary.KiCad.Symbol
{
   [SExprNode("symbol")]
   public class Symbol : IKiCadReadable
   {
      #region Local Props
      [SExprProperty(1)]
      public string? SymbolName { get; set; }

      [SExprSubNode("extends")]
      public string? ExtendsSymbol { get; set; }

      [SExprSubNode("exclude_from_sim")]
      public bool ExcludeFromSim { get; set; }

      [SExprSubNode("pin_numbers")]
      public SymbolVisibility PinVisibility { get; set; }

      [SExprNode("pin_names")]
      public PinNamesModel? PinNames { get; set; }

      [SExprSubNode("in_bom")]
      public bool InBom { get; set; }

      [SExprSubNode("on_board")]
      public bool OnBoard { get; set; }

      public PropertyCollection? Properties { get; set; }

      public SubSymbolCollection? SubSymbols { get; set; }
      #endregion

      #region Constructors
      public Symbol() { }
      #endregion

      #region Methods
      public void ParseNode(Node node)
      {
         if (node.Children != null && node.Properties != null)
         {
            var props = GetType().GetProperties();
            KiCadParseUtils.ParseNodes(props, node, this);
            KiCadParseUtils.ParseSubNodes(props, node, this);
            KiCadParseUtils.ParseProperties(props, node, this);
            KiCadParseUtils.ParseListNodes(props, node, this);
         }
      }
      #endregion

      #region Full Props

      #endregion
   }
}
