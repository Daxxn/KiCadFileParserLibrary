using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MVVMLibrary;

namespace KiCadFileParserLibrary.KiCad.Project.SubModels;

/// <summary>
/// List of Schematic sheet references
/// </summary>
public class SchematicSheetCollection : Model
{
   #region Local Props
   private ObservableCollection<SchematicSheetModel> _sheets = [];
   #endregion

   #region Constructors
   /// <inheritdoc/>
   public SchematicSheetCollection() { }
   #endregion

   #region Methods
   /// <summary>
   /// Convert the sheet refernces to a 2D array.
   /// </summary>
   /// <returns>A 2D array of sheet references.</returns>
   public string[][] ConvertToArray()
   {
      string[][] output = new string[Sheets.Count][];

      for (int i = 0; i < Sheets.Count; i++)
      {
         output[i] = new string[2];
         output[i][0] = Sheets[i].ID;
         output[i][1] = Sheets[i].Name;
      }

      return output;
   }

   /// <summary>
   /// Convert the sheet references from a 2D array.
   /// </summary>
   /// <param name="array">2D sheet references array.</param>
   public void ConvertFromArray(string[][] array)
   {
      foreach (var item in array)
      {
         Sheets.Add(new(item[0], item[1]));
      }
   }

   /// <summary>
   /// Get a project ID from the sheet name.
   /// </summary>
   /// <param name="name">Sheet name.</param>
   /// <returns>The found project ID, otherwise null.</returns>
   public string? GetProjectID(string? name)
   {
      if (string.IsNullOrEmpty(name)) return null;
      return Sheets?.FirstOrDefault(s => s.Name == name)?.ID;
   }

   /// <summary>
   /// Get the sheet reference by name.
   /// </summary>
   /// <param name="name">Sheet name.</param>
   /// <returns>The found sheet reference, otherwise null.</returns>
   public SchematicSheetModel? GetSheetByName(string name)
   {
      if (string.IsNullOrEmpty(name)) return null;
      return Sheets?.FirstOrDefault(s => s.Name == name);
   }

   /// <summary>
   /// Get the sheet reference by ID.
   /// </summary>
   /// <param name="id">The sheet unique ID.</param>
   /// <returns>The found sheet reference, otherwise null.</returns>
   public SchematicSheetModel? GetSheetByID(string id)
   {
      if (string.IsNullOrEmpty(id)) return null;
      return Sheets?.FirstOrDefault(s => s.ID == id);
   }
   #endregion

   #region Full Props
   /// <summary>
   /// List of sheet references.
   /// </summary>
   public ObservableCollection<SchematicSheetModel> Sheets
   {
      get => _sheets;
      set
      {
         _sheets = value;
         OnPropertyChanged();
      }
   }
   #endregion
}
