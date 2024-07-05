using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace KiCadFileParserLibrary.KiCad.Project.SubModels
{
   public class DefaultDesignSettingsModel
   {
      #region Local Props
      [JsonProperty(PropertyName = "apply_defaults_to_fp_fields")]
      public bool ApplyDefaultsToFpFields { get; set; }

      [JsonProperty(PropertyName = "apply_defaults_to_fp_shapes")]
      public bool ApplyDefaultsToFpShapes { get; set; }

      [JsonProperty(PropertyName = "apply_defaults_to_fp_text")]
      public bool ApplyDefaultsToFpText { get; set; }

      [JsonProperty(PropertyName = "board_outline_line_width")]
      public double BoardOutlineLineWidth { get; set; }

      [JsonProperty(PropertyName = "copper_line_width")]
      public double CopperLineWidth { get; set; }

      [JsonProperty(PropertyName = "copper_text_italic")]
      public bool CopperTextItalic { get; set; }

      [JsonProperty(PropertyName = "copper_text_size_h")]
      public double CopperTextWidth { get; set; }

      [JsonProperty(PropertyName = "copper_text_size_v")]
      public double CopperTextHeight { get; set; }

      [JsonProperty(PropertyName = "copper_text_thickness")]
      public double CopperTextThickness { get; set; }

      [JsonProperty(PropertyName = "copper_text_upright")]
      public bool CopperTextUpright { get; set; }

      [JsonProperty(PropertyName = "courtyard_line_width")]
      public double CourtyardLineWidth { get; set; }

      [JsonProperty(PropertyName = "dimension_precision")]
      public int DimensionPrecision { get; set; }

      [JsonProperty(PropertyName = "dimension_units")]
      public UnitsType DimensionUnits { get; set; }

      [JsonProperty(PropertyName = "dimensions")]
      public DimensionSettingsModel? DimensionSettings { get; set; }

      [JsonProperty(PropertyName = "fab_line_width")]
      public double FabLineWidth { get; set; }

      [JsonProperty(PropertyName = "fab_text_italic")]
      public bool FabTextItalic { get; set; }

      [JsonProperty(PropertyName = "fab_text_size_h")]
      public double FabTextWidth { get; set; }

      [JsonProperty(PropertyName = "fab_text_size_v")]
      public double FabTextHeight { get; set; }

      [JsonProperty(PropertyName = "fab_text_thickness")]
      public double FabTextThickness { get; set; }

      [JsonProperty(PropertyName = "fab_text_upright")]
      public bool FabTextUpright { get; set; }

      [JsonProperty(PropertyName = "other_line_width")]
      public double OtherLineWidth { get; set; }

      [JsonProperty(PropertyName = "other_text_italic")]
      public bool OtherTextItalic { get; set; }

      [JsonProperty(PropertyName = "other_text_size_h")]
      public double OtherTextWidth { get; set; }

      [JsonProperty(PropertyName = "other_text_size_v")]
      public double OtherTextHeight { get; set; }

      [JsonProperty(PropertyName = "other_text_thickness")]
      public double OtherTextThickness { get; set; }

      [JsonProperty(PropertyName = "other_text_upright")]
      public bool OtherTextUpright { get; set; }

      [JsonProperty(PropertyName = "pads")]
      public PadSettingsModel? Pads { get; set; }

      [JsonProperty(PropertyName = "silk_line_width")]
      public double SilkLineWidth { get; set; }

      [JsonProperty(PropertyName = "silk_text_italic")]
      public bool SilkTextItalic { get; set; }

      [JsonProperty(PropertyName = "silk_text_size_h")]
      public double SilkTextWidth { get; set; }

      [JsonProperty(PropertyName = "silk_text_size_v")]
      public double SilkTextHeight { get; set; }

      [JsonProperty(PropertyName = "silk_text_thickness")]
      public double SilkTextThickness { get; set; }

      [JsonProperty(PropertyName = "silk_text_upright")]
      public bool SilkTextUpright { get; set; }

      [JsonProperty(PropertyName = "zones")]
      public ZoneSettingsModel? ZoneSettings { get; set; }
      #endregion

      #region Constructors
      public DefaultDesignSettingsModel() { }
      #endregion

      #region Methods

      #endregion

      #region Full Props

      #endregion
   }
}
