using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KiCadFileParserLibrary.Attributes
{
   /// <summary>
   /// Defines an S-Expression node in the tree that can contain more than one parameter or sub-node.
   /// </summary>
   [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
   sealed class SExprNodeAttribute : Attribute
   {
      private readonly string _xpath;

      public SExprNodeAttribute(string xPath)
      {
         _xpath = xPath;
      }

      public string XPath => _xpath;
   }
}
