using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.General.Graphics;
using KiCadFileParserLibrary.SExprParser;

namespace KiCadFileParserLibrary.KiCad.Footprints.Graphics
{
   [SExprNode("fp_rect")]
   public class FpRectangle : GraphicBase
   {
      #region Local Props

      #endregion

      #region Constructors
      public FpRectangle() { }
      #endregion

      #region Methods
      public override void ParseNode(Node node)
      {

      }
      #endregion

      #region Full Props

      #endregion
   }
}
