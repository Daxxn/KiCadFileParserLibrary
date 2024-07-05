using System;
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
   [SExprNode("pts")]
   public class CoordinateModel : IKiCadReadable
   {
      #region Local Props
      public List<XyModel> Points { get; set; } = [];
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

      public void WriteNode(StringBuilder builder, int indent, string? auxName = null)
      {
         builder.Append('\t', indent);
         builder.AppendLine($"({auxName ?? "pts"}");
         foreach (var point in Points)
         {
            point.WriteNode(builder, indent + 1);
         }
         builder.Append('\t', indent);
         builder.AppendLine(")");
      }
      #endregion

      #region Full Props

      #endregion
   }
}
