using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.General;
using KiCadFileParserLibrary.KiCad.Pcb;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

namespace KiCadFileParserLibrary.KiCad.Footprints.Graphics
{
   [SExprNode("fp_circle")]
   public class FpCircle : FpGraphicBase
   {
      #region Local Props
      [SExprSubNode("layer")]
      public string? Layer { get; set; }

      [SExprSubNode("width")]
      public double? Width { get; set; }

      [SExprSubNode("Fill")]
      public FillType Fill { get; set; } = FillType.None;

      [SExprToken("locked")]
      public bool? Locked { get; set; }

      [SExprSubNode("uuid")]
      public string? ID { get; set; }

      public XyModel? Center { get; set; }

      public XyModel? End { get; set; }

      public StrokeModel? Stroke { get; set; }
      #endregion

      #region Constructors
      public FpCircle() { }
      #endregion

      #region Methods
      public override void ParseNode(Node node)
      {
         if (node.Children != null && node.Properties != null)
         {
            var props = GetType().GetProperties();

            KiCadParseUtils.ParseNodes(props, node, this);
            KiCadParseUtils.ParseSubNodes(props, node, this);
            KiCadParseUtils.ParseTokens(props, node, this);
         }
      }
      #endregion

      #region Full Props

      #endregion
   }
}
