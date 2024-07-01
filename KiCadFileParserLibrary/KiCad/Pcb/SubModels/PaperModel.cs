using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

namespace KiCadFileParserLibrary.KiCad.Pcb.SubModels
{
   [SExprNode("paper")]
   public class PaperModel : IKiCadReadable
   {
      #region Local Props
      [SExprProperty(1)]
      public string? Name { get; set; }
      public bool IsCustomSize { get; set; }
      [SExprProperty(2)]
      public double Width { get; set; }
      [SExprProperty(3)]
      public double Height { get; set; }
      [SExprToken("portrait")]
      public bool IsPortrait { get; set; }
      #endregion

      #region Constructors
      public PaperModel() { }
      #endregion

      #region Methods
      public void ParseNode(Node node)
      {
         if (node.Properties != null)
         {
            if (node.Properties.Count == 2)
            {
               IsCustomSize = false;
            }

            var props = GetType().GetProperties();
            var mainProps = props.Where(p => p.GetCustomAttribute<SExprPropertyAttribute>() != null);
            foreach (var prop in mainProps)
            {
               var propAttr = prop.GetCustomAttribute<SExprPropertyAttribute>();
               if (node.Properties.Count > propAttr!.PropertyIndex)
               {
                  prop.SetValue(this, PropertyParser.Parse(node.Properties[propAttr!.PropertyIndex], prop));
               }
            }

            var tokenProps = props.Where(p => p.GetCustomAttribute<SExprTokenAttribute>() != null);
            foreach (var tProp in tokenProps)
            {
               if (node.Properties.Contains(tProp.GetCustomAttribute<SExprTokenAttribute>()!.TokenName))
               {
                  tProp.SetValue(this, true);
               }
            }
         }
      }
      #endregion

      #region Full Props

      #endregion
   }
}
