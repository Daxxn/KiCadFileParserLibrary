using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.SExprParser;

namespace KiCadFileParserLibrary.KiCad.Footprints.Graphics
{
   [SExprNode("fp_line")]
   public class FpLine : FpGraphicBase
   {
      #region Local Props
      #endregion

      #region Constructors
      public FpLine() { }
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
