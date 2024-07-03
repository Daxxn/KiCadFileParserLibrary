using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.SExprParser;

namespace KiCadFileParserLibrary.KiCad.Symbol.Graphics
{
   public abstract class SyGraphicBase : IKiCadReadable
   {
      public abstract void ParseNode(Node node);
   }
}
