using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KiCadFileParserLibrary.Attributes
{
   /// <summary>
   /// Defines a property as an S-Expression item that can contain 0 or more of the same type on one level of the tree.
   /// </summary>
   [AttributeUsage(AttributeTargets.Class|AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
   sealed class SExprListNodeAttribute : Attribute
   {
      private readonly string _name;
      private readonly int _index = -1;

      public SExprListNodeAttribute(string name)
      {
         _name = name;
      }
      public SExprListNodeAttribute(string name, int index)
      {
         _name = name;
         _index = index;
      }

      public string Name => _name;
      public int Index => _index;
   }
}
