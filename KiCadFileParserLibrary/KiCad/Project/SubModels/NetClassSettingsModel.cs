using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace KiCadFileParserLibrary.KiCad.Project.SubModels
{
   public class NetClassSettingsModel
   {
      #region Local Props
      [JsonProperty(PropertyName = "bus_width")]
      public int BusWidth { get; set; }

      [JsonProperty(PropertyName = "clearance")]
      public double Clearance { get; set; }

      [JsonProperty(PropertyName = "diff_pair_gap")]
      public double DiffParGap { get; set; }

      [JsonProperty(PropertyName = "diff_pair_via_gap")]
      public double DiffPairViaGap { get; set; }

      [JsonProperty(PropertyName = "diff_pair_width")]
      public double DiffPairWidth { get; set; }

      [JsonProperty(PropertyName = "line_style")]
      public int LineStyle { get; set; } // Should be an enum...

      [JsonProperty(PropertyName = "microvia_diameter")]
      public double MicroviaDiameter { get; set; }

      [JsonProperty(PropertyName = "microvia_drill")]
      public double MicroviaDrill { get; set; }

      [JsonProperty(PropertyName = "name")]
      public string? Name { get; set; }

      [JsonProperty(PropertyName = "pcb_color")]
      public string? PcbColor { get; set; }

      [JsonProperty(PropertyName = "schematic_color")]
      public string? SchematicColor { get; set; }

      [JsonProperty(PropertyName = "track_width")]
      public double TrackWidth { get; set; }

      [JsonProperty(PropertyName = "via_diameter")]
      public double ViaDiameter { get; set; }

      [JsonProperty(PropertyName = "via_drill")]
      public double ViaDrill { get; set; }

      [JsonProperty(PropertyName = "wire_width")]
      public int WireWidth { get; set; }
      #endregion

      #region Constructors
      public NetClassSettingsModel() { }
      #endregion

      #region Methods

      #endregion

      #region Full Props

      #endregion
   }
}
