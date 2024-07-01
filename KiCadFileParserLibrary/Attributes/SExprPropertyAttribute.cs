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
      readonly int _propIndex;
      readonly bool _useQuotes;

      public SExprPropertyAttribute(int propertyIndex, bool useQuotes = false)
      {
         _propIndex = propertyIndex;
         _useQuotes = useQuotes;
      }

      public int PropertyIndex => _propIndex;
      public bool UseQuotes => _useQuotes;
   }
}
