using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.General;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

using MVVMLibrary;

namespace KiCadFileParserLibrary.KiCad.Schematics.SubModels;

/// <summary>
/// Schematic Fill model
/// </summary>
[SExprNode("fill")]
public class FillModel : Model, IKiCadReadable
{
   #region Local Props
   //private SymbolFillType _fillType = SymbolFillType.None;
   private ColorModel _color = new();
   #endregion

   #region Constructors
   /// <inheritdoc/>
   public FillModel() { }
   #endregion

   #region Methods
   /// <inheritdoc/>
   public void ParseNode(Node node)
   {
      if (node.Children is null) return;
      var props = GetType().GetProperties();
      KiCadParseUtils.ParseSubNodes(props, node, this);
   }
   #endregion

   #region Full Props
   /// <summary>
   /// Color
   /// </summary>
   public ColorModel Color
   {
      get => _color;
      set
      {
         _color = value;
         OnPropertyChanged();
      }
   }
   #endregion
}
