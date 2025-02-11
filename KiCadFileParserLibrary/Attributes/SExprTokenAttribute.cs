using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KiCadFileParserLibrary.Attributes
{
   /// <summary>
   /// Defines S-Expression optional properties that are only true if the name of the property is present, otherwise the value is false.
   /// </summary>
   [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
   sealed class SExprTokenAttribute : Attribute
   {
      private readonly string _tokenName;
      private readonly bool _addToEnd = false;
      private readonly int _index = -1;

      public SExprTokenAttribute(string tokenName)
      {
         _tokenName = tokenName;
      }
      public SExprTokenAttribute(string tokenName, int index)
      {
         _tokenName = tokenName;
         _index = index;
      }
      public SExprTokenAttribute(string tokenName, bool addToEnd)
      {
         _tokenName = tokenName;
         _addToEnd = addToEnd;
      }

      public string TokenName => _tokenName;
      public bool AddToEnd => _addToEnd;
      public int Index => _index;
   }
}
