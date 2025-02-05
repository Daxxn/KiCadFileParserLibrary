using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MVVMLibrary;

using Newtonsoft.Json;

namespace KiCadFileParserLibrary.KiCad.Project.SubModels
{
   public class ErcModel : Model
   {
      #region Local Props
      private ObservableCollection<string>? _exclusions;
      private MetadataModel? _metadata;
      private ObservableCollection<ObservableCollection<int>>? _pinMap;
      private SchRuleSeverityModel? _ruleSeverities;

      #endregion

      #region Constructors
      public ErcModel() { }
      #endregion

      #region Methods

      #endregion

      #region Full Props
      [JsonProperty(PropertyName = "erc_exclusions")]
      public ObservableCollection<string>? Exclusions
      {
         get => _exclusions;
         set
         {
            _exclusions = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "meta")]
      public MetadataModel? Metadata
      {
         get => _metadata;
         set
         {
            _metadata = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "pin_map")]
      public ObservableCollection<ObservableCollection<int>>? PinMap
      {
         get => _pinMap;
         set
         {
            _pinMap = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "rule_severities")]
      public SchRuleSeverityModel? RuleSeverities
      {
         get => _ruleSeverities;
         set
         {
            _ruleSeverities = value;
            OnPropertyChanged();
         }
      }
      #endregion
   }
}
