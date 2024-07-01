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
   [SExprNode("general")]
   public class GeneralModel : IKiCadReadable
   {
      [SExprSubNode("thickness")]
      public double Thickness { get; set; } = 1.6;
      [SExprSubNode("legacy_teardrops")]
      public bool UseLegacyTeardrop { get; set; } = false;

      public void ParseNode(Node node)
      {
         var props = GetType().GetProperties().Where(p => p.GetCustomAttribute<SExprSubNodeAttribute>() != null);
         foreach (var prop in props)
         {
            var subNode = node.GetNode(prop.GetCustomAttribute<SExprSubNodeAttribute>()!.XPath);
            if (subNode != null)
            {
               if (subNode.Properties != null)
               {
                  prop.SetValue(this, PropertyParser.Parse(subNode.Properties[1], prop));
               }
            }
         }
      }
   }
}
