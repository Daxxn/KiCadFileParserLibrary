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

/// <summary>
/// List of <see cref="HierarchicalPinModel">Hierarchical Pins</see>
/// </summary>
[SExprListNode("pin")]
public class HierarchicalPinCollection : Model, IKiCadReadable, IKiCadWriteableCollection
{
   #region Local Props
   private ObservableCollection<HierarchicalPinModel> _pins = [];
   #endregion

   #region Constructors
   /// <inheritdoc/>
   public HierarchicalPinCollection() { }
   #endregion

   #region Methods
   /// <inheritdoc/>
   public void ParseNode(Node node)
   {
      if (node.Children is null) return;
      var pinNodes = node.GetNodes(GetType().GetCustomAttribute<SExprListNodeAttribute>()!.Name);
      if (pinNodes is null) return;
      Pins = [];
      foreach (var pinNode in pinNodes)
      {
         var pin = new HierarchicalPinModel();
         pin.ParseNode(pinNode);
         Pins.Add(pin);
      }
   }

   /// <inheritdoc/>
   public void WriteCollection(StringBuilder builder, int indent)
   {
      if (Pins is null) return;
      foreach (var pin in Pins)
      {
         KiCadWriteUtils2.WriteNode(pin, builder, indent);
      }
   }
   #endregion

   #region Full Props
   /// <summary>
   /// List of <see cref="HierarchicalPinModel">Hierarchical Pins</see>
   /// </summary>
   public ObservableCollection<HierarchicalPinModel> Pins
   {
      get => _pins;
      set
      {
         _pins = value;
         OnPropertyChanged();
      }
   }
   #endregion
}
