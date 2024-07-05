using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace KiCadFileParserLibrary.KiCad.Project.SubModels
{
   public class DrawingSettingsModel
   {
      #region Local Props
      [JsonProperty(PropertyName = "dashed_lines_dash_length_ratio")]
      public double DashedLinesDashLenRatio { get; set; }

      [JsonProperty(PropertyName = "dashed_lines_gap_length_ratio")]
      public double DashedLinesGapLenRatio { get; set; }

      [JsonProperty(PropertyName = "default_line_thickness")]
      public double DefaultLineThickness { get; set; }

      [JsonProperty(PropertyName = "default_text_size")]
      public double DefaultTextSize { get; set; }

      [JsonProperty(PropertyName = "field_names")]
      public List<string>? FieldNames { get; set; }

      [JsonProperty(PropertyName = "intersheets_ref_own_page")]
      public bool IntersheetsRefOwnPage { get; set; }

      [JsonProperty(PropertyName = "intersheets_ref_prefix")]
      public string? IntersheetsRefPrefix { get; set; }

      [JsonProperty(PropertyName = "intersheets_ref_short")]
      public bool IntersheetsRefShort { get; set; }

      [JsonProperty(PropertyName = "intersheets_ref_show")]
      public bool IntersheetsRefShow { get; set; }

      [JsonProperty(PropertyName = "intersheets_ref_suffix")]
      public string? IntersheetsRefSuffix { get; set; }

      [JsonProperty(PropertyName = "junction_size_choice")]
      public int JunctionSizeChoice { get; set; } // Also probably an enum...

      [JsonProperty(PropertyName = "label_size_ratio")]
      public double LabelSizeRatio { get; set; }

      [JsonProperty(PropertyName = "operating_point_overlay_i_precision")]
      public int OeratingPointOverlayIPrecision { get; set; }

      [JsonProperty(PropertyName = "operating_point_overlay_i_range")]
      public string? OeratingPointOverlayIRange { get; set; }

      [JsonProperty(PropertyName = "operating_point_overlay_v_precision")]
      public int OeratingPointOverlayVPrecision { get; set; }

      [JsonProperty(PropertyName = "operating_point_overlay_v_range")]
      public string? OeratingPointOverlayVRange { get; set; }

      [JsonProperty(PropertyName = "overbar_offset_ratio")]
      public double OverbarOffsetRatio { get; set; }

      [JsonProperty(PropertyName = "pin_symbol_size")]
      public double PinSymbolSize { get; set; }

      [JsonProperty(PropertyName = "text_offset_ratio")]
      public double TextOffsetRatio { get; set; }
      #endregion

      #region Constructors
      public DrawingSettingsModel() { }
      #endregion

      #region Methods

      #endregion

      #region Full Props

      #endregion
   }
}
