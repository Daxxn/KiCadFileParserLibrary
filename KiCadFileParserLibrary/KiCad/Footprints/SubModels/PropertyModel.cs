using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.Pcb;
using KiCadFileParserLibrary.KiCad.Pcb.SubModels;
using KiCadFileParserLibrary.SExprParser;

namespace KiCadFileParserLibrary.KiCad.Footprints.SubModels
{
   [SExprNode("property")]
   public class PropertyModel : IKiCadReadable
   {
      #region Local Props
      [SExprProperty(0)]
      public string? Name { get; set; }

      [SExprProperty(1)]
      public string? Value { get; set; }

      public LocationModel? Coordinates { get; set; }

      [SExprSubNode("layer")]
      public string? Layer { get; set; }

      [SExprSubNode("uuid")]
      public string? ID { get; set; }

      [SExprSubNode("effects")]
      public EffectsModel? Effects { get; set; }
      #endregion

      #region Constructors
      public PropertyModel() { }
      #endregion

      #region Methods
      public void ParseNode(Node node)
      {

      }
      #endregion

      #region Full Props

      #endregion
   }
}
