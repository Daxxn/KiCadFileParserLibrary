using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MVVMLibrary;

using Newtonsoft.Json;

namespace KiCadFileParserLibrary.KiCad.Project.SubModels
{
   public class PcbRuleSeverityModel : Model
   {
      #region Local Props
      private string? _annularWidth;
      private string? _clearance;
      private string? _connectionWidth;
      private string? _copperEdgeClearance;
      private string? _copperSliver;
      private string? _courtyardOverlap;
      private string? _diffPairGapOutOfRange;
      private string? _diffPairUncoupledLength;
      private string? _drillOutOfRange;
      private string? _duplicateFootprints;
      private string? _extraFootprint;
      private string? _footprint;
      private string? _footprintSymbolMismatch;
      private string? _footprintTypeMismatch;
      private string? _holeClearance;
      private string? _holeNearHole;
      private string? _holesCoLocated;
      private string? _invalidOutline;
      private string? _isolatedCopper;
      private string? _itemOnDisabledLayer;
      private string? _itemNotAllowed;
      private string? _lengthOutOfRange;
      private string? _libFootprintIssues;
      private string? _libFootprintMismatch;
      private string? _malformedCourtyard;
      private string? _microviaDrillOutOfRange;
      private string? _missingCourtyard;
      private string? _missingFootprint;
      private string? _netConflict;
      private string? _npthInsideCourtyard;
      private string? _padStack;
      private string? _pthInsideCourtyard;
      private string? _shortingItems;
      private string? _silkEdgeClearance;
      private string? _silkOverCopper;
      private string? _silkOverlap;
      private string? _skewOutOfRange;
      private string? _solderMaskBridge;
      private string? _starvedThermal;
      private string? _textHeight;
      private string? _textThickness;
      private string? _throughHolePadWithoutHole;
      private string? _tooManyVias;
      private string? _trackDangling;
      private string? _trackWidth;
      private string? _tracksCrossing;
      private string? _unconnectedItems;
      private string? _unresolvedVariable;
      private string? _vaiaDangling;
      private string? _zonesIntersect;
      #endregion

      #region Constructors
      public PcbRuleSeverityModel() { }
      #endregion

      #region Methods

      #endregion

      #region Full Props
      [JsonProperty(PropertyName = "annular_width")]
      public string? AnnularWidth
      {
         get => _annularWidth;
         set
         {
            _annularWidth = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "clearance")]
      public string? Clearance
      {
         get => _clearance;
         set
         {
            _clearance = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "connection_width")]
      public string? ConnectionWidth
      {
         get => _connectionWidth;
         set
         {
            _connectionWidth = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "copper_edge_clearance")]
      public string? CopperEdgeClearance
      {
         get => _copperEdgeClearance;
         set
         {
            _copperEdgeClearance = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "copper_sliver")]
      public string? CopperSliver
      {
         get => _copperSliver;
         set
         {
            _copperSliver = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "courtyards_overlap")]
      public string? CourtyardOverlap
      {
         get => _courtyardOverlap;
         set
         {
            _courtyardOverlap = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "diff_pair_gap_out_of_range")]
      public string? DiffPairGapOutOfRange
      {
         get => _diffPairGapOutOfRange;
         set
         {
            _diffPairGapOutOfRange = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "diff_pair_uncoupled_length_too_long")]
      public string? DiffPairUncoupledLength
      {
         get => _diffPairUncoupledLength;
         set
         {
            _diffPairUncoupledLength = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "drill_out_of_range")]
      public string? DrillOutOfRange
      {
         get => _drillOutOfRange;
         set
         {
            _drillOutOfRange = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "duplicate_footprints")]
      public string? DuplicateFootprints
      {
         get => _duplicateFootprints;
         set
         {
            _duplicateFootprints = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "extra_footprint")]
      public string? ExtraFootprint
      {
         get => _extraFootprint;
         set
         {
            _extraFootprint = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "footprint")]
      public string? Footprint
      {
         get => _footprint;
         set
         {
            _footprint = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "footprint_symbol_mismatch")]
      public string? FootprintSymbolMismatch
      {
         get => _footprintSymbolMismatch;
         set
         {
            _footprintSymbolMismatch = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "footprint_type_mismatch")]
      public string? FootprintTypeMismatch
      {
         get => _footprintTypeMismatch;
         set
         {
            _footprintTypeMismatch = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "hole_clearance")]
      public string? HoleClearance
      {
         get => _holeClearance;
         set
         {
            _holeClearance = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "hole_near_hole")]
      public string? HoleNearHole
      {
         get => _holeNearHole;
         set
         {
            _holeNearHole = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "holes_co_located")]
      public string? HolesCoLocated
      {
         get => _holesCoLocated;
         set
         {
            _holesCoLocated = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "invalid_outline")]
      public string? InvalidOutline
      {
         get => _invalidOutline;
         set
         {
            _invalidOutline = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "isolated_copper")]
      public string? IsloatedCopper
      {
         get => _isolatedCopper;
         set
         {
            _isolatedCopper = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "item_on_disabled_layer")]
      public string? ItemOnDisabledLayer
      {
         get => _itemOnDisabledLayer;
         set
         {
            _itemOnDisabledLayer = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "items_not_allowed")]
      public string? ItemsNotAllowed
      {
         get => _itemNotAllowed;
         set
         {
            _itemNotAllowed = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "length_out_of_range")]
      public string? LengthOutOfRange
      {
         get => _lengthOutOfRange;
         set
         {
            _lengthOutOfRange = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "lib_footprint_issues")]
      public string? LibFootprintIssues
      {
         get => _libFootprintIssues;
         set
         {
            _libFootprintIssues = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "lib_footprint_mismatch")]
      public string? LibFootprintMismatch
      {
         get => _libFootprintMismatch;
         set
         {
            _libFootprintMismatch = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "malformed_courtyard")]
      public string? MalformedCourtyard
      {
         get => _malformedCourtyard;
         set
         {
            _malformedCourtyard = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "microvia_drill_out_of_range")]
      public string? MicroviaDrillOutOfRange
      {
         get => _microviaDrillOutOfRange;
         set
         {
            _microviaDrillOutOfRange = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "missing_courtyard")]
      public string? MissingCourtyard
      {
         get => _missingCourtyard;
         set
         {
            _missingCourtyard = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "missing_footprint")]
      public string? MissingFootprint
      {
         get => _missingFootprint;
         set
         {
            _missingFootprint = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "net_conflict")]
      public string? NetConflict
      {
         get => _netConflict;
         set
         {
            _netConflict = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "npth_inside_courtyard")]
      public string? NPTHInsideCourtyard
      {
         get => _npthInsideCourtyard;
         set
         {
            _npthInsideCourtyard = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "padstack")]
      public string? PadStack
      {
         get => _padStack;
         set
         {
            _padStack = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "pth_inside_courtyard")]
      public string? PTHInsideCourtyard
      {
         get => _pthInsideCourtyard;
         set
         {
            _pthInsideCourtyard = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "shorting_items")]
      public string? ShortingItems
      {
         get => _shortingItems;
         set
         {
            _shortingItems = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "silk_edge_clearance")]
      public string? SilkEdgeClearance
      {
         get => _silkEdgeClearance;
         set
         {
            _silkEdgeClearance = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "silk_over_copper")]
      public string? SilkOverCopper
      {
         get => _silkOverCopper;
         set
         {
            _silkOverCopper = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "silk_overlap")]
      public string? SilkOverlap
      {
         get => _silkOverlap;
         set
         {
            _silkOverlap = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "skew_out_of_range")]
      public string? SkewOutOfRange
      {
         get => _skewOutOfRange;
         set
         {
            _skewOutOfRange = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "solder_mask_bridge")]
      public string? SolderMaskBridge
      {
         get => _solderMaskBridge;
         set
         {
            _solderMaskBridge = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "starved_thermal")]
      public string? StarvedThermal
      {
         get => _starvedThermal;
         set
         {
            _starvedThermal = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "text_height")]
      public string? TextHeight
      {
         get => _textHeight;
         set
         {
            _textHeight = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "text_thickness")]
      public string? TextThickness
      {
         get => _textThickness;
         set
         {
            _textThickness = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "through_hole_pad_without_hole")]
      public string? ThroughHolePadWithoutHole
      {
         get => _throughHolePadWithoutHole;
         set
         {
            _throughHolePadWithoutHole = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "too_many_vias")]
      public string? TooManyVias
      {
         get => _tooManyVias;
         set
         {
            _tooManyVias = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "track_dangling")]
      public string? TrackDangling
      {
         get => _trackDangling;
         set
         {
            _trackDangling = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "track_width")]
      public string? TrackWidth
      {
         get => _trackWidth;
         set
         {
            _trackWidth = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "tracks_crossing")]
      public string? TracksCrossing
      {
         get => _tracksCrossing;
         set
         {
            _tracksCrossing = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "unconnected_items")]
      public string? UnconnectedItems
      {
         get => _unconnectedItems;
         set
         {
            _unconnectedItems = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "unresolved_variable")]
      public string? UnresolvedVariable
      {
         get => _unresolvedVariable;
         set
         {
            _unresolvedVariable = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "via_dangling")]
      public string? ViaDangling
      {
         get => _vaiaDangling;
         set
         {
            _vaiaDangling = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "zones_intersect")]
      public string? ZonesIntersect
      {
         get => _zonesIntersect;
         set
         {
            _zonesIntersect = value;
            OnPropertyChanged();
         }
      }
      #endregion
   }
}
