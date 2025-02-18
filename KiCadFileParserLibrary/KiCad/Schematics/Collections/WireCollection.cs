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
/// List of <see cref="WireModel">Wires</see>
/// </summary>
[SExprListNode("wire")]
public class WireCollection : Model, IKiCadReadable, IKiCadWriteableCollection
{
   #region Local Props
   private ObservableCollection<WireModel>? _wires;
   #endregion

   #region Constructors
   /// <inheritdoc/>
   public WireCollection() { }
   #endregion

   #region Methods
   /// <inheritdoc/>
   public void ParseNode(Node node)
   {
      if (node is null) return;
      var wireNodes = node.GetNodes(GetType().GetCustomAttribute<SExprListNodeAttribute>()!.Name);
      if (wireNodes == null) return;
      Wires = [];
      foreach (var wireNode in wireNodes)
      {
         var wire = new WireModel();
         wire.ParseNode(wireNode);
         Wires.Add(wire);
      }
   }

   /// <inheritdoc/>
   public void WriteCollection(StringBuilder builder, int indent)
   {
      if (Wires is null) return;
      foreach (var wire in Wires)
      {
         KiCadWriteUtils2.WriteNode(wire, builder, indent);
      }
   }
   #endregion

   #region Full Props
   /// <summary>
   /// List of <see cref="WireModel">Wires</see>
   /// </summary>
   public ObservableCollection<WireModel>? Wires
   {
      get => _wires;
      set
      {
         _wires = value;
         OnPropertyChanged();
      }
   }
   #endregion
}
