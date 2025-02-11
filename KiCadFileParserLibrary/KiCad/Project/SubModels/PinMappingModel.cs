using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Utils;

using MVVMLibrary;

namespace KiCadFileParserLibrary.KiCad.Project.SubModels;

/// <summary>
/// Pin map model usable by any application.
/// </summary>
public class PinMappingModel : Model
{
   #region Local Props
   private ObservableCollection<ObservableCollection<RuleSeverity>> _map = [];
   #endregion

   #region Constructors
   /// <inheritdoc/>
   public PinMappingModel()
   {
      InitMap();
   }
   #endregion

   #region Methods
   /// <summary>
   /// Initialize the pin map.
   /// </summary>
   public void InitMap()
   {
      Map = [];
      for (int x = 0; x < KiCadConstants.PinMapSize; x++)
      {
         var horz = new ObservableCollection<RuleSeverity>();
         for (int y = 0; y < KiCadConstants.PinMapSize; y++)
         {
            horz.Add(RuleSeverity.ignore);
         }
         Map.Add(horz);
      }
   }

   /// <summary>
   /// Convert the 2-Dimensional array from the project file to the pin map.
   /// </summary>
   /// <param name="data">The pin map as a 2D array</param>
   public void ConvertToMap(int[][] data)
   {
      Map = [];
      for (int x = 0; x < KiCadConstants.PinMapSize; x++)
      {
         var horz = new ObservableCollection<RuleSeverity>();
         for (int y = 0; y < KiCadConstants.PinMapSize; y++)
         {
            horz.Add((RuleSeverity)data[x][y]);
         }
         Map.Add(horz);
      }
   }

   /// <summary>
   /// Convert the pin map to a 2-Dimensional array for saving to the project file.
   /// </summary>
   /// <returns>The pin map as a 2D array</returns>
   public int[][] ConvertFromMap()
   {
      int[][] data = new int[KiCadConstants.PinMapSize][];
      for (int x = 0; x < KiCadConstants.PinMapSize; x++)
      {
         data[x] = new int[KiCadConstants.PinMapSize];
         for (int y = 0; y < KiCadConstants.PinMapSize; y++)
         {
            data[x][y] = (int)Map[x][y];
         }
      }
      return data;
   }

   /// <summary>
   /// Get a connections rule severity.
   /// </summary>
   /// <param name="pinA">The start pin</param>
   /// <param name="pinB">The stop pin</param>
   /// <returns>The rule for the connection</returns>
   public RuleSeverity ReadMap(PinElectricalType pinA, PinElectricalType pinB)
   {
      return Map[(int)pinA][(int)pinB];
   }

   /// <summary>
   /// Change a connections rule severity.
   /// </summary>
   /// <param name="pinA">The start pin</param>
   /// <param name="pinB">The stop pin</param>
   /// <param name="severity">The new <see cref="RuleSeverity"/> value.</param>
   public void ChangeSeverity(PinElectricalType pinA, PinElectricalType pinB, RuleSeverity severity)
   {
      if ((int)pinA == 11 || (int)pinB == 11) return;
      if ((int)pinB > (int)pinA) return;
      Map[(int)pinA][(int)pinB] = severity;
   }
   #endregion

   #region Full Props
   /// <summary>
   /// The 2-Dimensional map of the connection rule severities.
   /// </summary>
   public ObservableCollection<ObservableCollection<RuleSeverity>> Map
   {
      get => _map;
      set
      {
         _map = value;
         OnPropertyChanged();
      }
   }
   #endregion
}
