using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.General;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

using MVVMLibrary;

namespace KiCadFileParserLibrary.KiCad.Footprints.SubModels;

/// <summary>
/// PTH pad drill data.
/// </summary>
[SExprNode("drill")]
public class DrillModel : Model, IKiCadReadable
{
   #region Local Props
   private DrillShapeType? _oval;
   private double? _diameter = null;
   private double? _width = null;
   private XyModel? _offset = null;
   #endregion

   #region Constructors
   /// <inheritdoc/>
   public DrillModel() { }
   #endregion

   #region Methods
   /// <inheritdoc/>
   public void ParseNode(Node node)
   {
      if (node.Properties != null)
      {
         var props = GetType().GetProperties();

         if (node.Properties.Count > 1)
         {
            if (node.Properties[1] == "oval")
            {
               if (node.Properties.Count > 3)
               {
                  Oval = DrillShapeType.Oval;
                  if (double.TryParse(node.Properties[2], out double diam))
                  {
                     Diameter = diam;
                  }
                  if (double.TryParse(node.Properties[3], out double width))
                  {
                     Width = width;
                  }
               }
            }
            else
            {
               Oval = null;
               if (double.TryParse(node.Properties[1], out double diam))
               {
                  Diameter = diam;
               }
            }
         }
         KiCadParseUtils.ParseNodes(props, node, this);
      }
      if (node.Children != null)
      {
         var props = GetType().GetProperties();
         KiCadParseUtils.ParseSubNodes(props, node, this);
      }
   }
   #endregion

   #region Full Props
   /// <summary>
   /// Drill shape type.
   /// <para/>
   /// Is either oval or circular (null).
   /// </summary>
   [SExprProperty(1)]
   [SExprFormatting(false, true)]
   public DrillShapeType? Oval
   {
      get => _oval;
      set
      {
         _oval = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Pad diameter.
   /// </summary>
   [SExprProperty(2)]
   public double? Diameter
   {
      get => _diameter;
      set
      {
         _diameter = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Pad width.
   /// <para/>
   /// Circular if equal to <seealso cref="Diameter"/>.
   /// </summary>
   [SExprProperty(3)]
   public double? Width
   {
      get => _width;
      set
      {
         _width = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Offsets the drill hole in the pad.
   /// </summary>
   [SExprNode("offset")]
   public XyModel? Offset
   {
      get => _offset;
      set
      {
         _offset = value;
         OnPropertyChanged();
      }
   }
   #endregion
}
