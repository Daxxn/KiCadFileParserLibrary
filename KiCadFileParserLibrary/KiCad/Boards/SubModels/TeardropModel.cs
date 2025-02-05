using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

using MVVMLibrary;

namespace KiCadFileParserLibrary.KiCad.Boards.SubModels
{
   [SExprNode("teardrops")]
   public class TeardropModel : Model, IKiCadReadable
   {
      #region Local Props
      private double _bestLengthRatio;
      private double _maxLength;
      private double _bestWidthRatio;
      private double _maxWidth;
      private int _curvePoints;
      private double _filterRatio;
      private bool _enable;
      private bool _allowTwoSeg;
      private bool _preferZoneConn;
      #endregion

      #region Constructors
      public TeardropModel() { }
      #endregion

      #region Methods
      public void ParseNode(Node node)
      {
         if (node.Children != null)
         {
            var props = GetType().GetProperties();
            KiCadParseUtils.ParseSubNodes(props, node, this);
         }
      }

      public void WriteNode(StringBuilder builder, int indent, string? auxName = null)
      {
         builder.Append('\t', indent);
         builder.AppendLine($"(teardrops");

         builder.Append('\t', indent + 1);
         builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("best_length_ratio", BestLengthRatio));

         builder.Append('\t', indent + 1);
         builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("max_length", MaxLength));

         builder.Append('\t', indent + 1);
         builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("best_width_ratio", BestWidthRatio));

         builder.Append('\t', indent + 1);
         builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("max_width", MaxWidth));

         builder.Append('\t', indent + 1);
         builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("curve_points", CurvePoints));

         builder.Append('\t', indent + 1);
         builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("filter_ratio", FilterRatio));

         builder.Append('\t', indent + 1);
         builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("enabled", Enable));

         builder.Append('\t', indent + 1);
         builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("allow_two_segments", AllowTwoSegments));

         builder.Append('\t', indent + 1);
         builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("prefer_zone_connections", PreferZoneConn));

         builder.Append('\t', indent);
         builder.AppendLine(")");
      }
      #endregion

      #region Full Props
      [SExprSubNode("best_length_ratio")]
      public double BestLengthRatio
      {
         get => _bestLengthRatio;
         set
         {
            _bestLengthRatio = value;
            OnPropertyChanged();
         }
      }

      [SExprSubNode("max_length")]
      public double MaxLength
      {
         get => _maxLength;
         set
         {
            _maxLength = value;
            OnPropertyChanged();
         }
      }

      [SExprSubNode("max_width")]
      public double MaxWidth
      {
         get => _maxWidth;
         set
         {
            _maxWidth = value;
            OnPropertyChanged();
         }
      }

      [SExprSubNode("best_width_ratio")]
      public double BestWidthRatio
      {
         get => _bestWidthRatio;
         set
         {
            _bestWidthRatio = value;
            OnPropertyChanged();
         }
      }

      [SExprSubNode("curve_points")]
      public int CurvePoints
      {
         get => _curvePoints;
         set
         {
            _curvePoints = value;
            OnPropertyChanged();
         }
      }

      [SExprSubNode("filter_ratio")]
      public double FilterRatio
      {
         get => _filterRatio;
         set
         {
            _filterRatio = value;
            OnPropertyChanged();
         }
      }

      [SExprSubNode("enabled")]
      public bool Enable
      {
         get => _enable;
         set
         {
            _enable = value;
            OnPropertyChanged();
         }
      }

      [SExprSubNode("allow_two_segments")]
      public bool AllowTwoSegments
      {
         get => _allowTwoSeg;
         set
         {
            _allowTwoSeg = value;
            OnPropertyChanged();
         }
      }

      [SExprSubNode("prefer_zone_connections")]
      public bool PreferZoneConn
      {
         get => _preferZoneConn;
         set
         {
            _preferZoneConn = value;
            OnPropertyChanged();
         }
      }
      #endregion
   }
}
