using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.General;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.SExprParser;

using MVVMLibrary;

namespace KiCadFileParserLibrary.KiCad.Footprints.SubModels
{
   [SExprNode("pts")]
   public class CoordinateModel : Model, IKiCadReadable
   {
      #region Local Props
      private ObservableCollection<XyModel> _points = [];
      public ObservableCollection<XyModel> Points
      {
         get => _points;
         set
         {
            _points = value;
            OnPropertyChanged();
         }
      }
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
         //if (auxName is null)
         //{
         //   var extraPoints = Points.Count % 4;
         //   var div = Math.Floor(Points.Count / 4.0);
         //   for (int i = 0; i < Points.Count - 4; i += 4)
         //   {
         //      builder.Append('\t', indent + 1);
         //      Points[i].WriteNode(builder, indent + 1);
         //      builder.Append(' ');
         //      Points[i + 1].WriteNode(builder, indent + 1);
         //      builder.Append(' ');
         //      Points[i + 2].WriteNode(builder, indent + 1);
         //      builder.Append(' ');
         //      Points[i + 3].WriteNode(builder, indent + 1);
         //      builder.AppendLine();
         //   }
         //   if (extraPoints != 0)
         //   {
         //      for (int i = 0; i < extraPoints; i++)
         //      {
         //         builder.Append('\t', indent + 1);
         //         Points[(int)(div * 4) + i].WriteNode(builder, indent + 1);
         //         if (i != extraPoints - 1)
         //         {
         //            builder.Append(' ');
         //         }
         //      }
         //      builder.AppendLine();
         //   }
         //   else
         //   {
         //      for (int i = Points.Count - 4; i < Points.Count; i += 4)
         //      {
         //         builder.Append('\t', indent + 1);
         //         Points[i].WriteNode(builder, indent + 1);
         //         builder.Append(' ');
         //         Points[i + 1].WriteNode(builder, indent + 1);
         //         builder.Append(' ');
         //         Points[i + 2].WriteNode(builder, indent + 1);
         //         builder.Append(' ');
         //         Points[i + 3].WriteNode(builder, indent + 1);
         //         builder.AppendLine();
         //      }
         //   }
         //}
         //else
         //{
         //   foreach (var point in Points)
         //   {
         //      point.WriteNode(builder, indent + 1);
         //      builder.AppendLine();
         //   }
         //}

         foreach (var point in Points)
         {
            point.WriteNode(builder, indent + 1);
            //builder.AppendLine();
         }

         builder.Append('\t', indent);
         builder.AppendLine(")");
      }
      #endregion

      #region Full Props

      #endregion
   }
}
