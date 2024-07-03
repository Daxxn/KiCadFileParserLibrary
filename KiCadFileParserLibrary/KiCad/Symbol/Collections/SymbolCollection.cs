using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.SExprParser;

namespace KiCadFileParserLibrary.KiCad.Symbol.Collections
{
   [SExprListNode("symbol")]
   public class SymbolCollection : IKiCadReadable
   {
      #region Local Props
      public List<Symbol>? Symbols { get; set; }
      #endregion

      #region Constructors
      public SymbolCollection() { }
      #endregion

      #region Methods
      public void ParseNode(Node node)
      {
         if (node.Children != null)
         {
            var children = node.GetNodes("symbol");
            if (children is null) return;
            Symbols = [];
            foreach (var child in children)
            {
               var sym = new Symbol();
               sym.ParseNode(child);
               Symbols.Add(sym);
            }
         }
      }
      #endregion

      #region Full Props

      #endregion
   }
}
