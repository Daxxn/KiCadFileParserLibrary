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
   [SExprNode("text_box")]
   public class SyTextBoxModel : SyGraphicBase
   {
      #region Local Props
      [SExprProperty(1, true)]
      public string? Text { get; set; }

      public LocationModel? Location { get; set; }

      [SExprNode("size")]
      public XyModel? Size { get; set; }

      public StrokeModel? Stroke { get; set; }

      [SExprSubNode("fill")]
      public FillType Fill { get; set; }

      public EffectsModel? Effects { get; set; }

      [SExprToken("private")]
      public bool IsPrivate { get; set; }
      #endregion

      #region Constructors
      public SyTextBoxModel() { }
      #endregion

      #region Methods
      public override void ParseNode(Node node)
      {
         if (node.Properties != null && node.Children != null)
         {
            var props = GetType().GetProperties();
            KiCadParseUtils.ParseNodes(props, node, this);
            KiCadParseUtils.ParseSubNodes(props, node, this);
            KiCadParseUtils.ParseProperties(props, node, this);
            KiCadParseUtils.ParseTokens(props, node, this);
         }
      }
      #endregion

      #region Full Props

      #endregion
   }
}
