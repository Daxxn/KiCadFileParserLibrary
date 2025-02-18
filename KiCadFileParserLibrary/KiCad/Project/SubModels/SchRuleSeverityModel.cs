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
/// Schematic rule severity model.
/// </summary>
public class SchRuleSeverityModel : Model
{
   #region Local Props
   private RuleSeverity? _busDefConflict;
   private RuleSeverity? _busEntryNeeded;
   private RuleSeverity? _busToBusConflict;
   private RuleSeverity? _busToNetConflict;
   private RuleSeverity? _conflictingNetClasses;
   private RuleSeverity? _differentUnitFootprint;
   private RuleSeverity? _differentUnitNet;
   private RuleSeverity? _duplicateReference;
   private RuleSeverity? _duplicateSheetNames;
   private RuleSeverity? _endpointOffGrid;
   private RuleSeverity? _extraUnits;
   private RuleSeverity? _globalLabelDangling;
   private RuleSeverity? _heirLabelMismatch;
   private RuleSeverity? _labelDangling;
   private RuleSeverity? _libSymbolIssue;
   private RuleSeverity? _missingBiDirPin;
   private RuleSeverity? _missingInputPin;
   private RuleSeverity? _missingPowerPin;
   private RuleSeverity? _missingUnit;
   private RuleSeverity? _multipleNetNames;
   private RuleSeverity? _netNotBusMember;
   private RuleSeverity? _noConnectConnected;
   private RuleSeverity? _noConnectDangling;
   private RuleSeverity? _pinNotConnected;
   private RuleSeverity? _pinNotDriven;
   private RuleSeverity? _pinToPin;
   private RuleSeverity? _powerPinNotDriven;
   private RuleSeverity? _similarLabels;
   private RuleSeverity? _simModelIssue;
   private RuleSeverity? _unannotated;
   private RuleSeverity? _unitValueMismatch;
   private RuleSeverity? _unresolvedVariable;
   private RuleSeverity? _wireDangling;
   #endregion

   #region Constructors
   /// <inheritdoc/>
   public SchRuleSeverityModel() { }
   #endregion

   #region Methods

   #endregion

   #region Full Props
   /// <summary>
   /// Bus definition conflict
   /// </summary>
   [JsonProperty(PropertyName = "bus_definition_conflict")]
   [JsonConverter(typeof(StringEnumConverter))]
   public RuleSeverity? BusDefinitionConflict
   {
      get => _busDefConflict;
      set
      {
         _busDefConflict = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Bus entry needed
   /// </summary>
   [JsonProperty(PropertyName = "bus_entry_needed")]
   [JsonConverter(typeof(StringEnumConverter))]
   public RuleSeverity? BusEntryNeeded
   {
      get => _busEntryNeeded;
      set
      {
         _busEntryNeeded = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Bus to bus conflict
   /// </summary>
   [JsonProperty(PropertyName = "bus_to_bus_conflict")]
   [JsonConverter(typeof(StringEnumConverter))]
   public RuleSeverity? BusToBusConflict
   {
      get => _busToBusConflict;
      set
      {
         _busToBusConflict = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Bus to net conflict
   /// </summary>
   [JsonProperty(PropertyName = "bus_to_net_conflict")]
   [JsonConverter(typeof(StringEnumConverter))]
   public RuleSeverity? BusToNetConflict
   {
      get => _busToNetConflict;
      set
      {
         _busToNetConflict = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Conflicting net classes
   /// </summary>
   [JsonProperty(PropertyName = "conflicting_netclasses")]
   [JsonConverter(typeof(StringEnumConverter))]
   public RuleSeverity? ConflictingNetClasses
   {
      get => _conflictingNetClasses;
      set
      {
         _conflictingNetClasses = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Different unit footprint
   /// </summary>
   [JsonProperty(PropertyName = "different_unit_footprint")]
   [JsonConverter(typeof(StringEnumConverter))]
   public RuleSeverity? DifferentUnitFootprint
   {
      get => _differentUnitFootprint;
      set
      {
         _differentUnitFootprint = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Different unit net
   /// </summary>
   [JsonProperty(PropertyName = "different_unit_net")]
   [JsonConverter(typeof(StringEnumConverter))]
   public RuleSeverity? DifferentUnitNet
   {
      get => _differentUnitNet;
      set
      {
         _differentUnitNet = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Duplicate reference designator
   /// </summary>
   [JsonProperty(PropertyName = "duplicate_reference")]
   [JsonConverter(typeof(StringEnumConverter))]
   public RuleSeverity? DuplicateReference
   {
      get => _duplicateReference;
      set
      {
         _duplicateReference = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Duplicate sheet names
   /// </summary>
   [JsonProperty(PropertyName = "duplicate_sheet_names")]
   [JsonConverter(typeof(StringEnumConverter))]
   public RuleSeverity? DuplicateSheetNames
   {
      get => _duplicateSheetNames;
      set
      {
         _duplicateSheetNames = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Endpoint off grid
   /// </summary>
   [JsonProperty(PropertyName = "endpoint_off_grid")]
   [JsonConverter(typeof(StringEnumConverter))]
   public RuleSeverity? EndpointOffGrid
   {
      get => _endpointOffGrid;
      set
      {
         _endpointOffGrid = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Extra units
   /// </summary>
   [JsonProperty(PropertyName = "extra_units")]
   [JsonConverter(typeof(StringEnumConverter))]
   public RuleSeverity? ExtraUnits
   {
      get => _extraUnits;
      set
      {
         _extraUnits = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Dangling global label
   /// </summary>
   [JsonProperty(PropertyName = "global_label_dangling")]
   [JsonConverter(typeof(StringEnumConverter))]
   public RuleSeverity? GlobalLabelDangling
   {
      get => _globalLabelDangling;
      set
      {
         _globalLabelDangling = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Heirarchical label mismatch
   /// </summary>
   [JsonProperty(PropertyName = "hier_label_mismatch")]
   [JsonConverter(typeof(StringEnumConverter))]
   public RuleSeverity? HeirLabelMismatch
   {
      get => _heirLabelMismatch;
      set
      {
         _heirLabelMismatch = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Dangling label
   /// </summary>
   [JsonProperty(PropertyName = "label_dangling")]
   [JsonConverter(typeof(StringEnumConverter))]
   public RuleSeverity? LabelDangling
   {
      get => _labelDangling;
      set
      {
         _labelDangling = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Library symbol issue
   /// </summary>
   [JsonProperty(PropertyName = "lib_symbol_issues")]
   [JsonConverter(typeof(StringEnumConverter))]
   public RuleSeverity? LibSymbolIssue
   {
      get => _libSymbolIssue;
      set
      {
         _libSymbolIssue = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Missing bi-directional pin
   /// </summary>
   [JsonProperty(PropertyName = "missing_bidi_pin")]
   [JsonConverter(typeof(StringEnumConverter))]
   public RuleSeverity? MissingBiDirPin
   {
      get => _missingBiDirPin;
      set
      {
         _missingBiDirPin = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Missing input pin
   /// </summary>
   [JsonProperty(PropertyName = "missing_input_pin")]
   [JsonConverter(typeof(StringEnumConverter))]
   public RuleSeverity? MissingInputPin
   {
      get => _missingInputPin;
      set
      {
         _missingInputPin = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Missing power pin
   /// </summary>
   [JsonProperty(PropertyName = "missing_power_pin")]
   [JsonConverter(typeof(StringEnumConverter))]
   public RuleSeverity? MissingPowerPin
   {
      get => _missingPowerPin;
      set
      {
         _missingPowerPin = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Missing unit
   /// </summary>
   [JsonProperty(PropertyName = "missing_unit")]
   [JsonConverter(typeof(StringEnumConverter))]
   public RuleSeverity? MissingUnit
   {
      get => _missingUnit;
      set
      {
         _missingUnit = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Multiple net names
   /// </summary>
   [JsonProperty(PropertyName = "multiple_net_names")]
   [JsonConverter(typeof(StringEnumConverter))]
   public RuleSeverity? MultipleNetNames
   {
      get => _multipleNetNames;
      set
      {
         _multipleNetNames = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Net not bus member
   /// </summary>
   [JsonProperty(PropertyName = "net_not_bus_member")]
   [JsonConverter(typeof(StringEnumConverter))]
   public RuleSeverity? NetNotBusMember
   {
      get => _netNotBusMember;
      set
      {
         _netNotBusMember = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// No-connect connected
   /// </summary>
   [JsonProperty(PropertyName = "no_connect_connected")]
   [JsonConverter(typeof(StringEnumConverter))]
   public RuleSeverity? NoConnectConnected
   {
      get => _noConnectConnected;
      set
      {
         _noConnectConnected = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Dangling no-connect
   /// </summary>
   [JsonProperty(PropertyName = "no_connect_dangling")]
   [JsonConverter(typeof(StringEnumConverter))]
   public RuleSeverity? NoConnectDangling
   {
      get => _noConnectDangling;
      set
      {
         _noConnectDangling = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Pin not connected
   /// </summary>
   [JsonProperty(PropertyName = "pin_not_connected")]
   [JsonConverter(typeof(StringEnumConverter))]
   public RuleSeverity? PinNotConnected
   {
      get => _pinNotConnected;
      set
      {
         _pinNotConnected = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Pin not driven
   /// </summary>
   [JsonProperty(PropertyName = "pin_not_driven")]
   [JsonConverter(typeof(StringEnumConverter))]
   public RuleSeverity? PinNotDriven
   {
      get => _pinNotDriven;
      set
      {
         _pinNotDriven = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Pin to pin
   /// </summary>
   [JsonProperty(PropertyName = "pin_to_pin")]
   [JsonConverter(typeof(StringEnumConverter))]
   public RuleSeverity? PinToPin
   {
      get => _pinToPin;
      set
      {
         _pinToPin = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Power pin not driven
   /// </summary>
   [JsonProperty(PropertyName = "power_pin_not_driven")]
   [JsonConverter(typeof(StringEnumConverter))]
   public RuleSeverity? PowerPinNotDriven
   {
      get => _powerPinNotDriven;
      set
      {
         _powerPinNotDriven = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Similar labels
   /// </summary>
   [JsonProperty(PropertyName = "similar_labels")]
   [JsonConverter(typeof(StringEnumConverter))]
   public RuleSeverity? SimilarLabels
   {
      get => _similarLabels;
      set
      {
         _similarLabels = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Simulation model issue
   /// </summary>
   [JsonProperty(PropertyName = "simulation_model_issue")]
   [JsonConverter(typeof(StringEnumConverter))]
   public RuleSeverity? SimModelIssue
   {
      get => _simModelIssue;
      set
      {
         _simModelIssue = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Unannotated
   /// </summary>
   [JsonProperty(PropertyName = "unannotated")]
   [JsonConverter(typeof(StringEnumConverter))]
   public RuleSeverity? Unannotated
   {
      get => _unannotated;
      set
      {
         _unannotated = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Unit value mismatch
   /// </summary>
   [JsonProperty(PropertyName = "unit_value_mismatch")]
   [JsonConverter(typeof(StringEnumConverter))]
   public RuleSeverity? UnitValueMismatch
   {
      get => _unitValueMismatch;
      set
      {
         _unitValueMismatch = value;
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
   /// Dangling wire
   /// </summary>
   [JsonProperty(PropertyName = "wire_dangling")]
   [JsonConverter(typeof(StringEnumConverter))]
   public RuleSeverity? WireDangling
   {
      get => _wireDangling;
      set
      {
         _wireDangling = value;
         OnPropertyChanged();
      }
   }
   #endregion
}
