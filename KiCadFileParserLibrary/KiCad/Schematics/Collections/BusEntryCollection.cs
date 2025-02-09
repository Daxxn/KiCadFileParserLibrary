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

using static System.Runtime.InteropServices.JavaScript.JSType;

namespace KiCadFileParserLibrary.KiCad.Schematics.Collections;

[SExprListNode("bus_entry")]
public class BusEntryCollection : Model, IKiCadReadable, IKiCadWriteableCollection
{
   #region Local Props
   private ObservableCollection<BusEntryModel> _busEntries = [];
   #endregion

   #region Constructors
   public BusEntryCollection() { }
   #endregion

   #region Methods
   public void ParseNode(Node node)
   {
      if (node.Children is null) return;
      var beNodes = node.GetNodes(GetType().GetCustomAttribute<SExprListNodeAttribute>()!.Name);
      if (beNodes is null) return;
      BusEntries = [];
      foreach (var child in beNodes)
      {
         var busEntry = new BusEntryModel();
         busEntry.ParseNode(child);
         BusEntries.Add(busEntry);
      }
   }

   public void WriteCollection(StringBuilder builder, int indent)
   {
      foreach (var be in BusEntries)
      {
         KiCadWriteUtils2.WriteNode(be, builder, indent);
      }
   }
   #endregion

   #region Full Props
   public ObservableCollection<BusEntryModel> BusEntries
   {
      get => _busEntries;
      set
      {
         _busEntries = value;
         OnPropertyChanged();
      }
   }
   #endregion
}
