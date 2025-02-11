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

namespace KiCadFileParserLibrary.KiCad.Footprints.SubModels
{
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
      public DrillModel() { }
      #endregion

      #region Methods
      //public void ParseNode(Node node)
      //{
      //   if (node.Properties != null)
      //   {
      //      if (node.Properties.Count > 1)
      //      {
      //         if (node.Properties[1] == "oval")
      //         {
      //            if (node.Properties.Count > 3)
      //            {
      //               Oval = true;
      //               if (double.TryParse(node.Properties[2], out double diam))
      //               {
      //                  Diameter = diam;
      //               }
      //               if (double.TryParse(node.Properties[3], out double width))
      //               {
      //                  Width = width;
      //               }
      //            }
      //         }
      //         else
      //         {
      //            Oval = false;
      //            if (double.TryParse(node.Properties[1], out double diam))
      //            {
      //               Diameter = diam;
      //            }
      //         }
      //      }
      //      var offsetNode = node.GetNode("offset");
      //      if (offsetNode is null) return;

      //      if (offsetNode.Properties != null)
      //      {
      //         if (offsetNode.Properties.Count == 3)
      //         {
      //            Offset = new();
      //            if (double.TryParse(offsetNode.Properties[1], out double x))
      //            {
      //               Offset.X = x;
      //            }
      //            if (double.TryParse(offsetNode.Properties[2], out double y))
      //            {
      //               Offset.Y = y;
      //            }
      //         }
      //      }
      //   }
      //}

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
}
