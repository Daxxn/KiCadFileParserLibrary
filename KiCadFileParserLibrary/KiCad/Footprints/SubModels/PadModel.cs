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

namespace KiCadFileParserLibrary.KiCad.Footprints.SubModels
{
   [SExprNode("pad")]
   public class PadModel : IKiCadReadable
   {
      #region Local Props
      [SExprProperty(1)]
      public string? Number { get; set; }

      [SExprProperty(2)]
      public PadType Type { get; set; }

      [SExprProperty(3)]
      public PadShapeType Shape { get; set; }

      public LocationModel Location { get; set; } = new();

      [SExprSubNode("property")]
      public PadPropertyType PropertyType { get; set; }

      [SExprToken("locked")]
      public bool Locked { get; set; }

      [SExprNode("size")]
      public XyModel Size { get; set; } = new();

      public DrillModel? Drill { get; set; }

      public LayerCollection? Layers { get; set; }

      [SExprSubNode("remove_unused_layers")]
      public bool? RemoveUnusedLayers { get; set; }

      [SExprSubNode("keep_end_layers")]
      public bool? KeepEndLayers { get; set; }

      [SExprSubNode("thermal_bridge_angle")]
      public double? ThermalBridgeAngle { get; set; }

      [SExprSubNode("roundrect_rratio")]
      public double? RoundedRectRatio { get; set; }

      [SExprSubNode("chamfer_ratio")]
      public double? ChamferRatio { get; set; }

      [SExprSubNode("chamfer")]
      public ChamferType ChamferType { get; set; }

      [SExprSubNode("pinfunction")]
      public string? PinFunction { get; set; }

      [SExprSubNode("pintype")]
      public string? PinType { get; set; }

      [SExprSubNode("die_length")]
      public double? DieLength { get; set; }

      [SExprSubNode("uuid")]
      public string ID { get; set; } = "";

      public NetModel? Net { get; set; }

      [SExprSubNode("solder_mask_margin")]
      public double? MaskMargin { get; set; }

      [SExprSubNode("solder_paste_margin")]
      public double? PasteMargin { get; set; }

      [SExprSubNode("solder_paste_margin_ratio")]
      public double? PasteRatio { get; set; }

      [SExprSubNode("clearance")]
      public double? Clearance { get; set; }

      [SExprSubNode("zone_connection")]
      public ZoneConnectType ZoneConnection { get; set; }

      [SExprSubNode("thermal_width")]
      public double? ThermalWidth { get; set; }

      [SExprSubNode("thermal_gap")]
      public double? ThermalGap { get; set; }

      public PadOptions? CustomPadOptions { get; set; }

      public CustomPadPrimitives? CustomPadPrimitives { get; set; }
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

      #endregion
   }
}
