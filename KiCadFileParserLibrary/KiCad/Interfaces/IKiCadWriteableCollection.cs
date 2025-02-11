using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KiCadFileParserLibrary.KiCad.Interfaces;

/// <summary>
/// Defines the object as a collection of children in the current node.
/// </summary>
internal interface IKiCadWriteableCollection
{
   /// <summary>
   /// Write the collection of nodes to the SExpression file.
   /// </summary>
   /// <param name="builder">The string builder instance that handles the file text.</param>
   /// <param name="indent">The number of formatting tabs for this node.</param>
   void WriteCollection(StringBuilder builder, int indent);
}
