using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MVVMLibrary;

using Newtonsoft.Json;

namespace KiCadFileParserLibrary.KiCad.Project.SubModels
{
   public class ViaParamModel : Model
   {
      #region Local Props
      private double _diam;
      private double _drill;
      #endregion

      #region Constructors
      public ViaParamModel() { }
      #endregion

      #region Methods

      #endregion

      #region Full Props
      [JsonProperty(PropertyName = "diameter")]
      public double Diameter
      {
         get => _diam;
         set
         {
            _diam = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "drill")]
      public double Drill
      {
         get => _drill;
         set
         {
            _drill = value;
            OnPropertyChanged();
         }
      }
      #endregion
   }
}
