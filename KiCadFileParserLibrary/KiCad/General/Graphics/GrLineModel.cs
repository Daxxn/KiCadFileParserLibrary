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
   [SExprNode("gr_line")]
   public class GrLineModel : GraphicBase
   {
      #region Local Props
      [SExprNode("start")]
      public XyModel? Start { get; set; }

      [SExprNode("end")]
      public XyModel? End { get; set; }

      public StrokeModel? Stroke { get; set; }

      [SExprSubNode("uuid")]
      public string? ID { get; set; }

      [SExprSubNode("layer")]
      public string? Layer { get; set; }

      [SExprSubNode("angle")]
      public double? Angle { get; set; }
      #endregion

      #region Constructors
      public GrLineModel() { }
      #endregion

      #region Methods
      public override void ParseNode(Node node)
      {
         if (node.Children != null)
         {
            var props = GetType().GetProperties();

            KiCadParseUtils.ParseNodes(props, node, this);
            KiCadParseUtils.ParseSubNodes(props, node, this);
         }
      }
      #endregion

      #region Full Props

      #endregion
   }
}
