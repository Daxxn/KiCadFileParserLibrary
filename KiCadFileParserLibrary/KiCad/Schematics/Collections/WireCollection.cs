using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.KiCad.Schematics.SubModels;
using KiCadFileParserLibrary.SExprParser;

namespace KiCadFileParserLibrary.KiCad.Schematics.Collections
{
   [SExprListNode("wire")]
   public class WireCollection : IKiCadReadable
   {
      #region Local Props
      public List<WireModel>? Wires { get; set; }
      #endregion

      #region Constructors
      public WireCollection() { }
      #endregion

      #region Methods
      public void ParseNode(Node node)
      {
         throw new NotImplementedException();
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
