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
   [SExprListNode("property")]
   public class PropertyCollection : Model, IKiCadReadable
   {
      #region Local Props
      private ObservableCollection<SymbolProperty>? _props;
      #endregion

      #region Constructors
      public PropertyCollection() { }
      #endregion

      #region Methods
      public void ParseNode(Node node)
      {
         var children = node.GetNodes("property");
         if (children is null) return;
         Properties = [];
         foreach (var child in children)
         {
            SymbolProperty prop = new();
            prop.ParseNode(child);
            Properties.Add(prop);
         }
      }

      public void WriteNode(StringBuilder builder, int indent, string? auxName = null)
      {
         throw new NotImplementedException();
      }
      #endregion

      #region Full Props
      public ObservableCollection<SymbolProperty>? Properties
      {
         get => _props;
         set
         {
            _props = value;
            OnPropertyChanged();
         }
      }
      #endregion
   }
}
