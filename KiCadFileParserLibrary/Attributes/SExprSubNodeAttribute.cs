using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KiCadFileParserLibrary.Attributes
{
   /// <summary>
   /// Defines an S-Expression node in the tree that contains one or more parameters but no more nodes.
   /// </summary>
   [AttributeUsage(AttributeTargets.Property|AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
   sealed class SExprSubNodeAttribute : Attribute
   {
      private readonly string _xPath;
      private readonly int _index = -1;

      public SExprSubNodeAttribute(string xPath)
      {
         _xPath = xPath;
      }
      public SExprSubNodeAttribute(string xPath, int index)
      {
         _xPath = xPath;
         _index = index;
      }

      public string XPath => _xPath;
      public int Index => _index;
   }
}
