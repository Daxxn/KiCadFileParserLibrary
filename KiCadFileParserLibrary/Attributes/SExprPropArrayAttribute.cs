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
      private readonly int _index = -1;

      public SExprPropArrayAttribute(string xPath)
      {
         _xPath = xPath;
      }
      public SExprPropArrayAttribute(string xPath, int index)
      {
         _xPath = xPath;
         _index = index;
      }

      public string XPath => _xPath;
      public int Index => _index;
   }
}
