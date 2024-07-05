using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace KiCadFileParserLibrary.KiCad.Project.SubModels
{
   public class DesignSettingsModel
   {
      #region Local Props
      [JsonProperty(PropertyName = "defaults")]
      public DefaultDesignSettingsModel? Defaults { get; set; }

      [JsonProperty(PropertyName = "diff_pair_dimensions")]
      public List<DiffPairDimsSettingsModel>? DiffPairDimensions { get; set; }

      [JsonProperty(PropertyName = "drc_exclusions")]
      public List<string>? DrcExlusions { get; set; }

      [JsonProperty(PropertyName = "meta")]
      public MetadataModel? Metadata { get; set; }

      [JsonProperty(PropertyName = "rule_severities")]
      public PcbRuleSeverityModel? RuleSeverities { get; set; }

      [JsonProperty(PropertyName = "rules")]
      public RuleSettingsModel? RuleSettings { get; set; }

      [JsonProperty(PropertyName = "teardrop_options")]
      public List<TeardropOptionModel>? TeardropOptions { get; set; }

      [JsonProperty(PropertyName = "teardrop_parameters")]
      public List<TeardropParamModel>? TeardropParameters { get; set; }

      [JsonProperty(PropertyName = "track_widths")]
      public List<double>? TrackWidths { get; set; }

      [JsonProperty(PropertyName = "tuning_pattern_settings")]
      public Dictionary<string, TuningPatternSettingsModel>? TuningPatterns { get; set; }

      [JsonProperty(PropertyName = "via_dimensions")]
      public List<ViaParamModel>? ViaDimensions { get; set; }

      [JsonProperty(PropertyName = "zones_allow_external_fillets")]
      public bool ZonesAllowExternalFillets { get; set; }
      #endregion

      #region Constructors
      public DesignSettingsModel() { }
      #endregion

      #region Methods

      #endregion

      #region Full Props

      #endregion
   }
}
