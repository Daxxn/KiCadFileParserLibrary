using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

using MVVMLibrary;

namespace KiCadFileParserLibrary.KiCad.Boards.Collections;
[SExprListNode("layer")]
public class StackupLayerCollection : Model, IKiCadReadable, IKiCadWriteableCollection
{
   #region Local Props
   private ObservableCollection<StackupLayer> _layers = [];
   #endregion

   #region Constructors
   public StackupLayerCollection() { }
   #endregion

   #region Methods
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

   public void WriteNode(StringBuilder builder, int indent, string? auxName = null)
   {
      throw new NotImplementedException();
   }

   public void WriteCollection(StringBuilder builder, int indent)
   {
      if (Layers.Count == 0) return;
      foreach (var layer in Layers)
      {
         KiCadWriteUtils2.WriteNode(layer, builder, indent);
      }
   }
   #endregion

   #region Full Props
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
