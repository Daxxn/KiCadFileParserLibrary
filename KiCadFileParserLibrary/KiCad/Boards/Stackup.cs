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

namespace KiCadFileParserLibrary.KiCad.Boards
{
   [SExprNode("stackup")]
   public class Stackup : Model, IKiCadReadable
   {
      #region Local Props
      private ObservableCollection<StackupLayer> _layers = [];
      private string? _copperFinish;
      private bool _impedanceControlled;
      private bool _castellatedPads;
      private bool _edgePlating;
      private EdgeConnectorType _edgeConnector;
      #endregion

      #region Constructors
      public Stackup() { }
      #endregion

      #region Methods
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
         if (CopperFinish != null)
         {
            builder.Append('\t', indent + 1);
            builder.AppendLine($"(copper_finish \"{CopperFinish}\")");
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

      public override string ToString()
      {
         return $"Stackup - Finish: {CopperFinish} - Impedance: {ImpedanceControlled} - Castellated-Pads: {CastellatedPads} - Edge-Pating: {EdgePlating} - Edge-Conn: {EdgeConnector}";
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

      [SExprSubNode("copper_finish")]
      public string? CopperFinish
      {
         get => _copperFinish;
         set
         {
            _copperFinish = value;
            OnPropertyChanged();
         }
      }

      [SExprSubNode("dielectric_constraints")]
      public bool ImpedanceControlled
      {
         get => _impedanceControlled;
         set
         {
            _impedanceControlled = value;
            OnPropertyChanged();
         }
      }

      [SExprSubNode("castellated_pads")]
      public bool CastellatedPads
      {
         get => _castellatedPads;
         set
         {
            _castellatedPads = value;
            OnPropertyChanged();
         }
      }

      [SExprSubNode("edge_plating")]
      public bool EdgePlating
      {
         get => _edgePlating;
         set
         {
            _edgePlating = value;
            OnPropertyChanged();
         }
      }

      [SExprSubNode("edge_connector")]
      public EdgeConnectorType EdgeConnector
      {
         get => _edgeConnector;
         set
         {
            _edgeConnector = value;
            OnPropertyChanged();
         }
      }
      #endregion
   }
}
