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

namespace KiCadFileParserLibrary.KiCad.Symbols.SubModels;

[SExprNode("fill")]
public class SymbolFillModel : Model, IKiCadReadable
{
   #region Local Props
   private FillType _type = FillType.None;
   #endregion

   #region Constructors
   public SymbolFillModel() { }
   #endregion

   #region Methods
   public void ParseNode(Node node)
   {
      if (node.Children is null) return;
      var props = GetType().GetProperties();
      KiCadParseUtils.ParseSubNodes(props, node, this);
   }
   #endregion

   #region Full Props
   [SExprSubNode("type")]
   public FillType Type
   {
      get => _type;
      set
      {
         _type = value;
         OnPropertyChanged();
      }
   }
   #endregion
}
