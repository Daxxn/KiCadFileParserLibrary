using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.SExprParser;

namespace KiCadFileParserLibrary.KiCad.Pcb.SubModels
{
   [SExprNode("net")]
   public class NetModel : IKiCadReadable
   {
      [SExprProperty(1)]
      public int Index { get; set; }
      [SExprProperty(2)]
      public string Name { get; set; } = "";

      public void ParseNode(Node node)
      {

      }
   }
}
