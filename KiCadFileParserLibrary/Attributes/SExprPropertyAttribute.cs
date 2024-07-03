using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KiCadFileParserLibrary.Attributes
{
   /// <summary>
   /// Defines an S-Expression value.
   /// </summary>
   [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
   sealed class SExprPropertyAttribute : Attribute
   {
      private readonly Index _propIndex;

      public SExprPropertyAttribute(int propertyIndex, bool fromEnd = false)
      {
         _propIndex = new Index(propertyIndex, fromEnd);
      }

      public Index PropertyIndex => _propIndex;
   }
}
