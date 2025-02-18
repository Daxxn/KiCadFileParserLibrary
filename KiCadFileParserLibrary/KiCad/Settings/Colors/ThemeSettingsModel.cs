using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.KiCad.Settings.Colors.Editor;

using MVVMLibrary;

using Newtonsoft.Json;

namespace KiCadFileParserLibrary.KiCad.Settings.Colors;

/// <summary>
/// KiCad theme colors.
/// </summary>
public class ThemeSettingsModel : Model
{
   #region Local Props
   private Viewer3DThemeModel _3dViewer = new();
   private BoardThemeModel _board = new();
   private GerberThemeModel _gerber = new();
   private MetaSettingsModel _meta = new();
   private SchematicThemeModel _schematic = new();
   #endregion

   #region Constructors
   /// <inheritdoc/>
   public ThemeSettingsModel() { }
   #endregion

   #region Methods
   #endregion

   #region Full Props
   /// <summary>
   /// </summary>
   [JsonProperty("3d_viewer")]
   public Viewer3DThemeModel Viewer
   {
      get => _3dViewer;
      set
      {
         _3dViewer = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// </summary>
   [JsonProperty("board")]
   public BoardThemeModel Board
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
   [JsonProperty("gerbview")]
   public GerberThemeModel Gerber
   {
      get => _gerber;
      set
      {
         _gerber = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// </summary>
   [JsonProperty("meta")]
   public MetaSettingsModel Meta
   {
      get => _meta;
      set
      {
         _meta = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// </summary>
   [JsonProperty("schematic")]
   public SchematicThemeModel Schematic
   {
      get => _schematic;
      set
      {
         _schematic = value;
         OnPropertyChanged();
      }
   }
   #endregion
}
