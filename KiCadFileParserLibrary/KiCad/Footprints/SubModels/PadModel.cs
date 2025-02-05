using System;
using System.Collections.Generic;
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

namespace KiCadFileParserLibrary.KiCad.Footprints.SubModels
{
   [SExprNode("pad")]
   public class PadModel : Model, IKiCadReadable
   {
      #region Local Props
      private string? _number;
      private PadType _type;
      private PadShapeType _shape;
      private LocationModel _location;
      private PadPropertyType _propertyType;
      private bool _locked;
      private XyModel _size;
      private DrillModel? _drill;
      private LayerCollection? _layers;
      private bool? _removeUnusedLayers;
      private bool? _keepEndLayers;
      private double? _thermalBridgeAngle;
      private double? _roundedRectRatio;
      private double? _chamferRatio;
      private ChamferType _chamferType;
      private string? _pinFunction;
      private string? _pinType;
      private double? _dieLength;
      private string _id;
      private NetModel? _net;
      private double? _maskMargin;
      private double? _pasteMargin;
      private double? _pasteRatio;
      private double? _clearance;
      private ZoneConnectType _zoneConnection;
      private double? _thermalWidth;
      private double? _thermalGap;
      private PadOptions? _customPadOptions;
      private CustomPadPrimitives? _customPadPrimitives;

      #endregion

      #region Constructors
      public PadModel() { }
      #endregion

      #region Methods
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
         }
      }

      public void WriteNode(StringBuilder builder, int indent, string? auxName = null)
      {
         builder.Append('\t', indent);
         builder.AppendLine($"(pad \"{Number}\" {Type.ToString().ToLower()} {Shape.ToString().ToLower()}");

         Location.WriteNode(builder, indent + 1);
         if (Locked)
         {
            builder.Append('\t', indent + 1);
            builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("locked", Locked));
         }

         Size.WriteNode(builder, indent + 1, "size");
         Drill?.WriteNode(builder, indent + 1);

         if (PropertyType != PadPropertyType.None)
         {
            builder.Append('\t', indent + 1);
            builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("property", PropertyType));
         }

         Layers?.WriteNode(builder, indent + 1);

         if (RemoveUnusedLayers != null)
         {
            builder.Append('\t', indent + 1);
            builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("remove_unused_layers", RemoveUnusedLayers));
         }

         if (KeepEndLayers != null)
         {
            builder.Append('\t', indent + 1);
            builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("keep_end_layers", KeepEndLayers));
         }

         if (RoundedRectRatio != null)
         {
            builder.Append('\t', indent + 1);
            builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("roundrect_rratio", RoundedRectRatio));
         }

         if (ChamferRatio != null)
         {
            builder.Append('\t', indent + 1);
            builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("chamfer_ratio", ChamferRatio));
         }

         if (ChamferType != ChamferType.None)
         {
            builder.Append('\t', indent + 1);
            builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("chamfer", ChamferType));
         }

         Net?.WriteNode(builder, indent + 1);

         if (PinFunction != null)
         {
            builder.Append('\t', indent + 1);
            builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("pinfunction", PinFunction));
         }

         if (PinType != null)
         {
            builder.Append('\t', indent + 1);
            builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("pintype", PinType));
         }

         if (DieLength != null)
         {
            builder.Append('\t', indent + 1);
            builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("die_length", DieLength));
         }

         if (MaskMargin != null)
         {
            builder.Append('\t', indent + 1);
            builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("solder_mask_margin", MaskMargin));
         }

         if (PasteMargin != null)
         {
            builder.Append('\t', indent + 1);
            builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("solder_paste_margin", PasteMargin));
         }

         if (PasteRatio != null)
         {
            builder.Append('\t', indent + 1);
            builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("solder_paste_margin_ratio", PasteRatio));
         }

         if (Clearance != null)
         {
            builder.Append('\t', indent + 1);
            builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("clearance", Clearance));
         }

         if (ZoneConnection != ZoneConnectType.None)
         {
            builder.Append('\t', indent + 1);
            builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("zone_connect", ZoneConnection));
         }

         if (ThermalWidth != null)
         {
            builder.Append('\t', indent + 1);
            builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("thermal_width", ThermalWidth));
         }

         if (ThermalGap != null)
         {
            builder.Append('\t', indent + 1);
            builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("thermal_gap", ThermalGap));
         }

         if (ThermalBridgeAngle != null)
         {
            builder.Append('\t', indent + 1);
            builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("thermal_bridge_angle", ThermalBridgeAngle));
         }

         CustomPadOptions?.WriteNode(builder, indent + 1);
         CustomPadPrimitives?.WriteNode(builder, indent + 1);

         builder.Append('\t', indent + 1);
         builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("uuid", ID));

         builder.Append('\t', indent);
         builder.AppendLine(")");
      }
      #endregion

      #region Full Props
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

      [SExprProperty(2)]
      public PadType Type
      {
         get => _type;
         set
         {
            _type = value;
            OnPropertyChanged();
         }
      }

      [SExprProperty(3)]
      public PadShapeType Shape
      {
         get => _shape;
         set
         {
            _shape = value;
            OnPropertyChanged();
         }
      }

      public LocationModel Location
      {
         get => _location;
         set
         {
            _location = value;
            OnPropertyChanged();
         }
      }

      [SExprSubNode("property")]
      public PadPropertyType PropertyType
      {
         get => _propertyType;
         set
         {
            _propertyType = value;
            OnPropertyChanged();
         }
      }

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

      public DrillModel? Drill
      {
         get => _drill;
         set
         {
            _drill = value;
            OnPropertyChanged();
         }
      }

      public LayerCollection? Layers
      {
         get => _layers;
         set
         {
            _layers = value;
            OnPropertyChanged();
         }
      }

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

      [SExprSubNode("chamfer")]
      public ChamferType ChamferType
      {
         get => _chamferType;
         set
         {
            _chamferType = value;
            OnPropertyChanged();
         }
      }

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

      public NetModel? Net
      {
         get => _net;
         set
         {
            _net = value;
            OnPropertyChanged();
         }
      }

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

      [SExprSubNode("zone_connection")]
      public ZoneConnectType ZoneConnection
      {
         get => _zoneConnection;
         set
         {
            _zoneConnection = value;
            OnPropertyChanged();
         }
      }

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

      public PadOptions? CustomPadOptions
      {
         get => _customPadOptions;
         set
         {
            _customPadOptions = value;
            OnPropertyChanged();
         }
      }

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
}
