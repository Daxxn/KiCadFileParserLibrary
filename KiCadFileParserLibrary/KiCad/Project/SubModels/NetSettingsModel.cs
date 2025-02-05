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
   public class NetSettingsModel : Model
   {
      #region Local Props
      private ObservableCollection<NetClassSettingsModel>? _netClasses;
      private MetadataModel? _meta;
      private string? _netColors;
      private Dictionary<string, string>? _netClassAssignments;
      private ObservableCollection<string>? _netClassPatterns;

      #endregion

      #region Constructors
      public NetSettingsModel() { }
      #endregion

      #region Methods

      #endregion

      #region Full Props
      [JsonProperty(PropertyName = "classes")]
      public ObservableCollection<NetClassSettingsModel>? NetClasses
      {
         get => _netClasses;
         set
         {
            _netClasses = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "meta")]
      public MetadataModel? Metadata
      {
         get => _meta;
         set
         {
            _meta = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "net_colors")]
      public string? NetColors
      {
         get => _netColors;
         set
         {
            _netColors = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "netclass_assignments")]
      public Dictionary<string, string>? NetClassAssignments
      {
         get => _netClassAssignments;
         set
         {
            _netClassAssignments = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "netclass_patterns")]
      public ObservableCollection<string>? NetClassPatterns
      {
         get => _netClassPatterns;
         set
         {
            _netClassPatterns = value;
            OnPropertyChanged();
         }
      }
      #endregion
   }
}
