using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MVVMLibrary;

using Newtonsoft.Json;

namespace KiCadFileParserLibrary.KiCad.Settings.Common.SubModels;

/// <summary>
/// Common show prompt settings
/// </summary>
public class ShowPromptsModel : Model
{
   #region Local Props
   private bool _dataCollectionPrompt;
   private bool _envVarOverwriteWarning;
   private bool _scaled3dModelsWarning;
   private bool _updateCheckPrompt;
   private bool _zoneFillWarning;
   #endregion

   #region Constructors
   /// <inheritdoc/>
   public ShowPromptsModel() { }
   #endregion

   #region Methods

   #endregion

   #region Full Props
   /// <summary>
   /// Dont show data collection prompt
   /// </summary>
   [JsonProperty("data_collection_prompt")]
   public bool DataCollectionPrompt
   {
      get => _dataCollectionPrompt;
      set
      {
         _dataCollectionPrompt = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Dont show environment overwrite warning
   /// </summary>
   [JsonProperty("env_var_overwrite_warning")]
   public bool EnvVarOverwriteWarning
   {
      get => _envVarOverwriteWarning;
      set
      {
         _envVarOverwriteWarning = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Dont show scaled 3D models warning
   /// </summary>
   [JsonProperty("scaled_3d_models_warning")]
   public bool Scaled3dModelsWarning
   {
      get => _scaled3dModelsWarning;
      set
      {
         _scaled3dModelsWarning = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Dont show Update check prompt
   /// </summary>
   [JsonProperty("update_check_prompt")]
   public bool UpdateCheckPrompt
   {
      get => _updateCheckPrompt;
      set
      {
         _updateCheckPrompt = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Dont show Zone fill prompt
   /// </summary>
   [JsonProperty("zone_fill_warning")]
   public bool ZoneFillWarning
   {
      get => _zoneFillWarning;
      set
      {
         _zoneFillWarning = value;
         OnPropertyChanged();
      }
   }
   #endregion
}
