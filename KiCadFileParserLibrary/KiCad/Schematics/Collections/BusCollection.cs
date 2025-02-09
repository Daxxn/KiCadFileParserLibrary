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

[SExprListNode("bus")]
public class BusCollection : Model, IKiCadReadable, IKiCadWriteableCollection
{
   #region Local Props
   private ObservableCollection<BusModel> _busses = [];
   #endregion

   #region Constructors
   public BusCollection() { }
   #endregion

   #region Methods
   public void ParseNode(Node node)
   {
      if (node.Children is null) return;
      var busNodes = node.GetNodes(GetType().GetCustomAttribute<SExprListNodeAttribute>()!.Name);
      if (busNodes is null) return;
      Busses = [];
      foreach (var busNode in busNodes)
      {
         var busModel = new BusModel();
         busModel.ParseNode(busNode);
         Busses.Add(busModel);
      }
   }

   public void WriteCollection(StringBuilder builder, int indent)
   {
      foreach (var bus in Busses)
      {
         KiCadWriteUtils2.WriteNode(bus, builder, indent);
      }
   }
   #endregion

   #region Full Props
   public ObservableCollection<BusModel> Busses
   {
      get => _busses;
      set
      {
         _busses = value;
         OnPropertyChanged();
      }
   }
   #endregion
}
