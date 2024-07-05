using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.KiCad.Symbols.SubModels;
using KiCadFileParserLibrary.SExprParser;

namespace KiCadFileParserLibrary.KiCad.Symbols.Collections
{
   [SExprListNode("property")]
   public class PropertyCollection : IKiCadReadable
   {
      #region Local Props
      public List<SymbolProperty>? Properties { get; set; }
      #endregion

      #region Constructors
      public PropertyCollection() { }
      #endregion

      #region Methods
      public void ParseNode(Node node)
      {
         var children = node.GetNodes("property");
         if (children is null) return;
         Properties = [];
         foreach (var child in children)
         {
            SymbolProperty prop = new();
            prop.ParseNode(child);
            Properties.Add(prop);
         }
      }

      public void WriteNode(StringBuilder builder, int indent, string? auxName = null)
      {
         throw new NotImplementedException();
      }
      #endregion

      #region Full Props

      #endregion
   }
}
