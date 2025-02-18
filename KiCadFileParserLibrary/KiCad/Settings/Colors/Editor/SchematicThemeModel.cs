using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Utils.JsonConverters;

using MVVMLibrary;

using Newtonsoft.Json;

namespace KiCadFileParserLibrary.KiCad.Settings.Colors.Editor;

/// <summary>
/// Schematic color theme
/// </summary>
public class SchematicThemeModel : Model
{
   #region Local Props
   private RgbaColorModel _anchor = new();
   private RgbaColorModel _auxItems = new();
   private RgbaColorModel _background = new();
   private RgbaColorModel _brightened = new();
   private RgbaColorModel _bus = new();
   private RgbaColorModel _busJunction = new();
   private RgbaColorModel _compBody = new();
   private RgbaColorModel _compOutline = new();
   private RgbaColorModel _cursor = new();
   private RgbaColorModel _dnpMarker = new();
   private RgbaColorModel _ercError = new();
   private RgbaColorModel _ercExecution = new();
   private RgbaColorModel _ercWarning = new();
   private RgbaColorModel _fields = new();
   private RgbaColorModel _grid = new();
   private RgbaColorModel _gridAxes = new();
   private RgbaColorModel _hidden = new();
   private RgbaColorModel _hovered = new();
   private RgbaColorModel _junction = new();
   private RgbaColorModel _labelGlobal = new();
   private RgbaColorModel _labelHier = new();
   private RgbaColorModel _labelLocal = new();
   private RgbaColorModel _netclassFlag = new();
   private RgbaColorModel _noConnect = new();
   private RgbaColorModel _note = new();
   private RgbaColorModel _noteBackground = new();
   private RgbaColorModel _opCurrents = new();
   private RgbaColorModel _opVoltages = new();
   private RgbaColorModel _pageLimits = new();
   private RgbaColorModel _pin = new();
   private RgbaColorModel _pinName = new();
   private RgbaColorModel _pinNumber = new();
   private RgbaColorModel _privateNote = new();
   private RgbaColorModel _reference = new();
   private RgbaColorModel _shadow = new();
   private RgbaColorModel _sheet = new();
   private RgbaColorModel _sheetBackground = new();
   private RgbaColorModel _sheetFields = new();
   private RgbaColorModel _sheetFilename = new();
   private RgbaColorModel _sheetLabel = new();
   private RgbaColorModel _sheetName = new();
   private RgbaColorModel _value = new();
   private RgbaColorModel _wire = new();
   private RgbaColorModel _worksheet = new();
   private bool _overrideItemColors;
   #endregion

   #region Constructors
   /// <inheritdoc/>
   public SchematicThemeModel() { }
   #endregion

   #region Methods

   #endregion

   #region Full Props
   /// <summary>
   /// </summary>
   [JsonProperty("anchor")]
   [JsonConverter(typeof(RgbaColorJsonConverter))]
   public RgbaColorModel Anchor
   {
      get => _anchor;
      set
      {
         _anchor = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// </summary>
   [JsonProperty("aux_items")]
   [JsonConverter(typeof(RgbaColorJsonConverter))]
   public RgbaColorModel AuxItems
   {
      get => _auxItems;
      set
      {
         _auxItems = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// </summary>
   [JsonProperty("background")]
   [JsonConverter(typeof(RgbaColorJsonConverter))]
   public RgbaColorModel Background
   {
      get => _background;
      set
      {
         _background = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// </summary>
   [JsonProperty("brightened")]
   [JsonConverter(typeof(RgbaColorJsonConverter))]
   public RgbaColorModel Brightened
   {
      get => _brightened;
      set
      {
         _brightened = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// </summary>
   [JsonProperty("bus")]
   [JsonConverter(typeof(RgbaColorJsonConverter))]
   public RgbaColorModel Bus
   {
      get => _bus;
      set
      {
         _bus = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// </summary>
   [JsonProperty("bus_junction")]
   [JsonConverter(typeof(RgbaColorJsonConverter))]
   public RgbaColorModel BusJunction
   {
      get => _busJunction;
      set
      {
         _busJunction = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// </summary>
   [JsonProperty("component_body")]
   [JsonConverter(typeof(RgbaColorJsonConverter))]
   public RgbaColorModel ComponentBody
   {
      get => _compBody;
      set
      {
         _compBody = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// </summary>
   [JsonProperty("component_outline")]
   [JsonConverter(typeof(RgbaColorJsonConverter))]
   public RgbaColorModel ComponentOutline
   {
      get => _compOutline;
      set
      {
         _compOutline = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// </summary>
   [JsonProperty("cursor")]
   [JsonConverter(typeof(RgbaColorJsonConverter))]
   public RgbaColorModel Cursor
   {
      get => _cursor;
      set
      {
         _cursor = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// </summary>
   [JsonProperty("dnp_marker")]
   [JsonConverter(typeof(RgbaColorJsonConverter))]
   public RgbaColorModel DNPMarker
   {
      get => _dnpMarker;
      set
      {
         _dnpMarker = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// </summary>
   [JsonProperty("erc_error")]
   [JsonConverter(typeof(RgbaColorJsonConverter))]
   public RgbaColorModel ERCError
   {
      get => _ercError;
      set
      {
         _ercError = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// </summary>
   [JsonProperty("erc_exclusion")]
   [JsonConverter(typeof(RgbaColorJsonConverter))]
   public RgbaColorModel ERCExecution
   {
      get => _ercExecution;
      set
      {
         _ercExecution = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// </summary>
   [JsonProperty("erc_warning")]
   [JsonConverter(typeof(RgbaColorJsonConverter))]
   public RgbaColorModel ERCWarning
   {
      get => _ercWarning;
      set
      {
         _ercWarning = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// </summary>
   [JsonProperty("fields")]
   [JsonConverter(typeof(RgbaColorJsonConverter))]
   public RgbaColorModel Fields
   {
      get => _fields;
      set
      {
         _fields = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// </summary>
   [JsonProperty("grid")]
   [JsonConverter(typeof(RgbaColorJsonConverter))]
   public RgbaColorModel Grid
   {
      get => _grid;
      set
      {
         _grid = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// </summary>
   [JsonProperty("grid_axes")]
   [JsonConverter(typeof(RgbaColorJsonConverter))]
   public RgbaColorModel GridAxes
   {
      get => _gridAxes;
      set
      {
         _gridAxes = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// </summary>
   [JsonProperty("hidden")]
   [JsonConverter(typeof(RgbaColorJsonConverter))]
   public RgbaColorModel Hidden
   {
      get => _hidden;
      set
      {
         _hidden = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// </summary>
   [JsonProperty("hovered")]
   [JsonConverter(typeof(RgbaColorJsonConverter))]
   public RgbaColorModel Hovered
   {
      get => _hovered;
      set
      {
         _hovered = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// </summary>
   [JsonProperty("junction")]
   [JsonConverter(typeof(RgbaColorJsonConverter))]
   public RgbaColorModel Junction
   {
      get => _junction;
      set
      {
         _junction = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// </summary>
   [JsonProperty("label_global")]
   [JsonConverter(typeof(RgbaColorJsonConverter))]
   public RgbaColorModel LabelGlobal
   {
      get => _labelGlobal;
      set
      {
         _labelGlobal = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// </summary>
   [JsonProperty("label_hier")]
   [JsonConverter(typeof(RgbaColorJsonConverter))]
   public RgbaColorModel LabelHier
   {
      get => _labelHier;
      set
      {
         _labelHier = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// </summary>
   [JsonProperty("label_local")]
   [JsonConverter(typeof(RgbaColorJsonConverter))]
   public RgbaColorModel LabelLocal
   {
      get => _labelLocal;
      set
      {
         _labelLocal = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// </summary>
   [JsonProperty("netclass_flag")]
   [JsonConverter(typeof(RgbaColorJsonConverter))]
   public RgbaColorModel NetclassFlag
   {
      get => _netclassFlag;
      set
      {
         _netclassFlag = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// </summary>
   [JsonProperty("no_connect")]
   [JsonConverter(typeof(RgbaColorJsonConverter))]
   public RgbaColorModel NoConnect
   {
      get => _noConnect;
      set
      {
         _noConnect = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// </summary>
   [JsonProperty("note")]
   [JsonConverter(typeof(RgbaColorJsonConverter))]
   public RgbaColorModel Note
   {
      get => _note;
      set
      {
         _note = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// </summary>
   [JsonProperty("note_background")]
   [JsonConverter(typeof(RgbaColorJsonConverter))]
   public RgbaColorModel NoteBackground
   {
      get => _noteBackground;
      set
      {
         _noteBackground = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// </summary>
   [JsonProperty("op_currents")]
   [JsonConverter(typeof(RgbaColorJsonConverter))]
   public RgbaColorModel OpCurrents
   {
      get => _opCurrents;
      set
      {
         _opCurrents = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// </summary>
   [JsonProperty("op_voltages")]
   [JsonConverter(typeof(RgbaColorJsonConverter))]
   public RgbaColorModel OpVoltages
   {
      get => _opVoltages;
      set
      {
         _opVoltages = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// </summary>
   [JsonProperty("page_limits")]
   [JsonConverter(typeof(RgbaColorJsonConverter))]
   public RgbaColorModel PageLimits
   {
      get => _pageLimits;
      set
      {
         _pageLimits = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// </summary>
   [JsonProperty("pin")]
   [JsonConverter(typeof(RgbaColorJsonConverter))]
   public RgbaColorModel Pin
   {
      get => _pin;
      set
      {
         _pin = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// </summary>
   [JsonProperty("pin_name")]
   [JsonConverter(typeof(RgbaColorJsonConverter))]
   public RgbaColorModel PinName
   {
      get => _pinName;
      set
      {
         _pinName = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// </summary>
   [JsonProperty("pin_number")]
   [JsonConverter(typeof(RgbaColorJsonConverter))]
   public RgbaColorModel PinNumber
   {
      get => _pinNumber;
      set
      {
         _pinNumber = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// </summary>
   [JsonProperty("private_note")]
   [JsonConverter(typeof(RgbaColorJsonConverter))]
   public RgbaColorModel PrivateNote
   {
      get => _privateNote;
      set
      {
         _privateNote = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// </summary>
   [JsonProperty("reference")]
   [JsonConverter(typeof(RgbaColorJsonConverter))]
   public RgbaColorModel Reference
   {
      get => _reference;
      set
      {
         _reference = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// </summary>
   [JsonProperty("shadow")]
   [JsonConverter(typeof(RgbaColorJsonConverter))]
   public RgbaColorModel Shadow
   {
      get => _shadow;
      set
      {
         _shadow = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// </summary>
   [JsonProperty("sheet")]
   [JsonConverter(typeof(RgbaColorJsonConverter))]
   public RgbaColorModel Sheet
   {
      get => _sheet;
      set
      {
         _sheet = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// </summary>
   [JsonProperty("sheet_background")]
   [JsonConverter(typeof(RgbaColorJsonConverter))]
   public RgbaColorModel SheetBackground
   {
      get => _sheetBackground;
      set
      {
         _sheetBackground = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// </summary>
   [JsonProperty("sheet_fields")]
   [JsonConverter(typeof(RgbaColorJsonConverter))]
   public RgbaColorModel SheetFields
   {
      get => _sheetFields;
      set
      {
         _sheetFields = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// </summary>
   [JsonProperty("sheet_filename")]
   [JsonConverter(typeof(RgbaColorJsonConverter))]
   public RgbaColorModel SheetFileName
   {
      get => _sheetFilename;
      set
      {
         _sheetFilename = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// </summary>
   [JsonProperty("sheet_label")]
   [JsonConverter(typeof(RgbaColorJsonConverter))]
   public RgbaColorModel SheetLabel
   {
      get => _sheetLabel;
      set
      {
         _sheetLabel = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// </summary>
   [JsonProperty("sheet_name")]
   [JsonConverter(typeof(RgbaColorJsonConverter))]
   public RgbaColorModel SheetName
   {
      get => _sheetName;
      set
      {
         _sheetName = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// </summary>
   [JsonProperty("value")]
   [JsonConverter(typeof(RgbaColorJsonConverter))]
   public RgbaColorModel Value
   {
      get => _value;
      set
      {
         _value = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// </summary>
   [JsonProperty("wire")]
   [JsonConverter(typeof(RgbaColorJsonConverter))]
   public RgbaColorModel Wire
   {
      get => _wire;
      set
      {
         _wire = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// </summary>
   [JsonProperty("worksheet")]
   [JsonConverter(typeof(RgbaColorJsonConverter))]
   public RgbaColorModel Worksheet
   {
      get => _worksheet;
      set
      {
         _worksheet = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// </summary>
   [JsonProperty("override_item_colors")]
   public bool OverrideItemColors
   {
      get => _overrideItemColors;
      set
      {
         _overrideItemColors = value;
         OnPropertyChanged();
      }
   }
   #endregion
}
