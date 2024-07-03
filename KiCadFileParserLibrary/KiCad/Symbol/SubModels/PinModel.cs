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
   [SExprNode("pin")]
   public class PinModel : IKiCadReadable
   {
      #region Local Props
      [SExprProperty(1)]
      public PinElectricalType ElectricalType { get; set; }

      [SExprProperty(2)]
      public PinGraphicStyle GraphicalStyle { get; set; }

      public LocationModel? Location { get; set; }

      [SExprSubNode("length")]
      public double? Length { get; set; }

      [SExprNode("name")]
      public PinTextModel? Name { get; set; }

      [SExprNode("number")]
      public PinTextModel? Number { get; set; }
      #endregion

      #region Constructors
      public PinModel() { }
      #endregion

      #region Methods
      public void ParseNode(Node node)
      {
         if (node.Properties != null && node.Children != null)
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
