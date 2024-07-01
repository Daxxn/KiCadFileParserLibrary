using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.Pcb.SubModels;
using KiCadFileParserLibrary.SExprParser;

namespace KiCadFileParserLibrary.KiCad.Pcb
{
   [SExprNode("layers")]
   public class Layers : IKiCadReadable
   {
      public List<LayerModel>? LayerList { get; set; }

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
   }
}
