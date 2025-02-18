using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.KiCad.Settings.Common.SubModels;
using KiCadFileParserLibrary.Utils;

using MVVMLibrary;

using Newtonsoft.Json;

namespace KiCadFileParserLibrary.KiCad.Settings.Common;

/// <summary>
/// KiCad common settings
/// </summary>
public class CommonSettingsModel : Model
{
   #region Local Props
   private CommonAppearanceModel _appearance = new();
   private AutoBackupModel _autoBackup = new();
   private ShowPromptsModel _dontShowAgain = new();
   private EnvironmentModel _env = new();
   private GitSettingsModel _git = new();
   private CommonGraphicsSettingsModel _graphics = new();
   private InputSettingsModel _input = new();
   private MetaSettingsModel _meta = new();
   private UnknownModel _netclassPanel = new();
   private UnknownModel _packageManager = new();
   private SessionSettingsModel _session = new();
   private CommonSystemSettingsModel _system = new();
   #endregion

   #region Constructors
   /// <inheritdoc/>
   public CommonSettingsModel() { }
   #endregion

   #region Methods
   /// <summary>
   /// Read common KiCad settings data from the users' AppData folder.
   /// </summary>
   /// <returns>The KiCad settings.</returns>
   public static CommonSettingsModel? Read()
   {
      var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "kicad/8.0", KiCadConstants.CommonSettingsFileName);
      return JsonReaderLibrary.JsonReader.OpenJsonFile<CommonSettingsModel>(path);
   }

   /// <summary>
   /// Read common KiCad settings data from the provided file path.
   /// </summary>
   /// <param name="path">Path to the file to read.</param>
   /// <returns></returns>
   public static CommonSettingsModel? Read(string path)
   {
      if (!File.Exists(path)) return null;
      return JsonReaderLibrary.JsonReader.OpenJsonFile<CommonSettingsModel>(path);
   }

   /// <summary>
   /// Save the users' common settings file.
   /// </summary>
   public void Save()
   {
      var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "kicad/8.0", KiCadConstants.CommonSettingsFileName);
      JsonReaderLibrary.JsonReader.SaveJsonFile(path, this);
   }

   /// <summary>
   /// Save settings to a new file.
   /// </summary>
   /// <param name="newFilePath">Path to the new settings file.</param>
   public void SaveCopy(string newFilePath)
   {
      JsonReaderLibrary.JsonReader.SaveJsonFile(newFilePath, this);
   }
   #endregion

   #region Full Props
   /// <summary>
   /// Appearance settings
   /// </summary>
   [JsonProperty("appearance")]
   public CommonAppearanceModel Appearance
   {
      get => _appearance;
      set
      {
         _appearance = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Auto-backup settings
   /// </summary>
   [JsonProperty("auto_backup")]
   public AutoBackupModel AutoBackup
   {
      get => _autoBackup;
      set
      {
         _autoBackup = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Prompt dont show again settings
   /// </summary>
   [JsonProperty("do_not_show_again")]
   public ShowPromptsModel DontShowAgain
   {
      get => _dontShowAgain;
      set
      {
         _dontShowAgain = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Environment variables
   /// </summary>
   [JsonProperty("environment")]
   public EnvironmentModel EnvironmentVars
   {
      get => _env;
      set
      {
         _env = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Git setup
   /// <para/>
   /// Not sure where this is used. There isnt any way to add it in the "Preferences" dialog.
   /// </summary>
   [JsonProperty("git")]
   public GitSettingsModel Git
   {
      get => _git;
      set
      {
         _git = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Common graphics modes
   /// </summary>
   [JsonProperty("graphics")]
   public CommonGraphicsSettingsModel Graphics
   {
      get => _graphics;
      set
      {
         _graphics = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Input settings
   /// </summary>
   [JsonProperty("input")]
   public InputSettingsModel Input
   {
      get => _input;
      set
      {
         _input = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Metadata
   /// <para/>
   /// Nost sure what this is for. Don't touch it.
   /// </summary>
   [JsonProperty("meta")]
   public MetaSettingsModel Meta
   {
      get => _meta;
      set
      {
         _meta = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Unknown object
   /// <para/>
   /// No Touchee!!
   /// </summary>
   [JsonProperty("netclass_panel")]
   public UnknownModel NetclassPanel
   {
      get => _netclassPanel;
      set
      {
         _netclassPanel = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Unknown object
   /// <para/>
   /// No Touchee!!
   /// </summary>
   [JsonProperty("package_manager")]
   public UnknownModel PackageManager
   {
      get => _packageManager;
      set
      {
         _packageManager = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Session settings
   /// </summary>
   [JsonProperty("session")]
   public SessionSettingsModel Session
   {
      get => _session;
      set
      {
         _session = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Common system settings
   /// </summary>
   [JsonProperty("system")]
   public CommonSystemSettingsModel SystemSettings
   {
      get => _system;
      set
      {
         _system = value;
         OnPropertyChanged();
      }
   }
   #endregion
}
