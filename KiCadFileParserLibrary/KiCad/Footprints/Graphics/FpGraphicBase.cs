using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.KiCad.Pcb;
using KiCadFileParserLibrary.SExprParser;

namespace KiCadFileParserLibrary.KiCad.Footprints.Graphics
{
   public abstract class FpGraphicBase : IKiCadReadable
   {
      #region Local Props
      public string? Name { get; set; }
      #endregion

      #region Constructors
      public FpGraphicBase() { }
      #endregion

      #region Methods
      public abstract void ParseNode(Node node);
      #endregion

      #region Full Props

      #endregion
   }
}
