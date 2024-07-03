using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.General;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

namespace KiCadFileParserLibrary.KiCad.Pcb
{
    [SExprNode("setup")]
   public class Setup : IKiCadReadable
   {
      #region Local Props
      public Stackup? Stackup { get; set; }

      [SExprSubNode("pad_to_mask_clearance")]
      public double? PadToMaskClearance { get; set; }

      [SExprSubNode("solder_mask_min_width")]
      public double? SolderMaskMinWidth { get; set; }

      [SExprSubNode("pad_to_paste_clearance")]
      public double? PadToPasteClearance { get; set; }

      [SExprSubNode("pad_to_paste_clearance_ratio")]
      public double? PadToPasteRatio { get; set; }

      [SExprNode("aux_axis_origin")]
      public XyModel? AuxAxisOrigin { get; set; }

      [SExprNode("grid_origin")]
      public XyModel? GridOrigin { get; set; }

      [SExprSubNode("allow_soldermask_bridges_in_footprints")]
      public bool AllowMaskBridgeInFp { get; set; }

      public PcbPlotParameters? PlotParams { get; set; }
      #endregion

      #region Constructors
      public Setup() { }
      #endregion

      #region Methods
      public void ParseNode(Node node)
      {
         if (node.Children != null)
         {
            var props = GetType().GetProperties();

            KiCadParseUtils.ParseNodes(props, node, this);
            KiCadParseUtils.ParseSubNodes(props, node, this);
         }
      }
      #endregion

      #region Full Props

      #endregion
   }
}
