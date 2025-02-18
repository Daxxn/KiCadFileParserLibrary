using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.General;
using KiCadFileParserLibrary.KiCad.General.Graphics;
using KiCadFileParserLibrary.KiCad.Boards;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

namespace KiCadFileParserLibrary.KiCad.Footprints.Graphics;

/// <summary>
/// <see cref="Footprint"/> text graphic.
/// </summary>
[SExprNode("fp_text")]
public class FpTextModel : GraphicBase
{
   #region Local Props
   private FootprintTextType? _type;
   private string _text = "";
   private LocationModel? _location;
   private bool _isUnlocked;
   private bool _knockout;
   private string _layer = "";
   private string _id = "";
   private EffectsModel? _effects;
   private RenderCacheModel? _renderCache;
   #endregion

   #region Constructors
   /// <inheritdoc/>
   public FpTextModel() { }
   #endregion

   #region Methods
   /// <inheritdoc/>
   public override void ParseNode(Node node)
   {
      if (node.Children != null && node.Properties != null)
      {
         var props = GetType().GetProperties();

         KiCadParseUtils.ParseNodes(props, node, this);
         KiCadParseUtils.ParseSubNodes(props, node, this);
         KiCadParseUtils.ParseProperties(props, node, this);

         // Added check for knockout param.
         // For some stupid reason, its in the "layer" node...
         var layerNode = node.GetNode("layer");
         if (layerNode?.Properties is null) return;
         if (layerNode?.Properties.Contains("knockout") == true)
         {
            var knockoutProp = props.FirstOrDefault(p => p.Name == "Knockout");
            knockoutProp?.SetValue(this, true);
         }
      }
   }
   #endregion

   #region Full Props
   /// <summary>
   /// Footprint text type.
   /// <para/>
   /// Used to filter text when plotting the PCB.
   /// </summary>
   [SExprProperty(1)]
   public FootprintTextType? Type
   {
      get => _type;
      set
      {
         _type = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Display text.
   /// </summary>
   [SExprProperty(2)]
   public string Text
   {
      get => _text;
      set
      {
         _text = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Location coordinates.
   /// </summary>
   public LocationModel? Location
   {
      get => _location;
      set
      {
         _location = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Is unlocked.
   /// </summary>
   [SExprSubNode("unlocked")]
   public bool IsUnlocked
   {
      get => _isUnlocked;
      set
      {
         _isUnlocked = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Inverted text render mode.
   /// </summary>
   public bool Knockout
   {
      get => _knockout;
      set
      {
         _knockout = value;
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
   public EffectsModel? Effects
   {
      get => _effects;
      set
      {
         _effects = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Font render cache.
   /// </summary>
   public RenderCacheModel? RenderCache
   {
      get => _renderCache;
      set
      {
         _renderCache = value;
         OnPropertyChanged();
      }
   }
   #endregion
}
