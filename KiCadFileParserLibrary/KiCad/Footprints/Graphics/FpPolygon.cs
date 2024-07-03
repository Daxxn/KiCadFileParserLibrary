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

namespace KiCadFileParserLibrary.KiCad.Footprints.Graphics
{
   [SExprNode("fp_poly")]
   public class FpPolygon : GrPolygonModel
   {
      #region Local Props
      //public CoordinateModel? Points { get; set; }

      //public StrokeModel? Stroke { get; set; }

      //[SExprSubNode("fill")]
      //public FillType Fill { get; set; }

      //[SExprSubNode("layer")]
      //public string? Layer { get; set; }

      //[SExprSubNode("uuid")]
      //public string? ID { get; set; }

      //[SExprToken("locked")]
      //public bool Locked { get; set; }
      #endregion

      #region Constructors
      public FpPolygon() { }
      #endregion

      #region Methods
      #endregion

      #region Full Props

      #endregion
   }
}
