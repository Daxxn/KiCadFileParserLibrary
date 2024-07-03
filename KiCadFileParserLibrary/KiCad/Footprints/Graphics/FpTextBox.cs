using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.Footprints.SubModels;
using KiCadFileParserLibrary.KiCad.General;
using KiCadFileParserLibrary.KiCad.General.Graphics;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

namespace KiCadFileParserLibrary.KiCad.Footprints.Graphics
{
   [SExprNode("fp_text_box")]
   public class FpTextBox : GraphicBase
   {
      #region Local Props
      [SExprToken("locked")]
      public bool Locked { get; set; }

      [SExprProperty(1)]
      public string? Text { get; set; }

      [SExprSubNode("start")]
      public XyModel? Start { get; set; }

      [SExprSubNode("end")]
      public XyModel? End { get; set; }

      public CoordinateModel? Points { get; set; }

      [SExprSubNode("angle")]
      public double? Angle { get; set; }

      [SExprSubNode("layer")]
      public string? Layer { get; set; }

      [SExprSubNode("uuid")]
      public string? ID { get; set; }

      public EffectsModel? Effects { get; set; }

      public StrokeModel? Stroke { get; set; }

      public RenderCacheModel? RenderCache { get; set; }
      #endregion

      #region Constructors
      public FpTextBox() { }
      #endregion

      #region Methods
      public override void ParseNode(Node node)
      {
         if (node.Properties != null && node.Children != null)
         {
            var props = GetType().GetProperties();

            KiCadParseUtils.ParseProperties(props, node, this);
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
