using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Utils.JsonConverters;

using MVVMLibrary;

using Newtonsoft.Json;

namespace KiCadFileParserLibrary.KiCad.Settings.Colors.Editor;

/// <summary>
/// 
/// </summary>
public class GerberThemeModel : Model
{
   #region Local Props
   private RgbaColorModel _axes = new();
   private RgbaColorModel _background = new();
   private RgbaColorModel _dcodes = new();
   private RgbaColorModel _grid = new();
   private RgbaColorModel _negativeObjects = new();
   private RgbaColorModel _pageLimits = new();
   private RgbaColorModel _worksheet = new();
   private ObservableCollection<RgbaColorModel> _layers = [];
   #endregion

   #region Constructors
   /// <inheritdoc/>
   public GerberThemeModel() { }
   #endregion

   #region Methods

   #endregion

   #region Full Props
   /// <summary>
   /// </summary>
   [JsonProperty("axes")]
   [JsonConverter(typeof(RgbaColorJsonConverter))]
   public RgbaColorModel Axes
   {
      get => _axes;
      set
      {
         _axes = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// </summary>
   [JsonProperty("background")]
   [JsonConverter(typeof(RgbaColorJsonConverter))]
   public RgbaColorModel Background
   {
      get => _background;
      set
      {
         _background = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// </summary>
   [JsonProperty("dcodes")]
   [JsonConverter(typeof(RgbaColorJsonConverter))]
   public RgbaColorModel DCodes
   {
      get => _dcodes;
      set
      {
         _dcodes = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// </summary>
   [JsonProperty("grid")]
   [JsonConverter(typeof(RgbaColorJsonConverter))]
   public RgbaColorModel Grid
   {
      get => _grid;
      set
      {
         _grid = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// </summary>
   [JsonProperty("negative_objects")]
   [JsonConverter(typeof(RgbaColorJsonConverter))]
   public RgbaColorModel NegativeObjects
   {
      get => _negativeObjects;
      set
      {
         _negativeObjects = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// </summary>
   [JsonProperty("page_limits")]
   [JsonConverter(typeof(RgbaColorJsonConverter))]
   public RgbaColorModel PageLimits
   {
      get => _pageLimits;
      set
      {
         _pageLimits = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// </summary>
   [JsonProperty("worksheet")]
   [JsonConverter(typeof(RgbaColorJsonConverter))]
   public RgbaColorModel Worksheet
   {
      get => _worksheet;
      set
      {
         _worksheet = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// </summary>
   [JsonProperty("layers")]
   [JsonConverter(typeof(RgbaColorListJsonConverter))]
   public ObservableCollection<RgbaColorModel> Layers
   {
      get => _layers;
      set
      {
         _layers = value;
         OnPropertyChanged();
      }
   }
   #endregion
}
