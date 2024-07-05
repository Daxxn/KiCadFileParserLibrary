using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.Footprints.SubModels;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

namespace KiCadFileParserLibrary.KiCad.General.Graphics
{
   [SExprNode("bezier")]
   public class GrCurveModel : GraphicBase
   {
      #region Local Props
      public CoordinateModel? Points { get; set; }

      [SExprSubNode("layer")]
      public string? Layer { get; set; }

      [SExprSubNode("width")]
      public double? Width { get; set; }

      [SExprSubNode("uuid")]
      public string? ID { get; set; }
      #endregion

      #region Constructors
      public GrCurveModel() { }
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

      public override void WriteNode(StringBuilder builder, int indent, string? auxName = null)
      {
         throw new NotImplementedException();
      }
      #endregion

      #region Full Props

      #endregion
   }
}
