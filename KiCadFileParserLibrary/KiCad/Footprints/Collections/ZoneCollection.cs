using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.General;
using KiCadFileParserLibrary.KiCad.Pcb;
using KiCadFileParserLibrary.SExprParser;

namespace KiCadFileParserLibrary.KiCad.Footprints.Collections
{
   [SExprListNode("zone")]
   public class ZoneCollection : IKiCadReadable
   {
      #region Local Props
      public List<ZoneModel>? Zones { get; set; }
      #endregion

      #region Constructors
      public ZoneCollection() { }

      public void ParseNode(Node node)
      {
         var children = node.GetNodes("zone");
         if (children is null) return;
         Zones = [];
         foreach (var child in children)
         {
            ZoneModel zone = new();
            zone.ParseNode(child);
            Zones.Add(zone);
         }
      }
      #endregion

      #region Methods

      #endregion

      #region Full Props

      #endregion
   }
}
