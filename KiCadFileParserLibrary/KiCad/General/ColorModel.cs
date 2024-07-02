using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.Pcb;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

namespace KiCadFileParserLibrary.KiCad.General
{
   [SExprSubNode("color")]
   public class ColorModel : IKiCadReadable
   {
      #region Local Props
      public double? Red { get; set; }

      public double? Green { get; set; }

      public double? Blue { get; set; }

      public double? Alpha { get; set; }
      #endregion

      #region Constructors
      public ColorModel() { }
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
