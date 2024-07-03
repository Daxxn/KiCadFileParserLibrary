using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

namespace KiCadFileParserLibrary.KiCad.Pcb.SubModels
{
    [SExprNode("teardrops")]
   public class TeardropModel : IKiCadReadable
   {
      #region Local Props
      [SExprSubNode("best_length_ratio")]
      public double BestLengthRatio { get; set; }

      [SExprSubNode("max_length")]
      public double MaxLength { get; set; }

      [SExprSubNode("best_width_ratio")]
      public double BestWidthRatio { get; set; }

      [SExprSubNode("max_width")]
      public double MaxWidth { get; set; }

      [SExprSubNode("curve_points")]
      public int CurvePoints { get; set; }

      [SExprSubNode("filter_ratio")]
      public double FilterRatio { get; set; }

      [SExprSubNode("enabled")]
      public bool Enable { get; set; }

      [SExprSubNode("allow_two_segments")]
      public bool AllowTwoSegments { get; set; }

      [SExprSubNode("prefer_zone_connections")]
      public bool PreferZoneConn { get; set; }
      #endregion

      #region Constructors
      public TeardropModel() { }
      #endregion

      #region Methods
      public void ParseNode(Node node)
      {
         if (node.Children != null)
         {
            var props = GetType().GetProperties();
            KiCadParseUtils.ParseSubNodes(props, node, this);
         }
      }
      #endregion

      #region Full Props

      #endregion
   }
}
