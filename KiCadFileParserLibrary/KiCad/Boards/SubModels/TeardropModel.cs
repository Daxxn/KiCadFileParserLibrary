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
/// Teardrop definition options.
/// </summary>
[SExprNode("teardrops")]
public class TeardropModel : Model, IKiCadReadable
{
   #region Local Props
   private double _bestLengthRatio;
   private double _maxLength;
   private double _bestWidthRatio;
   private double _maxWidth;
   private int _curvePoints;
   private double _filterRatio;
   private bool _enable;
   private bool _allowTwoSeg;
   private bool _preferZoneConn;
   #endregion

   #region Constructors
   /// <inheritdoc/>
   public TeardropModel() { }
   #endregion

   #region Methods
   /// <inheritdoc/>
   public void ParseNode(Node node)
   {
      if (node.Children != null)
      {
         var props = GetType().GetProperties();
         KiCadParseUtils.ParseSubNodes(props, node, this);
      }
   }
   #endregion

   #region Full Props
   /// <summary>
   /// The best length ratio of the teardrop.
   /// </summary>
   [SExprSubNode("best_length_ratio")]
   public double BestLengthRatio
   {
      get => _bestLengthRatio;
      set
      {
         _bestLengthRatio = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Max teardrop length.
   /// </summary>
   [SExprSubNode("max_length")]
   public double MaxLength
   {
      get => _maxLength;
      set
      {
         _maxLength = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Max teardrop width.
   /// </summary>
   [SExprSubNode("max_width")]
   public double MaxWidth
   {
      get => _maxWidth;
      set
      {
         _maxWidth = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Best teardrop width ratio.
   /// </summary>
   [SExprSubNode("best_width_ratio")]
   public double BestWidthRatio
   {
      get => _bestWidthRatio;
      set
      {
         _bestWidthRatio = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Number of curve points.
   /// <para/>
   /// More points gives more definition to the teardrop while taking longer to calculate.
   /// </summary>
   [SExprSubNode("curve_points")]
   public int CurvePoints
   {
      get => _curvePoints;
      set
      {
         _curvePoints = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Filter ratio.
   /// </summary>
   [SExprSubNode("filter_ratio")]
   public double FilterRatio
   {
      get => _filterRatio;
      set
      {
         _filterRatio = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Enable teardrop rendering.
   /// </summary>
   [SExprSubNode("enabled")]
   public bool Enable
   {
      get => _enable;
      set
      {
         _enable = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// ???
   /// </summary>
   [SExprSubNode("allow_two_segments")]
   public bool AllowTwoSegments
   {
      get => _allowTwoSeg;
      set
      {
         _allowTwoSeg = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Prefer zone connections.
   /// </summary>
   [SExprSubNode("prefer_zone_connections")]
   public bool PreferZoneConn
   {
      get => _preferZoneConn;
      set
      {
         _preferZoneConn = value;
         OnPropertyChanged();
      }
   }
   #endregion
}
