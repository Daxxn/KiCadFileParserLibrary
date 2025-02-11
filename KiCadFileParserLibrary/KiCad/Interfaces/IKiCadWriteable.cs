using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KiCadFileParserLibrary.KiCad.Interfaces;

/// <summary>
/// Defines an object as a SExpression writable node.
/// </summary>
internal interface IKiCadWriteable
{
   /// <summary>
   /// Write the object to the SExpression file.
   /// </summary>
   /// <param name="builder">The string builder instance that handles the file text.</param>
   /// <param name="indent">The number of formatting tabs for this node.</param>
   /// <param name="auxName">An optional name for the new node.</param>
   void WriteNode(StringBuilder builder, int indent, string? auxName = null);
}
