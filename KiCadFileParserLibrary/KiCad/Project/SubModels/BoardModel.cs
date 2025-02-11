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

/// <summary>
/// KiCad Project PCB settings
/// </summary>
public class BoardModel : Model
{
   #region Local Props
   private ObservableCollection<Viewport3DModel>? _viewPorts3D;
   private DesignSettingsModel? _designSettings;
   private IPC2581SettingsModel? _ipcSettings;
   private ObservableCollection<LayerPresetModel>? _layerPresets;
   private ObservableCollection<ViewportModel>? _viewPorts;
   #endregion

   #region Constructors
   /// <inheritdoc/>
   public BoardModel() { }
   #endregion

   #region Methods
   /// <inheritdoc/>
   public override string ToString() => $"Board Settings";
   #endregion

   #region Full Props
   /// <summary>
   /// Saved 3D viewports
   /// </summary>
   [JsonProperty(PropertyName = "3dviewports")]
   public ObservableCollection<Viewport3DModel>? ViewPorts3D
   {
      get => _viewPorts3D;
      set
      {
         _viewPorts3D = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// PCB design settings.
   /// </summary>
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
   public ObservableCollection<LayerPresetModel>? LayerPresets
   {
      get => _layerPresets;
      set
      {
         _layerPresets = value;
         OnPropertyChanged();
      }
   }

   [JsonProperty(PropertyName = "viewports")]
   public ObservableCollection<ViewportModel>? ViewPorts
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
