using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KiCadFileParserLibrary.Attributes
{
   [AttributeUsage(AttributeTargets.Property, Inherited = true, AllowMultiple = false)]
   sealed class SExprIndexAttribute : Attribute
   {
      private readonly Index _index;

      public SExprIndexAttribute(int index, bool fromEnd = false)
      {
         _index = new Index(index, fromEnd);
      }

      public Index Index => _index;
   }
}
