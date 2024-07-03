using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.General;
using KiCadFileParserLibrary.KiCad.General.Collections;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.KiCad.Pcb.SubModels;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

namespace KiCadFileParserLibrary.KiCad.Pcb
{
    [SExprNode("via")]
   public class ViaModel : IKiCadReadable
   {
      #region Local Props
      [SExprSubNode("type")]
      public ViaType Type { get; set; }

      public LocationModel? Location { get; set; }

      [SExprSubNode("size")]
      public double? Size { get; set; }

      [SExprSubNode("drill")]
      public double? Drill { get; set; }

      public LayerCollection? Layers { get; set; }

      [SExprToken("remove_unused_layers")]
      public bool RemoveUnusedLayers { get; set; }

      [SExprToken("keep_end_layers")]
      public bool KeepEndLayers { get; set; }

      [SExprSubNode("free")]
      public bool IsFree { get; set; }

      [SExprSubNode("net")]
      public string? Net { get; set; }

      [SExprSubNode("uuid")]
      public string? ID { get; set; }

      public TeardropModel? Teardrops { get; set; }
      #endregion

      #region Constructors
      public ViaModel() { }
      #endregion

      #region Methods
      public void ParseNode(Node node)
      {
         if (node.Properties != null && node.Children != null)
         {
            var props = GetType().GetProperties();

            KiCadParseUtils.ParseTokens(props, node, this);
            KiCadParseUtils.ParseNodes(props, node, this);
            KiCadParseUtils.ParseSubNodes(props, node, this);
         }
      }
      #endregion

      #region Full Props

      #endregion
   }
}
