using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Utils.JsonConverters;

using MVVMLibrary;

using Newtonsoft.Json;

namespace KiCadFileParserLibrary.KiCad.Settings.Colors.Editor;

/// <summary>
/// 3D viewer color settings
/// </summary>
public class Viewer3DThemeModel : Model
{
   #region Local Props
   private RgbaColorModel _backgroundBottom = new();
   private RgbaColorModel _backgroundTop = new();
   private RgbaColorModel _board = new();
   private RgbaColorModel _copper = new();
   private RgbaColorModel _silkBottom = new();
   private RgbaColorModel _silkTop = new();
   private RgbaColorModel _maskBottom = new();
   private RgbaColorModel _maskTop = new();
   private RgbaColorModel _solderPaste = new();
   private bool _useBoardStackupColors;
   #endregion

   #region Constructors
   /// <inheritdoc/>
   public Viewer3DThemeModel() { }
   #endregion

   #region Methods

   #endregion

   #region Full Props
   /// <summary>
   /// </summary>
   [JsonProperty("background_bottom")]
   [JsonConverter(typeof(RgbaColorJsonConverter))]
   public RgbaColorModel BackgroundBottom
   {
      get => _backgroundBottom;
      set
      {
         _backgroundBottom = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// </summary>
   [JsonProperty("background_top")]
   [JsonConverter(typeof(RgbaColorJsonConverter))]
   public RgbaColorModel BackgroundTop
   {
      get => _backgroundTop;
      set
      {
         _backgroundTop = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// </summary>
   [JsonProperty("board")]
   [JsonConverter(typeof(RgbaColorJsonConverter))]
   public RgbaColorModel Board
   {
      get => _board;
      set
      {
         _board = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// </summary>
   [JsonProperty("copper")]
   [JsonConverter(typeof(RgbaColorJsonConverter))]
   public RgbaColorModel Copper
   {
      get => _copper;
      set
      {
         _copper = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// </summary>
   [JsonProperty("silkscreen_bottom")]
   [JsonConverter(typeof(RgbaColorJsonConverter))]
   public RgbaColorModel SilkscreenBottom
   {
      get => _silkBottom;
      set
      {
         _silkBottom = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// </summary>
   [JsonProperty("silkscreen_top")]
   [JsonConverter(typeof(RgbaColorJsonConverter))]
   public RgbaColorModel SilkscreenTop
   {
      get => _silkTop;
      set
      {
         _silkTop = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// </summary>
   [JsonProperty("soldermask_bottom")]
   [JsonConverter(typeof(RgbaColorJsonConverter))]
   public RgbaColorModel SolderMaskBottom
   {
      get => _maskBottom;
      set
      {
         _maskBottom = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// </summary>
   [JsonProperty("soldermask_top")]
   [JsonConverter(typeof(RgbaColorJsonConverter))]
   public RgbaColorModel SolderMaskTop
   {
      get => _maskTop;
      set
      {
         _maskTop = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// </summary>
   [JsonProperty("solderpaste")]
   [JsonConverter(typeof(RgbaColorJsonConverter))]
   public RgbaColorModel SolderPaste
   {
      get => _solderPaste;
      set
      {
         _solderPaste = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// </summary>
   [JsonProperty("use_board_stackup_colors")]
   public bool UseBoardStackupColors
   {
      get => _useBoardStackupColors;
      set
      {
         _useBoardStackupColors = value;
         OnPropertyChanged();
      }
   }
   #endregion
}
