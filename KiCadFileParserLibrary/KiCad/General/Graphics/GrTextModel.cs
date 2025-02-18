using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.Footprints.Graphics;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

namespace KiCadFileParserLibrary.KiCad.General.Graphics;

/// <summary>
/// General text graphic.
/// </summary>
[SExprNode("gr_text")]
public class GrTextModel : GraphicBase
{
   #region Local Props
   private bool _locked;
   private string _text = "";
   private FpTextLayerModel _layer = new();
   private bool _knockout;
   private LocationModel? _location;
   private string _id = "";
   private EffectsModel? _effect;
   private RenderCacheModel? _renderCache;
   #endregion

   #region Constructors
   /// <inheritdoc/>
   public GrTextModel() { }
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
         KiCadParseUtils.ParseListNodes(props, node, this);
      }
   }
   #endregion

   #region Full Props
   /// <summary>
   /// Is locked.
   /// </summary>
   [SExprSubNode("locked")]
   public bool Locked
   {
      get => _locked;
      set
      {
         _locked = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Display text.
   /// </summary>
   [SExprProperty(1)]
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
   /// Text layer data.
   /// </summary>
   public FpTextLayerModel Layer
   {
      get => _layer;
      set
      {
         _layer = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Knockout
   /// </summary>
   private bool Knockout
   {
      get => _knockout;
      set
      {
         _knockout = value;
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
      get => _effect;
      set
      {
         _effect = value;
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
