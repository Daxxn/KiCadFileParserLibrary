using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.KiCad.Symbols.Graphics;
using KiCadFileParserLibrary.SExprParser;

using MVVMLibrary;

namespace KiCadFileParserLibrary.KiCad.Symbols.Collections
{
   [SExprListNode("graphics")]
   public class SyGraphicsCollection : Model, IKiCadReadable
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

      private ObservableCollection<SyGraphicBase>? _graphics;
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

      public void WriteNode(StringBuilder builder, int indent, string? auxName = null)
      {
         throw new NotImplementedException();
      }
      #endregion

      #region Full Props
      public ObservableCollection<SyGraphicBase>? Graphics
      {
         get => _graphics;
         set
         {
            _graphics = value;
            OnPropertyChanged();
         }
      }
      #endregion
   }
}
