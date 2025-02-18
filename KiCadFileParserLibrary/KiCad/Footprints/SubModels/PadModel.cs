using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.Boards.SubModels;
using KiCadFileParserLibrary.KiCad.Footprints.Collections;
using KiCadFileParserLibrary.KiCad.General;
using KiCadFileParserLibrary.KiCad.General.Collections;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

using MVVMLibrary;

namespace KiCadFileParserLibrary.KiCad.Footprints.SubModels;

/// <summary>
/// <see cref="Footprint"/> pad definition.
/// </summary>
[SExprNode("pad")]
public class PadModel : Model, IKiCadReadable
{
   #region Local Props
   private string? _number;
   private PadType _type;
   private PadShapeType _shape;
   private LocationModel _location = new();
   private PadPropertyType? _propertyType;
   private bool _locked;
   private XyModel _size = new();
   private DrillModel? _drill;
   private LayerCollection? _layers;
   private bool? _removeUnusedLayers;
   private bool? _keepEndLayers;
   private double? _thermalBridgeAngle;
   private double? _roundedRectRatio;
   private double? _chamferRatio;
   private ObservableCollection<ChamferType> _chamferType = [];
   private string? _pinFunction;
   private string? _pinType;
   private double? _dieLength;
   private string _id = "";
   private NetModel? _net;
   private double? _maskMargin;
   private double? _pasteMargin;
   private double? _pasteRatio;
   private double? _clearance;
   private ZoneConnectType? _zoneConnection;
   private double? _thermalWidth;
   private double? _thermalGap;
   private PadOptions? _customPadOptions;
   private CustomPadPrimitives? _customPadPrimitives;
   #endregion

   #region Constructors
   /// <inheritdoc/>
   public PadModel() { }
   #endregion

   #region Methods
   /// <inheritdoc/>
   public void ParseNode(Node node)
   {
      if (node.Children != null && node.Properties != null)
      {
         var props = GetType().GetProperties();

         KiCadParseUtils.ParseNodes(props, node, this);
         KiCadParseUtils.ParseSubNodes(props, node, this);
         KiCadParseUtils.ParseProperties(props, node, this);
         KiCadParseUtils.ParseTokens(props, node, this);
         KiCadParseUtils.ParseListNodes(props, node, this);
         KiCadParseUtils.ParsePropLists(props, node, this);
      }
   }
   #endregion

   #region Full Props
   /// <summary>
   /// Pad number.
   /// <para/>
   /// Links this pad to a <see cref="Symbols.SubModels.PinModel">Pin</see> in the referenced <see cref="Symbols.Symbol">Symbol.</see>
   /// </summary>
   [SExprProperty(1)]
   public string? Number
   {
      get => _number;
      set
      {
         _number = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Type of pad.
   /// </summary>
   [SExprProperty(2)]
   [SExprFormatting(false, false)]
   public PadType Type
   {
      get => _type;
      set
      {
         _type = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Shape of the pad.
   /// </summary>
   [SExprProperty(3)]
   [SExprFormatting(false, false)]
   public PadShapeType Shape
   {
      get => _shape;
      set
      {
         _shape = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Origin coordinates.
   /// </summary>
   public LocationModel Location
   {
      get => _location;
      set
      {
         _location = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Pad property.
   /// </summary>
   [SExprSubNode("property")]
   [SExprFormatting(false, true)]
   public PadPropertyType? PropertyType
   {
      get => _propertyType;
      set
      {
         _propertyType = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Is locked.
   /// </summary>
   [SExprToken("locked")]
   public bool Locked
   {
      get => _locked;
      set
      {
         _locked = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// The horizontal and vertical size of the pad.
   /// </summary>
   [SExprNode("size")]
   public XyModel Size
   {
      get => _size;
      set
      {
         _size = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// The drill hole data for the pad.
   /// <para/>
   /// Null if a SMD pad.
   /// </summary>
   public DrillModel? Drill
   {
      get => _drill;
      set
      {
         _drill = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// List of layers this pad is drawn on.
   /// </summary>
   public LayerCollection? Layers
   {
      get => _layers;
      set
      {
         _layers = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// ???
   /// </summary>
   [SExprSubNode("remove_unused_layers")]
   public bool? RemoveUnusedLayers
   {
      get => _removeUnusedLayers;
      set
      {
         _removeUnusedLayers = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// ???
   /// </summary>
   [SExprSubNode("keep_end_layers")]
   public bool? KeepEndLayers
   {
      get => _keepEndLayers;
      set
      {
         _keepEndLayers = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// ???
   /// </summary>
   [SExprSubNode("thermal_bridge_angle")]
   public double? ThermalBridgeAngle
   {
      get => _thermalBridgeAngle;
      set
      {
         _thermalBridgeAngle = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Percentage of the corner rounding if the <see cref="Shape"/> is a rounded rectangle.
   /// </summary>
   [SExprSubNode("roundrect_rratio")]
   public double? RoundedRectRatio
   {
      get => _roundedRectRatio;
      set
      {
         _roundedRectRatio = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Parcentage of the corner chamfer if the <see cref="Shape"/> is a chamfered rectangle.
   /// </summary>
   [SExprSubNode("chamfer_ratio")]
   public double? ChamferRatio
   {
      get => _chamferRatio;
      set
      {
         _chamferRatio = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// The corners to chamfer if the <see cref="Shape"/> is a chamfered rectangle.
   /// </summary>
   [SExprPropArray("chamfer")]
   public ObservableCollection<ChamferType> ChamferTypes
   {
      get => _chamferType;
      set
      {
         _chamferType = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// ???
   /// </summary>
   [SExprSubNode("pinfunction")]
   public string? PinFunction
   {
      get => _pinFunction;
      set
      {
         _pinFunction = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// ???
   /// </summary>
   [SExprSubNode("pintype")]
   public string? PinType
   {
      get => _pinType;
      set
      {
         _pinType = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// The length of the trace inside the IC.
   /// <para/>
   /// Only used for calculating trace length of high-speed signals.
   /// </summary>
   [SExprSubNode("die_length")]
   public double? DieLength
   {
      get => _dieLength;
      set
      {
         _dieLength = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Unique ID.
   /// </summary>
   [SExprSubNode("uuid")]
   public string ID
   {
      get => _id;
      set
      {
         _id = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Schematic net data.
   /// </summary>
   public NetModel? Net
   {
      get => _net;
      set
      {
         _net = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Solder mask margin.
   /// <para/>
   /// Use the global settings if null.
   /// </summary>
   [SExprSubNode("solder_mask_margin")]
   public double? MaskMargin
   {
      get => _maskMargin;
      set
      {
         _maskMargin = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Solder paste margin.
   /// <para/>
   /// Use the global settings if null.
   /// </summary>
   [SExprSubNode("solder_paste_margin")]
   public double? PasteMargin
   {
      get => _pasteMargin;
      set
      {
         _pasteMargin = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Solder paste margin ratio.
   /// <para/>
   /// Use the global settings if null.
   /// </summary>
   [SExprSubNode("solder_paste_margin_ratio")]
   public double? PasteRatio
   {
      get => _pasteRatio;
      set
      {
         _pasteRatio = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Pad clearance.
   /// <para/>
   /// Use the global settings if null.
   /// </summary>
   [SExprSubNode("clearance")]
   public double? Clearance
   {
      get => _clearance;
      set
      {
         _clearance = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Zone connection mode.
   /// </summary>
   [SExprSubNode("zone_connect")]
   [SExprFormatting(true, true)]
   public ZoneConnectType? ZoneConnection
   {
      get => _zoneConnection;
      set
      {
         _zoneConnection = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Thermal isolation trace width.
   /// </summary>
   [SExprSubNode("thermal_width")]
   public double? ThermalWidth
   {
      get => _thermalWidth;
      set
      {
         _thermalWidth = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Thermal isolation trace gap.
   /// </summary>
   [SExprSubNode("thermal_gap")]
   public double? ThermalGap
   {
      get => _thermalGap;
      set
      {
         _thermalGap = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Custom pad option.
   /// <para/>
   /// Null if not a custom pad.
   /// </summary>
   public PadOptions? CustomPadOptions
   {
      get => _customPadOptions;
      set
      {
         _customPadOptions = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Custom pad shape data.
   /// <para/>
   /// Null if not a custom pad.
   /// </summary>
   public CustomPadPrimitives? CustomPadPrimitives
   {
      get => _customPadPrimitives;
      set
      {
         _customPadPrimitives = value;
         OnPropertyChanged();
      }
   }
   #endregion
}
