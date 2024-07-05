using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace KiCadFileParserLibrary.KiCad.Project.SubModels
{
   public class LibrariesModel
   {
      #region Local Props
      [JsonProperty(PropertyName = "pinned_footprint_libs")]
      public List<string>? PinnedFootprintLibs { get; set; }

      [JsonProperty(PropertyName = "pinned_symbol_libs")]
      public List<string>? PinnedSymbolLibs { get; set; }
      #endregion

      #region Constructors
      public LibrariesModel() { }
      #endregion

      #region Methods

      #endregion

      #region Full Props

      #endregion
   }
}
