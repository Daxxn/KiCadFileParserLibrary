using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.Pcb;
using KiCadFileParserLibrary.SExprParser;

namespace KiCadFileParserLibrary.KiCad.General
{
   [SExprNode("zone")]
   public class ZoneModel : IKiCadReadable
   {
      #region Local Props

      #endregion

      #region Constructors
      public ZoneModel() { }
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
