using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.General;
using KiCadFileParserLibrary.KiCad.General.Graphics;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

namespace KiCadFileParserLibrary.KiCad.Footprints.Graphics;

/// <summary>
/// <see cref="Footprint"/> text box graphic.
/// </summary>
[SExprNode("fp_text_box")]
public class FpTextBoxModel : GraphicBase
{
   #region Local Props
   private bool _locked;
   private string _text = "";
   private XyModel _start = new();
   private XyModel _end = new();
   private CoordinateModel? _point;
   private double? _angle;
   private bool _hasBorder = false;
   private string _layer = "";
   private string _id = "";
   private EffectsModel _effect = new();
   private StrokeModel? _stroke;
   private RenderCacheModel? _renderCache;
   #endregion

   #region Constructors
   /// <inheritdoc/>
   public FpTextBoxModel() { }
   #endregion

   #region Methods
   /// <inheritdoc/>
   public override void ParseNode(Node node)
   {
      if (node.Properties != null && node.Children != null)
      {
         var props = GetType().GetProperties();

         KiCadParseUtils.ParseProperties(props, node, this);
         KiCadParseUtils.ParseSubNodes(props, node, this);
         KiCadParseUtils.ParseNodes(props, node, this);
         KiCadParseUtils.ParseTokens(props, node, this);
      }
   }
   #endregion

   #region Full Props
   /// <summary>
   /// Is locked.
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

   /// <summary>
   /// Display text.
   /// </summary>
   [SExprProperty(1, true)]
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
   /// Start coordinates.
   /// </summary>
   [SExprNode("start", 0)]
   public XyModel Start
   {
      get => _start;
      set
      {
         _start = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// End coordinates.
   /// </summary>
   [SExprNode("end", 1)]
   public XyModel End
   {
      get => _end;
      set
      {
         _end = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Box coordinates
   /// </summary>
   public CoordinateModel? Points
   {
      get => _point;
      set
      {
         _point = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Text angle.
   /// </summary>
   [SExprSubNode("angle")]
   public double? Angle
   {
      get => _angle;
      set
      {
         _angle = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Has a border.
   /// </summary>
   [SExprSubNode("border")]
   public bool HasBorder
   {
      get => _hasBorder;
      set
      {
         _hasBorder = value;
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
   /// Text effects
   /// </summary>
   public EffectsModel Effects
   {
      get => _effect;
      set
      {
         _effect = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Stroke model.
   /// </summary>
   public StrokeModel? Stroke
   {
      get => _stroke;
      set
      {
         _stroke = value;
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
