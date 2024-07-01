using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace KiCadFileParserLibrary.Exceptions
{
   public class UnknownAttributeException : Exception
   {
      public UnknownAttributeException() { }
      public UnknownAttributeException(string? message) : base(message) { }
      public UnknownAttributeException(string? message, Exception? innerException) : base(message, innerException) { }
   }
}
