using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.KiCad.Symbols.SubModels;
using KiCadFileParserLibrary.SExprParser;

using MVVMLibrary;

namespace KiCadFileParserLibrary.KiCad.Symbols.Collections
{
   [SExprListNode("symbol")]
   public class SubSymbolCollection : Model, IKiCadReadable
   {
      #region Local Props
      private ObservableCollection<SubSymbolModel>? _subSymbols;
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

      public void WriteNode(StringBuilder builder, int indent, string? auxName = null)
      {
         throw new NotImplementedException();
      }
      #endregion

      #region Full Props
      public ObservableCollection<SubSymbolModel>? SubSymbols
      {
         get => _subSymbols;
         set
         {
            _subSymbols = value;
            OnPropertyChanged();
         }
      }
      #endregion
   }
}
