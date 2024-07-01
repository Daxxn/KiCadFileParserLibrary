using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.SExprParser;

namespace KiCadFileParserLibrary.KiCad.Pcb.SubModels
{
   [SExprNode("effects")]
   public class EffectsModel : IKiCadReadable
   {
      #region Local Props
      public FontModel? Font { get; set; }

      [SExprSubNode("justify")]
      public List<TextJustify> Justify { get; set; }
      #endregion

      #region Constructors
      public EffectsModel() { }
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
