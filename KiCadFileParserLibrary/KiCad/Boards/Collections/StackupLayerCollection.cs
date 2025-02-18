using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.Boards.SubModels;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

using MVVMLibrary;

namespace KiCadFileParserLibrary.KiCad.Boards.Collections;

/// <summary>
/// List of <see cref="StackupLayer">Stackups</see> for a <see cref="PcbModel">PCB.</see>
/// </summary>
[SExprListNode("layer")]
public class StackupLayerCollection : Model, IKiCadReadable, IKiCadWriteableCollection
{
   #region Local Props
   private ObservableCollection<StackupLayer> _layers = [];
   #endregion

   #region Constructors
   /// <inheritdoc/>
   public StackupLayerCollection() { }
   #endregion

   #region Methods
   /// <inheritdoc/>
   public void ParseNode(Node node)
   {
      if (node.Children is null) return;
      var layerNodes = node.GetNodes("layer")!;
      foreach (var layerNode in layerNodes)
      {
         var layer = new StackupLayer();
         layer.ParseNode(layerNode);
         Layers.Add(layer);
      }
   }

   /// <inheritdoc/>
   public void WriteCollection(StringBuilder builder, int indent)
   {
      if (Layers.Count == 0) return;
      foreach (var layer in Layers)
      {
         KiCadWriteUtils.WriteNode(layer, builder, indent);
      }
   }

   /// <inheritdoc/>
   public override string ToString() => $"Stackup Coll - {Layers.Count}";
   #endregion

   #region Full Props
   /// <summary>
   /// List of stackup layers.
   /// </summary>
   public ObservableCollection<StackupLayer> Layers
   {
      get => _layers;
      set
      {
         _layers = value;
         OnPropertyChanged();
      }
   }

   #endregion
}
