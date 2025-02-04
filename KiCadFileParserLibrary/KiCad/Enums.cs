using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KiCadFileParserLibrary.KiCad
{
   public enum ProjectFileType
   {
      Schematic,
      PCB,
      Project,
   }

   public enum LibraryFileType
   {
      Footprints,
      Symbols,
   }

   public enum LayerType
   {
      None = 0,
      signal,
      user,
      mixed,
      power,
      jumper,
   };

   public enum FabOutputType
   {
      HPGL = 0,
      Gerber = 1,
      PostScript = 2,
      DXF = 3,
      PDF = 4,
      SVG = 5,
   }

   public enum EdgeConnectorType
   {
      No,
      Yes,
      Bevelled,
   }

   public enum FootprintType
   {
      None = 0,
      SMD,
      through_hole
   }

   public enum ZoneConnectType
   {
      None = 0,
      ThermalReleif = 1,
      Solid = 2,
      UseZoneSettings = 3,
   }

   public enum FootprintTextType
   {
      Reference,
      value,
      User
   }

   public enum TextJustify
   {
      Center = 0,
      Mirror,
      Left,
      Right,
      Top,
      Bottom,
   }

   public enum StrokeType
   {
      Solid = 0,
      Dash,
      Dash_Dot,
      Dash_Dot_Dot,
      Dot,
      Default,
   }

   public enum FillType
   {
      None = 0,
      Solid,
      Yes,
      No,
   }

   public enum TextPositionMode
   {
      Outside = 0,
      InLine = 1,
      Manual = 2,
   }

   public enum TextFrameType
   {
      NoFrame = 0,
      Rectangle = 1,
      Circle = 2,
      RoundRectangle = 3,
   }

   public enum UnitsType
   {
      Inches = 0,
      Mils = 1,
      Millimeters = 2,
      Auto = 3,
   }

   public enum UnitsFormat
   {
      NoSuffix = 0,
      BareSuffix = 1,
      WrapSuffix = 2,
   }

   public enum PadType
   {
      Thru_Hole,
      SMD,
      Connect,
      Np_Thru_Hole,
   }

   public enum PadShapeType
   {
      None = 0,
      Circle,
      Rect,
      Oval,
      Trapezoid,
      RoundRect,
      Custom
   }

   public enum PadPropertyType
   {
      None = 0,
      Pad_Prop_BGA,
      Pad_Prop_Fiducial_Glob,
      Pad_Prop_Fiducial_Loc,
      Pad_Prop_Testpoint,
      Pad_Prop_Heatsink,
      Pad_Prop_Castellated,
   }

   public enum ChamferType
   {
      None = 0,
      Top_Left,
      Top_Right,
      Bottom_Left,
      Bottom_Right,
   }

   public enum CustomPadClearance
   {
      None = 0,
      Outline,
      ConvexHull
   }

   public enum CustomPadAnchor
   {
      None = 0,
      Rect,
      Circle,
   }

   public enum DimensionType
   {
      None = 0,
      Aligned,
      Leader,
      Center,
      Orthogonal,
      Radial,
   }

   public enum HatchType
   {
      None = 0,
      Edge,
      Full,
   }

   public enum KeepoutType
   {
      None = 0,
      Not_Allowed,
      Allowed,
   }

   public enum FillMode
   {
      None = 0,
      Solid,
      Hatched,
   }

   public enum SmoothingStyleType
   {
      None = 0,
      Chamfer,
      Fillet,
   }

   public enum IslandRemovalMode
   {
      AlwaysRemove = 0,
      NeverRemove = 1,
      MinimumArea = 2,
   }

   public enum HatchSmoothingLevel
   {
      NoSmoothing = 0,
      Fillet = 1,
      ArcMin = 2,
      ArcMax = 3,
   }

   public enum HatchBorderAlgorythmType
   {
      None = 0,
      Min_Thickness,
      Hatch_Thickness,
   }

   public enum ViaType
   {
      Normal = 0,
      Blind,
      Micro,
   }

   public enum GeneratedType
   {
      Tuning_Pattern
   }

   public enum SymbolVisibility
   {
      Hiden,
      Visible,
   }

   public enum PinElectricalType
   {
      Input,
      Output,
      Bidirectional,
      Tri_State,
      Passive,
      Free,
      Unspecified,
      Power_In,
      Power_Out,
      Open_Collector,
      Open_Emitter,
      No_Connect
   }

   public enum PinGraphicStyle
   {
      Line,
      Inverted,
      Clock,
      Inverted_Clock,
      Input_Low,
      Clock_Low,
      Output_Low,
      Edge_Clock_High,
      Non_Logic
   }

   public enum SymbolStyleIdentifier
   {
      Default_Style = 0,

   }

   public enum ZoneFillMode
   {
      Solid = 0,
      Hatch = 1,
   }

   public enum TeardropType
   {
      None,
      PadVia,
   }
}
