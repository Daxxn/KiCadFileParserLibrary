using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.Footprints.SubModels;
using KiCadFileParserLibrary.KiCad.General.Collections;
using KiCadFileParserLibrary.KiCad.General.Graphics;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

namespace KiCadFileParserLibrary.KiCad.General
{
    [SExprNode("zone")]
   public class ZoneModel : IKiCadReadable
   {
      #region Local Props
      [SExprSubNode("net")]
      public string? Net { get; set; }

      [SExprSubNode("net_name")]
      public string? NetName { get; set; }

      public LayerCollection? Layer { get; set; }

      [SExprSubNode("uuid")]
      public string? ID { get; set; }

      [SExprSubNode("name")]
      public string? Name { get; set; }

      [SExprSubNode("priority")]
      public int Priority { get; set; } = 0;

      public HatchModel? Hatch { get; set; }

      [SExprSubNode("min_thickness")]
      public double? MinThickness { get; set; }

      [SExprSubNode("filled_areas_thickness")]
      public bool FilledAreasThickness { get; set; }

      public ZoneKeepoutModel? Keepout { get; set; }

      public ZoneFillSettingsModel? Fill { get; set; }

      public PolygonModel? Polygon { get; set; }

      public ZoneFillPolygonModel? PolygonFill { get; set; }

      public ZoneFillSegments? Segments { get; set; }
      #endregion

      #region Constructors
      public ZoneModel() { }
      #endregion

      #region Methods
      public void ParseNode(Node node)
      {
         if (node.Properties != null && node.Children != null)
         {
            var props = GetType().GetProperties();

            KiCadParseUtils.ParseSubNodes(props, node, this);
            KiCadParseUtils.ParseNodes(props, node, this);
         }
      }
      #endregion

      #region Full Props

      #endregion
   }
}
