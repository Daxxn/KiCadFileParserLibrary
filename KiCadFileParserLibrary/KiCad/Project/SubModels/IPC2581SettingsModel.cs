using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace KiCadFileParserLibrary.KiCad.Project.SubModels
{
   public class IPC2581SettingsModel
   {
      #region Local Props
      [JsonProperty(PropertyName = "dist")]
      public string? Dist { get; set; }

      [JsonProperty(PropertyName = "distpn")]
      public string? DistPn { get; set; }

      [JsonProperty(PropertyName = "internal_id")]
      public string? InternalID { get; set; }

      [JsonProperty(PropertyName = "mfg")]
      public string? MFG { get; set; }

      [JsonProperty(PropertyName = "mpn")]
      public string? MPN { get; set; }
      #endregion

      #region Constructors
      public IPC2581SettingsModel() { }
      #endregion

      #region Methods

      #endregion

      #region Full Props

      #endregion
   }
}
