using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

namespace KiCadFileParserLibrary.KiCad.Pcb
{
    [SExprNode("stackup")]
   public class Stackup : IKiCadReadable
   {
      public List<Layer>? Layers { get; set; }

      [SExprSubNode("copper_finish")]
      public string? Copperfinish { get; set; }

      [SExprSubNode("dielectric_constraints")]
      public bool ImpedanceControlled { get; set; }

      public void ParseNode(Node node)
      {
         if (node.Children is null) return;
         var props = GetType().GetProperties();

         KiCadParseUtils.ParseSubNodes(props, node, this);

         var layerNodes = node.GetNodes("layer")!;
         Layers = [];
         foreach (var layerNode in layerNodes)
         {
            var layer = new Layer();
            layer.ParseNode(layerNode);
            Layers.Add(layer);
         }
      }
   }
}
