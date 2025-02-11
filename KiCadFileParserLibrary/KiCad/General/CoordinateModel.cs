using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.General.Collections;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

using MVVMLibrary;

namespace KiCadFileParserLibrary.KiCad.General
{
   [SExprNode("pts")]
   public class CoordinateModel : Model, IKiCadReadable
   {
      #region Local Props
      //private ObservableCollection<XyModel> _points = [];
      private PointCollection _points = new();
      #endregion

      #region Constructors
      public CoordinateModel() { }
      #endregion

      #region Methods
      public void ParseNode(Node node)
      {
         if (node.Children != null)
         {
            var props = GetType().GetProperties();

            KiCadParseUtils.ParseListNodes(props, node, this);
         }
         //if (node.Children is null) return;
         //Coordinates = [];
         //foreach (var child in node.Children)
         //{
         //   if (child.Type == "xy")
         //   {
         //      var xy = new XyModel();
         //      xy.ParseNode(child);
         //      Coordinates.Add(xy);
         //   }
         //}
      }

      //public void WriteNode(StringBuilder builder, int indent, string? auxName = null)
      //{
      //   builder.Append('\t', indent);
      //   builder.AppendLine($"({auxName ?? "pts"}");
      //   //if (auxName is null)
      //   //{
      //   //   var extraPoints = Coordinates.Count % 4;
      //   //   var div = Math.Floor(Coordinates.Count / 4.0);
      //   //   for (int i = 0; i < Coordinates.Count - 4; i += 4)
      //   //   {
      //   //      builder.Append('\t', indent + 1);
      //   //      Coordinates[i].WriteNode(builder, indent + 1);
      //   //      builder.Append(' ');
      //   //      Coordinates[i + 1].WriteNode(builder, indent + 1);
      //   //      builder.Append(' ');
      //   //      Coordinates[i + 2].WriteNode(builder, indent + 1);
      //   //      builder.Append(' ');
      //   //      Coordinates[i + 3].WriteNode(builder, indent + 1);
      //   //      builder.AppendLine();
      //   //   }
      //   //   if (extraPoints != 0)
      //   //   {
      //   //      for (int i = 0; i < extraPoints; i++)
      //   //      {
      //   //         builder.Append('\t', indent + 1);
      //   //         Coordinates[(int)(div * 4) + i].WriteNode(builder, indent + 1);
      //   //         if (i != extraPoints - 1)
      //   //         {
      //   //            builder.Append(' ');
      //   //         }
      //   //      }
      //   //      builder.AppendLine();
      //   //   }
      //   //   else
      //   //   {
      //   //      for (int i = Coordinates.Count - 4; i < Coordinates.Count; i += 4)
      //   //      {
      //   //         builder.Append('\t', indent + 1);
      //   //         Coordinates[i].WriteNode(builder, indent + 1);
      //   //         builder.Append(' ');
      //   //         Coordinates[i + 1].WriteNode(builder, indent + 1);
      //   //         builder.Append(' ');
      //   //         Coordinates[i + 2].WriteNode(builder, indent + 1);
      //   //         builder.Append(' ');
      //   //         Coordinates[i + 3].WriteNode(builder, indent + 1);
      //   //         builder.AppendLine();
      //   //      }
      //   //   }
      //   //}
      //   //else
      //   //{
      //   //   foreach (var point in Coordinates)
      //   //   {
      //   //      point.WriteNode(builder, indent + 1);
      //   //      builder.AppendLine();
      //   //   }
      //   //}

      //   //foreach (var point in Coordinates)
      //   //{
      //   //   point.WriteNode(builder, indent + 1);
      //   //   //builder.AppendLine();
      //   //}

      //   builder.Append('\t', indent);
      //   builder.AppendLine(")");
      //}
      #endregion

      #region Full Props
      public PointCollection Points
      {
         get => _points;
         set
         {
            _points = value;
            OnPropertyChanged();
         }
      }
      #endregion
   }
}
