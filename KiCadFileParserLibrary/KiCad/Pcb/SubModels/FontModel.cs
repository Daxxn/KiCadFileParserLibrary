using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

namespace KiCadFileParserLibrary.KiCad.Pcb.SubModels
{
    [SExprNode("font")]
   public class FontModel : IKiCadReadable
   {
      [SExprSubNode("face")]
      public string? Family { get; set; }

      public SizeModel? Size { get; set; }

      [SExprSubNode("thickness")]
      public double? Thickness { get; set; }

      [SExprSubNode("bold")]
      public bool Bold { get; set; }

      [SExprSubNode("italic")]
      public bool Italic { get; set; }

      public void ParseNode(Node node)
      {
         if (node.Children != null)
         {
            var props = GetType().GetProperties();
            KiCadParseUtils.ParseNodes(props, node, this);
            KiCadParseUtils.ParseSubNodes(props, node, this);
         }
      }
   }
}
