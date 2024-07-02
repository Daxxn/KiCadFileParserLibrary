using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.General;
using KiCadFileParserLibrary.KiCad.Pcb;
using KiCadFileParserLibrary.SExprParser;

namespace KiCadFileParserLibrary.KiCad.Footprints.SubModels
{
   [SExprNode("pts")]
   public class CoordinateModel : IKiCadReadable
   {
      #region Local Props
      public List<XyModel>? Points { get; set; }
      #endregion

      #region Constructors
      public CoordinateModel() { }
      #endregion

      #region Methods
      public void ParseNode(Node node)
      {
         if (node.Children is null) return;
         Points = [];
         foreach (var child in node.Children)
         {
            if (child.Type == "xy")
            {
               var xy = new XyModel();
               xy.ParseNode(child);
               Points.Add(xy);
            }
         }
      }
      #endregion

      #region Full Props

      #endregion
   }
}
