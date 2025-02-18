using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MVVMLibrary;

using Newtonsoft.Json;

namespace KiCadFileParserLibrary.KiCad.Project.SubModels;

/// <summary>
/// PCB settings model.
/// </summary>
public class PcbSettingsModel : Model
{
   #region Local Props
   private LastPathsSettingsModel? _lastPaths;
   private string? _pageLayoutDescFile;
   #endregion

   #region Constructors
   /// <inheritdoc/>
   public PcbSettingsModel() { }
   #endregion

   #region Methods

   #endregion

   #region Full Props
   /// <summary>
   /// Last paths settings.
   /// </summary>
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

   /// <summary>
   /// Page layout description file.
   /// </summary>
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
