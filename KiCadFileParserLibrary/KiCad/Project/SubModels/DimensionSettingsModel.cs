using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace KiCadFileParserLibrary.KiCad.Project.SubModels
{
   public class DimensionSettingsModel
   {
      #region Local Props
      [JsonProperty(PropertyName = "arrow_length")]
      public int ArrowLength { get; set; }

      [JsonProperty(PropertyName = "extension_offset")]
      public int ExtensionOffset { get; set; }

      [JsonProperty(PropertyName = "keep_text_aligned")]
      public bool KeepTextAligned { get; set; }

      [JsonProperty(PropertyName = "suppress_zeroes")]
      public bool SuppressZeroes { get; set; }

      [JsonProperty(PropertyName = "text_position")]
      public int TextPosition { get; set; } // I think this is an enum. Need to check the dimension object.

      [JsonProperty(PropertyName = "units_format")]
      public UnitsType UnitFormat { get; set; }
      #endregion

      #region Constructors
      public DimensionSettingsModel() { }
      #endregion

      #region Methods

      #endregion

      #region Full Props

      #endregion
   }
}
