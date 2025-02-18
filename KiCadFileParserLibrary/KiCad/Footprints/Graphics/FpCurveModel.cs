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
/// <see cref="Footprint"/> curve graphic.
/// </summary>
[SExprNode("fp_curve")]
public class FpCurveModel : GraphicBase
{
   #region Local Props
   private string? _layer;
   private double? _width;
   private bool? _locked;
   private string? _id;
   private CoordinateModel? _coordinates;
   private StrokeModel? _stroke;
   #endregion

   #region Constructors
   /// <inheritdoc/>
   public FpCurveModel() { }
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
   /// Curve radius
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
   /// Is locked.
   /// </summary>
   [SExprToken("locked")]
   public bool? Locked
   {
      get => _locked;
      set
      {
         _locked = value;
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

   /// <summary>
   /// Location
   /// </summary>
   public CoordinateModel? Coordinates
   {
      get => _coordinates;
      set
      {
         _coordinates = value;
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
   #endregion
}
