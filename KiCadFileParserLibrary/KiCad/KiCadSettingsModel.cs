using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.KiCad.Settings.Colors;
using KiCadFileParserLibrary.KiCad.Settings.Common;
using KiCadFileParserLibrary.Utils;

using MVVMLibrary;

namespace KiCadFileParserLibrary.KiCad;

/// <summary>
/// KiCad settings
/// </summary>
public class KiCadSettingsModel : Model
{
   #region Local Props
   private ThemeCollection? _themes;
   private CommonSettingsModel? _settings;
   #endregion

   #region Constructors
   /// <inheritdoc/>
   public KiCadSettingsModel() { }
   #endregion

   #region Methods
   /// <summary>
   /// Read themes and common settings data from the users' local settings.
   /// </summary>
   /// <returns>The <see cref="KiCadSettingsModel">Settings</see> data.</returns>
   public static KiCadSettingsModel Read()
   {
      var settings = new KiCadSettingsModel();
      settings.ThemeData = ThemeCollection.Read();
      settings.Settings = CommonSettingsModel.Read();
      return settings;
   }

   /// <summary>
   /// Reads themes and common settings data from the provided rootSettingsFolder.
   /// </summary>
   /// <param name="settingsFolder">Path to the rootSettingsFolder to read from.</param>
   /// <returns>The <see cref="KiCadSettingsModel">Settings</see> data.</returns>
   public static KiCadSettingsModel Read(string settingsFolder)
   {
      var settings = new KiCadSettingsModel();
      settings.ThemeData = ThemeCollection.Read(Path.Combine(settingsFolder, "color"));
      settings.Settings = CommonSettingsModel.Read(Path.Combine(settingsFolder, KiCadConstants.CommonSettingsFileName));
      return settings;
   }

   /// <summary>
   /// Save the settings to the users' local settings.
   /// </summary>
   public void Save()
   {
      ThemeData?.Save();
      Settings?.Save();
   }

   /// <summary>
   /// Save the settings to the provided settings rootSettingsFolder.
   /// </summary>
   /// <param name="rootSettingsFolder">Path to the new root settings folder.</param>
   public void SaveCopy(string rootSettingsFolder)
   {
      ThemeData?.SaveCopy(Path.Combine(rootSettingsFolder, "color"));
      Settings?.SaveCopy(Path.Combine(rootSettingsFolder, KiCadConstants.CommonSettingsFileName));
   }
   #endregion

   #region Full Props
   /// <summary>
   /// Collection of themes
   /// </summary>
   public ThemeCollection? ThemeData
   {
      get => _themes;
      set
      {
         _themes = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// KiCad common settings data.
   /// </summary>
   public CommonSettingsModel? Settings
   {
      get => _settings;
      set
      {
         _settings = value;
         OnPropertyChanged();
      }
   }
   #endregion
}
