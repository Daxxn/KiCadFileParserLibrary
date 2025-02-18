using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MVVMLibrary;

using Newtonsoft.Json;

namespace KiCadFileParserLibrary.KiCad.Project.SubModels;

/// <summary>
/// 
/// </summary>
public class ViaDimensionModel : Model
{
   #region Local Props
   private double _diam = 0;
   private double _drill = 0;
   #endregion

   #region Constructors
   /// <inheritdoc/>
   public ViaDimensionModel() { }
   #endregion

   #region Methods

   #endregion

   #region Full Props
   /// <summary>
   /// Pad diameter
   /// </summary>
   [JsonProperty(PropertyName = "diameter")]
   public double Diameter
   {
      get => _diam;
      set
      {
         _diam = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Drill diameter
   /// </summary>
   [JsonProperty(PropertyName = "drill")]
   public double Drill
   {
      get => _drill;
      set
      {
         _drill = value;
         OnPropertyChanged();
      }
   }
   #endregion
}
