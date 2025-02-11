using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

using MVVMLibrary;

namespace KiCadFileParserLibrary.KiCad.Symbols.Collections
{
   [SExprListNode("symbol")]
   public class SymbolCollection : Model, IKiCadReadable, IKiCadWriteableCollection
   {
      #region Local Props
      private ObservableCollection<Symbol>? _symbols;
      #endregion

      #region Constructors
      public SymbolCollection() { }
      #endregion

      #region Methods
      public void ParseNode(Node node)
      {
         if (node.Children != null)
         {
            var children = node.GetNodes(GetType().GetCustomAttribute<SExprListNodeAttribute>()!.Name);
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

      public void WriteCollection(StringBuilder builder, int indent)
      {
         foreach (var symbol in Symbols)
         {
            KiCadWriteUtils2.WriteNode(symbol, builder, indent);
         }
      }
      #endregion

      #region Full Props
      public ObservableCollection<Symbol>? Symbols
      {
         get => _symbols;
         set
         {
            _symbols = value;
            OnPropertyChanged();
         }
      }
      #endregion
   }
}
