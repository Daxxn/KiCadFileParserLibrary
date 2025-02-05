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

namespace KiCadFileParserLibrary.KiCad.General.Graphics
{
   [SExprNode("format")]
   public class DimensionFormatModel : Model, IKiCadReadable
   {
      #region Local Props
      private string _prefix = "";
      private string _suffix = "";
      private UnitsType _units;
      private UnitsFormat _unitsFormat;
      private int _precision;
      private string? _overrideValue;
      private bool _suppressZeros;
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
      [SExprSubNode("prefix")]
      public string Prefix
      {
         get => _prefix;
         set
         {
            _prefix = value;
            OnPropertyChanged();
         }
      }

      [SExprSubNode("suffix")]
      public string Suffix
      {
         get => _suffix;
         set
         {
            _suffix = value;
            OnPropertyChanged();
         }
      }

      [SExprSubNode("units")]
      public UnitsType Units
      {
         get => _units;
         set
         {
            _units = value;
            OnPropertyChanged();
         }
      }

      [SExprSubNode("units_format")]
      public UnitsFormat UnitsFormat
      {
         get => _unitsFormat;
         set
         {
            _unitsFormat = value;
            OnPropertyChanged();
         }
      }

      [SExprSubNode("precision")]
      public int Precision
      {
         get => _precision;
         set
         {
            _precision = value;
            OnPropertyChanged();
         }
      }

      [SExprSubNode("override_value")]
      public string? OverrideValue
      {
         get => _overrideValue;
         set
         {
            _overrideValue = value;
            OnPropertyChanged();
         }
      }

      [SExprToken("suppress_zeros")]
      public bool SuppressZeros
      {
         get => _suppressZeros;
         set
         {
            _suppressZeros = value;
            OnPropertyChanged();
         }
      }
      #endregion
   }
}
