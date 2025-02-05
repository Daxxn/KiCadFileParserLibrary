using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MVVMLibrary;

using Newtonsoft.Json;

namespace KiCadFileParserLibrary.KiCad.Project.SubModels
{
   public class PcbSettingsModel : Model
   {
      #region Local Props
      private LastPathsSettingsModel? _lastPaths;
      private string? _pageLayoutDescFile;
      #endregion

      #region Constructors
      public PcbSettingsModel() { }
      #endregion

      #region Methods

      #endregion

      #region Full Props
      [JsonProperty(PropertyName = "last_paths")]
      public LastPathsSettingsModel? LastPaths
      {
         get => _lastPaths;
         set
         {
            _lastPaths = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "page_layout_descr_file")]
      public string? PageLayoutDescFile
      {
         get => _pageLayoutDescFile;
         set
         {
            _pageLayoutDescFile = value;
            OnPropertyChanged();
         }
      }
      #endregion
   }
}
