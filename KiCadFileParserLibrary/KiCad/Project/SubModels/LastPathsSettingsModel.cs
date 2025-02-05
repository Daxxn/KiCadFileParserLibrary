using MVVMLibrary;

using Newtonsoft.Json;

namespace KiCadFileParserLibrary.KiCad.Project.SubModels
{
   public class LastPathsSettingsModel : Model
   {
      #region Local Props
      [JsonProperty(PropertyName = "gencad")]
      public string? GenCad
      {
         get => _genCad;
         set
         {
            _genCad = value;
            OnPropertyChanged();
         }
      }
      private string? _genCad;

      [JsonProperty(PropertyName = "idf")]
      public string? IDF
      {
         get => _idf;
         set
         {
            _idf = value;
            OnPropertyChanged();
         }
      }
      private string? _idf;

      [JsonProperty(PropertyName = "netlist")]
      public string? NetList
      {
         get => _netList;
         set
         {
            _netList = value;
            OnPropertyChanged();
         }
      }
      private string? _netList;

      [JsonProperty(PropertyName = "plot")]
      public string? Plot
      {
         get => _plot;
         set
         {
            _plot = value;
            OnPropertyChanged();
         }
      }
      private string? _plot;

      [JsonProperty(PropertyName = "pos_files")]
      public string? PositionFiles
      {
         get => _posFiles;
         set
         {
            _posFiles = value;
            OnPropertyChanged();
         }
      }
      private string? _posFiles;

      [JsonProperty(PropertyName = "specctra_dsn")]
      public string? SpectraDSN
      {
         get => _spectraDSN;
         set
         {
            _spectraDSN = value;
            OnPropertyChanged();
         }
      }
      private string? _spectraDSN;

      [JsonProperty(PropertyName = "step")]
      public string? Step
      {
         get => _step;
         set
         {
            _step = value;
            OnPropertyChanged();
         }
      }
      private string? _step;

      [JsonProperty(PropertyName = "svg")]
      public string? SVG
      {
         get => _svg;
         set
         {
            _svg = value;
            OnPropertyChanged();
         }
      }
      private string? _svg;

      [JsonProperty(PropertyName = "vrml")]
      public string? VRML
      {
         get => _vrml;
         set
         {
            _vrml = value;
            OnPropertyChanged();
         }
      }
      private string? _vrml;
      #endregion

      #region Constructors
      public LastPathsSettingsModel() { }
      #endregion

      #region Methods

      #endregion

      #region Full Props

      #endregion
   }
}
