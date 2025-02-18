using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

using MVVMLibrary;

namespace KiCadFileParserLibrary.KiCad.Boards.SubModels;

/// <summary>
/// Model of a layer in the <see cref="Stackup">Stackup.</see>
/// </summary>
[SExprNode("layer")]
public class StackupLayer : Model, IKiCadReadable
{
   #region Local Props
   private string? _name;
   private string? _type;
   private string? _color;
   private string? _material;
   private double? _thickness;
   private double? _epsilon;
   private double? _loss;
   private bool _locked;
   #endregion

   #region Constructors
   /// <inheritdoc/>
   public StackupLayer() { }
   #endregion

   #region Methods
   /// <inheritdoc/>
   public void ParseNode(Node node)
   {
      if (node.Properties != null && node.Children != null)
      {
         var props = GetType().GetProperties();

         KiCadParseUtils.ParseProperties(props, node, this);
         KiCadParseUtils.ParseSubNodes(props, node, this);

         var thickNode = node.GetNode("thickness");
         if (thickNode is null) return;
         if (thickNode.Properties!.Count > 2)
         {
            if (thickNode.Properties[2] == "locked")
               Locked = true;
         }
      }
   }

   /// <inheritdoc/>
   public override string ToString()
   {
      return $"Stackup-Layer - {Name} - Type: {Type} - Color: {Color} - Material: {Material} - Thickness: {Thickness} - eR: {EpsilonR} - Loss-Tan: {LossTangent} - Locked: {Locked}";
   }
   #endregion

   #region Full Props
   /// <summary>
   /// The name of the layer.
   /// </summary>
   [SExprProperty(1)]
   public string? Name
   {
      get => _name;
      set
      {
         _name = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// The type of the layer.
   /// </summary>
   [SExprSubNode("type")]
   public string? Type
   {
      get => _type;
      set
      {
         _type = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// An optional color when displaying a 3D model of the PCB.
   /// </summary>
   [SExprSubNode("color")]
   public string? Color
   {
      get => _color;
      set
      {
         _color = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// The name of the material used for the layer.
   /// </summary>
   [SExprSubNode("material")]
   public string? Material
   {
      get => _material;
      set
      {
         _material = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// The thickness of the layer.
   /// </summary>
   [SExprSubNode("thickness")]
   public double? Thickness
   {
      get => _thickness;
      set
      {
         _thickness = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// The relative permittivity of the layer.
   /// </summary>
   [SExprSubNode("epsilon_r")]
   public double? EpsilonR
   {
      get => _epsilon;
      set
      {
         _epsilon = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// The loss tangent of the layer.
   /// </summary>
   [SExprSubNode("loss_tangent")]
   public double? LossTangent
   {
      get => _loss;
      set
      {
         _loss = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Locks this layer from further edits.
   /// </summary>
   [SExprToken("locked")]
   public bool Locked
   {
      get => _locked;
      set
      {
         _locked = value;
         OnPropertyChanged();
      }
   }
   #endregion
}
