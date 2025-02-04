using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.SExprParser;

namespace KiCadFileParserLibrary.KiCad.General.Collections
{
   [SExprListNode("zone")]
   public class ZoneCollection : IKiCadReadable
   {
      #region Local Props
      public List<ZoneModel> Zones { get; set; } = [];
      #endregion

      #region Constructors
      public ZoneCollection() { }
      #endregion

      #region Methods
      public void ParseNode(Node node)
      {
         var zoneNodes = node.GetNodes("zone");
         if (zoneNodes is null) return;
         Zones = [];
         foreach (var zoneNode in zoneNodes)
         {
            ZoneModel zone = new();
            zone.ParseNode(zoneNode);
            Zones.Add(zone);
         }
      }

      public void WriteNode(StringBuilder builder, int indent, string? auxName = null)
      {
         foreach (var zone in Zones)
         {
            zone.WriteNode(builder, indent);
         }
      }

      public override string ToString()
      {
         return $"Zones - {Zones.Count}";
      }
      #endregion

      #region Full Props

      #endregion
   }
}
