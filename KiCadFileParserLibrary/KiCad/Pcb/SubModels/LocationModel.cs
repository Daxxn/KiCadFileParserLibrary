using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;

namespace KiCadFileParserLibrary.KiCad.Pcb.SubModels
{
   [SExprNode("at")]
   public class LocationModel
   {
      [SExprProperty(0)]
      public double X { get; set; }
      [SExprProperty(1)]
      public double Y { get; set; }
      [SExprProperty(2)]
      public double Z { get; set; }
   }
}
