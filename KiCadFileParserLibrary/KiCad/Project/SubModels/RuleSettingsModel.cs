using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MVVMLibrary;

using Newtonsoft.Json;

namespace KiCadFileParserLibrary.KiCad.Project.SubModels
{
   public class RuleSettingsModel : Model
   {
      #region Local Props
      private double _maxError;
      private double _minClearance;
      private double _minConnection;
      private double _minCopperEdgeClearance;
      private double _minHoleClearance;
      private double _minHoleToHole;
      private double _minMicroviaDiameter;
      private double _minMicroviaDrill;
      private int _minResolvedSpokes;
      private double _minSilkClearance;
      private double _minTextHeight;
      private double _minTextThickness;
      private double _minThroughHoleDiameter;
      private double _minTrackWidth;
      private double _minViaAnnularWidth;
      private double _minViaDiameter;
      private double _solderMaskClearance;
      private double _solderMaskMinWidth;
      private double _solderMaskToCopperClearance;
      private bool _useHeightForLengthCalcs;
      #endregion

      #region Constructors
      public RuleSettingsModel() { }
      #endregion

      #region Methods

      #endregion

      #region Full Props
      [JsonProperty(PropertyName = "max_error")]
      public double MaxError
      {
         get => _maxError;
         set
         {
            _maxError = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "min_clearance")]
      public double MinClearance
      {
         get => _minClearance;
         set
         {
            _minClearance = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "min_connection")]
      public double MinConnection
      {
         get => _minConnection;
         set
         {
            _minConnection = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "min_copper_edge_clearance")]
      public double MinCopperEdgeClearance
      {
         get => _minCopperEdgeClearance;
         set
         {
            _minCopperEdgeClearance = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "min_hole_clearance")]
      public double MinHoleClearance
      {
         get => _minHoleClearance;
         set
         {
            _minHoleClearance = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "min_hole_to_hole")]
      public double MinHoleToHole
      {
         get => _minHoleToHole;
         set
         {
            _minHoleToHole = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "min_microvia_diameter")]
      public double MinMicroviaDiameter
      {
         get => _minMicroviaDiameter;
         set
         {
            _minMicroviaDiameter = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "min_microvia_drill")]
      public double MinMicroviaDrill
      {
         get => _minMicroviaDrill;
         set
         {
            _minMicroviaDrill = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "min_resolved_spokes")]
      public int MinResolvedSpokes
      {
         get => _minResolvedSpokes;
         set
         {
            _minResolvedSpokes = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "min_silk_clearance")]
      public double MinSilkClearance
      {
         get => _minSilkClearance;
         set
         {
            _minSilkClearance = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "min_text_height")]
      public double MinTextHeight
      {
         get => _minTextHeight;
         set
         {
            _minTextHeight = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "min_text_thickness")]
      public double MinTextThickness
      {
         get => _minTextThickness;
         set
         {
            _minTextThickness = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "min_through_hole_diameter")]
      public double MinThroughHoleDiameter
      {
         get => _minThroughHoleDiameter;
         set
         {
            _minThroughHoleDiameter = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "min_track_width")]
      public double MinTrackWidth
      {
         get => _minTrackWidth;
         set
         {
            _minTrackWidth = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "min_via_annular_width")]
      public double MinViaAnnularWidth
      {
         get => _minViaAnnularWidth;
         set
         {
            _minViaAnnularWidth = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "min_via_diameter")]
      public double MinViaDiameter
      {
         get => _minViaDiameter;
         set
         {
            _minViaDiameter = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "solder_mask_clearance")]
      public double SolderMaskClearance
      {
         get => _solderMaskClearance;
         set
         {
            _solderMaskClearance = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "solder_mask_min_width")]
      public double SolderMaskMinWidth
      {
         get => _solderMaskMinWidth;
         set
         {
            _solderMaskMinWidth = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "solder_mask_to_copper_clearance")]
      public double SolderMaskToCopperClearance
      {
         get => _solderMaskToCopperClearance;
         set
         {
            _solderMaskToCopperClearance = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "use_height_for_length_calcs")]
      public bool UseHeightForLengthCalcs
      {
         get => _useHeightForLengthCalcs;
         set
         {
            _useHeightForLengthCalcs = value;
            OnPropertyChanged();
         }
      }
      #endregion
   }
}
