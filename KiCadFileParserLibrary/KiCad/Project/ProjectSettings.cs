using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using JsonReaderLibrary;

using KiCadFileParserLibrary.KiCad.Project.SubModels;

using MVVMLibrary;

using Newtonsoft.Json;

using JsonReader = JsonReaderLibrary.JsonReader;

namespace KiCadFileParserLibrary.KiCad.Project
{
   public class ProjectSettings : Model
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
      private SchematicSettingsModel? _schematic;
      private ObservableCollection<ObservableCollection<string>>? _sheets;
      private Dictionary<string, string>? _textVars;
      #endregion

      #region Constructors
      public ProjectSettings() { }
      #endregion

      #region Methods
      public static ProjectSettings? Parse(string filePath)
      {
         return JsonReader.OpenJsonFile<ProjectSettings>(filePath);
      }

      public void Write(string path)
      {
         JsonReader.SaveJsonFile(path, this);
      }
      #endregion

      #region Full Props
      [JsonProperty(PropertyName = "board")]
      public BoardModel? DefaultBoardSettings
      {
         get => _defaultBoardSettings;
         set
         {
            _defaultBoardSettings = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "boards")]
      public ObservableCollection<string>? Boards
      {
         get => _boards;
         set
         {
            _boards = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "cvpcb")]
      public CvPcbModel? CvPcb
      {
         get => _cvPcb;
         set
         {
            _cvPcb = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "erc")]
      public ErcModel? ERCSettings
      {
         get => _ercSettings;
         set
         {
            _ercSettings = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "libraries")]
      public LibrariesModel? Libraries
      {
         get => _libraries;
         set
         {
            _libraries = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "meta")]
      public MetadataModel? Metadata
      {
         get => _metadata;
         set
         {
            _metadata = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "net_settings")]
      public NetSettingsModel? NetSettings
      {
         get => _netSettings;
         set
         {
            _netSettings = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "pcbnew")]
      public PcbSettingsModel? PcbSettings
      {
         get => _pbcSettings;
         set
         {
            _pbcSettings = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "schematic")]
      public SchematicSettingsModel? Schematic
      {
         get => _schematic;
         set
         {
            _schematic = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "sheets")]
      public ObservableCollection<ObservableCollection<string>>? Sheets
      {
         get => _sheets;
         set
         {
            _sheets = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "text_variables")]
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
}
