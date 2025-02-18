using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

using MVVMLibrary;

namespace KiCadFileParserLibrary.KiCad.General.Collections;

/// <summary>
/// List of <see cref="ZoneModel">Zones.</see>
/// </summary>
[SExprListNode("zone")]
public class ZoneCollection : Model, IKiCadReadable, IKiCadWriteableCollection
{
   #region Local Props
   private ObservableCollection<ZoneModel> _zones = [];
   #endregion

   #region Constructors
   /// <inheritdoc/>
   public ZoneCollection() { }
   #endregion

   #region Methods
   /// <inheritdoc/>
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

   /// <inheritdoc/>
   public override string ToString()
   {
      return $"Zones - {Zones.Count}";
   }

   /// <inheritdoc/>
   public void WriteCollection(StringBuilder builder, int indent)
   {
      foreach (var zone in Zones)
      {
         KiCadWriteUtils2.WriteNode(zone, builder, indent);
      }
   }
   #endregion

   #region Full Props
   /// <summary>
   /// List of <see cref="ZoneModel">Zones.</see>
   /// </summary>
   public ObservableCollection<ZoneModel> Zones
   {
      get => _zones;
      set
      {
         _zones = value;
         OnPropertyChanged();
      }
   }
   #endregion
}
