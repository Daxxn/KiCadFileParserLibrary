using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

using MVVMLibrary;

namespace KiCadFileParserLibrary.KiCad.General
{
   [SExprNode("fill")]
   public class ZoneFillSettingsModel : Model, IKiCadReadable
   {
      #region Local Props
      private bool _isFilled;
      private ZoneFillMode _fillMode;
      private double _thermalGap;
      private double _thermalBridge;
      private SmoothingStyleType _smoothing;
      private double? _smoothingRadius;
      private IslandRemovalMode _islandRemovalMode;
      private double? _islandAreaMin;
      private double? _hatchThickness;
      private double? _hatchGap;
      private double? _hatchOrient;
      private HatchSmoothingLevel _hatchSmoothingLevel;
      private double? _hatchSmoothingValue;
      private HatchBorderAlgorythmType _hatchBorderAl;
      private double? _hatchMinHoleArea;
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
      [SExprToken("yes")]
      public bool IsFilled
      {
         get => _isFilled;
         set
         {
            _isFilled = value;
            OnPropertyChanged();
         }
      }

      [SExprSubNode("mode")]
      public ZoneFillMode FillMode
      {
         get => _fillMode;
         set
         {
            _fillMode = value;
            OnPropertyChanged();
         }
      }

      [SExprSubNode("thermal_gap")]
      public double ThermalGap
      {
         get => _thermalGap;
         set
         {
            _thermalGap = value;
            OnPropertyChanged();
         }
      }

      [SExprSubNode("thermal_bridge_width")]
      public double ThermalBridge
      {
         get => _thermalBridge;
         set
         {
            _thermalBridge = value;
            OnPropertyChanged();
         }
      }

      [SExprSubNode("smoothing")]
      public SmoothingStyleType Smoothing
      {
         get => _smoothing;
         set
         {
            _smoothing = value;
            OnPropertyChanged();
         }
      }

      [SExprSubNode("radius")]
      public double? SmoothingRadius
      {
         get => _smoothingRadius;
         set
         {
            _smoothingRadius = value;
            OnPropertyChanged();
         }
      }

      [SExprSubNode("island_removal_mode")]
      public IslandRemovalMode IslandRemovalMode
      {
         get => _islandRemovalMode;
         set
         {
            _islandRemovalMode = value;
            OnPropertyChanged();
         }
      }

      [SExprSubNode("island_area_min")]
      public double? IslandAreaMin
      {
         get => _islandAreaMin;
         set
         {
            _islandAreaMin = value;
            OnPropertyChanged();
         }
      }

      [SExprSubNode("hatch_thickness")]
      public double? HatchThickness
      {
         get => _hatchThickness;
         set
         {
            _hatchThickness = value;
            OnPropertyChanged();
         }
      }

      [SExprSubNode("hatch_gap")]
      public double? HatchGap
      {
         get => _hatchGap;
         set
         {
            _hatchGap = value;
            OnPropertyChanged();
         }
      }

      [SExprSubNode("hatch_orientation")]
      public double? HatchOrientation
      {
         get => _hatchOrient;
         set
         {
            _hatchOrient = value;
            OnPropertyChanged();
         }
      }

      [SExprSubNode("hatch_smoothing_level")]
      public HatchSmoothingLevel HatchSmoothingLevel
      {
         get => _hatchSmoothingLevel;
         set
         {
            _hatchSmoothingLevel = value;
            OnPropertyChanged();
         }
      }

      [SExprSubNode("hatch_smoothing_value")]
      public double? HatchSmoothingValue
      {
         get => _hatchSmoothingValue;
         set
         {
            _hatchSmoothingValue = value;
            OnPropertyChanged();
         }
      }

      [SExprSubNode("hatch_border_algorithm")]
      public HatchBorderAlgorythmType HatchBorderAlgorythm
      {
         get => _hatchBorderAl;
         set
         {
            _hatchBorderAl = value;
            OnPropertyChanged();
         }
      }

      [SExprSubNode("hatch_min_hole_area")]
      public double? HatchMinHoleArea
      {
         get => _hatchMinHoleArea;
         set
         {
            _hatchMinHoleArea = value;
            OnPropertyChanged();
         }
      }
      #endregion
   }
}
