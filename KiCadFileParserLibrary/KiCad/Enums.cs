using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KiCadFileParserLibrary.KiCad
{
   public enum LayerType
   {
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

   public enum FootprintType
   {
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
      Mirror,
      Left,
      Right,
      Top,
      Bottom,
      Center,
   }

   public enum StrokeType
   {
      Dash,
      Dash_Dot,
      Dash_Dot_Dot,
      Dot,
      Default,
      Solid
   }

   public enum FillType
   {
      None,
      Solid,
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
      Circle,
      Rect,
      Oval,
      Trapezoid,
      RoundRect,
      Custom
   }

   public enum PadPropertyType
   {
      Pad_Prop_BGA,
      Pad_Prop_Fiducial_Glob,
      Pad_Prop_Fiducial_Loc,
      Pad_Prop_Testpoint,
      Pad_Prop_Heatsink,
      Pad_Prop_Castellated,
   }

   public enum ChamferType
   {
      Top_Left,
      Top_Right,
      Bottom_Left,
      Bottom_Right,
   }

   public enum CustomPadClearance
   {
      Outline,
      ConvexHull
   }

   public enum CustomPadAnchor
   {
      Rect,
      Circle,
   }
}
