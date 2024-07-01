using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;

namespace KiCadFileParserLibrary.KiCad.Pcb
{
   [SExprNode("stackup")]
   public class Stackup
   {
      public List<Layer> Layers;
      [SExprSubNode("copper_finish")]
      public string Copperfinish { get; set; }
      [SExprSubNode("dielectric_constraints")]
      public bool ImpedanceControlled { get; set; }
   }
}
