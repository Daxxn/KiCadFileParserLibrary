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

namespace KiCadFileParserLibrary.KiCad.Symbol.SubModels
{
   [SExprNode("property")]
   public class SymbolProperty : IKiCadReadable
   {
      #region Local Props
      [SExprProperty(1)]
      public string? Key { get; set; }

      [SExprProperty(2)]
      public string? Value { get; set; }

      public LocationModel? Location { get; set; }

      public EffectsModel? Effects { get; set; }
      #endregion

      #region Constructors
      public SymbolProperty() { }
      #endregion

      #region Methods
      public void ParseNode(Node node)
      {
         if (node.Children != null && node.Properties != null)
         {
            var props = GetType().GetProperties();

            KiCadParseUtils.ParseNodes(props, node, this);
            KiCadParseUtils.ParseSubNodes(props, node, this);
            KiCadParseUtils.ParseProperties(props, node, this);
         }
      }
      #endregion

      #region Full Props

      #endregion
   }
}
