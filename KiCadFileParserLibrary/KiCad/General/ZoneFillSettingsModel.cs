﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

namespace KiCadFileParserLibrary.KiCad.General
{
   [SExprNode("fill")]
   public class ZoneFillSettingsModel : IKiCadReadable
   {
      #region Local Props
      [SExprToken("yes")]
      public bool IsFilled { get; set; }

      [SExprSubNode("mode")]
      public ZoneFillMode FillMode { get; set; }

      [SExprSubNode("thermal_gap")]
      public double ThermalGap { get; set; }

      [SExprSubNode("thermal_bridge_width")]
      public double ThermalBridge { get; set; }

      [SExprSubNode("smoothing")]
      public SmoothingStyleType Smoothing { get; set; }

      [SExprSubNode("radius")]
      public double? SmoothingRadius { get; set; }

      [SExprSubNode("island_removal_mode")]
      public IslandRemovalMode IslandRemovalMode { get; set; }

      [SExprSubNode("island_area_min")]
      public double? IslandAreaMin { get; set; }

      [SExprSubNode("hatch_thickness")]
      public double? HatchThickness { get; set; }

      [SExprSubNode("hatch_gap")]
      public double? HatchGap { get; set; }

      [SExprSubNode("hatch_orientation")]
      public double? HatchOrientation { get; set; }

      [SExprSubNode("hatch_smoothing_level")]
      public HatchSmoothingLevel HatchSmoothingLevel { get; set; }

      [SExprSubNode("hatch_smoothing_value")]
      public double? HatchSmoothingValue { get; set; }

      [SExprSubNode("hatch_border_algorithm")]
      public HatchBorderAlgorythmType HatchBorderAlgorythm { get; set; }

      [SExprSubNode("hatch_min_hole_area")]
      public double? HatchMinHoleArea { get; set; }
      #endregion

      #region Constructors
      public ZoneFillSettingsModel() { }
      #endregion

      #region Methods
      public void ParseNode(Node node)
      {
         if (node.Properties != null && node.Children != null)
         {
            var props = GetType().GetProperties();

            KiCadParseUtils.ParseNodes(props, node, this);
            KiCadParseUtils.ParseSubNodes(props, node, this);
            KiCadParseUtils.ParseTokens(props, node, this);
         }
      }

      public void WriteNode(StringBuilder builder, int indent, string? auxName = null)
      {
         builder.Append('\t', indent);
         builder.Append("(fill");

         if (IsFilled)
         {
            builder.Append(" yes");
         }
         builder.AppendLine();

         if (FillMode != ZoneFillMode.Solid)
         {
            builder.Append('\t', indent + 1);
            builder.AppendLine($"(mode hatch)");
         }

         builder.Append('\t', indent + 1);
         builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("thermal_gap", ThermalGap));

         builder.Append('\t', indent + 1);
         builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("thermal_bridge_width", ThermalBridge));

         if (Smoothing != SmoothingStyleType.None)
         {
            builder.Append('\t', indent + 1);
            builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("smoothing", Smoothing));
         }

         if (SmoothingRadius != null)
         {
            builder.Append('\t', indent + 1);
            builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("radius", SmoothingRadius));
         }

         if (IslandRemovalMode != IslandRemovalMode.AlwaysRemove)
         {
            builder.Append('\t', indent + 1);
            builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("island_removal_mode", (int)IslandRemovalMode));
         }

         if (IslandAreaMin != null)
         {
            builder.Append('\t', indent + 1);
            builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("island_area_min", IslandAreaMin));
         }

         if (HatchThickness != null)
         {
            builder.Append('\t', indent + 1);
            builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("hatch_thickness", HatchThickness));
         }

         if (HatchGap != null)
         {
            builder.Append('\t', indent + 1);
            builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("hatch_gap", HatchGap));
         }

         if (HatchOrientation != null)
         {
            builder.Append('\t', indent + 1);
            builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("hatch_orientation", HatchOrientation));
         }

         if (HatchSmoothingLevel != HatchSmoothingLevel.NoSmoothing)
         {
            builder.Append('\t', indent + 1);
            builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("hatch_smoothing_level", HatchSmoothingLevel));
         }

         if (HatchSmoothingValue != null)
         {
            builder.Append('\t', indent + 1);
            builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("hatch_smoothing_value", HatchSmoothingValue));
         }

         if (HatchBorderAlgorythm != HatchBorderAlgorythmType.None)
         {
            builder.Append('\t', indent + 1);
            builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("hatch_border_algorithm", HatchBorderAlgorythm));
         }

         if (HatchMinHoleArea != null)
         {
            builder.Append('\t', indent + 1);
            builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("hatch_min_hole_area", HatchMinHoleArea));
         }

         builder.Append('\t', indent);
         builder.AppendLine(")");
      }
      #endregion

      #region Full Props

      #endregion
   }
}
