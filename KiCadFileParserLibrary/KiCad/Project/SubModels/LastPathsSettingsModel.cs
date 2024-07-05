using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace KiCadFileParserLibrary.KiCad.Project.SubModels
{
   public class LastPathsSettingsModel
   {
      #region Local Props
      [JsonProperty(PropertyName = "gencad")]
      public string? GenCad { get; set; }

      [JsonProperty(PropertyName = "idf")]
      public string? IDF { get; set; }

      [JsonProperty(PropertyName = "netlist")]
      public string? NetList { get; set; }

      [JsonProperty(PropertyName = "plot")]
      public string? Plot { get; set; }

      [JsonProperty(PropertyName = "pos_files")]
      public string? PositionFiles { get; set; }

      [JsonProperty(PropertyName = "specctra_dsn")]
      public string? SpectraDSN { get; set; }

      [JsonProperty(PropertyName = "step")]
      public string? Step { get; set; }

      [JsonProperty(PropertyName = "svg")]
      public string? SVG { get; set; }

      [JsonProperty(PropertyName = "vrml")]
      public string? VRML { get; set; }
      #endregion

      #region Constructors
      public LastPathsSettingsModel() { }
      #endregion

      #region Methods

      #endregion

      #region Full Props

      #endregion
   }
}
