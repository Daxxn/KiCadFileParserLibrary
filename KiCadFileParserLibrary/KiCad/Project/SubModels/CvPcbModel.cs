using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace KiCadFileParserLibrary.KiCad.Project.SubModels
{
   public class CvPcbModel
   {
      #region Local Props
      [JsonProperty(PropertyName = "equivalence_files")]
      public List<string>? EquivalenceFiles { get; set; }
      #endregion

      #region Constructors
      public CvPcbModel() { }
      #endregion

      #region Methods

      #endregion

      #region Full Props

      #endregion
   }
}
