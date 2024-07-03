using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

namespace KiCadFileParserLibrary.KiCad.General.Graphics
{
    [SExprNode("render_cache")]
   public class RenderCacheModel : IKiCadReadable
   {
      #region Local Props
      [SExprProperty(1)]
      public string? Text { get; set; }

      [SExprProperty(2)]
      public int Index { get; set; }

      public PolygonModel? Polygon { get; set; }
      #endregion

      #region Constructors
      public RenderCacheModel() { }
      #endregion

      #region Methods
      public void ParseNode(Node node)
      {
         if (node.Properties != null && node.Children != null)
         {
            var props = GetType().GetProperties();

            KiCadParseUtils.ParseProperties(props, node, this);
            KiCadParseUtils.ParseNodes(props, node, this);
         }
      }
      #endregion

      #region Full Props

      #endregion
   }
}
