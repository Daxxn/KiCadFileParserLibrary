using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace KiCadFileParserLibrary.KiCad.Project.SubModels
{
   public class RuleSettingsModel
   {
      #region Local Props
      [JsonProperty(PropertyName = "max_error")]
      public double MaxError { get; set; }

      [JsonProperty(PropertyName = "min_clearance")]
      public double MinClearance { get; set; }

      [JsonProperty(PropertyName = "min_connection")]
      public double MinConnection { get; set; }

      [JsonProperty(PropertyName = "min_copper_edge_clearance")]
      public double MinCopperEdgeClearance { get; set; }

      [JsonProperty(PropertyName = "min_hole_clearance")]
      public double MinHoleClearance { get; set; }

      [JsonProperty(PropertyName = "min_hole_to_hole")]
      public double MinHoleToHole { get; set; }

      [JsonProperty(PropertyName = "min_microvia_diameter")]
      public double MinMicroviaDiameter { get; set; }

      [JsonProperty(PropertyName = "min_microvia_drill")]
      public double MinMicroviaDrill { get; set; }

      [JsonProperty(PropertyName = "min_resolved_spokes")]
      public int MinResolvedSpokes { get; set; }

      [JsonProperty(PropertyName = "min_silk_clearance")]
      public double MinSilkClearance { get; set; }

      [JsonProperty(PropertyName = "min_text_height")]
      public double MinTextHeight { get; set; }

      [JsonProperty(PropertyName = "min_text_thickness")]
      public double MinTextThickness { get; set; }

      [JsonProperty(PropertyName = "min_through_hole_diameter")]
      public double MinThroughHoleDiameter { get; set; }

      [JsonProperty(PropertyName = "min_track_width")]
      public double MinTrackWidth { get; set; }

      [JsonProperty(PropertyName = "min_via_annular_width")]
      public double MinViaAnnularWidth { get; set; }

      [JsonProperty(PropertyName = "min_via_diameter")]
      public double MinViaDiameter { get; set; }

      [JsonProperty(PropertyName = "solder_mask_clearance")]
      public double SolderMaskClearance { get; set; }

      [JsonProperty(PropertyName = "solder_mask_min_width")]
      public double SolderMaskMinWidth { get; set; }

      [JsonProperty(PropertyName = "solder_mask_to_copper_clearance")]
      public double SolderMaskToCopperClearance { get; set; }

      [JsonProperty(PropertyName = "use_height_for_length_calcs")]
      public bool UseHeightForLengthCalcs { get; set; }
      #endregion

      #region Constructors
      public RuleSettingsModel() { }
      #endregion

      #region Methods

      #endregion

      #region Full Props

      #endregion
   }
}
