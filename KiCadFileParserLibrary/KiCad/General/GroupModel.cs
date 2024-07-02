using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.Footprints;
using KiCadFileParserLibrary.KiCad.Pcb;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

namespace KiCadFileParserLibrary.KiCad.General
{
   [SExprNode("group")]
   public class GroupModel : IKiCadReadable
   {
      #region Local Props
      [SExprProperty(1)]
      public string? Name { get; set; }

      [SExprSubNode("uuid")]
      public string? ID { get; set; }

      [SExprPropArray("members")]
      public List<string>? Members { get; set; }
      #endregion

      #region Constructors
      public GroupModel() { }
      #endregion

      #region Methods
      public void ParseNode(Node node)
      {
         if (node.Properties != null && node.Children != null)
         {
            var props = GetType().GetProperties();

            KiCadParseUtils.ParseProperties(props, node, this);
            KiCadParseUtils.ParseSubNodes(props, node, this);

            var arrProps = props.Where(p => p.PropertyType.GetCustomAttribute<SExprPropArrayAttribute>() != null);
            foreach (var cProp in arrProps)
            {
               var n = node.GetNode(cProp.GetCustomAttribute<SExprPropArrayAttribute>()!.XPath);
               if (n != null)
               {
                  if (n.Properties is null) break;
                  var newArr = new List<string>();
                  foreach (var p in n.Properties)
                  {
                     newArr.Add(p);
                  }
                  cProp.SetValue(this, newArr);
               }
            }
         }
      }
      #endregion

      #region Full Props

      #endregion
   }
}
