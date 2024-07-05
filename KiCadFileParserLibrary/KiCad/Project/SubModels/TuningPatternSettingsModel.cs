using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace KiCadFileParserLibrary.KiCad.Project.SubModels
{
   public class TuningPatternSettingsModel
   {
      #region Local Props
      [JsonProperty(PropertyName = "corner_radius_percentage")]
      public int CornerRadiusPerc { get; set; }

      [JsonProperty(PropertyName = "corner_style")]
      public int CornerStyle { get; set; } // Should be an enum...

      [JsonProperty(PropertyName = "max_amplitude")]
      public double MaxAmplitude { get; set; }

      [JsonProperty(PropertyName = "min_amplitude")]
      public double MinAmplitude { get; set; }

      [JsonProperty(PropertyName = "single_sided")]
      public bool SingleSided { get; set; }

      [JsonProperty(PropertyName = "spacing")]
      public double Spacing { get; set; }
      #endregion

      #region Constructors
      public TuningPatternSettingsModel() { }
      #endregion

      #region Methods

      #endregion

      #region Full Props

      #endregion
   }
}
