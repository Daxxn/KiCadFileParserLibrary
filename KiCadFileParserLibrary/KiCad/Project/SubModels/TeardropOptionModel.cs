using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace KiCadFileParserLibrary.KiCad.Project.SubModels
{
   public class TeardropOptionModel
   {
      #region Local Props
      [JsonProperty(PropertyName = "td_onpadsmd")]
      public bool OnPadSmd { get; set; }

      [JsonProperty(PropertyName = "td_onroundshapesonly")]
      public bool OnRoundShapesOnly { get; set; }

      [JsonProperty(PropertyName = "td_ontrackend")]
      public bool OnTrackEnd { get; set; }

      [JsonProperty(PropertyName = "td_onviapad")]
      public bool OnViaPad { get; set; }
      #endregion

      #region Constructors
      public TeardropOptionModel() { }
      #endregion

      #region Methods

      #endregion

      #region Full Props

      #endregion
   }
}
