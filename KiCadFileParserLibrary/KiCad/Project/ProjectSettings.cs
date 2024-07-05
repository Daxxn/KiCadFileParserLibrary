using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using JsonReaderLibrary;

using KiCadFileParserLibrary.KiCad.Project.SubModels;

using Newtonsoft.Json;

using JsonReader = JsonReaderLibrary.JsonReader;

namespace KiCadFileParserLibrary.KiCad.Project
{
   public class ProjectSettings
   {
      #region Local Props
      [JsonProperty(PropertyName = "board")]
      public BoardModel? DefaultBoardSettings { get; set; }

      [JsonProperty(PropertyName = "boards")]
      public List<string>? Boards { get; set; }

      [JsonProperty(PropertyName = "cvpcb")]
      public CvPcbModel? CvPcb { get; set; }

      [JsonProperty(PropertyName = "erc")]
      public ErcModel? ERCSettings { get; set; }

      [JsonProperty(PropertyName = "libraries")]
      public LibrariesModel? Libraries { get; set; }

      [JsonProperty(PropertyName = "meta")]
      public MetadataModel? Metadata { get; set; }

      [JsonProperty(PropertyName = "net_settings")]
      public NetSettingsModel? NetSettings { get; set; }

      [JsonProperty(PropertyName = "pcbnew")]
      public PcbSettingsModel? PcbSettings { get; set; }

      [JsonProperty(PropertyName = "schematic")]
      public SchematicSettingsModel? Schematic { get; set; }

      [JsonProperty(PropertyName = "sheets")]
      public List<List<string>>? Sheets { get; set; }

      [JsonProperty(PropertyName = "text_variables")]
      public Dictionary<string, string>? TextVariables { get; set; }
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

      #endregion
   }
}
