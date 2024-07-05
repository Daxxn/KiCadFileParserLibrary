using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace KiCadFileParserLibrary.KiCad.Project.SubModels
{
   public class SchRuleSeverityModel
   {
      #region Local Props
      [JsonProperty(PropertyName = "bus_definition_conflict")]
      public string? BusDefinitionConflict { get; set; }

      [JsonProperty(PropertyName = "bus_entry_needed")]
      public string? BusEntryNeeded { get; set; }

      [JsonProperty(PropertyName = "bus_to_bus_conflict")]
      public string? BusToBusConflict { get; set; }

      [JsonProperty(PropertyName = "bus_to_net_conflict")]
      public string? BusToNetConflict { get; set; }

      [JsonProperty(PropertyName = "conflicting_netclasses")]
      public string? ConflictingNetClasses { get; set; }

      [JsonProperty(PropertyName = "different_unit_footprint")]
      public string? DifferentUnitFootprint { get; set; }

      [JsonProperty(PropertyName = "different_unit_net")]
      public string? DifferentUnitNet { get; set; }

      [JsonProperty(PropertyName = "duplicate_reference")]
      public string? DuplicateReference { get; set; }

      [JsonProperty(PropertyName = "duplicate_sheet_names")]
      public string? DuplicateSheetNames { get; set; }

      [JsonProperty(PropertyName = "endpoint_off_grid")]
      public string? EndpointOffGrid { get; set; }

      [JsonProperty(PropertyName = "extra_units")]
      public string? ExtraUnits { get; set; }

      [JsonProperty(PropertyName = "global_label_dangling")]
      public string? GlobalLabelDangling { get; set; }

      [JsonProperty(PropertyName = "hier_label_mismatch")]
      public string? HeirLabelMismatch { get; set; }

      [JsonProperty(PropertyName = "label_dangling")]
      public string? LabelDangling { get; set; }

      [JsonProperty(PropertyName = "lib_symbol_issues")]
      public string? LibSymbolIssue { get; set; }

      [JsonProperty(PropertyName = "missing_bidi_pin")]
      public string? MissingBiDirPin { get; set; }

      [JsonProperty(PropertyName = "missing_input_pin")]
      public string? MissingInputPin { get; set; }

      [JsonProperty(PropertyName = "missing_power_pin")]
      public string? MissingPowerPin { get; set; }

      [JsonProperty(PropertyName = "missing_unit")]
      public string? MissingUnit { get; set; }

      [JsonProperty(PropertyName = "multiple_net_names")]
      public string? MultipleNetNames { get; set; }

      [JsonProperty(PropertyName = "net_not_bus_member")]
      public string? NetNotBusMember { get; set; }

      [JsonProperty(PropertyName = "no_connect_connected")]
      public string? NoConnectConnected { get; set; }

      [JsonProperty(PropertyName = "no_connect_dangling")]
      public string? NoConnectDangling { get; set; }

      [JsonProperty(PropertyName = "pin_not_connected")]
      public string? PinNotConnected { get; set; }

      [JsonProperty(PropertyName = "pin_not_driven")]
      public string? PinNotDriven { get; set; }

      [JsonProperty(PropertyName = "pin_to_pin")]
      public string? PinToPin { get; set; }

      [JsonProperty(PropertyName = "power_pin_not_driven")]
      public string? PowerPinNotDriven { get; set; }

      [JsonProperty(PropertyName = "similar_labels")]
      public string? SimilarLabels { get; set; }

      [JsonProperty(PropertyName = "simulation_model_issue")]
      public string? SimModelIssue { get; set; }

      [JsonProperty(PropertyName = "unannotated")]
      public string? Unannotated { get; set; }

      [JsonProperty(PropertyName = "unit_value_mismatch")]
      public string? UnitValueMismatch { get; set; }

      [JsonProperty(PropertyName = "unresolved_variable")]
      public string? UnresolvedVariable { get; set; }

      [JsonProperty(PropertyName = "wire_dangling")]
      public string? WireDangling { get; set; }
      #endregion

      #region Constructors
      public SchRuleSeverityModel() { }
      #endregion

      #region Methods

      #endregion

      #region Full Props

      #endregion
   }
}
