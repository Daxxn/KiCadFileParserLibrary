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
   [SExprNode("gr_arc")]
   public class GrArcModel : GraphicBase
   {
      #region Local Props
      [SExprNode("start")]
      public XyModel? Start { get; set; }

      [SExprNode("mid")]
      public XyModel? Middle { get; set; }

      [SExprNode("end")]
      public XyModel? End { get; set; }

      public StrokeModel? Stroke { get; set; }

      [SExprNode("layer")]
      public string? Layer { get; set; }

      [SExprNode("uuid")]
      public string? ID { get; set; }

      [SExprSubNode("locked")]
      public bool Locked { get; set; }
      #endregion

      #region Constructors
      public GrArcModel() { }
      #endregion

      #region Methods
      public override void ParseNode(Node node)
      {
         if (node.Children != null)
         {
            var props = GetType().GetProperties();

            KiCadParseUtils.ParseSubNodes(props, node, this);
            KiCadParseUtils.ParseNodes(props, node, this);
         }
      }
      #endregion

      #region Full Props

      #endregion
   }
}
