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
   [SExprListNode("pin")]
   public class PinCollection : IKiCadReadable
   {
      #region Local Props
      public List<PinModel>? Pins { get; set; }
      #endregion

      #region Constructors
      public PinCollection() { }
      #endregion

      #region Methods
      public void ParseNode(Node node)
      {
         var children = node.GetNodes("pin");
         if (children is null) return;
         Pins = [];
         foreach (var child in children)
         {
            PinModel pin = new();
            pin.ParseNode(child);
            Pins.Add(pin);
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
