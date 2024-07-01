using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;

namespace KiCadFileParserLibrary.KiCad.Pcb.SubModels
{
   [SExprNode("size")]
   public class SizeModel
   {
      [SExprProperty(0)]
      public double Width { get; set; }
      [SExprProperty(1)]
      public double Height { get; set; }
   }
}
