using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MVVMLibrary;

using Newtonsoft.Json;

namespace KiCadFileParserLibrary.KiCad.Project.SubModels;

/// <summary>
/// Tuning pattern settings model
/// </summary>
public class TuningPatternSettingsModel : Model
{
   #region Local Props
   private int _cornerRadiusPerc;
   private int _cornerStyle;
   private double _maxAmplitude;
   private double _minAmplitude;
   private bool _singleSided;
   private double _spacing;
   #endregion

   #region Constructors
   /// <inheritdoc/>
   public TuningPatternSettingsModel() { }
   #endregion

   #region Methods

   #endregion

   #region Full Props
   /// <summary>
   /// Corner radius percentage
   /// </summary>
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

   /// <summary>
   /// Corner style
   /// </summary>
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

   /// <summary>
   /// Maximum amplitude
   /// </summary>
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

   /// <summary>
   /// Minimum amplitude
   /// </summary>
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

   /// <summary>
   /// Single sided
   /// </summary>
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

   /// <summary>
   /// Spacing
   /// </summary>
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
   #endregion
}
