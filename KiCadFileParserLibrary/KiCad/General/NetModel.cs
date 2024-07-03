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
    [SExprNode("net")]
   public class NetModel : IKiCadReadable
   {
      #region Local Props
      [SExprProperty(1)]
      public int NetIndex { get; set; }

      [SExprProperty(2)]
      public string? NetName { get; set; }
      #endregion

      #region Constructors
      public NetModel() { }
      #endregion

      #region Methods
      public void ParseNode(Node node)
      {
         if (node.Properties != null)
         {
            var props = GetType().GetProperties();
            KiCadParseUtils.ParseProperties(props, node, this);
         }
      }
      #endregion

      #region Full Props

      #endregion
   }
}
