using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.KiCad.Boards.SubModels;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;
using MVVMLibrary;
using System.Collections.ObjectModel;

namespace KiCadFileParserLibrary.KiCad.Boards.Collections
{
   [SExprNode("layers")]
   public class LayerDefCollection : Model, IKiCadReadable
   {
      private ObservableCollection<LayerModel> _layerList { get; set; } = [];

      public void ParseNode(Node node)
      {
         if (node.Children is null) return;
         LayerList = [];
         foreach (var child in node.Children)
         {
            var newLayer = new LayerModel();
            newLayer.ParseNode(child);
            LayerList.Add(newLayer);
         }
      }

      public void WriteNode(StringBuilder builder, int indent, string? auxName = null)
      {
         builder.Append('\t', indent);
         builder.AppendLine("(layers");
         foreach (var layer in LayerList)
         {
            layer.WriteNode(builder, indent + 1);
         }
         builder.Append('\t', indent);
         builder.AppendLine(")");
      }

      public override string ToString()
      {
         return $"Layers: {LayerList.Count}";
      }

      public ObservableCollection<LayerModel> LayerList
      {
         get => _layerList;
         set
         {
            _layerList = value;
            OnPropertyChanged();
         }
      }
   }
}
