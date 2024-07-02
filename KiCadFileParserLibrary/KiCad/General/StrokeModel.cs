using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.Pcb;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

namespace KiCadFileParserLibrary.KiCad.General
{
   [SExprNode("stroke")]
   public class StrokeModel : IKiCadReadable
   {
      #region Local Props
      [SExprSubNode("width")]
      public double? Width { get; set; }

      [SExprSubNode("type")]
      public StrokeType? Type { get; set; }

      public ColorModel? Color { get; set; }
      #endregion

      #region Constructors
      public StrokeModel() { }
      #endregion

      #region Methods
      public void ParseNode(Node node)
      {
         if (node.Children != null)
         {
            var subNodeProps = GetType().GetProperties().Where(p => p.GetCustomAttribute<SExprSubNodeAttribute>() != null);
            foreach (var prop in subNodeProps)
            {
               var subNodeAttr = prop.GetCustomAttribute<SExprSubNodeAttribute>()!;
               var subNode = node.GetNode(subNodeAttr.XPath);
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
      #endregion

      #region Full Props

      #endregion
   }
}
