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
   [SExprNode("circle")]
   public class SyCircleModel : SyGraphicBase
   {
      #region Local Props
      [SExprNode("center")]
      public XyModel? Center { get; set; }

      [SExprSubNode("radius")]
      public double? Radius { get; set; }

      [SExprToken("private")]
      public bool IsPrivate { get; set; }

      public StrokeModel? Stroke { get; set; }

      [SExprSubNode("fill")]
      public FillType Fill { get; set; }
      #endregion

      #region Constructors
      public SyCircleModel() { }
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
