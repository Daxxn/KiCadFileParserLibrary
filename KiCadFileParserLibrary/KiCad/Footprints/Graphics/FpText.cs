using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.Pcb;
using KiCadFileParserLibrary.KiCad.Pcb.SubModels;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

namespace KiCadFileParserLibrary.KiCad.Footprints.Graphics
{
   [SExprNode("fp_text")]
   public class FpText : FpGraphicBase, IKiCadReadable
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
      #endregion

      #region Constructors
      public FpText() { }
      #endregion

      #region Methods
      public void ParseNode(Node node)
      {
         var props = GetType().GetProperties();
         if (node.Properties != null)
         {
            var pProps = props.Where(p => p.GetCustomAttribute<SExprPropertyAttribute>() != null);
            foreach (var prop in pProps)
            {
               var propAttr = prop.GetCustomAttribute<SExprPropertyAttribute>();
               if (node.Properties.Count > propAttr!.PropertyIndex)
               {
                  prop.SetValue(this, PropertyParser.Parse(node.Properties[propAttr!.PropertyIndex], prop));
               }
            }

            var nProps = 
         }
      }
      #endregion

      #region Full Props

      #endregion
   }
}
