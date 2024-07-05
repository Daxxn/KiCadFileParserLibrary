using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.SExprParser;

namespace KiCadFileParserLibrary.KiCad.General.Graphics
{
   public abstract class GraphicBase : IKiCadReadable
   {
      public abstract void ParseNode(Node node);

      public abstract void WriteNode(StringBuilder builder, int indent, string? auxName = null);
   }
}
