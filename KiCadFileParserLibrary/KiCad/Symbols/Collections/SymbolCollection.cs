using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.SExprParser;

namespace KiCadFileParserLibrary.KiCad.Symbols.Collections
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

      public void WriteNode(StringBuilder builder, int indent, string? auxName = null)
      {
         throw new NotImplementedException();
      }
      #endregion

      #region Full Props

      #endregion
   }
}
