using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

namespace KiCadFileParserLibrary.KiCad.General
{
    [SExprNode("fill")]
   public class ZoneFillSettingsModel : IKiCadReadable
   {
      #region Local Props
      [SExprToken("yes")]
      public bool IsFilled { get; set; }

      [SExprSubNode("mode")]
      public bool FillMode { get; set; }

      [SExprSubNode("thermal_gap")]
      public double? ThermalGap { get; set; }

      [SExprSubNode("thermal_bridge_width")]
      public double? ThermalBridge { get; set; }

      public ZoneFillSmoothingModel? Smoothing { get; set; }

      [SExprSubNode("island_removal_mode")]
      public IslandRemovalMode IslandRemovalMode { get; set; }

      [SExprSubNode("island_area_min")]
      public double? IslandAreaMin { get; set; }

      [SExprSubNode("hatch_thickness")]
      public double? HatchThickness { get; set; }

      [SExprSubNode("hatch_gap")]
      public double? HatchGap { get; set; }

      [SExprSubNode("hatch_orientation")]
      public double? HatchOrientation { get; set; }

      [SExprSubNode("hatch_smoothing_level")]
      public HatchSmoothingLevel HatchSmoothingLevel { get; set; }

      [SExprSubNode("hatch_smoothing_value")]
      public double? HatchSmoothingValue { get; set; }

      [SExprSubNode("hatch_border_algorithm")]
      public HatchBorderAlgorythmType HatchBorderAlgorythm { get; set; }

      [SExprSubNode("hatch_min_hole_area")]
      public double? HatchMinHoleArea { get; set; }
      #endregion

      #region Constructors
      public ZoneFillSettingsModel() { }
      #endregion

      #region Methods
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

      #endregion
   }
}
