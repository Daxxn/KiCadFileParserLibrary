using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.Footprints.Graphics;
using KiCadFileParserLibrary.KiCad.Footprints.SubModels;
using KiCadFileParserLibrary.KiCad.Pcb;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

namespace KiCadFileParserLibrary.KiCad.General.Graphics
{
   [SExprNode("dimension")]
   public class DimensionModel : GraphicBase
   {
      #region Local Props
      [SExprToken("locked")]
      public bool Locked { get; set; }

      [SExprSubNode("type")]
      public DimensionType Type { get; set; }

      [SExprSubNode("layer")]
      public string? Layer { get; set; }

      [SExprSubNode("height")]
      public double? Height { get; set; }

      [SExprSubNode("uuid")]
      public string? ID { get; set; }

      public CoordinateModel? Points { get; set; }

      [SExprSubNode("leader_length")]
      public double? LeaderLength { get; set; }

      public GrTextModel? Text { get; set; }

      public DimensionStyleModel? Style { get; set; }

      public DimensionFormatModel? Format { get; set; }
      #endregion

      #region Constructors
      public DimensionModel() { }
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
