using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MVVMLibrary;

using Newtonsoft.Json;

namespace KiCadFileParserLibrary.KiCad.Project.SubModels;

/// <summary>
/// Design settings used by the PCB editor.
/// </summary>
public class DesignSettingsModel : Model
{
   #region Local Props
   private DefaultDesignSettingsModel _defaults = new();
   private ObservableCollection<DiffPairDimensionModel> _diffPairDims = [];
   private ObservableCollection<string> _drcExcl = [];
   private MetadataModel _metadata = new();
   private PcbRuleSeverityModel _ruleSeverity = new();
   private RuleSettingsModel _ruleSettings = new();
   private ObservableCollection<TeardropOptionModel> _teardropOptions = [];
   private ObservableCollection<TeardropParamModel> _teardropParameters = [];
   private ObservableCollection<double> _trackWidths = [0];
   private Dictionary<string, TuningPatternSettingsModel> _tuningPatterns = [];
   private ObservableCollection<ViaDimensionModel> _viaDims = [];
   private bool _zonesAllowExternalFillets;
   #endregion

   #region Constructors
   /// <inheritdoc/>
   public DesignSettingsModel() { }
   #endregion

   #region Methods

   #endregion

   #region Full Props
   [JsonProperty(PropertyName = "defaults")]
   public DefaultDesignSettingsModel Defaults
   {
      get => _defaults;
      set
      {
         _defaults = value;
         OnPropertyChanged();
      }
   }

   [JsonProperty(PropertyName = "diff_pair_dimensions")]
   public ObservableCollection<DiffPairDimensionModel> DiffPairDimensions
   {
      get => _diffPairDims;
      set
      {
         _diffPairDims = value;
         OnPropertyChanged();
      }
   }

   [JsonProperty(PropertyName = "drc_exclusions")]
   public ObservableCollection<string> DrcExlusions
   {
      get => _drcExcl;
      set
      {
         _drcExcl = value;
         OnPropertyChanged();
      }
   }

   [JsonProperty(PropertyName = "meta")]
   public MetadataModel Metadata
   {
      get => _metadata;
      set
      {
         _metadata = value;
         OnPropertyChanged();
      }
   }

   [JsonProperty(PropertyName = "rule_severities")]
   public PcbRuleSeverityModel RuleSeverities
   {
      get => _ruleSeverity;
      set
      {
         _ruleSeverity = value;
         OnPropertyChanged();
      }
   }

   [JsonProperty(PropertyName = "rules")]
   public RuleSettingsModel RuleSettings
   {
      get => _ruleSettings;
      set
      {
         _ruleSettings = value;
         OnPropertyChanged();
      }
   }

   [JsonProperty(PropertyName = "teardrop_options")]
   public ObservableCollection<TeardropOptionModel> TeardropOptions
   {
      get => _teardropOptions;
      set
      {
         _teardropOptions = value;
         OnPropertyChanged();
      }
   }

   [JsonProperty(PropertyName = "teardrop_parameters")]
   public ObservableCollection<TeardropParamModel> TeardropParameters
   {
      get => _teardropParameters;
      set
      {
         _teardropParameters = value;
         OnPropertyChanged();
      }
   }

   [JsonProperty(PropertyName = "track_widths")]
   public ObservableCollection<double> TrackWidths
   {
      get => _trackWidths;
      set
      {
         _trackWidths = value;
         OnPropertyChanged();
      }
   }

   [JsonProperty(PropertyName = "tuning_pattern_settings")]
   public Dictionary<string, TuningPatternSettingsModel> TuningPatterns
   {
      get => _tuningPatterns;
      set
      {
         _tuningPatterns = value;
         OnPropertyChanged();
      }
   }

   [JsonProperty(PropertyName = "via_dimensions")]
   public ObservableCollection<ViaDimensionModel> ViaDimensions
   {
      get => _viaDims;
      set
      {
         _viaDims = value;
         OnPropertyChanged();
      }
   }

   [JsonProperty(PropertyName = "zones_allow_external_fillets")]
   public bool ZonesAllowExternalFillets
   {
      get => _zonesAllowExternalFillets;
      set
      {
         _zonesAllowExternalFillets = value;
         OnPropertyChanged();
      }
   }
   #endregion
}
