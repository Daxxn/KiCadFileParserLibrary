using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

namespace KiCadFileParserLibrary.KiCad.General.Graphics
{
   [SExprNode("format")]
   public class DimensionFormatModel : IKiCadReadable
   {
      #region Local Props
      [SExprSubNode("prefix")]
      public string Prefix { get; set; } = "";

      [SExprSubNode("suffix")]
      public string Suffix { get; set; } = "";

      [SExprSubNode("units")]
      public UnitsType Units { get; set; }

      [SExprSubNode("units_format")]
      public UnitsFormat UnitsFormat { get; set; }

      [SExprSubNode("precision")]
      public int Precision { get; set; }

      [SExprSubNode("override_value")]
      public string? OverrideValue { get; set; }

      [SExprToken("suppress_zeros")]
      public bool SuppressZeros { get; set; }
      #endregion

      #region Constructors
      public DimensionFormatModel() { }
      #endregion

      #region Methods
      public void ParseNode(Node node)
      {
         if (node.Children != null)
         {
            var props = GetType().GetProperties();

            KiCadParseUtils.ParseSubNodes(props, node, this);
            KiCadParseUtils.ParseTokens(props, node, this);
         }
      }

      public void WriteNode(StringBuilder builder, int indent, string? auxName = null)
      {
         builder.Append('\t', indent);
         builder.AppendLine("(format");

         builder.Append('\t', indent + 1);
         builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("prefix", Prefix));

         builder.Append('\t', indent + 1);
         builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("suffix", Suffix));

         builder.Append('\t', indent + 1);
         builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("units", (int)Units));

         builder.Append('\t', indent + 1);
         builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("units_format", (int)UnitsFormat));

         builder.Append('\t', indent + 1);
         builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("precision", Precision));

         if (OverrideValue != null)
         {
            builder.Append('\t', indent + 1);
            builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("override_value", OverrideValue));
         }

         if (SuppressZeros)
         {
            builder.Append('\t', indent + 1);
            builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("suppress_zeros", SuppressZeros));
         }

         builder.Append('\t', indent);
         builder.AppendLine(")");
      }
      #endregion

      #region Full Props

      #endregion
   }
}
