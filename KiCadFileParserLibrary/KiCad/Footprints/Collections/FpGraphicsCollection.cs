using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.Footprints.Graphics;
using KiCadFileParserLibrary.KiCad.General;
using KiCadFileParserLibrary.KiCad.Pcb;
using KiCadFileParserLibrary.SExprParser;

namespace KiCadFileParserLibrary.KiCad.Footprints.Collections
{
   [SExprListNode("fp_")]
   public class FpGraphicsCollection : IKiCadReadable
   {
      #region Local Props
      private static readonly string[] GraphicsNodeNames =
      {
         "fp_line", "fp_circle", "fp_rect", "fp_arc", "fp_curve", "fp_poly", "fp_text", "fp_text_box", "dimension"
      };

      private static readonly Dictionary<string, Func<FpGraphicBase>> GraphicsNodes = new()
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
      public List<FpGraphicBase>? Graphics { get; set; }
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
               if (GraphicsNodes.ContainsKey(child.Type))
               {
                  var newItem = GraphicsNodes[child.Type]();
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
