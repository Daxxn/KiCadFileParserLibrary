using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MVVMLibrary;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace KiCadFileParserLibrary.KiCad.Project.SubModels;

/// <summary>
/// PCB rule severity model.
/// </summary>
public class PcbRuleSeverityModel : Model
{
   #region Local Props
   private RuleSeverity? _annularWidth;
   private RuleSeverity? _clearance;
   private RuleSeverity? _connectionWidth;
   private RuleSeverity? _copperEdgeClearance;
   private RuleSeverity? _copperSliver;
   private RuleSeverity? _courtyardOverlap;
   private RuleSeverity? _diffPairGapOutOfRange;
   private RuleSeverity? _diffPairUncoupledLength;
   private RuleSeverity? _drillOutOfRange;
   private RuleSeverity? _duplicateFootprints;
   private RuleSeverity? _extraFootprint;
   private RuleSeverity? _footprint;
   private RuleSeverity? _footprintSymbolMismatch;
   private RuleSeverity? _footprintTypeMismatch;
   private RuleSeverity? _holeClearance;
   private RuleSeverity? _holeNearHole;
   private RuleSeverity? _holesCoLocated;
   private RuleSeverity? _invalidOutline;
   private RuleSeverity? _isolatedCopper;
   private RuleSeverity? _itemOnDisabledLayer;
   private RuleSeverity? _itemNotAllowed;
   private RuleSeverity? _lengthOutOfRange;
   private RuleSeverity? _libFootprintIssues;
   private RuleSeverity? _libFootprintMismatch;
   private RuleSeverity? _malformedCourtyard;
   private RuleSeverity? _microviaDrillOutOfRange;
   private RuleSeverity? _missingCourtyard;
   private RuleSeverity? _missingFootprint;
   private RuleSeverity? _netConflict;
   private RuleSeverity? _npthInsideCourtyard;
   private RuleSeverity? _padStack;
   private RuleSeverity? _pthInsideCourtyard;
   private RuleSeverity? _shortingItems;
   private RuleSeverity? _silkEdgeClearance;
   private RuleSeverity? _silkOverCopper;
   private RuleSeverity? _silkOverlap;
   private RuleSeverity? _skewOutOfRange;
   private RuleSeverity? _solderMaskBridge;
   private RuleSeverity? _starvedThermal;
   private RuleSeverity? _textHeight;
   private RuleSeverity? _textThickness;
   private RuleSeverity? _throughHolePadWithoutHole;
   private RuleSeverity? _tooManyVias;
   private RuleSeverity? _trackDangling;
   private RuleSeverity? _trackWidth;
   private RuleSeverity? _tracksCrossing;
   private RuleSeverity? _unconnectedItems;
   private RuleSeverity? _unresolvedVariable;
   private RuleSeverity? _vaiaDangling;
   private RuleSeverity? _zonesIntersect;
   #endregion

   #region Constructors
   /// <inheritdoc/>
   public PcbRuleSeverityModel() { }
   #endregion

   #region Methods

   #endregion

   #region Full Props
   /// <summary>
   /// Rule severity.
   /// </summary>
   [JsonProperty(PropertyName = "annular_width")]
   [JsonConverter(typeof(StringEnumConverter))]
   public RuleSeverity? RuleSeverity
   {
      get => _annularWidth;
      set
      {
         _annularWidth = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Clearance
   /// </summary>
   [JsonProperty(PropertyName = "clearance")]
   [JsonConverter(typeof(StringEnumConverter))]
   public RuleSeverity? Clearance
   {
      get => _clearance;
      set
      {
         _clearance = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Connection width
   /// </summary>
   [JsonProperty(PropertyName = "connection_width")]
   [JsonConverter(typeof(StringEnumConverter))]
   public RuleSeverity? ConnectionWidth
   {
      get => _connectionWidth;
      set
      {
         _connectionWidth = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Copper edge clearance
   /// </summary>
   [JsonProperty(PropertyName = "copper_edge_clearance")]
   [JsonConverter(typeof(StringEnumConverter))]
   public RuleSeverity? CopperEdgeClearance
   {
      get => _copperEdgeClearance;
      set
      {
         _copperEdgeClearance = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Copper sliver
   /// </summary>
   [JsonProperty(PropertyName = "copper_sliver")]
   [JsonConverter(typeof(StringEnumConverter))]
   public RuleSeverity? CopperSliver
   {
      get => _copperSliver;
      set
      {
         _copperSliver = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Courtyard overlap
   /// </summary>
   [JsonProperty(PropertyName = "courtyards_overlap")]
   [JsonConverter(typeof(StringEnumConverter))]
   public RuleSeverity? CourtyardOverlap
   {
      get => _courtyardOverlap;
      set
      {
         _courtyardOverlap = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Differential pair gap out of range
   /// </summary>
   [JsonProperty(PropertyName = "diff_pair_gap_out_of_range")]
   [JsonConverter(typeof(StringEnumConverter))]
   public RuleSeverity? DiffPairGapOutOfRange
   {
      get => _diffPairGapOutOfRange;
      set
      {
         _diffPairGapOutOfRange = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Differential pair uncoupled length
   /// </summary>
   [JsonProperty(PropertyName = "diff_pair_uncoupled_length_too_long")]
   [JsonConverter(typeof(StringEnumConverter))]
   public RuleSeverity? DiffPairUncoupledLength
   {
      get => _diffPairUncoupledLength;
      set
      {
         _diffPairUncoupledLength = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Drill out of range
   /// </summary>
   [JsonProperty(PropertyName = "drill_out_of_range")]
   [JsonConverter(typeof(StringEnumConverter))]
   public RuleSeverity? DrillOutOfRange
   {
      get => _drillOutOfRange;
      set
      {
         _drillOutOfRange = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Duplicate footprints
   /// </summary>
   [JsonProperty(PropertyName = "duplicate_footprints")]
   [JsonConverter(typeof(StringEnumConverter))]
   public RuleSeverity? DuplicateFootprints
   {
      get => _duplicateFootprints;
      set
      {
         _duplicateFootprints = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Extra footprint
   /// </summary>
   [JsonProperty(PropertyName = "extra_footprint")]
   [JsonConverter(typeof(StringEnumConverter))]
   public RuleSeverity? ExtraFootprint
   {
      get => _extraFootprint;
      set
      {
         _extraFootprint = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Footprint
   /// </summary>
   [JsonProperty(PropertyName = "footprint")]
   [JsonConverter(typeof(StringEnumConverter))]
   public RuleSeverity? Footprint
   {
      get => _footprint;
      set
      {
         _footprint = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Footprint symbol mismatch
   /// </summary>
   [JsonProperty(PropertyName = "footprint_symbol_mismatch")]
   [JsonConverter(typeof(StringEnumConverter))]
   public RuleSeverity? FootprintSymbolMismatch
   {
      get => _footprintSymbolMismatch;
      set
      {
         _footprintSymbolMismatch = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Footprint type mismatch
   /// </summary>
   [JsonProperty(PropertyName = "footprint_type_mismatch")]
   [JsonConverter(typeof(StringEnumConverter))]
   public RuleSeverity? FootprintTypeMismatch
   {
      get => _footprintTypeMismatch;
      set
      {
         _footprintTypeMismatch = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Hole clearance
   /// </summary>
   [JsonProperty(PropertyName = "hole_clearance")]
   [JsonConverter(typeof(StringEnumConverter))]
   public RuleSeverity? HoleClearance
   {
      get => _holeClearance;
      set
      {
         _holeClearance = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Hole near hole
   /// </summary>
   [JsonProperty(PropertyName = "hole_near_hole")]
   [JsonConverter(typeof(StringEnumConverter))]
   public RuleSeverity? HoleNearHole
   {
      get => _holeNearHole;
      set
      {
         _holeNearHole = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Holes coLocated
   /// </summary>
   [JsonProperty(PropertyName = "holes_co_located")]
   [JsonConverter(typeof(StringEnumConverter))]
   public RuleSeverity? HolesCoLocated
   {
      get => _holesCoLocated;
      set
      {
         _holesCoLocated = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Invalid outline
   /// </summary>
   [JsonProperty(PropertyName = "invalid_outline")]
   [JsonConverter(typeof(StringEnumConverter))]
   public RuleSeverity? InvalidOutline
   {
      get => _invalidOutline;
      set
      {
         _invalidOutline = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Isloated copper
   /// </summary>
   [JsonProperty(PropertyName = "isolated_copper")]
   [JsonConverter(typeof(StringEnumConverter))]
   public RuleSeverity? IsloatedCopper
   {
      get => _isolatedCopper;
      set
      {
         _isolatedCopper = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Item on disabled layer
   /// </summary>
   [JsonProperty(PropertyName = "item_on_disabled_layer")]
   [JsonConverter(typeof(StringEnumConverter))]
   public RuleSeverity? ItemOnDisabledLayer
   {
      get => _itemOnDisabledLayer;
      set
      {
         _itemOnDisabledLayer = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Items not allowed
   /// </summary>
   [JsonProperty(PropertyName = "items_not_allowed")]
   [JsonConverter(typeof(StringEnumConverter))]
   public RuleSeverity? ItemsNotAllowed
   {
      get => _itemNotAllowed;
      set
      {
         _itemNotAllowed = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Length out of range
   /// </summary>
   [JsonProperty(PropertyName = "length_out_of_range")]
   [JsonConverter(typeof(StringEnumConverter))]
   public RuleSeverity? LengthOutOfRange
   {
      get => _lengthOutOfRange;
      set
      {
         _lengthOutOfRange = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Library footprint issues
   /// </summary>
   [JsonProperty(PropertyName = "lib_footprint_issues")]
   [JsonConverter(typeof(StringEnumConverter))]
   public RuleSeverity? LibFootprintIssues
   {
      get => _libFootprintIssues;
      set
      {
         _libFootprintIssues = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Library footprint mismatch
   /// </summary>
   [JsonProperty(PropertyName = "lib_footprint_mismatch")]
   [JsonConverter(typeof(StringEnumConverter))]
   public RuleSeverity? LibFootprintMismatch
   {
      get => _libFootprintMismatch;
      set
      {
         _libFootprintMismatch = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Malformed courtyard
   /// </summary>
   [JsonProperty(PropertyName = "malformed_courtyard")]
   [JsonConverter(typeof(StringEnumConverter))]
   public RuleSeverity? MalformedCourtyard
   {
      get => _malformedCourtyard;
      set
      {
         _malformedCourtyard = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Micro-via drill out of range
   /// </summary>
   [JsonProperty(PropertyName = "microvia_drill_out_of_range")]
   [JsonConverter(typeof(StringEnumConverter))]
   public RuleSeverity? MicroviaDrillOutOfRange
   {
      get => _microviaDrillOutOfRange;
      set
      {
         _microviaDrillOutOfRange = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Missing courtyard
   /// </summary>
   [JsonProperty(PropertyName = "missing_courtyard")]
   [JsonConverter(typeof(StringEnumConverter))]
   public RuleSeverity? MissingCourtyard
   {
      get => _missingCourtyard;
      set
      {
         _missingCourtyard = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Missing footprint
   /// </summary>
   [JsonProperty(PropertyName = "missing_footprint")]
   [JsonConverter(typeof(StringEnumConverter))]
   public RuleSeverity? MissingFootprint
   {
      get => _missingFootprint;
      set
      {
         _missingFootprint = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Net conflict
   /// </summary>
   [JsonProperty(PropertyName = "net_conflict")]
   [JsonConverter(typeof(StringEnumConverter))]
   public RuleSeverity? NetConflict
   {
      get => _netConflict;
      set
      {
         _netConflict = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// NPTH inside courtyard
   /// </summary>
   [JsonProperty(PropertyName = "npth_inside_courtyard")]
   [JsonConverter(typeof(StringEnumConverter))]
   public RuleSeverity? NPTHInsideCourtyard
   {
      get => _npthInsideCourtyard;
      set
      {
         _npthInsideCourtyard = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Pad stack
   /// </summary>
   [JsonProperty(PropertyName = "padstack")]
   [JsonConverter(typeof(StringEnumConverter))]
   public RuleSeverity? PadStack
   {
      get => _padStack;
      set
      {
         _padStack = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// PTH inside courtyard
   /// </summary>
   [JsonProperty(PropertyName = "pth_inside_courtyard")]
   [JsonConverter(typeof(StringEnumConverter))]
   public RuleSeverity? PTHInsideCourtyard
   {
      get => _pthInsideCourtyard;
      set
      {
         _pthInsideCourtyard = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Shorting items
   /// </summary>
   [JsonProperty(PropertyName = "shorting_items")]
   [JsonConverter(typeof(StringEnumConverter))]
   public RuleSeverity? ShortingItems
   {
      get => _shortingItems;
      set
      {
         _shortingItems = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Silkscreen edge clearance
   /// </summary>
   [JsonProperty(PropertyName = "silk_edge_clearance")]
   [JsonConverter(typeof(StringEnumConverter))]
   public RuleSeverity? SilkEdgeClearance
   {
      get => _silkEdgeClearance;
      set
      {
         _silkEdgeClearance = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Silkscreen over copper
   /// </summary>
   [JsonProperty(PropertyName = "silk_over_copper")]
   [JsonConverter(typeof(StringEnumConverter))]
   public RuleSeverity? SilkOverCopper
   {
      get => _silkOverCopper;
      set
      {
         _silkOverCopper = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Silkscreen overlap
   /// </summary>
   [JsonProperty(PropertyName = "silk_overlap")]
   [JsonConverter(typeof(StringEnumConverter))]
   public RuleSeverity? SilkOverlap
   {
      get => _silkOverlap;
      set
      {
         _silkOverlap = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Skew out of range
   /// </summary>
   [JsonProperty(PropertyName = "skew_out_of_range")]
   [JsonConverter(typeof(StringEnumConverter))]
   public RuleSeverity? SkewOutOfRange
   {
      get => _skewOutOfRange;
      set
      {
         _skewOutOfRange = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Solder mask bridge
   /// </summary>
   [JsonProperty(PropertyName = "solder_mask_bridge")]
   [JsonConverter(typeof(StringEnumConverter))]
   public RuleSeverity? SolderMaskBridge
   {
      get => _solderMaskBridge;
      set
      {
         _solderMaskBridge = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Starved thermal
   /// </summary>
   [JsonProperty(PropertyName = "starved_thermal")]
   [JsonConverter(typeof(StringEnumConverter))]
   public RuleSeverity? StarvedThermal
   {
      get => _starvedThermal;
      set
      {
         _starvedThermal = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Text height
   /// </summary>
   [JsonProperty(PropertyName = "text_height")]
   [JsonConverter(typeof(StringEnumConverter))]
   public RuleSeverity? TextHeight
   {
      get => _textHeight;
      set
      {
         _textHeight = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Text thickness
   /// </summary>
   [JsonProperty(PropertyName = "text_thickness")]
   [JsonConverter(typeof(StringEnumConverter))]
   public RuleSeverity? TextThickness
   {
      get => _textThickness;
      set
      {
         _textThickness = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Through hole pad without hole
   /// </summary>
   [JsonProperty(PropertyName = "through_hole_pad_without_hole")]
   [JsonConverter(typeof(StringEnumConverter))]
   public RuleSeverity? ThroughHolePadWithoutHole
   {
      get => _throughHolePadWithoutHole;
      set
      {
         _throughHolePadWithoutHole = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Too many vias
   /// </summary>
   [JsonProperty(PropertyName = "too_many_vias")]
   [JsonConverter(typeof(StringEnumConverter))]
   public RuleSeverity? TooManyVias
   {
      get => _tooManyVias;
      set
      {
         _tooManyVias = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Dangling Track
   /// </summary>
   [JsonProperty(PropertyName = "track_dangling")]
   [JsonConverter(typeof(StringEnumConverter))]
   public RuleSeverity? TrackDangling
   {
      get => _trackDangling;
      set
      {
         _trackDangling = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Track width
   /// </summary>
   [JsonProperty(PropertyName = "track_width")]
   [JsonConverter(typeof(StringEnumConverter))]
   public RuleSeverity? TrackWidth
   {
      get => _trackWidth;
      set
      {
         _trackWidth = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Tracks crossing
   /// </summary>
   [JsonProperty(PropertyName = "tracks_crossing")]
   [JsonConverter(typeof(StringEnumConverter))]
   public RuleSeverity? TracksCrossing
   {
      get => _tracksCrossing;
      set
      {
         _tracksCrossing = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Unconnected items
   /// </summary>
   [JsonProperty(PropertyName = "unconnected_items")]
   [JsonConverter(typeof(StringEnumConverter))]
   public RuleSeverity? UnconnectedItems
   {
      get => _unconnectedItems;
      set
      {
         _unconnectedItems = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Unresolved variable
   /// </summary>
   [JsonProperty(PropertyName = "unresolved_variable")]
   [JsonConverter(typeof(StringEnumConverter))]
   public RuleSeverity? UnresolvedVariable
   {
      get => _unresolvedVariable;
      set
      {
         _unresolvedVariable = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Dangling vias
   /// </summary>
   [JsonProperty(PropertyName = "via_dangling")]
   [JsonConverter(typeof(StringEnumConverter))]
   public RuleSeverity? ViaDangling
   {
      get => _vaiaDangling;
      set
      {
         _vaiaDangling = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Zones intersect
   /// </summary>
   [JsonProperty(PropertyName = "zones_intersect")]
   [JsonConverter(typeof(StringEnumConverter))]
   public RuleSeverity? ZonesIntersect
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
