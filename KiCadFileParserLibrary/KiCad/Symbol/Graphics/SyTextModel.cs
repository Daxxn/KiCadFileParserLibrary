using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.General;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

namespace KiCadFileParserLibrary.KiCad.Symbol.Graphics
{
   [SExprNode("text")]
   public class SyTextModel : SyGraphicBase
   {
      #region Local Props
      [SExprProperty(1, true)]
      public string? Text { get; set; }

      [SExprToken("private")]
      public bool IsPrivate { get; set; }

      public LocationModel? Location { get; set; }

      public EffectsModel? Effects { get; set; }
      #endregion

      #region Constructors
      public SyTextModel() { }
      #endregion

      #region Methods
      public override void ParseNode(Node node)
      {
         if (node.Properties != null && node.Children != null)
         {
            var props = GetType().GetProperties();
            KiCadParseUtils.ParseNodes(props, node, this);
            KiCadParseUtils.ParseProperties(props, node, this);
            KiCadParseUtils.ParseTokens(props, node, this);
         }
      }
      #endregion

      #region Full Props

      #endregion
   }
}
