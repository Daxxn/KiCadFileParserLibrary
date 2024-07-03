using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.Footprints.Graphics;
using KiCadFileParserLibrary.KiCad.General;
using KiCadFileParserLibrary.KiCad.General.Graphics;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.SExprParser;

namespace KiCadFileParserLibrary.KiCad.Footprints.Collections
{
    [SExprListNode("fp_*")]
   public class FpGraphicsCollection : IKiCadReadable
   {
      #region Local Props
      private static readonly Dictionary<string, Func<GraphicBase>> GraphicsNodes = new()
      {
         { "fp_text", () => new FpText() },
         { "fp_text_box", () => new FpTextBox() },
         { "fp_line", () => new FpLine() },
         { "fp_rect", () => new FpRectangle() },
         { "fp_circle", () => new FpCircle() },
         { "fp_arc", () => new FpArc() },
         { "fp_poly", () => new FpPolygon() },
         { "fp_curve", () => new FpCurve() },
         { "dimension", () => new DimensionModel() },
      };

      public List<GraphicBase>? Graphics { get; set; }
      #endregion

      #region Constructors
      public FpGraphicsCollection() { }
      #endregion

      #region Methods
      public void ParseNode(Node node)
      {
         if (node.Children != null)
         {
            Graphics = [];
            foreach (var child in node.Children)
            {
               if (GraphicsNodes.TryGetValue(child.Type, out Func<GraphicBase>? value))
               {
                  var newItem = value();
                  newItem.ParseNode(child);
                  Graphics.Add(newItem);
               }
            }
         }
      }
      #endregion

      #region Full Props

      #endregion
   }
}
