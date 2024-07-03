using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.Pcb;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

namespace KiCadFileParserLibrary.KiCad.General.Graphics
{
   public class GrTextModel : GraphicBase
   {
      #region Local Props
      [SExprSubNode("locked")]
      public bool Locked { get; set; }

      [SExprProperty(1)]
      public string? Text { get; set; }

      [SExprSubNode("layer")]
      public string? Layer { get; set; }

      public LocationModel? Location { get; set; }

      [SExprSubNode("uuid")]
      public string? ID { get; set; }

      public EffectsModel? Effects { get; set; }

      public RenderCacheModel? RenderCache { get; set; }
      #endregion

      #region Constructors
      public GrTextModel() { }
      #endregion

      #region Methods
      public override void ParseNode(Node node)
      {
         if (node.Children != null && node.Properties != null)
         {
            var props = GetType().GetProperties();

            KiCadParseUtils.ParseNodes(props, node, this);
            KiCadParseUtils.ParseSubNodes(props, node, this);
            KiCadParseUtils.ParseProperties(props, node, this);
         }
      }
      #endregion

      #region Full Props

      #endregion
   }
}
