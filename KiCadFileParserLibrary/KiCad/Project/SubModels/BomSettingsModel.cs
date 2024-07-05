using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace KiCadFileParserLibrary.KiCad.Project.SubModels
{
   public class BomSettingsModel
   {
      #region Local Props
      [JsonProperty(PropertyName = "exclude_dnp")]
      public bool ExcludeDNP { get; set; }

      [JsonProperty(PropertyName = "fields_ordered")]
      public List<BomFieldSettingsModel>? FieldSettings { get; set; }

      [JsonProperty(PropertyName = "filter_string")]
      public string? FilterString { get; set; }

      [JsonProperty(PropertyName = "group_symbols")]
      public bool GroupSymbols { get; set; }

      [JsonProperty(PropertyName = "name")]
      public string? Name { get; set; }

      [JsonProperty(PropertyName = "sort_asc")]
      public bool SortAscending { get; set; }

      [JsonProperty(PropertyName = "sort_field")]
      public string? SortField { get; set; }
      #endregion

      #region Constructors
      public BomSettingsModel() { }
      #endregion

      #region Methods

      #endregion

      #region Full Props

      #endregion
   }
}
