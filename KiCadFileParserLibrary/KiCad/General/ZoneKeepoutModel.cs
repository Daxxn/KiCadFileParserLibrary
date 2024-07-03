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
    [SExprNode("keepout")]
   public class ZoneKeepoutModel : IKiCadReadable
   {
      #region Local Props
      [SExprSubNode("tracks")]
      public KeepoutType Tracks { get; set; }

      [SExprSubNode("vias")]
      public KeepoutType Vias { get; set; }

      [SExprSubNode("pads")]
      public KeepoutType Pads { get; set; }

      [SExprSubNode("copperpour")]
      public KeepoutType Copper { get; set; }

      [SExprSubNode("footprints")]
      public KeepoutType Footprints { get; set; }
      #endregion

      #region Constructors
      public ZoneKeepoutModel() { }
      #endregion

      #region Methods
      public void ParseNode(Node node)
      {
         if (node.Children != null)
         {
            var props = GetType().GetProperties();
            KiCadParseUtils.ParseSubNodes(props, node, this);
         }
      }
      #endregion

      #region Full Props

      #endregion
   }
}
