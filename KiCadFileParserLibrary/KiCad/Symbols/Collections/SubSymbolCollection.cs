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
using KiCadFileParserLibrary.Utils;

using MVVMLibrary;

namespace KiCadFileParserLibrary.KiCad.Symbols.Collections;

/// <summary>
/// List of <see cref="SubSymbolModel">Sub-Symbols</see>
/// </summary>
[SExprListNode("symbol")]
public class SubSymbolCollection : Model, IKiCadReadable, IKiCadWriteableCollection
{
   #region Local Props
   private ObservableCollection<SubSymbolModel> _subSymbols = [];
   #endregion

   #region Constructors
   /// <inheritdoc/>
   public SubSymbolCollection() { }
   #endregion

   #region Methods
   /// <inheritdoc/>
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

   /// <inheritdoc/>
   public void WriteCollection(StringBuilder builder, int indent)
   {
      if (SubSymbols is null) return;

      foreach (var sub in SubSymbols)
      {
         KiCadWriteUtils.WriteNode(sub, builder, indent);
      }
   }
   #endregion

   #region Full Props
   /// <summary>
   /// List of <see cref="SubSymbolModel">Sub-Symbols</see>
   /// </summary>
   public ObservableCollection<SubSymbolModel> SubSymbols
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
