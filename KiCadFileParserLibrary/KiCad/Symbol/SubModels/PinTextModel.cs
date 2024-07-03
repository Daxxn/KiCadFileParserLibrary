using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.General;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.SExprParser;

namespace KiCadFileParserLibrary.KiCad.Symbol.SubModels
{
   [SExprNode("name|number")]
   public class PinTextModel : IKiCadReadable
   {
      #region Local Props
      public string? Value { get; set; }

      public EffectsModel? Effects { get; set; }
      #endregion

      #region Constructors
      public PinTextModel() { }
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
