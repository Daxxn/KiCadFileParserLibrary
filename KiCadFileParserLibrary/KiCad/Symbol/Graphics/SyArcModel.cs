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
   [SExprNode("arc")]
   public class SyArcModel : SyGraphicBase
   {
      #region Local Props
      [SExprNode("start")]
      public XyModel? Start { get; set; }

      [SExprNode("mid")]
      public XyModel? Middle { get; set; }

      [SExprNode("end")]
      public XyModel? End { get; set; }

      [SExprToken("private")]
      public bool IsPrivate { get; set; }

      public StrokeModel? Stroke { get; set; }

      [SExprSubNode("fill")]
      public FillType Fill { get; set; }
      #endregion

      #region Constructors
      public SyArcModel() { }
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
