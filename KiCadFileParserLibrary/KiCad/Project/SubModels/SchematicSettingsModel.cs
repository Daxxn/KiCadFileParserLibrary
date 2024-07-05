using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace KiCadFileParserLibrary.KiCad.Project.SubModels
{
   public class SchematicSettingsModel
   {
      #region Local Props
      [JsonProperty(PropertyName = "annotate_start_num")]
      public int AnnotateStartNumber { get; set; }

      [JsonProperty(PropertyName = "bom_export_filename")]
      public string? BomExportFileName { get; set; }

      [JsonProperty(PropertyName = "bom_fmt_presets")]
      public List<string>? BomFMTPresets { get; set; }

      [JsonProperty(PropertyName = "bom_fmt_settings")]
      public BomFmtSettingsModel? BomFmtSettings { get; set; }

      [JsonProperty(PropertyName = "bom_presets")]
      public List<string>? BomPresets { get; set; }

      [JsonProperty(PropertyName = "bom_settings")]
      public BomSettingsModel? BomSettings { get; set; }

      [JsonProperty(PropertyName = "connection_grid_size")]
      public double ConnectionGridSize { get; set; }

      [JsonProperty(PropertyName = "drawing")]
      public DrawingSettingsModel? DrawingSettings { get; set; }

      [JsonProperty(PropertyName = "legacy_lib_dir")]
      public string? LegacyLibraryDir { get; set; }

      [JsonProperty(PropertyName = "legacy_lib_list")]
      public List<string>? LegacyLibraryList { get; set; }

      [JsonProperty(PropertyName = "meta")]
      public MetadataModel? Metadata { get; set; }

      [JsonProperty(PropertyName = "net_format_name")]
      public string? NetFormatName { get; set; }

      [JsonProperty(PropertyName = "page_layout_descr_file")]
      public string? PageLayoutDescrFile { get; set; }

      [JsonProperty(PropertyName = "plot_directory")]
      public string? PlotDirectory { get; set; }

      [JsonProperty(PropertyName = "spice_current_sheet_as_root")]
      public bool SpiceCurrentSheetAsRoot { get; set; }

      [JsonProperty(PropertyName = "spice_external_command")]
      public string? SpiceExternalCommand { get; set; }

      [JsonProperty(PropertyName = "spice_model_current_sheet_as_root")]
      public bool SpiceModelCurrentSheetAsRoot { get; set; }

      [JsonProperty(PropertyName = "spice_save_all_currents")]
      public bool SpiceSaveAllCurrents { get; set; }

      [JsonProperty(PropertyName = "spice_save_all_dissipations")]
      public bool SpiceSaveAllDissipations { get; set; }

      [JsonProperty(PropertyName = "spice_save_all_voltages")]
      public bool SpiceSaveAllVoltages { get; set; }

      [JsonProperty(PropertyName = "subpart_first_id")]
      public int SubPartFirstID { get; set; }

      [JsonProperty(PropertyName = "subpart_id_separator")]
      public int SubPartIDSeparator { get; set; }
      #endregion

      #region Constructors
      public SchematicSettingsModel() { }
      #endregion

      #region Methods

      #endregion

      #region Full Props

      #endregion
   }
}
