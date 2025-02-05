using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MVVMLibrary;

using Newtonsoft.Json;

namespace KiCadFileParserLibrary.KiCad.Project.SubModels
{
   public class NetClassSettingsModel : Model
   {
      #region Local Props
      private int _busWidth;
      private double _clearance;
      private double _diffPairGap;
      private double _diffPairViaGap;
      private double _diffPairWidth;
      private int _lineStyle;
      private double _microviaDiameter;
      private double _microviaDrill;
      private string? _name;
      private string? _pcbColor;
      private string? _schColor;
      private double _trackWidth;
      private double _viaDiam;
      private double _viaDrill;
      private int _wireWidth;
      #endregion

      #region Constructors
      public NetClassSettingsModel() { }
      #endregion

      #region Methods

      #endregion

      #region Full Props
      [JsonProperty(PropertyName = "bus_width")]
      public int BusWidth
      {
         get => _busWidth;
         set
         {
            _busWidth = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "clearance")]
      public double Clearance
      {
         get => _clearance;
         set
         {
            _clearance = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "diff_pair_gap")]
      public double DiffParGap
      {
         get => _diffPairGap;
         set
         {
            _diffPairGap = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "diff_pair_via_gap")]
      public double DiffPairViaGap
      {
         get => _diffPairViaGap;
         set
         {
            _diffPairViaGap = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "diff_pair_width")]
      public double DiffPairWidth
      {
         get => _diffPairWidth;
         set
         {
            _diffPairWidth = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "line_style")]
      public int LineStyle // Should be an enum...
      {
         get => _lineStyle;
         set
         {
            _lineStyle = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "microvia_diameter")]
      public double MicroviaDiameter
      {
         get => _microviaDiameter;
         set
         {
            _microviaDiameter = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "microvia_drill")]
      public double MicroviaDrill
      {
         get => _microviaDrill;
         set
         {
            _microviaDrill = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "name")]
      public string? Name
      {
         get => _name;
         set
         {
            _name = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "pcb_color")]
      public string? PcbColor
      {
         get => _pcbColor;
         set
         {
            _pcbColor = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "schematic_color")]
      public string? SchematicColor
      {
         get => _schColor;
         set
         {
            _schColor = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "track_width")]
      public double TrackWidth
      {
         get => _trackWidth;
         set
         {
            _trackWidth = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "via_diameter")]
      public double ViaDiameter
      {
         get => _viaDiam;
         set
         {
            _viaDiam = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "via_drill")]
      public double ViaDrill
      {
         get => _viaDrill;
         set
         {
            _viaDrill = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "wire_width")]
      public int WireWidth
      {
         get => _wireWidth;
         set
         {
            _wireWidth = value;
            OnPropertyChanged();
         }
      }
      #endregion
   }
}
