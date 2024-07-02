using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.Footprints.Graphics;
using KiCadFileParserLibrary.KiCad.Footprints.SubModels;
using KiCadFileParserLibrary.KiCad.General.Graphics;
using KiCadFileParserLibrary.KiCad.Pcb;
using KiCadFileParserLibrary.SExprParser;

namespace KiCadFileParserLibrary.KiCad.General
{
   [SExprNode("dimension")]
   public class DimensionModel : FpGraphicBase
   {
      #region Local Props
      public bool? Locked { get; set; }

      public string? Layer { get; set; }

      public double? Height { get; set; }

      public CoordinateModel? Points { get; set; }

      public double? LeaderLength { get; set; }

      public GeneralTextModel? Text { get; set; }

      public DimensionStyleModel? Style { get; set; }
      #endregion

      #region Constructors
      public DimensionModel() { }
      #endregion

      #region Methods
      public override void ParseNode(Node node)
      {
         throw new NotImplementedException();
      }
      #endregion

      #region Full Props

      #endregion
   }
}
