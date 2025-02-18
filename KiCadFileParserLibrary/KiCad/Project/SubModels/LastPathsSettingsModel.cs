using MVVMLibrary;

using Newtonsoft.Json;

namespace KiCadFileParserLibrary.KiCad.Project.SubModels;

/// <summary>
/// Last path settings model.
/// </summary>
public class LastPathsSettingsModel : Model
{
   #region Local Props
   private string? _genCad;
   private string? _idf;
   private string? _netList;
   private string? _plot;
   private string? _posFiles;
   private string? _spectraDSN;
   private string? _step;
   private string? _svg;
   private string? _vrml;
   #endregion

   #region Constructors
   /// <inheritdoc/>
   public LastPathsSettingsModel() { }
   #endregion

   #region Methods

   #endregion

   #region Full Props
   /// <summary>
   /// GenCAD path.
   /// </summary>
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

   /// <summary>
   /// IDF path.
   /// </summary>
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

   /// <summary>
   /// Net list path.
   /// </summary>
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

   /// <summary>
   /// Plot path.
   /// </summary>
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

   /// <summary>
   /// Position files path.
   /// </summary>
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

   /// <summary>
   /// SpectraDSN path.
   /// </summary>
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

   /// <summary>
   /// Step path.
   /// </summary>
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

   /// <summary>
   /// SVG path.
   /// </summary>
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

   /// <summary>
   /// VRML path.
   /// </summary>
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
   #endregion
}
