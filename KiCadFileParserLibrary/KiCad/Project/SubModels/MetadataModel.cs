using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace KiCadFileParserLibrary.KiCad.Project.SubModels
{
   public class MetadataModel
   {
      #region Local Props
      [JsonProperty(PropertyName = "filename", NullValueHandling = NullValueHandling.Ignore)]
      public string? FileName { get; set; }

      [JsonProperty(PropertyName = "version")]
      public int Version { get; set; }
      #endregion

      #region Constructors
      public MetadataModel() { }
      #endregion

      #region Methods

      #endregion

      #region Full Props

      #endregion
   }
}
