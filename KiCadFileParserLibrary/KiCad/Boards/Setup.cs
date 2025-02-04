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

namespace KiCadFileParserLibrary.KiCad.Boards
{
   [SExprNode("setup")]
   public class Setup : IKiCadReadable
   {
      #region Local Props
      public Stackup? Stackup { get; set; }

      [SExprSubNode("pad_to_mask_clearance")]
      public double PadToMaskClearance { get; set; }

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

      public PcbPlotParameters PlotParams { get; set; } = new();
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

      public void WriteNode(StringBuilder builder, int indent, string? auxName = null)
      {
         builder.Append('\t', indent);
         builder.AppendLine("(setup");
         if (Stackup != null)
         {
            Stackup.WriteNode(builder, indent + 1);
         }

         builder.Append('\t', indent + 1);
         builder.AppendLine($"(pad_to_mask_clearance {PadToMaskClearance})");

         if (SolderMaskMinWidth != null)
         {
            builder.Append('\t', indent + 1);
            builder.AppendLine($"(solder_mask_min_width {SolderMaskMinWidth})");
         }

         if (PadToPasteClearance != null)
         {
            builder.Append('\t', indent + 1);
            builder.AppendLine($"(pad_to_paste_clearance {PadToPasteClearance})");
         }

         if (PadToPasteRatio != null)
         {
            builder.Append('\t', indent + 1);
            builder.AppendLine($"(pad_to_paste_clearance_ratio {PadToPasteRatio})");
         }

         builder.Append('\t', indent + 1);
         builder.AppendLine($"(allow_soldermask_bridges_in_footprints {KiCadWriteUtils.PrintBool(AllowMaskBridgeInFp)})");

         AuxAxisOrigin?.WriteNode(builder, indent + 1, "aux_axis_origin");
         GridOrigin?.WriteNode(builder, indent + 1, "grid_origin");
         PlotParams.WriteNode(builder, indent + 1);

         builder.Append('\t', indent);
         builder.AppendLine(")");
      }

      public override string ToString()
      {
         return $"Setup - Pad-Mask: {PadToMaskClearance} - Mask-Min-Width: {SolderMaskMinWidth} - Pad-Paste: {PadToPasteClearance} - Pad-Paste-Ratio: {PadToPasteRatio} - Allow-Mask-Bridge: {AllowMaskBridgeInFp}";
      }
      #endregion

      #region Full Props

      #endregion
   }
}
