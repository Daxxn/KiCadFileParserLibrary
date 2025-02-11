using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MVVMLibrary;

using Newtonsoft.Json;

namespace KiCadFileParserLibrary.KiCad.Project.SubModels;

/// <summary>
/// A differential pair option used by the PCB editor.
/// </summary>
public class DiffPairDimensionModel : Model
{
   #region Local Props
   private double _gap;
   private double _viaGap;
   private double _width;
   #endregion

   #region Constructors
   /// <inheritdoc/>
   public DiffPairDimensionModel() { }
   #endregion

   #region Methods

   #endregion

   #region Full Props
   /// <summary>
   /// The gap between the pair
   /// </summary>
   [JsonProperty(PropertyName = "gap")]
   public double Gap
   {
      get => _gap;
      set
      {
         _gap = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// The gap between the pair vias. Distance is measured from the edge of the via pads.
   /// </summary>
   [JsonProperty(PropertyName = "via_gap")]
   public double ViaGap
   {
      get => _viaGap;
      set
      {
         _viaGap = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// The width of the pairs tracks.
   /// </summary>
   [JsonProperty(PropertyName = "width")]
   public double Width
   {
      get => _width;
      set
      {
         _width = value;
         OnPropertyChanged();
      }
   }
   #endregion
}
