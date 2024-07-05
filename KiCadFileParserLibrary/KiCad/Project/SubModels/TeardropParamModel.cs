using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace KiCadFileParserLibrary.KiCad.Project.SubModels
{
   public class TeardropParamModel
   {
      #region Local Props
      [JsonProperty(PropertyName = "td_allow_use_two_tracks")]
      public bool AllowUseTwoTracks { get; set; }

      [JsonProperty(PropertyName = "td_curve_segcount")]
      public int CurveSegCount { get; set; }

      [JsonProperty(PropertyName = "td_height_ratio")]
      public double HeightRatio { get; set; }

      [JsonProperty(PropertyName = "td_length_ratio")]
      public double LengthRatio { get; set; }

      [JsonProperty(PropertyName = "td_maxheight")]
      public double MaxHeight { get; set; }

      [JsonProperty(PropertyName = "td_maxlen")]
      public double MaxLength { get; set; }

      [JsonProperty(PropertyName = "td_on_pad_in_zone")]
      public bool OnPadInZone { get; set; }

      [JsonProperty(PropertyName = "td_target_name")]
      public string? TargetName { get; set; }

      [JsonProperty(PropertyName = "td_width_to_size_filter_ratio")]
      public double FilterRatio { get; set; }
      #endregion

      #region Constructors
      public TeardropParamModel() { }
      #endregion

      #region Methods

      #endregion

      #region Full Props

      #endregion
   }
}
