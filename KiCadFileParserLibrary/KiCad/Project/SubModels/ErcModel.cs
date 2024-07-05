using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace KiCadFileParserLibrary.KiCad.Project.SubModels
{
   public class ErcModel
   {
      #region Local Props
      [JsonProperty(PropertyName = "erc_exclusions")]
      public List<string>? Exclusions { get; set; }

      [JsonProperty(PropertyName = "meta")]
      public MetadataModel? Metadata { get; set; }

      [JsonProperty(PropertyName = "pin_map")]
      public List<List<int>>? PinMap { get; set; }

      [JsonProperty(PropertyName = "rule_severities")]
      public SchRuleSeverityModel? RuleSeverities { get; set; }
      #endregion

      #region Constructors
      public ErcModel() { }
      #endregion

      #region Methods

      #endregion

      #region Full Props

      #endregion
   }
}
