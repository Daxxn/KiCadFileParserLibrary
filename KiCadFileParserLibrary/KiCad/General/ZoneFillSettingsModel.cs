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

namespace KiCadFileParserLibrary.KiCad.General;

/// <summary>
/// <see cref="ZoneModel">Zone</see> fill settings model.
/// </summary>
[SExprNode("fill")]
public class ZoneFillSettingsModel : Model, IKiCadReadable
{
   #region Local Props
   private bool _isFilled;
   private ZoneFillMode? _fillMode;
   private double _thermalGap;
   private double _thermalBridge;
   private SmoothingStyleType? _smoothing;
   private double? _smoothingRadius;
   private IslandRemovalMode? _islandRemovalMode;
   private double? _islandAreaMin;
   private double? _hatchThickness;
   private double? _hatchGap;
   private double? _hatchOrient;
   private HatchSmoothingLevel? _hatchSmoothingLevel;
   private double? _hatchSmoothingValue;
   private HatchBorderAlgorythmType? _hatchBorderAl;
   private double? _hatchMinHoleArea;
   #endregion

   #region Constructors
   /// <inheritdoc/>
   public ZoneFillSettingsModel() { }
   #endregion

   #region Methods
   /// <inheritdoc/>
   public void ParseNode(Node node)
   {
      if (node.Properties != null && node.Children != null)
      {
         var props = GetType().GetProperties();

         KiCadParseUtils.ParseNodes(props, node, this);
         KiCadParseUtils.ParseSubNodes(props, node, this);
         KiCadParseUtils.ParseTokens(props, node, this);
      }
   }
   #endregion

   #region Full Props
   /// <summary>
   /// Is filled.
   /// </summary>
   [SExprToken("yes")]
   public bool IsFilled
   {
      get => _isFilled;
      set
      {
         _isFilled = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Zone fill mode.
   /// </summary>
   [SExprSubNode("mode")]
   [SExprFormatting(false, true)]
   public ZoneFillMode? FillMode
   {
      get => _fillMode;
      set
      {
         _fillMode = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Thermal releif gap.
   /// </summary>
   [SExprSubNode("thermal_gap")]
   public double ThermalGap
   {
      get => _thermalGap;
      set
      {
         _thermalGap = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Thermal bridge width.
   /// </summary>
   [SExprSubNode("thermal_bridge_width")]
   public double ThermalBridge
   {
      get => _thermalBridge;
      set
      {
         _thermalBridge = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Zone smoothing style.
   /// </summary>
   [SExprSubNode("smoothing")]
   public SmoothingStyleType? Smoothing
   {
      get => _smoothing;
      set
      {
         _smoothing = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Smoothing radius.
   /// </summary>
   [SExprSubNode("radius")]
   public double? SmoothingRadius
   {
      get => _smoothingRadius;
      set
      {
         _smoothingRadius = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Island removal mode.
   /// </summary>
   [SExprSubNode("island_removal_mode")]
   [SExprFormatting(true, true)]
   public IslandRemovalMode? IslandRemovalMode
   {
      get => _islandRemovalMode;
      set
      {
         _islandRemovalMode = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Minimum island area.
   /// </summary>
   [SExprSubNode("island_area_min")]
   public double? IslandAreaMin
   {
      get => _islandAreaMin;
      set
      {
         _islandAreaMin = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Hatch thickness.
   /// </summary>
   [SExprSubNode("hatch_thickness")]
   public double? HatchThickness
   {
      get => _hatchThickness;
      set
      {
         _hatchThickness = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Hatch gap.
   /// </summary>
   [SExprSubNode("hatch_gap")]
   public double? HatchGap
   {
      get => _hatchGap;
      set
      {
         _hatchGap = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Hatch orientation.
   /// </summary>
   [SExprSubNode("hatch_orientation")]
   public double? HatchOrientation
   {
      get => _hatchOrient;
      set
      {
         _hatchOrient = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Hatch smoothing level.
   /// </summary>
   [SExprSubNode("hatch_smoothing_level")]
   [SExprFormatting(true, true)]
   public HatchSmoothingLevel? HatchSmoothingLevel
   {
      get => _hatchSmoothingLevel;
      set
      {
         _hatchSmoothingLevel = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Hatch smoothing value.
   /// </summary>
   [SExprSubNode("hatch_smoothing_value")]
   public double? HatchSmoothingValue
   {
      get => _hatchSmoothingValue;
      set
      {
         _hatchSmoothingValue = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Hatch border algorithm type.
   /// </summary>
   [SExprSubNode("hatch_border_algorithm")]
   [SExprFormatting(false, true)]
   public HatchBorderAlgorythmType? HatchBorderAlgorythm
   {
      get => _hatchBorderAl;
      set
      {
         _hatchBorderAl = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Hatch minimum hole area.
   /// </summary>
   [SExprSubNode("hatch_min_hole_area")]
   public double? HatchMinHoleArea
   {
      get => _hatchMinHoleArea;
      set
      {
         _hatchMinHoleArea = value;
         OnPropertyChanged();
      }
   }
   #endregion
}
