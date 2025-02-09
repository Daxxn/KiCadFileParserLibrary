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
using KiCadFileParserLibrary.Utils;

using MVVMLibrary;

namespace KiCadFileParserLibrary.KiCad.Symbols.Collections
{
   [SExprListNode("graphics")]
   public class SyGraphicsCollection : Model, IKiCadReadable, IKiCadWriteableCollection
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

      public void WriteCollection(StringBuilder builder, int indent)
      {
         if (Graphics is null) return;

         foreach (var gr in Graphics)
         {
            KiCadWriteUtils2.WriteNode(gr, builder, indent);
         }
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
