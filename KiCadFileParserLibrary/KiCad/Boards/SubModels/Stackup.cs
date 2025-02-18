using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.Boards.Collections;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

using MVVMLibrary;

namespace KiCadFileParserLibrary.KiCad.Boards.SubModels;

/// <summary>
/// Stackup settings model.
/// </summary>
[SExprNode("stackup")]
public class Stackup : Model, IKiCadReadable
{
   #region Local Props
   private StackupLayerCollection _layers = new();
   private string? _copperFinish;
   private bool _impedanceControlled;
   private bool _castellatedPads;
   private bool _edgePlating;
   private EdgeConnectorType _edgeConnector;
   #endregion

   #region Constructors
   /// <inheritdoc/>
   public Stackup() { }
   #endregion

   #region Methods
   /// <inheritdoc/>
   public void ParseNode(Node node)
   {
      if (node.Children is null) return;
      var props = GetType().GetProperties();

      KiCadParseUtils.ParseSubNodes(props, node, this);

      Layers.ParseNode(node);
   }

   /// <inheritdoc/>
   public override string ToString()
   {
      return $"Stackup - Finish: {CopperFinish} - Impedance: {ImpedanceControlled} - Castellated-Pads: {CastellatedPads} - Edge-Pating: {EdgePlating} - Edge-Conn: {EdgeConnector}";
   }
   #endregion

   #region Full Props
   /// <summary>
   /// List of stackup layer definitions.
   /// </summary>
   public StackupLayerCollection Layers
   {
      get => _layers;
      set
      {
         _layers = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Type of copper finish. Used when calculating trace impedances.
   /// </summary>
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

   /// <summary>
   /// The PCB contains high-speed, impedance constrained traces.
   /// </summary>
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

   /// <summary>
   /// The PCB has castellated pads along the edges.
   /// </summary>
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

   /// <summary>
   /// The PCB has plated edges.
   /// </summary>
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

   /// <summary>
   /// The PCB has an edge connector.
   /// </summary>
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
