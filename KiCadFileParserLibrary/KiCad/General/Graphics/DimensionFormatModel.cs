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

namespace KiCadFileParserLibrary.KiCad.General.Graphics;

/// <summary>
/// <see cref="DimensionModel">Dimension</see> formatting.
/// </summary>
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
   /// <inheritdoc/>
   public DimensionFormatModel() { }
   #endregion

   #region Methods
   /// <inheritdoc/>
   public void ParseNode(Node node)
   {
      if (node.Children != null)
      {
         var props = GetType().GetProperties();

         KiCadParseUtils.ParseSubNodes(props, node, this);
         KiCadParseUtils.ParseTokens(props, node, this);
      }
   }
   #endregion

   #region Full Props
   /// <summary>
   /// Value display prefix format.
   /// </summary>
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

   /// <summary>
   /// Value display suffix format.
   /// </summary>
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

   /// <summary>
   /// Display units.
   /// </summary>
   [SExprSubNode("units")]
   [SExprFormatting(true, false)]
   public UnitsType Units
   {
      get => _units;
      set
      {
         _units = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Display units formatting.
   /// </summary>
   [SExprSubNode("units_format")]
   [SExprFormatting(true, false)]
   public UnitsFormat UnitsFormat
   {
      get => _unitsFormat;
      set
      {
         _unitsFormat = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Display precision.
   /// </summary>
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

   /// <summary>
   /// Value override.
   /// </summary>
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

   /// <summary>
   /// Suppress trailing zeros.
   /// </summary>
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
