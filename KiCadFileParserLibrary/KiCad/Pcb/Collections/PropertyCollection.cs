using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.Footprints.SubModels;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.SExprParser;

namespace KiCadFileParserLibrary.KiCad.Pcb.Collections
{
    [SExprListNode("property")]
   public class PropertyCollection : IKiCadReadable
   {
      #region Local Props
      public List<PropertyModel>? Properties { get; set; }
      #endregion

      #region Constructors
      public PropertyCollection() { }
      #endregion

      #region Methods
      public void ParseNode(Node node)
      {
         var children = node.GetNodes("property");
         if (children is null) return;
         Properties = [];
         foreach (var child in children)
         {
            PropertyModel prop = new();
            prop.ParseNode(child);
            Properties.Add(prop);
         }
      }
      #endregion

      #region Full Props

      #endregion
   }
}
