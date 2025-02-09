using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.KiCad.Symbols;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

using MVVMLibrary;

namespace KiCadFileParserLibrary.KiCad.Schematics.Collections;

[SExprListNode("lib_symbols")]
public class SchematicSymbolCollection : Model, IKiCadReadable, IKiCadWriteableCollection
{
   #region Local Props
   private ObservableCollection<Symbol> _symbols = [];
   #endregion

   #region Constructors
   public SchematicSymbolCollection() { }
   #endregion

   #region Methods
   public void ParseNode(Node node)
   {
      if (node.Children is null) return;
      var symbolNodes = node.GetNodes("symbol");
      if (symbolNodes is null) return;
      foreach ( var symbolNode in symbolNodes )
      {
         var symbol = new Symbol();
         symbol.ParseNode(symbolNode);
         Symbols.Add(symbol);
      }
   }

   public void WriteCollection(StringBuilder builder, int indent)
   {
      builder.Append('\t', indent);
      builder.AppendLine("(lib_symbols");

      foreach (var symbol in Symbols)
      {
         KiCadWriteUtils2.WriteNode(symbol, builder, indent + 1);
      }

      builder.Append('\t', indent);
      builder.AppendLine(")");
   }
   #endregion

   #region Full Props
   public ObservableCollection<Symbol> Symbols
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
