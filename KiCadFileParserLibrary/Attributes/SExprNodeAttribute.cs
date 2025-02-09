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
   [AttributeUsage(AttributeTargets.Class|AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
   sealed class SExprNodeAttribute : Attribute
   {
      private readonly string _xpath;
      private readonly int _index = -1;

      public SExprNodeAttribute(string xPath)
      {
         _xpath = xPath;
      }
      public SExprNodeAttribute(string xPath, int index)
      {
         _xpath = xPath;
         _index = index;
      }

      public string XPath => _xpath;
      public int Index => _index;
   }
}
