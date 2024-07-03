using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.SExprParser;

namespace KiCadFileParserLibrary.KiCad.Footprints.SubModels
{
    [SExprNode("options")]
   public class PadOptions : IKiCadReadable
   {
      #region Local Props
      [SExprSubNode("clearance")]
      public CustomPadClearance Clearance { get; set; }

      [SExprSubNode("anchor")]
      public CustomPadAnchor Anchor { get; set; }
      #endregion

      #region Constructors
      public PadOptions() { }
      #endregion

      #region Methods
      public void ParseNode(Node node)
      {
         throw new NotImplementedException();
      }
      #endregion

      #region Full Props

      #endregion
   }
}
