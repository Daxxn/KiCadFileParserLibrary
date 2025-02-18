using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

namespace KiCadFileParserLibrary.KiCad.General.Graphics;

/// <summary>
/// General text box graphic.
/// </summary>
[SExprNode("gr_text_box")]
public class GrTextBoxModel : GraphicBase
{
   #region Local Props
   private bool _locked;
   private string _text = "";
   private XyModel? _start;
   private XyModel? _end;
   private CoordinateModel? _points;
   private double? _angle;
   private bool _hasBorder;
   private string _layer = "";
   private string _id = "";
   private EffectsModel _effect = new();
   private StrokeModel? _stroke;
   private RenderCacheModel? _renderCache;
   #endregion

   #region Constructors
   /// <inheritdoc/>
   public GrTextBoxModel() { }
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
   [SExprNode("start")]
   public XyModel? Start
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
   [SExprNode("end")]
   public XyModel? End
   {
      get => _end;
      set
      {
         _end = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// List of border points.
   /// </summary>
   public CoordinateModel? Points
   {
      get => _points;
      set
      {
         _points = value;
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
   /// Stroke data.
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
   /// Font render cache
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
