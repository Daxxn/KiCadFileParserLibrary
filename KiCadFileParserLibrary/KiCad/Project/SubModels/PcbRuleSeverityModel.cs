using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace KiCadFileParserLibrary.KiCad.Project.SubModels
{
   public class PcbRuleSeverityModel
   {
      #region Local Props
      [JsonProperty(PropertyName = "annular_width")]
      public string? AnnularWidth { get; set; }

      [JsonProperty(PropertyName = "clearance")]
      public string? Clearance { get; set; }

      [JsonProperty(PropertyName = "connection_width")]
      public string? ConnectionWidth { get; set; }

      [JsonProperty(PropertyName = "copper_edge_clearance")]
      public string? CopperEdgeClearance { get; set; }

      [JsonProperty(PropertyName = "copper_sliver")]
      public string? CopperSliver { get; set; }

      [JsonProperty(PropertyName = "courtyards_overlap")]
      public string? CourtyardOverlap { get; set; }

      [JsonProperty(PropertyName = "diff_pair_gap_out_of_range")]
      public string? DiffPairGapOutOfRange { get; set; }

      [JsonProperty(PropertyName = "diff_pair_uncoupled_length_too_long")]
      public string? DiffPairUncoupledLength { get; set; }

      [JsonProperty(PropertyName = "drill_out_of_range")]
      public string? DrillOutOfRange { get; set; }

      [JsonProperty(PropertyName = "duplicate_footprints")]
      public string? DuplicateFootprints { get; set; }

      [JsonProperty(PropertyName = "extra_footprint")]
      public string? ExtraFootprint { get; set; }

      [JsonProperty(PropertyName = "footprint")]
      public string? Footprint { get; set; }

      [JsonProperty(PropertyName = "footprint_symbol_mismatch")]
      public string? FootprintSymbolMismatch { get; set; }

      [JsonProperty(PropertyName = "footprint_type_mismatch")]
      public string? FootprintTypeMismatch { get; set; }

      [JsonProperty(PropertyName = "hole_clearance")]
      public string? HoleClearance { get; set; }

      [JsonProperty(PropertyName = "hole_near_hole")]
      public string? HoleNearHole { get; set; }

      [JsonProperty(PropertyName = "holes_co_located")]
      public string? HolesCoLocated { get; set; }

      [JsonProperty(PropertyName = "invalid_outline")]
      public string? InvalidOutline { get; set; }

      [JsonProperty(PropertyName = "isolated_copper")]
      public string? IsloatedCopper { get; set; }

      [JsonProperty(PropertyName = "item_on_disabled_layer")]
      public string? ItemOnDisabledLayer { get; set; }

      [JsonProperty(PropertyName = "items_not_allowed")]
      public string? ItemsNotAllowed { get; set; }

      [JsonProperty(PropertyName = "length_out_of_range")]
      public string? LengthOutOfRange { get; set; }

      [JsonProperty(PropertyName = "lib_footprint_issues")]
      public string? LibFootprintIssues { get; set; }

      [JsonProperty(PropertyName = "lib_footprint_mismatch")]
      public string? LibFootprintMismatch { get; set; }

      [JsonProperty(PropertyName = "malformed_courtyard")]
      public string? MalformedCourtyard { get; set; }

      [JsonProperty(PropertyName = "microvia_drill_out_of_range")]
      public string? MicroviaDrillOutOfRange { get; set; }

      [JsonProperty(PropertyName = "missing_courtyard")]
      public string? MissingCourtyard { get; set; }

      [JsonProperty(PropertyName = "missing_footprint")]
      public string? MissingFootprint { get; set; }

      [JsonProperty(PropertyName = "net_conflict")]
      public string? NetConflict { get; set; }

      [JsonProperty(PropertyName = "npth_inside_courtyard")]
      public string? NPTHInsideCourtyard { get; set; }

      [JsonProperty(PropertyName = "padstack")]
      public string? PadStack { get; set; }

      [JsonProperty(PropertyName = "pth_inside_courtyard")]
      public string? PTHInsideCourtyard { get; set; }

      [JsonProperty(PropertyName = "shorting_items")]
      public string? ShortingItems { get; set; }

      [JsonProperty(PropertyName = "silk_edge_clearance")]
      public string? SilkEdgeClearance { get; set; }

      [JsonProperty(PropertyName = "silk_over_copper")]
      public string? SilkOverCopper { get; set; }

      [JsonProperty(PropertyName = "silk_overlap")]
      public string? SilkOverlap { get; set; }

      [JsonProperty(PropertyName = "skew_out_of_range")]
      public string? SkewOutOfRange { get; set; }

      [JsonProperty(PropertyName = "solder_mask_bridge")]
      public string? SolderMaskBridge { get; set; }

      [JsonProperty(PropertyName = "starved_thermal")]
      public string? StarvedThermal { get; set; }

      [JsonProperty(PropertyName = "text_height")]
      public string? TextHeight { get; set; }

      [JsonProperty(PropertyName = "text_thickness")]
      public string? TextThickness { get; set; }

      [JsonProperty(PropertyName = "through_hole_pad_without_hole")]
      public string? ThroughHolePadWithoutHole { get; set; }

      [JsonProperty(PropertyName = "too_many_vias")]
      public string? TooManyVias { get; set; }

      [JsonProperty(PropertyName = "track_dangling")]
      public string? TrackDangling { get; set; }

      [JsonProperty(PropertyName = "track_width")]
      public string? TrackWidth { get; set; }

      [JsonProperty(PropertyName = "tracks_crossing")]
      public string? TracksCrossing { get; set; }

      [JsonProperty(PropertyName = "unconnected_items")]
      public string? UnconnectedItems { get; set; }

      [JsonProperty(PropertyName = "unresolved_variable")]
      public string? UnresolvedVariable { get; set; }

      [JsonProperty(PropertyName = "via_dangling")]
      public string? ViaDangling { get; set; }

      [JsonProperty(PropertyName = "zones_intersect")]
      public string? ZonesIntersect { get; set; }
      #endregion

      #region Constructors
      public PcbRuleSeverityModel() { }
      #endregion

      #region Methods

      #endregion

      #region Full Props

      #endregion
   }
}
