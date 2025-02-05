using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MVVMLibrary;

using Newtonsoft.Json;

namespace KiCadFileParserLibrary.KiCad.Project.SubModels
{
   public class DrawingSettingsModel : Model
   {
      #region Local Props
      private double _dashedLinesDashLenRatio;
      private double _dashedLinesGapLenRatio;
      private double _defaultLineThickness;
      private double _defaultTextSize;
      private ObservableCollection<string>? _fieldNames;
      private bool _intersheetsRefOwnPage;
      private string? _intersheetsRefPrefix;
      private bool _intersheetsRefShort;
      private bool _intersheetsRefShow;
      private string? _intersheetsRefSuffix;
      private int _junctionSizeChoice;
      private double _labelSizeRatio;
      private int _operatingPointOverlayIPrecision;
      private string? _operatingPointOverlayIRange;
      private int _operatingPointOverlayVPrecision;
      private string? _operatingPointOverlayVRange;
      private double _overbarOffsetRatio;
      private double _pinSymbolSize;
      private double _textOffsetRatio;

      #endregion

      #region Constructors
      public DrawingSettingsModel() { }
      #endregion

      #region Methods

      #endregion

      #region Full Props
      [JsonProperty(PropertyName = "dashed_lines_dash_length_ratio")]
      public double DashedLinesDashLenRatio
      {
         get => _dashedLinesDashLenRatio;
         set
         {
            _dashedLinesDashLenRatio = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "dashed_lines_gap_length_ratio")]
      public double DashedLinesGapLenRatio
      {
         get => _dashedLinesGapLenRatio;
         set
         {
            _dashedLinesGapLenRatio = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "default_line_thickness")]
      public double DefaultLineThickness
      {
         get => _defaultLineThickness;
         set
         {
            _defaultLineThickness = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "default_text_size")]
      public double DefaultTextSize
      {
         get => _defaultTextSize;
         set
         {
            _defaultTextSize = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "field_names")]
      public ObservableCollection<string>? FieldNames
      {
         get => _fieldNames;
         set
         {
            _fieldNames = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "intersheets_ref_own_page")]
      public bool IntersheetsRefOwnPage
      {
         get => _intersheetsRefOwnPage;
         set
         {
            _intersheetsRefOwnPage = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "intersheets_ref_prefix")]
      public string? IntersheetsRefPrefix
      {
         get => _intersheetsRefPrefix;
         set
         {
            _intersheetsRefPrefix = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "intersheets_ref_short")]
      public bool IntersheetsRefShort
      {
         get => _intersheetsRefShort;
         set
         {
            _intersheetsRefShort = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "intersheets_ref_show")]
      public bool IntersheetsRefShow
      {
         get => _intersheetsRefShow;
         set
         {
            _intersheetsRefShow = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "intersheets_ref_suffix")]
      public string? IntersheetsRefSuffix
      {
         get => _intersheetsRefSuffix;
         set
         {
            _intersheetsRefSuffix = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "junction_size_choice")]
      public int JunctionSizeChoice // Also probably an enum...
      {
         get => _junctionSizeChoice;
         set
         {
            _junctionSizeChoice = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "label_size_ratio")]
      public double LabelSizeRatio
      {
         get => _labelSizeRatio;
         set
         {
            _labelSizeRatio = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "operating_point_overlay_i_precision")]
      public int OperatingPointOverlayIPrecision
      {
         get => _operatingPointOverlayIPrecision;
         set
         {
            _operatingPointOverlayIPrecision = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "operating_point_overlay_i_range")]
      public string? OeratingPointOverlayIRange
      {
         get => _operatingPointOverlayIRange;
         set
         {
            _operatingPointOverlayIRange = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "operating_point_overlay_v_precision")]
      public int OeratingPointOverlayVPrecision
      {
         get => _operatingPointOverlayVPrecision;
         set
         {
            _operatingPointOverlayVPrecision = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "operating_point_overlay_v_range")]
      public string? OeratingPointOverlayVRange
      {
         get => _operatingPointOverlayVRange;
         set
         {
            _operatingPointOverlayVRange = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "overbar_offset_ratio")]
      public double OverbarOffsetRatio
      {
         get => _overbarOffsetRatio;
         set
         {
            _overbarOffsetRatio = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "pin_symbol_size")]
      public double PinSymbolSize
      {
         get => _pinSymbolSize;
         set
         {
            _pinSymbolSize = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "text_offset_ratio")]
      public double TextOffsetRatio
      {
         get => _textOffsetRatio;
         set
         {
            _textOffsetRatio = value;
            OnPropertyChanged();
         }
      }
      #endregion
   }
}
