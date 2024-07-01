﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.SExprParser;

namespace KiCadFileParserLibrary.KiCad.Pcb.SubModels
{
   [SExprNode("font")]
   public class FontModel : IKiCadReadable
   {
      [SExprSubNode("face")]
      public string? Name { get; set; }
      public SizeModel? Size { get; set; }
      [SExprSubNode("thickness")]
      public double? Thickness { get; set; }
      [SExprSubNode("bold")]
      public bool Bold { get; set; }
      [SExprSubNode("italic")]
      public bool Italic { get; set; }

      public void ParseNode(Node node)
      {

      }
   }
}
