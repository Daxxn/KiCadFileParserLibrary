using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

namespace KiCadFileParserLibrary.KiCad.General.Graphics
{
   [SExprNode("gr_text_box")]
   public class GrTextBoxModel : GraphicBase
   {
      #region Local Props
      [SExprProperty(1)]
      public string? Text { get; set; }

      [SExprNode("start")]
      public XyModel? Start { get; set; }

      [SExprNode("end")]
      public XyModel? End { get; set; }

      [SExprSubNode("layer")]
      public string? Layer { get; set; }

      [SExprSubNode("uuid")]
      public string? ID { get; set; }

      [SExprSubNode("angle")]
      public double? Angle { get; set; }

      [SExprSubNode("border")]
      public bool Border { get; set; }

      public EffectsModel? Effects { get; set; }

      public StrokeModel? Stroke { get; set; }
      #endregion

      #region Constructors
      public GrTextBoxModel() { }
      #endregion

      #region Methods
      public override void ParseNode(Node node)
      {
         if (node.Children != null && node.Properties != null)
         {
            var props = GetType().GetProperties();

            KiCadParseUtils.ParseNodes(props, node, this);
            KiCadParseUtils.ParseSubNodes(props, node, this);
            KiCadParseUtils.ParseProperties(props, node, this);
         }
      }
      #endregion

      #region Full Props

      #endregion
   }
}
