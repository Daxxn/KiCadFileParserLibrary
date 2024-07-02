using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.General;
using KiCadFileParserLibrary.KiCad.Pcb;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

namespace KiCadFileParserLibrary.KiCad.Footprints.SubModels
{
   [SExprNode("drill")]
   public class DrillModel : IKiCadReadable
   {
      #region Local Props
      public bool IsOval { get; set; }

      public double? Diameter { get; set; }

      public double? Width { get; set; }

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
            var offsetNode = node.GetNode("offset");
            if (offsetNode is null) return;

            if (offsetNode.Properties != null)
            {
               Offset = new();
               if (double.TryParse(node.Properties[1], out double x))
               {
                  Offset.X = x;
               }
               if (double.TryParse(node.Properties[2], out double y))
               {
                  Offset.Y = y;
               }
            }
         }
      }
      #endregion

      #region Full Props

      #endregion
   }
}
