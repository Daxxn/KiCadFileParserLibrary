using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace KiCadFileParserLibrary.KiCad.Project.SubModels
{
   public class BoardModel
   {
      #region Local Props
      [JsonProperty(PropertyName = "3dviewports")]
      public List<string>? ViewPorts3D { get; set; }

      [JsonProperty(PropertyName = "design_settings")]
      public DesignSettingsModel? DesignSettings { get; set; }

      [JsonProperty(PropertyName = "ipc2581")]
      public IPC2581SettingsModel? IPCSettings { get; set; }

      [JsonProperty(PropertyName = "layer_presets")]
      public List<string>? LayerPresets { get; set; }

      [JsonProperty(PropertyName = "viewports")]
      public List<string>? ViewPorts { get; set; }
      #endregion

      #region Constructors
      public BoardModel() { }
      #endregion

      #region Methods

      #endregion

      #region Full Props

      #endregion
   }
}
