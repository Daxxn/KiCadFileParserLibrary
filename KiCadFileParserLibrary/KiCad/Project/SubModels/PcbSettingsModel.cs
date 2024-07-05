using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace KiCadFileParserLibrary.KiCad.Project.SubModels
{
   public class PcbSettingsModel
   {
      #region Local Props
      [JsonProperty(PropertyName = "last_paths")]
      public LastPathsSettingsModel? LastPaths { get; set; }

      [JsonProperty(PropertyName = "page_layout_descr_file")]
      public string? PageLayoutDescFile { get; set; }
      #endregion

      #region Constructors
      public PcbSettingsModel() { }
      #endregion

      #region Methods

      #endregion

      #region Full Props

      #endregion
   }
}
