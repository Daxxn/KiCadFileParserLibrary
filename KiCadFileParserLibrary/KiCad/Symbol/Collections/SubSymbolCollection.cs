using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.KiCad.Symbol.SubModels;
using KiCadFileParserLibrary.SExprParser;

namespace KiCadFileParserLibrary.KiCad.Symbol.Collections
{
   [SExprListNode("symbol")]
   public class SubSymbolCollection : IKiCadReadable
   {
      #region Local Props
      public List<SubSymbolModel>? SubSymbols { get; set; }
      #endregion

      #region Constructors
      public SubSymbolCollection() { }
      #endregion

      #region Methods
      public void ParseNode(Node node)
      {
         var children = node.GetNodes("symbol");
         if (children is null) return;
         SubSymbols = [];
         foreach (var child in children)
         {
            SubSymbolModel subSym = new();
            subSym.ParseNode(child);
            SubSymbols.Add(subSym);
         }
      }
      #endregion

      #region Full Props

      #endregion
   }
}
