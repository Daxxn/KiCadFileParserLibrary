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
}
