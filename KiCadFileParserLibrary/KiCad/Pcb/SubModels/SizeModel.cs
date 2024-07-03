using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

namespace KiCadFileParserLibrary.KiCad.Pcb.SubModels
{
    [SExprNode("size")]
   public class SizeModel : IKiCadReadable
   {
      #region Local Props
      [SExprProperty(1)]
      public double Width { get; set; }

      [SExprProperty(2)]
      public double Height { get; set; }
      #endregion

      #region Constructors
      public SizeModel() { }
      #endregion

      #region Methods
      public void ParseNode(Node node)
      {
         var props = GetType().GetProperties();
         if (node.Properties != null)
         {
            KiCadParseUtils.ParseProperties(props, node, this);
         }
      }
      #endregion

      #region Full Props

      #endregion
   }
}
