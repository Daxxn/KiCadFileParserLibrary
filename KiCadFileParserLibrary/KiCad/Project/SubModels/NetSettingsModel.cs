using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace KiCadFileParserLibrary.KiCad.Project.SubModels
{
   public class NetSettingsModel
   {
      #region Local Props
      [JsonProperty(PropertyName = "classes")]
      public List<NetClassSettingsModel>? NetClasses { get; set; }

      [JsonProperty(PropertyName = "meta")]
      public MetadataModel? Metadata { get; set; }

      [JsonProperty(PropertyName = "net_colors")]
      public string? NetColors { get; set; }

      [JsonProperty(PropertyName = "netclass_assignments")]
      public Dictionary<string, string>? NetClassAssignments { get; set; }

      [JsonProperty(PropertyName = "netclass_patterns")]
      public List<string>? NetClassPatterns { get; set; }
      #endregion

      #region Constructors
      public NetSettingsModel() { }
      #endregion

      #region Methods

      #endregion

      #region Full Props

      #endregion
   }
}
