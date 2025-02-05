using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MVVMLibrary;

using Newtonsoft.Json;

namespace KiCadFileParserLibrary.KiCad.Project.SubModels
{
   public class TuningPatternSettingsModel : Model
   {
      #region Local Props
      [JsonProperty(PropertyName = "corner_radius_percentage")]
      public int CornerRadiusPerc
      {
         get => _cornerRadiusPerc;
         set
         {
            _cornerRadiusPerc = value;
            OnPropertyChanged();
         }
      }
      private int _cornerRadiusPerc;

      [JsonProperty(PropertyName = "corner_style")]
      public int CornerStyle // Should be an enum...
      {
         get => _cornerStyle;
         set
         {
            _cornerStyle = value;
            OnPropertyChanged();
         }
      }
      private int _cornerStyle;

      [JsonProperty(PropertyName = "max_amplitude")]
      public double MaxAmplitude
      {
         get => _maxAmplitude;
         set
         {
            _maxAmplitude = value;
            OnPropertyChanged();
         }
      }
      private double _maxAmplitude;

      [JsonProperty(PropertyName = "min_amplitude")]
      public double MinAmplitude
      {
         get => _minAmplitude;
         set
         {
            _minAmplitude = value;
            OnPropertyChanged();
         }
      }
      private double _minAmplitude;

      [JsonProperty(PropertyName = "single_sided")]
      public bool SingleSided
      {
         get => _singleSided;
         set
         {
            _singleSided = value;
            OnPropertyChanged();
         }
      }
      private bool _singleSided;

      [JsonProperty(PropertyName = "spacing")]
      public double Spacing
      {
         get => _spacing;
         set
         {
            _spacing = value;
            OnPropertyChanged();
         }
      }
      private double _spacing;
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
