using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

namespace KiCadFileParserLibrary.KiCad.Boards.SubModels
{
   [SExprNode("teardrops")]
   public class TeardropModel : IKiCadReadable
   {
      #region Local Props
      [SExprSubNode("best_length_ratio")]
      public double BestLengthRatio { get; set; }

      [SExprSubNode("max_length")]
      public double MaxLength { get; set; }

      [SExprSubNode("best_width_ratio")]
      public double BestWidthRatio { get; set; }

      [SExprSubNode("max_width")]
      public double MaxWidth { get; set; }

      [SExprSubNode("curve_points")]
      public int CurvePoints { get; set; }

      [SExprSubNode("filter_ratio")]
      public double FilterRatio { get; set; }

      [SExprSubNode("enabled")]
      public bool Enable { get; set; }

      [SExprSubNode("allow_two_segments")]
      public bool AllowTwoSegments { get; set; }

      [SExprSubNode("prefer_zone_connections")]
      public bool PreferZoneConn { get; set; }
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
         builder.Append($"(teardrops");

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

      #endregion
   }
}
