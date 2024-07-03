using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.General;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.KiCad.Pcb.SubModels;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

namespace KiCadFileParserLibrary.KiCad.Pcb
{
    [SExprNode("segment")]
   public class TraceSegmentModel : IKiCadReadable
   {
      #region Local Props
      [SExprNode("start")]
      public LocationModel? Start { get; set; }

      [SExprNode("end")]
      public LocationModel? End { get; set; }

      [SExprSubNode("width")]
      public double? Width { get; set; }

      [SExprSubNode("layer")]
      public string? Layer { get; set; }

      [SExprToken("locked")]
      public bool Locked { get; set; }

      [SExprSubNode("net")]
      public int? NetIndex { get; set; }

      [SExprSubNode("uuid")]
      public string? ID { get; set; }
      #endregion

      #region Constructors
      public TraceSegmentModel() { }
      #endregion

      #region Methods
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

      #region Full Props

      #endregion
   }
}
