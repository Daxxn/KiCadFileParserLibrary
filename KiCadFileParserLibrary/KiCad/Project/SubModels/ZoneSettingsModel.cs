using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MVVMLibrary;

using Newtonsoft.Json;

namespace KiCadFileParserLibrary.KiCad.Project.SubModels
{
   public class ZoneSettingsModel : Model
   {
      #region Local Props
      private double _minClearance;
      #endregion

      #region Constructors
      public ZoneSettingsModel() { }
      #endregion

      #region Methods

      #endregion

      #region Full Props
      [JsonProperty(PropertyName = "min_clearance")]
      public double MinClearance
      {
         get => _minClearance;
         set
         {
            _minClearance = value;
            OnPropertyChanged();
         }
      }
      #endregion
   }
}
