using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.General;
using KiCadFileParserLibrary.KiCad.General.Graphics;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

namespace KiCadFileParserLibrary.KiCad.Footprints.Graphics
{
   [SExprNode("fp_line")]
   public class FpLine : GraphicBase
   {
      #region Local Props
      [SExprNode("start")]
      public XyModel? Start { get; set; }

      [SExprNode("end")]
      public XyModel? End { get; set; }

      [SExprSubNode("layer")]
      public string? Layer { get; set; }

      public StrokeModel? Stroke { get; set; }

      [SExprToken("locked")]
      public bool Locked { get; set; }

      [SExprSubNode("uuid")]
      public string? ID { get; set; }
      #endregion

      #region Constructors
      public FpLine() { }
      #endregion

      #region Methods
      public override void ParseNode(Node node)
      {
         if (node.Properties != null && node.Children != null)
         {
            var props = GetType().GetProperties();

            KiCadParseUtils.ParseSubNodes(props, node, this);
            KiCadParseUtils.ParseNodes(props, node, this);
            KiCadParseUtils.ParseTokens(props, node, this);
         }
      }
      #endregion

      #region Full Props

      #endregion
   }
}
