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
   [SExprNode("comment")]
   public class CommentModel : IKiCadReadable
   {
      [SExprProperty(1)]
      public int Index { get; set; }
      [SExprProperty(2)]
      public string Comment { get; set; } = "";

      public void ParseNode(Node node)
      {
         if (node.Properties != null)
         {
            var props = GetType().GetProperties();
            KiCadParseUtils.ParseProperties(props, node, this);
            //foreach (var prop in props)
            //{
            //   var attr = prop.GetCustomAttribute<SExprPropertyAttribute>();
            //   if (attr != null)
            //   {
            //      if (node.Properties.Count > attr.PropertyIndex)
            //      {
            //         prop.SetValue(this, PropertyParser.Parse(node.Properties[attr.PropertyIndex], prop));
            //      }
            //   }
            //}
         }
      }
   }
}
