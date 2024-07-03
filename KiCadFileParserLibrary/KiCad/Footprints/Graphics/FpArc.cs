using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.General;
using KiCadFileParserLibrary.KiCad.General.Graphics;
using KiCadFileParserLibrary.KiCad.Pcb;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

namespace KiCadFileParserLibrary.KiCad.Footprints.Graphics
{
   [SExprNode("fp_arc")]
   public class FpArc : GrArcModel
   {
      #region Local Props
      //[SExprSubNode("start")]
      //public XyModel? Start { get; set; }

      //[SExprSubNode("mid")]
      //public XyModel? Middle { get; set; }

      //[SExprSubNode("end")]
      //public XyModel? End { get; set; }

      //[SExprSubNode("layer")]
      //public string? Layer { get; set; }

      //[SExprSubNode("uuid")]
      //public string? ID { get; set; }

      //[SExprToken("locked")]
      //public bool Locked { get; set; }

      //public StrokeModel? Stroke { get; set; }
      #endregion

      #region Constructors
      public FpArc() { }
      #endregion

      #region Methods
      //public override void ParseNode(Node node)
      //{
      //   if (node.Children != null && node.Properties != null)
      //   {
      //      var props = GetType().GetProperties();
      //      KiCadParseUtils.ParseNodes(props, node, this);
      //      KiCadParseUtils.ParseSubNodes(props, node, this);
      //      KiCadParseUtils.ParseTokens(props, node, this);
      //   }
      //}
      #endregion

      #region Full Props

      #endregion
   }
}
