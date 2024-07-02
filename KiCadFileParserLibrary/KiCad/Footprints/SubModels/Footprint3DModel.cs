using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.General;
using KiCadFileParserLibrary.KiCad.Pcb;
using KiCadFileParserLibrary.KiCad.Pcb.SubModels;
using KiCadFileParserLibrary.SExprParser;

namespace KiCadFileParserLibrary.KiCad.Footprints.SubModels
{
   [SExprNode("model")]
   public class Footprint3DModel : IKiCadReadable
   {
      #region Local Props
      [SExprProperty(1)]
      public string? Path { get; set; }

      [SExprSubNode("opacity")]
      public double Opacity { get; set; }

      [SExprSubNode("offset/xyz")]
      public XyzModel? Offset { get; set; }

      [SExprSubNode("scale/xyz")]
      public XyzModel? Scale { get; set; }

      [SExprSubNode("rotate/xyz")]
      public XyzModel? Rotation { get; set; }
      #endregion

      #region Constructors
      public Footprint3DModel() { }
      #endregion

      #region Methods
      public void ParseNode(Node node)
      {

      }
      #endregion

      #region Full Props

      #endregion
   }
}
