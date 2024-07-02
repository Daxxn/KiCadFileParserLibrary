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
   [SExprNode("xyz")]
   public class XyzModel : IKiCadReadable
   {
      #region Local Props
      [SExprProperty(1)]
      public double? X { get; set; }

      [SExprProperty(2)]
      public double? Y { get; set; }

      [SExprProperty(3)]
      public double? Z { get; set; }
      #endregion

      #region Constructors
      public XyzModel() { }
      #endregion

      #region Methods
      public void ParseNode(Node node)
      {
         if (node.Properties != null)
         {
            var props = GetType().GetProperties();
            var pProps = props.Where(p => p.GetCustomAttribute<SExprPropertyAttribute>() != null);
            foreach (var prop in pProps)
            {
               var index = prop.GetCustomAttribute<SExprPropertyAttribute>()!.PropertyIndex;
               if (node.Properties.Count > index)
               {
                  prop.SetValue(this, PropertyParser.Parse(node.Properties[index], prop));
               }
            }
         }
      }
      #endregion

      #region Full Props

      #endregion
   }
}
