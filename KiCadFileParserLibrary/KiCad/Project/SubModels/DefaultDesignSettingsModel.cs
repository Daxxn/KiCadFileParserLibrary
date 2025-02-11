using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MVVMLibrary;

using Newtonsoft.Json;

namespace KiCadFileParserLibrary.KiCad.Project.SubModels;

/// <summary>
/// PCB default settings
/// </summary>
public class DefaultDesignSettingsModel : Model
{
   #region Local Props
   private bool _applyDefaultsToFpFields;
   private bool _applyDefaultsToFpShapes;
   private bool _applyDefaultsToFpText;
   private double _boardOutlineLineWidth;
   private double _copperLineWidth;
   private bool _copperTextItalic;
   private double _copperTextWidth;
   private double _copperTextHeight;
   private double _copperTextThickness;
   private bool _copperTextUpright;
   private double _courtyardLineWidth;
   private int _dimensionPrecision;
   private UnitsType _dimensionUnits;
   private DimensionSettingsModel? _dimensionSettings;
   private double _fabLineWidth;
   private bool _fabTextItalic;
   private double _fabTextWidth;
   private double _fabTextHeight;
   private double _fabTextThickness;
   private bool _fabTextUpright;
   private double _otherLineWidth;
   private bool _otherTextItalic;
   private double _otherTextWidth;
   private double _otherTextHeight;
   private double _otherTextThickness;
   private bool _otherTextUpright;
   private PadSettingsModel? _pads;
   private double _silkLineWidth;
   private bool _silkTextItalic;
   private double _silkTextWidth;
   private double _silkTextHeight;
   private double _silkTextThickness;
   private bool _silkTextUpright;
   private ZoneSettingsModel? _zoneSettings;

   #endregion

   #region Constructors
   /// <inheritdoc/>
   public DefaultDesignSettingsModel() { }
   #endregion

   #region Methods

   #endregion

   #region Full Props
   /// <summary>
   /// 
   /// </summary>
   [JsonProperty(PropertyName = "apply_defaults_to_fp_fields")]
   public bool ApplyDefaultsToFpFields
   {
      get => _applyDefaultsToFpFields;
      set
      {
         _applyDefaultsToFpFields = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// 
   /// </summary>
   [JsonProperty(PropertyName = "apply_defaults_to_fp_shapes")]
   public bool ApplyDefaultsToFpShapes
   {
      get => _applyDefaultsToFpShapes;
      set
      {
         _applyDefaultsToFpShapes = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// 
   /// </summary>
   [JsonProperty(PropertyName = "apply_defaults_to_fp_text")]
   public bool ApplyDefaultsToFpText
   {
      get => _applyDefaultsToFpText;
      set
      {
         _applyDefaultsToFpText = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// 
   /// </summary>
   [JsonProperty(PropertyName = "board_outline_line_width")]
   public double BoardOutlineLineWidth
   {
      get => _boardOutlineLineWidth;
      set
      {
         _boardOutlineLineWidth = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// 
   /// </summary>
   [JsonProperty(PropertyName = "copper_line_width")]
   public double CopperLineWidth
   {
      get => _copperLineWidth;
      set
      {
         _copperLineWidth = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// 
   /// </summary>
   [JsonProperty(PropertyName = "copper_text_italic")]
   public bool CopperTextItalic
   {
      get => _copperTextItalic;
      set
      {
         _copperTextItalic = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// 
   /// </summary>
   [JsonProperty(PropertyName = "copper_text_size_h")]
   public double CopperTextWidth
   {
      get => _copperTextWidth;
      set
      {
         _copperTextWidth = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// 
   /// </summary>
   [JsonProperty(PropertyName = "copper_text_size_v")]
   public double CopperTextHeight
   {
      get => _copperTextHeight;
      set
      {
         _copperTextHeight = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// 
   /// </summary>
   [JsonProperty(PropertyName = "copper_text_thickness")]
   public double CopperTextThickness
   {
      get => _copperTextThickness;
      set
      {
         _copperTextThickness = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// 
   /// </summary>
   [JsonProperty(PropertyName = "copper_text_upright")]
   public bool CopperTextUpright
   {
      get => _copperTextUpright;
      set
      {
         _copperTextUpright = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// 
   /// </summary>
   [JsonProperty(PropertyName = "courtyard_line_width")]
   public double CourtyardLineWidth
   {
      get => _courtyardLineWidth;
      set
      {
         _courtyardLineWidth = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// 
   /// </summary>
   [JsonProperty(PropertyName = "dimension_precision")]
   public int DimensionPrecision
   {
      get => _dimensionPrecision;
      set
      {
         _dimensionPrecision = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// 
   /// </summary>
   [JsonProperty(PropertyName = "dimension_units")]
   public UnitsType DimensionUnits
   {
      get => _dimensionUnits;
      set
      {
         _dimensionUnits = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// 
   /// </summary>
   [JsonProperty(PropertyName = "dimensions")]
   public DimensionSettingsModel? DimensionSettings
   {
      get => _dimensionSettings;
      set
      {
         _dimensionSettings = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// 
   /// </summary>
   [JsonProperty(PropertyName = "fab_line_width")]
   public double FabLineWidth
   {
      get => _fabLineWidth;
      set
      {
         _fabLineWidth = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// 
   /// </summary>
   [JsonProperty(PropertyName = "fab_text_italic")]
   public bool FabTextItalic
   {
      get => _fabTextItalic;
      set
      {
         _fabTextItalic = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// 
   /// </summary>
   [JsonProperty(PropertyName = "fab_text_size_h")]
   public double FabTextWidth
   {
      get => _fabTextWidth;
      set
      {
         _fabTextWidth = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// 
   /// </summary>
   [JsonProperty(PropertyName = "fab_text_size_v")]
   public double FabTextHeight
   {
      get => _fabTextHeight;
      set
      {
         _fabTextHeight = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// 
   /// </summary>
   [JsonProperty(PropertyName = "fab_text_thickness")]
   public double FabTextThickness
   {
      get => _fabTextThickness;
      set
      {
         _fabTextThickness = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// 
   /// </summary>
   [JsonProperty(PropertyName = "fab_text_upright")]
   public bool FabTextUpright
   {
      get => _fabTextUpright;
      set
      {
         _fabTextUpright = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// 
   /// </summary>
   [JsonProperty(PropertyName = "other_line_width")]
   public double OtherLineWidth
   {
      get => _otherLineWidth;
      set
      {
         _otherLineWidth = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// 
   /// </summary>
   [JsonProperty(PropertyName = "other_text_italic")]
   public bool OtherTextItalic
   {
      get => _otherTextItalic;
      set
      {
         _otherTextItalic = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// 
   /// </summary>
   [JsonProperty(PropertyName = "other_text_size_h")]
   public double OtherTextWidth
   {
      get => _otherTextWidth;
      set
      {
         _otherTextWidth = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// 
   /// </summary>
   [JsonProperty(PropertyName = "other_text_size_v")]
   public double OtherTextHeight
   {
      get => _otherTextHeight;
      set
      {
         _otherTextHeight = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// 
   /// </summary>
   [JsonProperty(PropertyName = "other_text_thickness")]
   public double OtherTextThickness
   {
      get => _otherTextThickness;
      set
      {
         _otherTextThickness = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// 
   /// </summary>
   [JsonProperty(PropertyName = "other_text_upright")]
   public bool OtherTextUpright
   {
      get => _otherTextUpright;
      set
      {
         _otherTextUpright = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// 
   /// </summary>
   [JsonProperty(PropertyName = "pads")]
   public PadSettingsModel? Pads
   {
      get => _pads;
      set
      {
         _pads = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// 
   /// </summary>
   [JsonProperty(PropertyName = "silk_line_width")]
   public double SilkLineWidth
   {
      get => _silkLineWidth;
      set
      {
         _silkLineWidth = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// 
   /// </summary>
   [JsonProperty(PropertyName = "silk_text_italic")]
   public bool SilkTextItalic
   {
      get => _silkTextItalic;
      set
      {
         _silkTextItalic = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// 
   /// </summary>
   [JsonProperty(PropertyName = "silk_text_size_h")]
   public double SilkTextWidth
   {
      get => _silkTextWidth;
      set
      {
         _silkTextWidth = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// 
   /// </summary>
   [JsonProperty(PropertyName = "silk_text_size_v")]
   public double SilkTextHeight
   {
      get => _silkTextHeight;
      set
      {
         _silkTextHeight = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// 
   /// </summary>
   [JsonProperty(PropertyName = "silk_text_thickness")]
   public double SilkTextThickness
   {
      get => _silkTextThickness;
      set
      {
         _silkTextThickness = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// 
   /// </summary>
   [JsonProperty(PropertyName = "silk_text_upright")]
   public bool SilkTextUpright
   {
      get => _silkTextUpright;
      set
      {
         _silkTextUpright = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// 
   /// </summary>
   [JsonProperty(PropertyName = "zones")]
   public ZoneSettingsModel? ZoneSettings
   {
      get => _zoneSettings;
      set
      {
         _zoneSettings = value;
         OnPropertyChanged();
      }
   }
   #endregion
}
