using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

namespace KiCadFileParserLibrary.KiCad.General
{
   [SExprNode("property")]
   public class GenericProperty : IKiCadReadable
   {
      #region Local Props
      [SExprProperty(1)]
      public string? Key { get; set; }

      [SExprProperty(2)]
      public string? Value { get; set; }
      #endregion

      #region Constructors
      public GenericProperty() { }
      #endregion

      #region Methods
      public void ParseNode(Node node)
      {
         if (node.Properties is null) return;
         var props = GetType().GetProperties();
         KiCadParseUtils.ParseProperties(props, node, this);
      }
      #endregion

      #region Full Props

      #endregion
   }
}
