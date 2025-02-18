using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using JsonReaderLibrary;

using MVVMLibrary;

namespace KiCadFileParserLibrary.KiCad.Settings.Colors;

/// <summary>
/// List of <see cref="ThemeSettingsModel">ThemeData</see>
/// </summary>
public class ThemeCollection : Model
{
   #region Local Props
   private ObservableCollection<ThemeSettingsModel> _themes = [];
   #endregion

   #region Constructors
   /// <inheritdoc/>
   public ThemeCollection() { }
   #endregion

   #region Methods
   /// <summary>
   /// Reads the themes stored in the users' AppData folder.
   /// </summary>
   /// <returns>The list of <see cref="ThemeSettingsModel">Themes.</see></returns>
   public static ThemeCollection? Read()
   {
      var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "kicad/8.0/colors");
      var files = Directory.GetFiles(path);
      if (files.Length > 0 )
      {
         var themes = new ThemeCollection();
         foreach (var file in files)
         {
            var theme = JsonReader.OpenJsonFile<ThemeSettingsModel>(file);
            if (theme != null)
            {
               themes.Themes.Add(theme);
            }
         }
         return themes;
      }
      return null;
   }

   /// <summary>
   /// Reads the themes stored in the provided folder.
   /// </summary>
   /// <param name="folder">The folder to read from.</param>
   /// <returns>The list of <see cref="ThemeSettingsModel">Themes.</see></returns>
   public static ThemeCollection? Read(string folder)
   {
      var files = Directory.GetFiles(folder);
      if (files.Length > 0)
      {
         var themes = new ThemeCollection();
         foreach (var file in files)
         {
            var theme = JsonReader.OpenJsonFile<ThemeSettingsModel>(file);
            if (theme != null)
            {
               themes.Themes.Add(theme);
            }
         }
         return themes;
      }
      return null;
   }

   /// <summary>
   /// Save the themes to the users' settings folder.
   /// </summary>
   public void Save()
   {
      var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "kicad/8.0/colors");
      foreach (var theme in Themes)
      {
         JsonReader.SaveJsonFile(Path.Combine(path, $"{theme.Meta.Name}.json"), theme);
      }
   }

   /// <summary>
   /// Save the themes to a new folder.
   /// </summary>
   /// <param name="folderPath">new themes folder.</param>
   public void SaveCopy(string folderPath)
   {
      var folderDir = new DirectoryInfo(folderPath);
      if (!folderDir.Exists)
      {
         folderDir.Create();
      }
      foreach (var theme in Themes)
      {
         JsonReader.SaveJsonFile(Path.Combine(folderDir.FullName, $"{theme.Meta.Name}.json"), theme);
      }
   }
   #endregion

   #region Full Props
   /// <summary>
   /// List of <see cref="ThemeSettingsModel">ThemeData</see>
   /// </summary>
   public ObservableCollection<ThemeSettingsModel> Themes
   {
      get => _themes;
      set
      {
         _themes = value;
         OnPropertyChanged();
      }
   }
   #endregion
}
