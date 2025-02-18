using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace KiCadFileParserLibrary.Exceptions;

/// <summary>
/// An unknown attribute was used.
/// </summary>
public class UnknownAttributeException : Exception
{
   /// <inheritdoc/>
   public UnknownAttributeException() { }
   /// <inheritdoc/>
   public UnknownAttributeException(string? message) : base(message) { }
   /// <inheritdoc/>
   public UnknownAttributeException(string? message, Exception? innerException) : base(message, innerException) { }
}
