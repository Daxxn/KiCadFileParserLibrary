using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MVVMLibrary;

namespace KiCadFileParserLibrary.KiCad.Project.SubModels;
public class SchematicSheetCollection : Model
{
   #region Local Props
   private ObservableCollection<SchematicSheetModel> _sheets = [];
   #endregion

   #region Constructors
   public SchematicSheetCollection() { }
   #endregion

   #region Methods
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

   public void ConvertFromArray(string[][] array)
   {
      foreach (var item in array)
      {
         Sheets.Add(new(item[0], item[1]));
      }
   }

   public string? GetProjectID(string? name)
   {
      if (string.IsNullOrEmpty(name)) return null;
      return Sheets?.FirstOrDefault(s => s.Name == name)?.ID;
   }

   public SchematicSheetModel? GetSheetByName(string name)
   {
      if (string.IsNullOrEmpty(name)) return null;
      return Sheets?.FirstOrDefault(s => s.Name == name);
   }

   public SchematicSheetModel? GetSheetByID(string id)
   {
      if (string.IsNullOrEmpty(id)) return null;
      return Sheets?.FirstOrDefault(s => s.ID == id);
   }
   #endregion

   #region Full Props
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
