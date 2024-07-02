using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.Footprints.Collections;
using KiCadFileParserLibrary.KiCad.General;
using KiCadFileParserLibrary.KiCad.General.Collections;
using KiCadFileParserLibrary.KiCad.Pcb;
using KiCadFileParserLibrary.KiCad.Pcb.SubModels;
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

      public LocationModel? Location { get; set; }

      [SExprSubNode("property")]
      public PadPropertyType? PropertyType { get; set; }

      [SExprToken("locked")]
      public bool Locked { get; set; }

      public SizeModel? Size { get; set; }

      public DrillModel? Drill { get; set; }

      public LayerCollection? Layers { get; set; }

      [SExprSubNode("remove_unused_layers")]
      public bool RemoveUnusedLayers { get; set; }

      [SExprSubNode("thermal_bridge_angle")]
      public double? ThermalBridgeAngle { get; set; }

      [SExprSubNode("roundrect_rratio")]
      public double? RoundedRectRatio { get; set; }

      [SExprSubNode("chamfer_ratio")]
      public double? ChamferRatio { get; set; }

      [SExprSubNode("chamfer")]
      public ChamferType? ChamferType { get; set; }

      [SExprSubNode("die_length")]
      public double? DieLength { get; set; }

      [SExprSubNode("uuid")]
      public string? ID { get; set; }

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

      //public CustomPadPrimitives? Primitives { get; set; }

      [SExprSubNode("primitives")]
      public FpGraphicsCollection? Primitives { get; set; }
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
      #endregion

      #region Full Props

      #endregion
   }
}
