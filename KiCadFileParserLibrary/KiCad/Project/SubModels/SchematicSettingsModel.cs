using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MVVMLibrary;

using Newtonsoft.Json;

namespace KiCadFileParserLibrary.KiCad.Project.SubModels
{
   public class SchematicSettingsModel : Model
   {
      #region Local Props
      private int _annotateStartNumber;
      private string? _bomExportFileName;
      private ObservableCollection<string>? _bomFMTPresets;
      private BomFmtSettingsModel? _bomFmtSettings;
      private ObservableCollection<string>? _bomPresets;
      private BomSettingsModel? _bomSettings;
      private double _connectionGridSize;
      private DrawingSettingsModel? _drawingSettings;
      private string? _legacyLibraryDir;
      private ObservableCollection<string>? _legacyLibraryList;
      private MetadataModel? _metadata;
      private string _netFormatName;
      private string? _pageLayoutDescrFile;
      private string? _plotDirectory;
      private bool _spiceCurrentSheetAsRoot;
      private string? _spiceExternalCommand;
      private bool _spiceModelCurrentSheetAsRoot;
      private bool _spiceSaveAllCurrents;
      private bool _spiceSaveAllDissipations;
      private bool _spiceSaveAllVoltages;
      private int _subPartFirstID;
      private int _subPartIDSeparator;
      #endregion

      #region Constructors
      public SchematicSettingsModel() { }
      #endregion

      #region Methods

      #endregion

      #region Full Props
      [JsonProperty(PropertyName = "annotate_start_num")]
      public int AnnotateStartNumber
      {
         get => _annotateStartNumber;
         set
         {
            _annotateStartNumber = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "bom_export_filename")]
      public string? BomExportFileName
      {
         get => _bomExportFileName;
         set
         {
            _bomExportFileName = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "bom_fmt_presets")]
      public ObservableCollection<string>? BomFMTPresets
      {
         get => _bomFMTPresets;
         set
         {
            _bomFMTPresets = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "bom_fmt_settings")]
      public BomFmtSettingsModel? BomFmtSettings
      {
         get => _bomFmtSettings;
         set
         {
            _bomFmtSettings = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "bom_presets")]
      public ObservableCollection<string>? BomPresets
      {
         get => _bomPresets;
         set
         {
            _bomPresets = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "bom_settings")]
      public BomSettingsModel? BomSettings
      {
         get => _bomSettings;
         set
         {
            _bomSettings = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "connection_grid_size")]
      public double ConnectionGridSize
      {
         get => _connectionGridSize;
         set
         {
            _connectionGridSize = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "drawing")]
      public DrawingSettingsModel? DrawingSettings
      {
         get => _drawingSettings;
         set
         {
            _drawingSettings = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "legacy_lib_dir")]
      public string? LegacyLibraryDir
      {
         get => _legacyLibraryDir;
         set
         {
            _legacyLibraryDir = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "legacy_lib_list")]
      public ObservableCollection<string>? LegacyLibraryList
      {
         get => _legacyLibraryList;
         set
         {
            _legacyLibraryList = value;
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

      [JsonProperty(PropertyName = "net_format_name")]
      public string? NetFormatName
      {
         get => _netFormatName;
         set
         {
            _netFormatName = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "page_layout_descr_file")]
      public string? PageLayoutDescrFile
      {
         get => _pageLayoutDescrFile;
         set
         {
            _pageLayoutDescrFile = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "plot_directory")]
      public string? PlotDirectory
      {
         get => _plotDirectory;
         set
         {
            _plotDirectory = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "spice_current_sheet_as_root")]
      public bool SpiceCurrentSheetAsRoot
      {
         get => _spiceCurrentSheetAsRoot;
         set
         {
            _spiceCurrentSheetAsRoot = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "spice_external_command")]
      public string? SpiceExternalCommand
      {
         get => _spiceExternalCommand;
         set
         {
            _spiceExternalCommand = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "spice_model_current_sheet_as_root")]
      public bool SpiceModelCurrentSheetAsRoot
      {
         get => _spiceModelCurrentSheetAsRoot;
         set
         {
            _spiceModelCurrentSheetAsRoot = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "spice_save_all_currents")]
      public bool SpiceSaveAllCurrents
      {
         get => _spiceSaveAllCurrents;
         set
         {
            _spiceSaveAllCurrents = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "spice_save_all_dissipations")]
      public bool SpiceSaveAllDissipations
      {
         get => _spiceSaveAllDissipations;
         set
         {
            _spiceSaveAllDissipations = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "spice_save_all_voltages")]
      public bool SpiceSaveAllVoltages
      {
         get => _spiceSaveAllVoltages;
         set
         {
            _spiceSaveAllVoltages = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "subpart_first_id")]
      public int SubPartFirstID
      {
         get => _subPartFirstID;
         set
         {
            _subPartFirstID = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "subpart_id_separator")]
      public int SubPartIDSeparator
      {
         get => _subPartIDSeparator;
         set
         {
            _subPartIDSeparator = value;
            OnPropertyChanged();
         }
      }
      #endregion
   }
}
