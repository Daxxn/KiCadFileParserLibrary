using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.KiCad.Schematics.SubModels;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

using MVVMLibrary;

namespace KiCadFileParserLibrary.KiCad.Schematics.Collections;

[SExprListNode("symbol")]
public class SymbolReferenceCollection : Model, IKiCadReadable, IKiCadWriteableCollection
{
   #region Local Props
   private ObservableCollection<SchematicSymbolModel> _symbols = new();
   #endregion

   #region Constructors
   public SymbolReferenceCollection() { }
   #endregion

   #region Methods
   public void ParseNode(Node node)
   {
      if (node.Children is null) return;
      var symbolNodes = node.GetNodes(GetType().GetCustomAttribute<SExprListNodeAttribute>()!.Name);
      if (symbolNodes is null) return;
      Symbols = [];
      foreach (var symNode in symbolNodes)
      {
         var symbol = new SchematicSymbolModel();
         symbol.ParseNode(symNode);
         Symbols.Add(symbol);
      }
   }

   public void WriteCollection(StringBuilder builder, int indent)
   {
      if (Symbols is null) return;
      foreach (var symbol in Symbols)
      {
         KiCadWriteUtils2.WriteNode(symbol, builder, indent);
      }
   }
   #endregion

   #region Full Props
   public ObservableCollection<SchematicSymbolModel> Symbols
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
