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
    public class LayerModel : IKiCadReadable
   {
      #region Local Props
      [SExprProperty(0)]
      public int Index { get; set; } = -1;
      [SExprProperty(1)]
      public string? Name { get; set; }
      [SExprProperty(2)]
      public LayerType Type { get; set; }
      [SExprProperty(3)]
      public string? FullName { get; set; }
      #endregion

      #region Constructors
      public LayerModel() { }

      public void ParseNode(Node node)
      {
         if (node.Properties is null) return;
         var props = GetType().GetProperties();
         foreach (var p in props)
         {
            var attr = p.GetCustomAttribute<SExprPropertyAttribute>();
            if (attr != null)
            {
               if (node.Properties.Count > attr.PropertyIndex)
               {
                  p.SetValue(this, PropertyParser.Parse(node.Properties[attr.PropertyIndex], p));
               }
            }
         }
      }
      #endregion

      #region Methods

      #endregion

      #region Full Props

      #endregion
   }
}
