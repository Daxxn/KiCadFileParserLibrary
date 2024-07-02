using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.Pcb;
using KiCadFileParserLibrary.SExprParser;

namespace KiCadFileParserLibrary.KiCad.General.Collections
{
   [SExprSubNode("layers")]
   public class LayerCollection : IKiCadReadable
   {
      #region Local Props
      public List<string>? Layers { get; set; }
      #endregion

      #region Constructors
      public LayerCollection() { }

      public void ParseNode(Node node)
      {
         if (node.Properties is null) return;

         Layers = [];
         foreach (var layer in node.Properties[1..])
         {
            Layers.Add(layer);
         }
      }
      #endregion

      #region Methods

      #endregion

      #region Full Props

      #endregion
   }
}
