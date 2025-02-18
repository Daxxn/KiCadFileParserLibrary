using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.General;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

using MVVMLibrary;

namespace KiCadFileParserLibrary.KiCad.Footprints.SubModels;

/// <summary>
/// <see cref="Footprint"/> property.
/// </summary>
[SExprNode("property")]
public class PropertyModel : Model, IKiCadReadable
{
   #region Local Props
   private string _key = "";
   private string _value = "";
   private LocationModel _location = new();
   private bool _unlocked;
   private bool _hide;
   private string _layer = "";
   private string _id = "";
   private EffectsModel _effects = new();
   #endregion

   #region Constructors
   /// <inheritdoc/>
   public PropertyModel() { }
   #endregion

   #region Methods
   /// <inheritdoc/>
   public void ParseNode(Node node)
   {
      if (node.Properties != null && node.Children != null)
      {
         var props = GetType().GetProperties();
         KiCadParseUtils.ParseProperties(props, node, this);
         KiCadParseUtils.ParseNodes(props, node, this);
         KiCadParseUtils.ParseSubNodes(props, node, this);
      }
   }
   #endregion

   #region Full Props
   /// <summary>
   /// The property key.
   /// </summary>
   [SExprProperty(1)]
   public string Key
   {
      get => _key;
      set
      {
         _key = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// The property value.
   /// </summary>
   [SExprProperty(2)]
   public string Value
   {
      get => _value;
      set
      {
         _value = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Location of the property relative to the <see cref="Footprint">Footprint.</see>
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
   /// Is movable in the PCB.
   /// </summary>
   [SExprSubNode("unlocked")]
   public bool Unlocked
   {
      get => _unlocked;
      set
      {
         _unlocked = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Is hidden on the PCB.
   /// </summary>
   [SExprSubNode("hide")]
   public bool Hide
   {
      get => _hide;
      set
      {
         _hide = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Layer name.
   /// </summary>
   [SExprSubNode("layer")]
   public string Layer
   {
      get => _layer;
      set
      {
         _layer = value;
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

   /// <summary>
   /// Text effects.
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
   #endregion
}
