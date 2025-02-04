﻿using System;
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
   [SExprNode("fp_curve")]
   public class FpCurveModel : GraphicBase
   {
      #region Local Props
      [SExprSubNode("layer")]
      public string? Layer { get; set; }

      [SExprSubNode("width")]
      public double? Width { get; set; }

      [SExprToken("locked")]
      public bool? Locked { get; set; }

      [SExprSubNode("uuid")]
      public string? ID { get; set; }

      public CoordinateModel? Coordinates { get; set; }

      public StrokeModel? Stroke { get; set; }
      #endregion

      #region Constructors
      public FpCurveModel() { }

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

      public override void WriteNode(StringBuilder builder, int indent, string? auxName = null)
      {
         throw new NotImplementedException();
      }
      #endregion

      #region Full Props

      #endregion
   }
}
