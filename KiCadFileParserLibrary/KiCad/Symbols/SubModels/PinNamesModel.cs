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

namespace KiCadFileParserLibrary.KiCad.Symbols.SubModels
{
   [SExprNode("pin_names")]
   public class PinNamesModel : Model, IKiCadReadable
   {
      #region Local Props
      private SymbolVisibility _vis;
      private double? _offset;
      #endregion

      #region Constructors
      public PinNamesModel() { }
      #endregion

      #region Methods
      public void ParseNode(Node node)
      {
         if (node.Children != null && node.Properties != null)
         {
            var props = GetType().GetProperties();
            KiCadParseUtils.ParseSubNodes(props, node, this);
            KiCadParseUtils.ParseTokens(props, node, this);
         }
      }

      public void WriteNode(StringBuilder builder, int indent, string? auxName = null)
      {
         throw new NotImplementedException();
      }
      #endregion

      #region Full Props
      [SExprToken("hide")]
      public SymbolVisibility Visible
      {
         get => _vis;
         set
         {
            _vis = value;
            OnPropertyChanged();
         }
      }

      [SExprSubNode("offset")]
      public double? Offset
      {
         get => _offset;
         set
         {
            _offset = value;
            OnPropertyChanged();
         }
      }
      #endregion
   }
}
