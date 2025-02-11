using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.SExprParser;

namespace KiCadFileParserLibrary.KiCad.Interfaces;

/// <summary>
/// Defines an object as KiCad file readable.
/// </summary>
internal interface IKiCadReadable
{
   /// <summary>
   /// Parse the objects node in the SExpression file.
   /// </summary>
   /// <param name="node">The current SExpression <see cref="Node"/></param>
   void ParseNode(Node node);
}
