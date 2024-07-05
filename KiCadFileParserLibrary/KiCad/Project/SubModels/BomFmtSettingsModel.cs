using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace KiCadFileParserLibrary.KiCad.Project.SubModels
{
   public class BomFmtSettingsModel
   {
      #region Local Props
      [JsonProperty(PropertyName = "field_delimiter")]
      public string? FieldDelimiter { get; set; }

      [JsonProperty(PropertyName = "keep_line_breaks")]
      public bool KeepLineBreaks { get; set; }

      [JsonProperty(PropertyName = "keep_tabs")]
      public bool KeepTabs { get; set; }

      [JsonProperty(PropertyName = "name")]
      public string? Name { get; set; }

      [JsonProperty(PropertyName = "ref_delimiter")]
      public string? RefDelimiter { get; set; }

      [JsonProperty(PropertyName = "ref_range_delimiter")]
      public string? RefRangeDelimiter { get; set; }

      [JsonProperty(PropertyName = "string_delimiter")]
      public string? StringDelimiter { get; set; }
      #endregion

      #region Constructors
      public BomFmtSettingsModel() { }
      #endregion

      #region Methods

      #endregion

      #region Full Props

      #endregion
   }
}
