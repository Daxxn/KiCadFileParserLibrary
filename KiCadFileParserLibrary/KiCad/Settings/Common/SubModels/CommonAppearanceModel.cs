using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MVVMLibrary;

using Newtonsoft.Json;

namespace KiCadFileParserLibrary.KiCad.Settings.Common.SubModels;

/// <summary>
/// KiCad Common settings appearance model
/// </summary>
public class CommonAppearanceModel : Model
{
   #region Local Props
   private double _hiContDimmFactor = 0;
   private int _iconScale = 0;
   private int _iconTheme = 0;
   private bool _showScrollbars;
   private double _textEditorZoom;
   private int _toolbarIconSize;
   private bool _useIconInMenus;
   #endregion

   #region Constructors
   /// <inheritdoc/>
   public CommonAppearanceModel() { }
   #endregion

   #region Methods

   #endregion

   #region Full Props
   /// <summary>
   /// High-contrast dimming factor
   /// </summary>
   [JsonProperty("hicontrast_dimming_factor")]
   public double HiContrastDimmFactor
   {
      get => _hiContDimmFactor;
      set
      {
         _hiContDimmFactor = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Icon scale
   /// </summary>
   [JsonProperty("icon_scale")]
   public int IconScale
   {
      get => _iconScale;
      set
      {
         _iconScale = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Icon theme
   /// </summary>
   [JsonProperty("icon_theme")]
   public int IconTheme
   {
      get => _iconTheme;
      set
      {
         _iconTheme = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Show scrollbars
   /// </summary>
   [JsonProperty("show_scrollbars")]
   public bool ShowScrollbars
   {
      get => _showScrollbars;
      set
      {
         _showScrollbars = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Text editor zoom
   /// </summary>
   [JsonProperty("text_editor_zoom")]
   public double TextEditorZoom
   {
      get => _textEditorZoom;
      set
      {
         _textEditorZoom = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Toolbar icon size
   /// </summary>
   [JsonProperty("toolbar_icon_size")]
   public int ToolbarIconSize
   {
      get => _toolbarIconSize;
      set
      {
         _toolbarIconSize = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Use icons in dropdown? menus
   /// </summary>
   [JsonProperty("use_icons_in_menus")]
   public bool UseIconsInMenus
   {
      get => _useIconInMenus;
      set
      {
         _useIconInMenus = value;
         OnPropertyChanged();
      }
   }
   #endregion
}
