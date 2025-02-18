using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.General;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

using MVVMLibrary;

namespace KiCadFileParserLibrary.KiCad.Schematics.SubModels;

/// <summary>
/// Hierarchical pin model
/// </summary>
[SExprNode("pin")]
public class HierarchicalPinModel : Model, IKiCadReadable
{
   #region Local Props
   private string _name = "";
   private LabelShape _shape = LabelShape.Input;
   private LocationModel _location = new();
   private EffectsModel _effects = new();
   private string _id = "";
   #endregion

   #region Constructors
   /// <inheritdoc/>
   public HierarchicalPinModel() { }
   #endregion

   #region Methods
   /// <inheritdoc/>
   public void ParseNode(Node node)
   {
      if (node.Properties is null && node.Children is null) return;

      var props = GetType().GetProperties();
      KiCadParseUtils.ParseNodes(props, node, this);
      KiCadParseUtils.ParseSubNodes(props, node, this);
      KiCadParseUtils.ParseProperties(props, node, this);
   }
   #endregion

   #region Full Props
   /// <summary>
   /// Pin name
   /// </summary>
   [SExprProperty(1)]
   public string Name
   {
      get => _name;
      set
      {
         _name = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Pin shape
   /// </summary>
   [SExprProperty(2)]
   public LabelShape Shape
   {
      get => _shape;
      set
      {
         _shape = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Location coordinates
   /// </summary>
   public LocationModel Location
   {
      get => _location;
      set
      {
         _location = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Font effects
   /// </summary>
   public EffectsModel Effects
   {
      get => _effects;
      set
      {
         _effects = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Unique ID.
   /// </summary>
   [SExprSubNode("uuid")]
   public string ID
   {
      get => _id;
      set
      {
         _id = value;
         OnPropertyChanged();
      }
   }
   #endregion
}
