using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MVVMLibrary;

using Newtonsoft.Json;

namespace KiCadFileParserLibrary.KiCad.Project.SubModels
{
   public class SchRuleSeverityModel : Model
   {
      #region Local Props
      private string? _busDefConflict;
      private string? _busEntryNeeded;
      private string? _busToBusConflict;
      private string? _busToNetConflict;
      private string? _conflictingNetClasses;
      private string? _differentUnitFootprint;
      private string? _differentUnitNet;
      private string? _duplicateReference;
      private string? _duplicateSheetNames;
      private string? _endpointOffGrid;
      private string? _extraUnits;
      private string? _globalLabelDangling;
      private string? _heirLabelMismatch;
      private string? _labelDangling;
      private string? _libSymbolIssue;
      private string? _missingBiDirPin;
      private string? _missingInputPin;
      private string? _missingPowerPin;
      private string? _missingUnit;
      private string? _multipleNetNames;
      private string? _netNotBusMember;
      private string? _noConnectConnected;
      private string? _noConnectDangling;
      private string? _pinNotConnected;
      private string? _pinNotDriven;
      private string? _pinToPin;
      private string? _powerPinNotDriven;
      private string? _similarLabels;
      private string? _simModelIssue;
      private string? _unannotated;
      private string? _unitValueMismatch;
      private string? _unresolvedVariable;
      private string? _wireDangling;
      #endregion

      #region Constructors
      public SchRuleSeverityModel() { }
      #endregion

      #region Methods

      #endregion

      #region Full Props
      [JsonProperty(PropertyName = "bus_definition_conflict")]
      public string? BusDefinitionConflict
      {
         get => _busDefConflict;
         set
         {
            _busDefConflict = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "bus_entry_needed")]
      public string? BusEntryNeeded
      {
         get => _busEntryNeeded;
         set
         {
            _busEntryNeeded = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "bus_to_bus_conflict")]
      public string? BusToBusConflict
      {
         get => _busToBusConflict;
         set
         {
            _busToBusConflict = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "bus_to_net_conflict")]
      public string? BusToNetConflict
      {
         get => _busToNetConflict;
         set
         {
            _busToNetConflict = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "conflicting_netclasses")]
      public string? ConflictingNetClasses
      {
         get => _conflictingNetClasses;
         set
         {
            _conflictingNetClasses = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "different_unit_footprint")]
      public string? DifferentUnitFootprint
      {
         get => _differentUnitFootprint;
         set
         {
            _differentUnitFootprint = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "different_unit_net")]
      public string? DifferentUnitNet
      {
         get => _differentUnitNet;
         set
         {
            _differentUnitNet = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "duplicate_reference")]
      public string? DuplicateReference
      {
         get => _duplicateReference;
         set
         {
            _duplicateReference = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "duplicate_sheet_names")]
      public string? DuplicateSheetNames
      {
         get => _duplicateSheetNames;
         set
         {
            _duplicateSheetNames = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "endpoint_off_grid")]
      public string? EndpointOffGrid
      {
         get => _endpointOffGrid;
         set
         {
            _endpointOffGrid = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "extra_units")]
      public string? ExtraUnits
      {
         get => _extraUnits;
         set
         {
            _extraUnits = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "global_label_dangling")]
      public string? GlobalLabelDangling
      {
         get => _globalLabelDangling;
         set
         {
            _globalLabelDangling = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "hier_label_mismatch")]
      public string? HeirLabelMismatch
      {
         get => _heirLabelMismatch;
         set
         {
            _heirLabelMismatch = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "label_dangling")]
      public string? LabelDangling
      {
         get => _labelDangling;
         set
         {
            _labelDangling = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "lib_symbol_issues")]
      public string? LibSymbolIssue
      {
         get => _libSymbolIssue;
         set
         {
            _libSymbolIssue = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "missing_bidi_pin")]
      public string? MissingBiDirPin
      {
         get => _missingBiDirPin;
         set
         {
            _missingBiDirPin = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "missing_input_pin")]
      public string? MissingInputPin
      {
         get => _missingInputPin;
         set
         {
            _missingInputPin = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "missing_power_pin")]
      public string? MissingPowerPin
      {
         get => _missingPowerPin;
         set
         {
            _missingPowerPin = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "missing_unit")]
      public string? MissingUnit
      {
         get => _missingUnit;
         set
         {
            _missingUnit = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "multiple_net_names")]
      public string? MultipleNetNames
      {
         get => _multipleNetNames;
         set
         {
            _multipleNetNames = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "net_not_bus_member")]
      public string? NetNotBusMember
      {
         get => _netNotBusMember;
         set
         {
            _netNotBusMember = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "no_connect_connected")]
      public string? NoConnectConnected
      {
         get => _noConnectConnected;
         set
         {
            _noConnectConnected = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "no_connect_dangling")]
      public string? NoConnectDangling
      {
         get => _noConnectDangling;
         set
         {
            _noConnectDangling = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "pin_not_connected")]
      public string? PinNotConnected
      {
         get => _pinNotConnected;
         set
         {
            _pinNotConnected = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "pin_not_driven")]
      public string? PinNotDriven
      {
         get => _pinNotDriven;
         set
         {
            _pinNotDriven = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "pin_to_pin")]
      public string? PinToPin
      {
         get => _pinToPin;
         set
         {
            _pinToPin = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "power_pin_not_driven")]
      public string? PowerPinNotDriven
      {
         get => _powerPinNotDriven;
         set
         {
            _powerPinNotDriven = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "similar_labels")]
      public string? SimilarLabels
      {
         get => _similarLabels;
         set
         {
            _similarLabels = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "simulation_model_issue")]
      public string? SimModelIssue
      {
         get => _simModelIssue;
         set
         {
            _simModelIssue = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "unannotated")]
      public string? Unannotated
      {
         get => _unannotated;
         set
         {
            _unannotated = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "unit_value_mismatch")]
      public string? UnitValueMismatch
      {
         get => _unitValueMismatch;
         set
         {
            _unitValueMismatch = value;
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

      [JsonProperty(PropertyName = "wire_dangling")]
      public string? WireDangling
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
}
