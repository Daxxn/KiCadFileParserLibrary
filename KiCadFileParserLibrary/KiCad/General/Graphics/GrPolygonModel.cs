using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

namespace KiCadFileParserLibrary.KiCad.General.Graphics;

/// <summary>
/// General polygon graphic.
/// </summary>
[SExprNode("gr_poly")]
public class GrPolygonModel : GraphicBase
{
   #region Local Props
   private CoordinateModel _points = new();
   private bool _locked;
   private StrokeModel? _stroke;
   private double? _width;
   private FillType? _fill;
   private string? _layer;
   private string? _id;
   #endregion

   #region Constructors
   /// <inheritdoc/>
   public GrPolygonModel() { }
   #endregion

   #region Methods
   /// <inheritdoc/>
   public override void ParseNode(Node node)
   {
      if (node.Children != null)
      {
         var props = GetType().GetProperties();

         KiCadParseUtils.ParseNodes(props, node, this);
         KiCadParseUtils.ParseSubNodes(props, node, this);
      }
   }
   #endregion

   #region Full Props
   /// <summary>
   /// List of polygon points.
   /// </summary>
   [SExprNode("pts", 0)]
   public CoordinateModel Points
   {
      get => _points;
      set
      {
         _points = value;
         OnPropertyChanged();
      }
   }

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
   /// Line width.
   /// </summary>
   [SExprSubNode("width")]
   public double? Width
   {
      get => _width;
      set
      {
         _width = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Fill type.
   /// </summary>
   [SExprSubNode("fill")]
   public FillType? Fill
   {
      get => _fill;
      set
      {
         _fill = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Layer name.
   /// </summary>
   [SExprSubNode("layer")]
   public string? Layer
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
   public string? ID
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
