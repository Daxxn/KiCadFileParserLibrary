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
using KiCadFileParserLibrary.Utils;

using MVVMLibrary;

namespace KiCadFileParserLibrary.KiCad.Footprints.Collections;

/// <summary>
/// List of <see cref="GraphicBase">Graphics</see> in a <see cref="Footprint">Footprint.</see>
/// </summary>
[SExprListNode("fp_*")]
public class FpGraphicsCollection : Model, IKiCadReadable, IKiCadWriteableCollection
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
   /// <inheritdoc/>
   public FpGraphicsCollection() { }
   #endregion

   #region Methods
   /// <inheritdoc/>
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

   /// <inheritdoc/>
   public override string ToString()
   {
      return $"FP Graphics - {Graphics?.Count}";
   }

   /// <inheritdoc/>
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
   /// <summary>
   /// List of <see cref="GraphicBase">Graphics.</see>
   /// </summary>
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
