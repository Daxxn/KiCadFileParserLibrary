using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace KiCadFileParserLibrary.KiCad.Project.SubModels
{
   public class ViaParamModel
   {
      #region Local Props
      [JsonProperty(PropertyName = "diameter")]
      public double Diameter { get; set; }

      [JsonProperty(PropertyName = "drill")]
      public double Drill { get; set; }
      #endregion

      #region Constructors
      public ViaParamModel() { }
      #endregion

      #region Methods

      #endregion

      #region Full Props

      #endregion
   }
}
