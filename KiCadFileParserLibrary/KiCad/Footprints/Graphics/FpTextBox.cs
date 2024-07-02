using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.SExprParser;

namespace KiCadFileParserLibrary.KiCad.Footprints.Graphics
{
   [SExprNode("fp_text_box")]
   public class FpTextBox : FpGraphicBase
   {
      #region Local Props

      #endregion

      #region Constructors
      public FpTextBox() { }
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
