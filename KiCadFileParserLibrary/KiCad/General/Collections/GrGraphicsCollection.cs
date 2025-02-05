using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.General.Graphics;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.SExprParser;

using MVVMLibrary;

namespace KiCadFileParserLibrary.KiCad.General.Collections
{
   [SExprListNode("gr_*")]
   public class GrGraphicsCollection : Model, IKiCadReadable
   {
      #region Local Props
      private static readonly Dictionary<string, Func<GraphicBase>> GraphicsNodes = new()
      {
         { "gr_text", () => new GrTextModel() },
         { "gr_text_box", () => new GrTextBoxModel() },
         { "gr_line", () => new GrLineModel() },
         { "gr_rect", () => new GrRectangleModel() },
         { "gr_circle", () => new GrCircleModel() },
         { "gr_arc", () => new GrArcModel() },
         { "gr_poly", () => new GrPolygonModel() },
         { "bezier", () => new GrCurveModel() },
         { "dimension", () => new DimensionModel() },
      };

      private ObservableCollection<GraphicBase>? _graphics;
      #endregion

      #region Constructors
      public GrGraphicsCollection() { }
      #endregion

      #region Methods
      public void ParseNode(Node node)
      {
         if (node.Children != null)
         {
            List<GraphicBase> graphics = [];
            foreach (var child in node.Children)
            {
               if (GraphicsNodes.ContainsKey(child.Type))
               {
                  var newItem = GraphicsNodes[child.Type]();
                  newItem.ParseNode(child);
                  graphics.Add(newItem);
               }
            }
            if (graphics.Count > 0)
            {
               Graphics = new(graphics);
            }
         }
      }

      public void WriteNode(StringBuilder builder, int indent, string? auxName = null)
      {
         if (Graphics == null) return;
         foreach (var graphic in Graphics)
         {
            graphic.WriteNode(builder, indent);
         }
      }

      public override string ToString()
      {
         return $"Graphics - {Graphics?.Count}";
      }
      #endregion

      #region Full Props
      public ObservableCollection<GraphicBase>? Graphics
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
