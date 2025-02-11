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
using System.Xml.Linq;

namespace KiCadFileParserLibrary.KiCad.Boards.Collections
{
   /// <summary>
   /// List of all the PCB <see cref="LayerModel">Layers.</see>
   /// </summary>
   [SExprListNode("layers")]
   public class LayerDefCollection : Model, IKiCadReadable, IKiCadWriteableCollection
   {
      private ObservableCollection<LayerModel> _layerList { get; set; } = [];

      /// <inheritdoc/>
      public void ParseNode(Node node)
      {
         if (node.Children is null) return;
         var layersNode = node.GetNode("layers");
         if (layersNode is null) return;
         if (layersNode.Children is null) return;
         LayerList = [];
         foreach (var child in layersNode.Children)
         {
            var newLayer = new LayerModel();
            newLayer.ParseNode(child);
            LayerList.Add(newLayer);
         }
      }

      //public void WriteNode(StringBuilder builder, int indent, string? auxName = null)
      //{
      //   builder.Append('\t', indent);
      //   builder.AppendLine("(layers");
      //   foreach (var layer in LayerList)
      //   {
      //      layer.WriteNode(builder, indent + 1);
      //   }
      //   builder.Append('\t', indent);
      //   builder.AppendLine(")");
      //}

      /// <inheritdoc/>
      public override string ToString()
      {
         return $"Layer Coll - {LayerList.Count}";
      }

      /// <inheritdoc/>
      public void WriteCollection(StringBuilder builder, int indent)
      {
         builder.Append('\t', indent);
         builder.AppendLine("(layers");

         foreach (var layer in LayerList)
         {
            builder.Append('\t', indent + 1);
            builder.Append('(');
            builder.Append(layer.Index);
            builder.Append(" \"");
            builder.Append(layer.Name);
            builder.Append("\" ");
            builder.Append(layer.Type);
            if (layer.UserName != null)
            {
               builder.Append(" \"");
               builder.Append(layer.UserName);
               builder.AppendLine("\")");
            }
            else
            {
               builder.AppendLine(")");
            }
         }

         builder.Append('\t', indent);
         builder.AppendLine(")");
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
