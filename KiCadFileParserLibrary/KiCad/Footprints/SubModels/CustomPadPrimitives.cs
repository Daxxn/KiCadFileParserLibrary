using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.Footprints.Collections;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

namespace KiCadFileParserLibrary.KiCad.Footprints.SubModels
{
    [SExprNode("primitives")]
   public class CustomPadPrimitives : IKiCadReadable
   {
      #region Local Props
      [SExprSubNode("width")]
      public double? Width { get; set; }

      [SExprSubNode("fill")]
      public bool IsFilled { get; set; }

      [SExprSubNode("primitives")]
      public FpGraphicsCollection? Primitives { get; set; }
      #endregion

      #region Constructors
      public CustomPadPrimitives() { }
      #endregion

      #region Methods
      public void ParseNode(Node node)
      {
         if (node.Children != null)
         {
            var props = GetType().GetProperties();
            KiCadParseUtils.ParseSubNodes(props, node, this);
         }
      }
      #endregion

      #region Full Props

      #endregion
   }
}
