using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MVVMLibrary;

using Newtonsoft.Json;

namespace KiCadFileParserLibrary.KiCad.Project.SubModels
{
   public class PadSettingsModel : Model
   {
      #region Local Props
      private double _drill;
      private double _height;
      private double _width;
      #endregion

      #region Constructors
      public PadSettingsModel() { }
      #endregion

      #region Methods

      #endregion

      #region Full Props
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

      [JsonProperty(PropertyName = "height")]
      public double Height
      {
         get => _height;
         set
         {
            _height = value;
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
