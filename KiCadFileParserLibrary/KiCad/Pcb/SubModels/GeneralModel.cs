using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

namespace KiCadFileParserLibrary.KiCad.Pcb.SubModels
{
    [SExprNode("general")]
   public class GeneralModel : IKiCadReadable
   {
      [SExprSubNode("thickness")]
      public double? Thickness { get; set; }

      [SExprSubNode("legacy_teardrops")]
      public bool UseLegacyTeardrop { get; set; }

      public void ParseNode(Node node)
      {
         if (node.Children != null)
         {
            var props = GetType().GetProperties();
            KiCadParseUtils.ParseSubNodes(props, node, this);
         }
      }
   }
}
