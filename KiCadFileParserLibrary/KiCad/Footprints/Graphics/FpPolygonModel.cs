using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.General;
using KiCadFileParserLibrary.KiCad.General.Graphics;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

namespace KiCadFileParserLibrary.KiCad.Footprints.Graphics;

/// <summary>
/// <see cref="Footprint"/> polygon graphic.
/// </summary>
[SExprNode("fp_poly")]
public class FpPolygonModel : GraphicBase
{
   #region Local Props
   private CoordinateModel _points = new();
   private StrokeModel _stroke = new();
   private FillType? _fill;
   private string _layer = "";
   private string _id = "";
   #endregion

   #region Constructors
   /// <inheritdoc/>
   public FpPolygonModel() { }
   #endregion

   #region Methods
   /// <inheritdoc/>
   public override void ParseNode(Node node)
   {
      if (node.Properties != null && node.Children != null)
      {
         var props = GetType().GetProperties();
         KiCadParseUtils.ParseNodes(props, node, this);
         KiCadParseUtils.ParseSubNodes(props, node, this);
      }
   }
   #endregion

   #region Full Props
   /// <summary>
   /// Collection of polygon points.
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
   /// Stroke model
   /// </summary>
   public StrokeModel Stroke
   {
      get => _stroke;
      set
      {
         _stroke = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Fill type
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
   #endregion
}
