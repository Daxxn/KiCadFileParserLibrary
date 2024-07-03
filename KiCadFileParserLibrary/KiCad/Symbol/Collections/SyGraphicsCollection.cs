using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.KiCad.Symbol.Graphics;
using KiCadFileParserLibrary.SExprParser;

namespace KiCadFileParserLibrary.KiCad.Symbol.Collections
{
   [SExprListNode("graphics")]
   public class SyGraphicsCollection : IKiCadReadable
   {
      #region Local Props
      private static readonly Dictionary<string, Func<SyGraphicBase>> GraphicsNodes = new()
      {
         { "text", () => new SyTextModel() },
         { "text_box", () => new SyTextBoxModel() },
         { "polyline", () => new SyLineModel() },
         { "rectangle", () => new SyRectangleModel() },
         { "circle", () => new SyCircleModel() },
         { "arc", () => new SyArcModel() },
         { "bezier", () => new SyCurveModel() },
      };

      public List<SyGraphicBase>? Graphics { get; set; }
      #endregion

      #region Constructors
      public SyGraphicsCollection() { }
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
