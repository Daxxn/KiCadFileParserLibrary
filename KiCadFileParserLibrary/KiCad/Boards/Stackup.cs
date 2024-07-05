using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

namespace KiCadFileParserLibrary.KiCad.Boards
{
   [SExprNode("stackup")]
   public class Stackup : IKiCadReadable
   {
      public List<StackupLayer> Layers { get; set; } = [];

      [SExprSubNode("copper_finish")]
      public string? Copperfinish { get; set; }

      [SExprSubNode("dielectric_constraints")]
      public bool ImpedanceControlled { get; set; }

      [SExprSubNode("castellated_pads")]
      public bool CastellatedPads { get; set; }

      [SExprSubNode("edge_plating")]
      public bool EdgePlating { get; set; }

      [SExprSubNode("edge_connector")]
      public EdgeConnectorType EdgeConnector { get; set; }

      public void ParseNode(Node node)
      {
         if (node.Children is null) return;
         var props = GetType().GetProperties();

         KiCadParseUtils.ParseSubNodes(props, node, this);

         var layerNodes = node.GetNodes("layer")!;
         Layers = [];
         foreach (var layerNode in layerNodes)
         {
            var layer = new StackupLayer();
            layer.ParseNode(layerNode);
            Layers.Add(layer);
         }
      }

      public void WriteNode(StringBuilder builder, int indent, string? auxName = null)
      {
         builder.Append('\t', indent);
         builder.AppendLine("(stackup");
         foreach (var layer in Layers)
         {
            layer.WriteNode(builder, indent + 1);
         }
         if (Copperfinish != null)
         {
            builder.Append('\t', indent + 1);
            builder.AppendLine($"(copper_finish \"{Copperfinish}\")");
         }
         if (ImpedanceControlled)
         {
            builder.Append('\t', indent + 1);
            builder.AppendLine($"(dielectric_constraints yes)");
         }
         if (EdgeConnector != EdgeConnectorType.No)
         {
            builder.Append('\t', indent + 1);
            builder.AppendLine($"(edge_connector {EdgeConnector.ToString()!.ToLower()})");
         }
         if (CastellatedPads)
         {
            builder.Append('\t', indent + 1);
            builder.AppendLine($"(castellated_pads yes)");
         }
         if (EdgePlating)
         {
            builder.Append('\t', indent + 1);
            builder.AppendLine($"(edge_plating yes)");
         }
         builder.Append('\t', indent);
         builder.AppendLine(")");
      }
   }
}
