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

namespace KiCadFileParserLibrary.KiCad.Pcb
{
    [SExprNode("arc")]
   public class TraceArcModel : IKiCadReadable
   {
      #region Local Props
      [SExprNode("start")]
      public LocationModel? Start { get; set; }

      [SExprNode("mid")]
      public LocationModel? Middle { get; set; }

      [SExprNode("end")]
      public LocationModel? End { get; set; }

      [SExprSubNode("width")]
      public string? Width { get; set; }

      [SExprSubNode("layer")]
      public string? Layer { get; set; }

      [SExprSubNode("net")]
      public int Net { get; set; } = 0;

      [SExprSubNode("uuid")]
      public string? ID { get; set; }

      [SExprToken("locked")]
      public bool Locked { get; set; }
      #endregion

      #region Constructors
      public TraceArcModel() { }

      public void ParseNode(Node node)
      {
         if (node.Properties != null && node.Children != null)
         {
            var props = GetType().GetProperties();

            KiCadParseUtils.ParseNodes(props, node, this);
            KiCadParseUtils.ParseSubNodes(props, node, this);
            KiCadParseUtils.ParseTokens(props, node, this);
         }
      }
      #endregion

      #region Methods

      #endregion

      #region Full Props

      #endregion
   }
}
