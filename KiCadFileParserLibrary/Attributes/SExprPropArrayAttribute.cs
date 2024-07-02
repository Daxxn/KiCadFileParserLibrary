using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KiCadFileParserLibrary.Attributes
{
   [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
   sealed class SExprPropArrayAttribute : Attribute
   {
      private readonly string _xPath;

      public SExprPropArrayAttribute(string xPath)
      {
         _xPath = xPath;
      }

      public string XPath => _xPath;
   }
}
