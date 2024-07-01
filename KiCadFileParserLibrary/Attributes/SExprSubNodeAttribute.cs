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
      //private readonly bool _exludeName;

      //public SExprSubNodeAttribute(string xPath, bool exludeName = false)
      public SExprSubNodeAttribute(string xPath)
      {
         _xPath = xPath;
         //_exludeName = exludeName;
      }

      public string XPath => _xPath;
      //public bool ExludeName => _exludeName;
   }
}
