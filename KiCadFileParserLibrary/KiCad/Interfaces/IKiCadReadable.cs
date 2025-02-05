using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.SExprParser;

namespace KiCadFileParserLibrary.KiCad.Interfaces;

internal interface IKiCadReadable
{
   void ParseNode(Node node);
   void WriteNode(StringBuilder builder, int indent, string? auxName = null);
}
