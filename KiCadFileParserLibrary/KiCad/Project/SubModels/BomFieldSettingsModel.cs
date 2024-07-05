using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace KiCadFileParserLibrary.KiCad.Project.SubModels
{
   public class BomFieldSettingsModel
   {
      #region Local Props
      [JsonProperty(PropertyName = "group_by")]
      public bool GroupBy { get; set; }

      [JsonProperty(PropertyName = "label")]
      public string? Label { get; set; }

      [JsonProperty(PropertyName = "name")]
      public string? Name { get; set; }

      [JsonProperty(PropertyName = "show")]
      public bool Show { get; set; }
      #endregion

      #region Constructors
      public BomFieldSettingsModel() { }
      #endregion

      #region Methods

      #endregion

      #region Full Props

      #endregion
   }
}
