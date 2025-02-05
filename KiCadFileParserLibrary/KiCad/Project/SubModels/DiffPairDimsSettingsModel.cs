using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MVVMLibrary;

using Newtonsoft.Json;

namespace KiCadFileParserLibrary.KiCad.Project.SubModels
{
   public class DiffPairDimsSettingsModel : Model
   {
      #region Local Props
      private double _gap;
      private double _viaGap;
      private double _width;
      #endregion

      #region Constructors
      public DiffPairDimsSettingsModel() { }
      #endregion

      #region Methods

      #endregion

      #region Full Props
      [JsonProperty(PropertyName = "gap")]
      public double Gap
      {
         get => _gap;
         set
         {
            _gap = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "via_gap")]
      public double ViaGap
      {
         get => _viaGap;
         set
         {
            _viaGap = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "width")]
      public double Width
      {
         get => _width;
         set
         {
            _width = value;
            OnPropertyChanged();
         }
      }
      #endregion
   }
}
