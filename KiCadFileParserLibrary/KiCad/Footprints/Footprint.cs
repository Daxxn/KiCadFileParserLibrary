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
using KiCadFileParserLibrary.KiCad.Pcb;
using KiCadFileParserLibrary.KiCad.Pcb.Collections;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

namespace KiCadFileParserLibrary.KiCad.Footprints
{
    [SExprNode("footprint")]
   public class Footprint : IKiCadReadable
   {
      #region Local Props
      [SExprProperty(1)]
      public string? LibraryPath { get; set; }

      [SExprToken("locked")]
      public bool Locked { get; set; }

      [SExprToken("placed")]
      public bool Placed { get; set; }

      [SExprSubNode("layer")]
      public string? LayerName { get; set; }

      [SExprSubNode("uuid")]
      public string? ID { get; set; }

      //[SExprSubNode("at")]
      public LocationModel? Coordinates { get; set; }

      [SExprSubNode("descr")]
      public string? Description { get; set; }

      [SExprSubNode("tags")]
      public string? Tags { get; set; }

      //[SExprSubNode("uuid")]
      //public List<PropertyModel>? Properties { get; set; }

      public PropertyCollection? Properties { get; set; }

      [SExprSubNode("path")]
      public string? Path { get; set; }

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
      public ZoneConnectType ZoneConnect { get; set; } = ZoneConnectType.ThermalReleif;

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
            

            //var 

            //var exprProps = props.Where(p => p.GetCustomAttribute<SExprPropertyAttribute>() != null);
            //foreach (var prop in exprProps)
            //{
            //   var attr = prop.GetCustomAttribute<SExprPropertyAttribute>();
            //   if (node.Properties.Count > attr!.PropertyIndex)
            //   {
            //      prop.SetValue(this, PropertyParser.Parse(node.Properties[attr!.PropertyIndex], prop));
            //   }
            //}
            //if (node.Properties.Count > 2)
            //{
            //   var tProps = props.Where(p => p.GetCustomAttribute<SExprTokenAttribute>() != null);
            //   foreach (var prop in tProps)
            //   {
            //      if (node.Properties.Contains(prop.GetCustomAttribute<SExprTokenAttribute>()!.TokenName))
            //      {
            //         prop.SetValue(this, true);
            //      }

            //   }
            //}
         }
      }
      #endregion

      #region Full Props

      #endregion
   }
}
