using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MVVMLibrary;

using Newtonsoft.Json;

namespace KiCadFileParserLibrary.KiCad.Project.SubModels
{
   public class TeardropParamModel : Model
   {
      #region Local Props
      private bool _allowUseTwoTracks;
      private int _curveSegCount;
      private double _heightRatio;
      private double _lengthRatio;
      private double _maxHeight;
      private double _maxLength;
      private bool _onPadInZone;
      private string? _targetName;
      private double _filterRatio;
      #endregion

      #region Constructors
      public TeardropParamModel() { }
      #endregion

      #region Methods

      #endregion

      #region Full Props
      [JsonProperty(PropertyName = "td_allow_use_two_tracks")]
      public bool AllowUseTwoTracks
      {
         get => _allowUseTwoTracks;
         set
         {
            _allowUseTwoTracks = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "td_curve_segcount")]
      public int CurveSegCount
      {
         get => _curveSegCount;
         set
         {
            _curveSegCount = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "td_height_ratio")]
      public double HeightRatio
      {
         get => _heightRatio;
         set
         {
            _heightRatio = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "td_length_ratio")]
      public double LengthRatio
      {
         get => _lengthRatio;
         set
         {
            _lengthRatio = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "td_maxheight")]
      public double MaxHeight
      {
         get => _maxHeight;
         set
         {
            _maxHeight = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "td_maxlen")]
      public double MaxLength
      {
         get => _maxLength;
         set
         {
            _maxLength = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "td_on_pad_in_zone")]
      public bool OnPadInZone
      {
         get => _onPadInZone;
         set
         {
            _onPadInZone = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "td_target_name")]
      public string? TargetName
      {
         get => _targetName;
         set
         {
            _targetName = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "td_width_to_size_filter_ratio")]
      public double FilterRatio
      {
         get => _filterRatio;
         set
         {
            _filterRatio = value;
            OnPropertyChanged();
         }
      }
      #endregion
   }
}
