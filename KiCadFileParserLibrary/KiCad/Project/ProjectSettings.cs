using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using JsonReaderLibrary;

using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.KiCad.Project.SubModels;

using MVVMLibrary;

using Newtonsoft.Json;

using JsonReader = JsonReaderLibrary.JsonReader;

namespace KiCadFileParserLibrary.KiCad.Project;

/// <summary>
/// Project settings from the KiCad project file <c>*.kicad_pro</c>
/// </summary>
public class ProjectSettings : Model, IKiCadProjectFile
{
   #region Local Props
   private BoardModel? _defaultBoardSettings;
   private ObservableCollection<string>? _boards;
   private CvPcbModel? _cvPcb;
   private ErcModel? _ercSettings;
   private LibrariesModel? _libraries;
   private MetadataModel? _metadata;
   private NetSettingsModel? _netSettings;
   private PcbSettingsModel? _pbcSettings;
   private SchematicSettingsModel? _schematic = new();
   private SchematicSheetCollection? _sheets;
   private Dictionary<string, string>? _textVars;
   #endregion

   #region Constructors
   /// <inheritdoc/>
   public ProjectSettings() { }
   #endregion

   #region Methods
   /// <summary>
   /// Parse the KiCad Project (<c>.kicad_pro</c>) file.
   /// </summary>
   /// <param name="filePath">The path to the file.</param>
   /// <returns>The settings from the project file.</returns>
   public static ProjectSettings? Parse(string filePath)
   {
      return JsonReader.OpenJsonFile<ProjectSettings>(filePath);
   }

   /// <inheritdoc/>
   public void Write(string path)
   {
      JsonReader.SaveJsonFile(path, this);
   }
   #endregion

   #region Full Props
   /// <summary>
   /// Default board settings
   /// </summary>
   [JsonProperty("board")]
   public BoardModel? DefaultBoardSettings
   {
      get => _defaultBoardSettings;
      set
      {
         _defaultBoardSettings = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Boards
   /// </summary>
   [JsonProperty("boards")]
   public ObservableCollection<string>? Boards
   {
      get => _boards;
      set
      {
         _boards = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// CvPcb
   /// </summary>
   [JsonProperty("cvpcb")]
   public CvPcbModel? CvPcb
   {
      get => _cvPcb;
      set
      {
         _cvPcb = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// ERC settings
   /// </summary>
   [JsonProperty("erc")]
   public ErcModel? ERCSettings
   {
      get => _ercSettings;
      set
      {
         _ercSettings = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Libraries
   /// </summary>
   [JsonProperty("libraries")]
   public LibrariesModel? Libraries
   {
      get => _libraries;
      set
      {
         _libraries = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Metadata
   /// </summary>
   [JsonProperty("meta")]
   public MetadataModel? Metadata
   {
      get => _metadata;
      set
      {
         _metadata = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Net settings
   /// </summary>
   [JsonProperty("net_settings")]
   public NetSettingsModel? NetSettings
   {
      get => _netSettings;
      set
      {
         _netSettings = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// PCB settings
   /// </summary>
   [JsonProperty("pcbnew")]
   public PcbSettingsModel? PcbSettings
   {
      get => _pbcSettings;
      set
      {
         _pbcSettings = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Schematic settings
   /// </summary>
   [JsonProperty("schematic")]
   public SchematicSettingsModel? Schematic
   {
      get => _schematic;
      set
      {
         _schematic = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// List of the sheets included in this project.
   /// </summary>
   [JsonIgnore]
   public SchematicSheetCollection? Sheets
   {
      get => _sheets;
      set
      {
         _sheets = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Sheet reference array.
   /// <para/>
   /// Used to save the <seealso cref="Sheets"/> data. This is only meant to be used by the json serializer.
   /// <para/>
   /// Use <seealso cref="Sheets"/> instead.
   /// </summary>
   [JsonProperty("sheets")]
   public string[][]? SheetsArray
   {
      get => Sheets?.ConvertToArray();
      set
      {
         if (value is null)
         {
            Sheets = null;
         }
         else
         {
            Sheets = new();
            Sheets?.ConvertFromArray(value);
         }
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// List of Text variables
   /// </summary>
   [JsonProperty("text_variables")]
   public Dictionary<string, string>? TextVariables
   {
      get => _textVars;
      set
      {
         _textVars = value;
         OnPropertyChanged();
      }
   }
   #endregion
}
