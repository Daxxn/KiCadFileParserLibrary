using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;

namespace KiCadFileParserLibrary.KiCad.Pcb
{
   [SExprNode("layer")]
   public class Layer
   {
      [SExprProperty(0)]
      public string Name { get; set; }
      [SExprSubNode("type")]
      public string Type { get; set; }
      [SExprSubNode("color")]
      public string Color { get; set; }
      [SExprSubNode("material")]
      public string Material { get; set; }
      [SExprSubNode("thickness")]
      public double Thickness { get; set; }
      [SExprSubNode("epsilon_r")]
      public double EpsilonR { get; set; }
      [SExprSubNode("loss_tangent")]
      public double LossTangent { get; set; }
   }
}
