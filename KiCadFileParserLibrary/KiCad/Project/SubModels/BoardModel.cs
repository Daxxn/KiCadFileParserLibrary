using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

using MVVMLibrary;

using Newtonsoft.Json;

namespace KiCadFileParserLibrary.KiCad.Project.SubModels;

public class BoardModel : Model
{
   #region Local Props
   private ObservableCollection<string>? _viewPorts3D;
   private DesignSettingsModel? _designSettings;
   private IPC2581SettingsModel? _ipcSettings;
   private ObservableCollection<string>? _layerPresets;
   private ObservableCollection<string>? _viewPorts;
   #endregion

   #region Constructors
   public BoardModel() { }
   #endregion

   #region Methods

   #endregion

   #region Full Props
   [JsonProperty(PropertyName = "3dviewports")]
   public ObservableCollection<string>? ViewPorts3D
   {
      get => _viewPorts3D;
      set
      {
         _viewPorts3D = value;
         OnPropertyChanged();
      }
   }

   [JsonProperty(PropertyName = "design_settings")]
   public DesignSettingsModel? DesignSettings
   {
      get => _designSettings;
      set
      {
         _designSettings = value;
         OnPropertyChanged();
      }
   }

   [JsonProperty(PropertyName = "ipc2581")]
   public IPC2581SettingsModel? IPCSettings
   {
      get => _ipcSettings;
      set
      {
         _ipcSettings = value;
         OnPropertyChanged();
      }
   }

   [JsonProperty(PropertyName = "layer_presets")]
   public ObservableCollection<string>? LayerPresets
   {
      get => _layerPresets;
      set
      {
         _layerPresets = value;
         OnPropertyChanged();
      }
   }

   [JsonProperty(PropertyName = "viewports")]
   public ObservableCollection<string>? ViewPorts
   {
      get => _viewPorts;
      set
      {
         _viewPorts = value;
         OnPropertyChanged();
      }
   }
   #endregion
}
