using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace KiCadFileParserLibrary.KiCad.Project.SubModels
{
   public class DiffPairDimsSettingsModel
   {
      #region Local Props
      [JsonProperty(PropertyName = "gap")]
      public double Gap { get; set; }

      [JsonProperty(PropertyName = "via_gap")]
      public double ViaGap { get; set; }

      [JsonProperty(PropertyName = "width")]
      public double Width { get; set; }
      #endregion

      #region Constructors
      public DiffPairDimsSettingsModel() { }
      #endregion

      #region Methods

      #endregion

      #region Full Props

      #endregion
   }
}
