using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MVVMLibrary;

using Newtonsoft.Json;

namespace KiCadFileParserLibrary.KiCad.Project.SubModels;

/// <summary>
/// Schematic settings model.
/// </summary>
public class SchematicSettingsModel : Model
{
   #region Local Props
   private int _annotateStartNumber;
   private string? _bomExportFileName;
   private ObservableCollection<string>? _bomFMTPresets;
   private BomFormatSettingsModel? _bomFmtSettings;
   private ObservableCollection<string>? _bomPresets;
   private BomSettingsModel? _bomSettings;
   private double _connectionGridSize;
   private DrawingSettingsModel? _drawingSettings;
   private string? _legacyLibraryDir;
   private ObservableCollection<string>? _legacyLibraryList;
   private MetadataModel? _metadata;
   private string _netFormatName = "";
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
   /// <inheritdoc/>
   public SchematicSettingsModel() { }
   #endregion

   #region Methods

   #endregion

   #region Full Props
   /// <summary>
   /// Annotate start number
   /// </summary>
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

   /// <summary>
   /// BOM export file name
   /// </summary>
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

   /// <summary>
   /// List of BOM format presets
   /// </summary>
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

   /// <summary>
   /// BOM format settings
   /// </summary>
   [JsonProperty(PropertyName = "bom_fmt_settings")]
   public BomFormatSettingsModel? BomFmtSettings
   {
      get => _bomFmtSettings;
      set
      {
         _bomFmtSettings = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// List of BOM presets
   /// </summary>
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

   /// <summary>
   /// BOM settings
   /// </summary>
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

   /// <summary>
   /// Connection grid size
   /// </summary>
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

   /// <summary>
   /// Drawing settings
   /// </summary>
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

   /// <summary>
   /// Legacy library folder
   /// </summary>
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

   /// <summary>
   /// Legacy library list
   /// </summary>
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

   /// <summary>
   /// Metadata
   /// </summary>
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

   /// <summary>
   /// Net format name
   /// </summary>
   [JsonProperty(PropertyName = "net_format_name")]
   public string NetFormatName
   {
      get => _netFormatName;
      set
      {
         _netFormatName = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Page layout descriptor file
   /// </summary>
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

   /// <summary>
   /// Plot directory
   /// </summary>
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

   /// <summary>
   /// Spice current sheet as root
   /// </summary>
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

   /// <summary>
   /// Spice external command
   /// </summary>
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

   /// <summary>
   /// Spice model current sheet as root
   /// </summary>
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

   /// <summary>
   /// Spice save all currents
   /// </summary>
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

   /// <summary>
   /// Spice save all dissipations
   /// </summary>
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

   /// <summary>
   /// Spice save all voltages
   /// </summary>
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

   /// <summary>
   /// Sub-part first ID
   /// </summary>
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

   /// <summary>
   /// Sub-part ID separator
   /// </summary>
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
