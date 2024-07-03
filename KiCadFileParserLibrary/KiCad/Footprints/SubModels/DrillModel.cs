﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.General;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.SExprParser;

namespace KiCadFileParserLibrary.KiCad.Footprints.SubModels
{
    [SExprNode("drill")]
   public class DrillModel : IKiCadReadable
   {
      #region Local Props
      public bool IsOval { get; set; }

      public double? Diameter { get; set; }

      public double? Width { get; set; }

      [SExprNode("offset")]
      public XyModel? Offset { get; set; }
      #endregion

      #region Constructors
      public DrillModel() { }
      #endregion

      #region Methods
      public void ParseNode(Node node)
      {
         if (node.Children != null && node.Properties != null)
         {
            if (node.Properties.Count > 1)
            {
               if (node.Properties[1] == "oval")
               {
                  if (node.Properties.Count > 3)
                  {
                     IsOval = true;
                     if (double.TryParse(node.Properties[1], out double diam))
                     {
                        Diameter = diam;
                     }
                     if (double.TryParse(node.Properties[2], out double width))
                     {
                        Width = width;
                     }
                  }
               }
               else
               {
                  IsOval = false;
                  if (double.TryParse(node.Properties[1], out double diam))
                  {
                     Diameter = diam;
                  }
               }
            }
            var offsetNode = node.GetNode("offset");
            if (offsetNode is null) return;

            if (offsetNode.Properties != null)
            {
               if (offsetNode.Properties.Count == 3)
               {
                  Offset = new();
                  if (double.TryParse(offsetNode.Properties[1], out double x))
                  {
                     Offset.X = x;
                  }
                  if (double.TryParse(offsetNode.Properties[2], out double y))
                  {
                     Offset.Y = y;
                  }
               }
            }
         }
      }
      #endregion

      #region Full Props

      #endregion
   }
}
