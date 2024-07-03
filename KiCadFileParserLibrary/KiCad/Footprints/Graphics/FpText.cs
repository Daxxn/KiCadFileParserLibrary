using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.General;
using KiCadFileParserLibrary.KiCad.General.Graphics;
using KiCadFileParserLibrary.KiCad.Pcb;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

namespace KiCadFileParserLibrary.KiCad.Footprints.Graphics
{
    [SExprNode("fp_text")]
   public class FpText : GraphicBase
   {
      #region Local Props
      [SExprProperty(1)]
      public FootprintTextType Type { get; set; }

      [SExprProperty(2)]
      public string? Text { get; set; }

      public LocationModel? Location { get; set; }

      [SExprSubNode("unlocked")]
      public bool IsUnlocked { get; set; }

      public bool Knockout { get; set; }

      [SExprSubNode("layer")]
      public string? Layer { get; set; }

      [SExprSubNode("uuid")]
      public string? ID { get; set; }

      public EffectsModel? Effects { get; set; }

      public RenderCacheModel? RenderCache { get; set; }
      #endregion

      #region Constructors
      public FpText() { }
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

            // Added check for knockout param.
            // For some stupid reason, its in the "layer" node...
            var layerNode = node.GetNode("layer");
            if (layerNode?.Properties is null) return;
            if (layerNode?.Properties.Contains("Knockout") == true)
            {
               var knockoutProp = props.FirstOrDefault(p => p.Name == "Knockout");
               knockoutProp?.SetValue(this, layerNode.Properties[2]);
            }
         }
      }
      #endregion

      #region Full Props

      #endregion
   }
}
