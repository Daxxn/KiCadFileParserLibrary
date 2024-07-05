using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace KiCadFileParserLibrary.KiCad.Project.SubModels
{
   public class ZoneSettingsModel
   {
      #region Local Props
      [JsonProperty(PropertyName = "min_clearance")]
      public double MinClearance { get; set; }
      #endregion

      #region Constructors
      public ZoneSettingsModel() { }
      #endregion

      #region Methods

      #endregion

      #region Full Props

      #endregion
   }
}
