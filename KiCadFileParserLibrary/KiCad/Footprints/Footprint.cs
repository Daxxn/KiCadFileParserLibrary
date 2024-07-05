using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.Footprints.Collections;
using KiCadFileParserLibrary.KiCad.Footprints.SubModels;
using KiCadFileParserLibrary.KiCad.General;
using KiCadFileParserLibrary.KiCad.General.Collections;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.KiCad.Boards.Collections;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

namespace KiCadFileParserLibrary.KiCad.Footprints
{
   [SExprNode("footprint")]
   public class Footprint : IKiCadReadable
   {
      #region Local Props
      [SExprProperty(1)]
      public string LibraryPath { get; set; } = "";

      [SExprToken("locked")]
      public bool Locked { get; set; }

      [SExprToken("placed")]
      public bool Placed { get; set; }

      [SExprSubNode("layer")]
      public string LayerName { get; set; } = "";

      [SExprSubNode("uuid")]
      public string? ID { get; set; }

      //[SExprSubNode("at")]
      public LocationModel Coordinates { get; set; } = new();

      [SExprSubNode("descr")]
      public string? Description { get; set; }

      [SExprSubNode("tags")]
      public string? Tags { get; set; }

      //[SExprSubNode("uuid")]
      //public List<PropertyModel>? Properties { get; set; }

      public PropertyCollection? Properties { get; set; }

      [SExprSubNode("path")]
      public string? Path { get; set; }

      [SExprSubNode("sheetname")]
      public string? SheetName { get; set; }

      [SExprSubNode("sheetfile")]
      public string? SheetFile { get; set; }

      [SExprSubNode("autoplace_cost90")]
      public double? AutoplaceCostHorz { get; set; }

      [SExprSubNode("autoplace_cost180")]
      public double? AutoplaceCostVert { get; set; }

      [SExprSubNode("solder_mask_margin")]
      public double? SolderMaskMargin { get; set; }

      [SExprSubNode("solder_paste_margin")]
      public double? SolderPasteMargin { get; set; }

      [SExprSubNode("solder_paste_ratio")]
      public double? SolderPasteRatio { get; set; }

      [SExprSubNode("clearance")]
      public double? Clearance { get; set; }

      [SExprSubNode("zone_connect")]
      public ZoneConnectType ZoneConnect { get; set; } = ZoneConnectType.None;

      [SExprSubNode("thermal_width")]
      public double? ThermalWidth { get; set; }

      [SExprSubNode("thermal_gap")]
      public double? ThermalGap { get; set; }

      public FootprintAttributeModel? Attributes { get; set; }

      public PrivateLayersModel? PrivateLayers { get; set; }

      public NetTieGroupModel? NetTieGroups { get; set; }

      public FpGraphicsCollection? Graphics { get; set; }

      public PadCollection? Pads { get; set; }

      public GroupCollection? Groups { get; set; }

      public ModelCollection? Models { get; set; }

      public ZoneCollection? Zones { get; set; }

      public ImageCollection? Images { get; set; }
      #endregion

      #region Constructors
      public Footprint() { }
      #endregion

      #region Methods
      public void ParseNode(Node node)
      {
         if (node.Properties != null && node.Children != null)
         {
            var props = GetType().GetProperties();

            KiCadParseUtils.ParseProperties(props, node, this);
            KiCadParseUtils.ParseSubNodes(props, node, this);
            KiCadParseUtils.ParseNodes(props, node, this);
            KiCadParseUtils.ParseTokens(props, node, this);
            KiCadParseUtils.ParseListNodes(props, node, this);
         }
      }

      public void WriteNode(StringBuilder builder, int indent, string? auxName = null)
      {
         builder.Append('\t', indent);
         builder.AppendLine($"(footprint \"{LibraryPath}\"");

         if(Locked)
         {
            builder.Append(" locked");
         }
         if (Placed)
         {
            builder.Append(" placed");
         }

         builder.Append('\t', indent + 1);
         builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("layer", LayerName));

         if (ID != null)
         {
            builder.Append('\t', indent + 1);
            builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("uuid", ID));
         }

         Coordinates.WriteNode(builder, indent + 1);

         if (Description != null)
         {
            builder.Append('\t', indent + 1);
            builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("descr", Description));
         }

         if (Tags != null)
         {
            builder.Append('\t', indent + 1);
            builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("tags", Tags));
         }

         Properties?.WriteNode(builder, indent + 1);

         if (Path != null)
         {
            builder.Append('\t', indent + 1);
            builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("path", Path));
         }

         if (AutoplaceCostHorz != null)
         {
            builder.Append('\t', indent + 1);
            builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("autoplace_cost90", AutoplaceCostHorz));
         }

         if (AutoplaceCostVert != null)
         {
            builder.Append('\t', indent + 1);
            builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("autoplace_cost180", AutoplaceCostVert));
         }

         if (SolderMaskMargin != null)
         {
            builder.Append('\t', indent + 1);
            builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("solder_mask_margin", SolderMaskMargin));
         }

         if (SolderPasteMargin != null)
         {
            builder.Append('\t', indent + 1);
            builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("solder_paste_margin", SolderPasteMargin));
         }

         if (SolderPasteRatio != null)
         {
            builder.Append('\t', indent + 1);
            builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("solder_paste_ratio", SolderPasteRatio));
         }

         if (Clearance != null)
         {
            builder.Append('\t', indent + 1);
            builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("clearance", Clearance));
         }

         if (ZoneConnect != ZoneConnectType.None)
         {
            builder.Append('\t', indent + 1);
            builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("zone_connect", (int)ZoneConnect));
         }

         if (SheetName != null)
         {
            builder.Append('\t', indent + 1);
            builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("sheetname", SheetName));
         }

         if (SheetFile != null)
         {
            builder.Append('\t', indent + 1);
            builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("sheetfile", SheetFile));
         }

         Attributes?.WriteNode(builder, indent + 1);

         PrivateLayers?.WriteNode(builder, indent + 1);

         NetTieGroups?.WriteNode(builder, indent + 1);

         Graphics?.WriteNode(builder, indent + 1);

         Images?.WriteNode(builder, indent + 1);

         Pads?.WriteNode(builder, indent + 1);

         Zones?.WriteNode(builder, indent + 1);

         Groups?.WriteNode(builder, indent + 1);

         Models?.WriteNode(builder, indent + 1);

         builder.Append('\t', indent);
         builder.AppendLine(")");
      }
      #endregion

      #region Full Props

      #endregion
   }
}
