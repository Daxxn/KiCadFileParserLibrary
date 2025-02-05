using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.Footprints.Graphics;
using KiCadFileParserLibrary.KiCad.General.Graphics;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.SExprParser;

using MVVMLibrary;

namespace KiCadFileParserLibrary.KiCad.Footprints.Collections
{
   [SExprListNode("fp_*")]
   public class FpGraphicsCollection : Model, IKiCadReadable
   {
      #region Local Props
      private static readonly Dictionary<string, Func<GraphicBase>> GraphicsNodes = new()
      {
         { "fp_text", () => new FpTextModel() },
         { "fp_text_box", () => new FpTextBoxModel() },
         { "fp_line", () => new FpLineModel() },
         { "fp_rect", () => new FpRectangleModel() },
         { "fp_circle", () => new FpCircleModel() },
         { "fp_arc", () => new FpArcModel() },
         { "fp_poly", () => new FpPolygonModel() },
         { "fp_curve", () => new FpCurveModel() },
         { "dimension", () => new DimensionModel() },
      };

      private ObservableCollection<GraphicBase>? _graphics;
      #endregion

      #region Constructors
      public FpGraphicsCollection() { }
      #endregion

      #region Methods
      public void ParseNode(Node node)
      {
         if (node.Children != null)
         {
            List<GraphicBase> graphics = [];
            foreach (var child in node.Children)
            {
               if (GraphicsNodes.TryGetValue(child.Type, out Func<GraphicBase>? value))
               {
                  var newItem = value();
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
         if (Graphics is null) return;
         foreach (var gr in Graphics)
         {
            gr.WriteNode(builder, indent);
         }
      }

      public override string ToString()
      {
         return $"FP Graphics - {Graphics?.Count}";
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
