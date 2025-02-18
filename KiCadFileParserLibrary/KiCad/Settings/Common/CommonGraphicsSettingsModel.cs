using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MVVMLibrary;

using Newtonsoft.Json;

namespace KiCadFileParserLibrary.KiCad.Settings.Common;

/// <summary>
/// KiCad common graphics settings
/// </summary>
public class CommonGraphicsSettingsModel : Model
{
   #region Local Props
   private int _cairoAAMode;
   private int _openglAAMode;
   #endregion

   #region Constructors
   /// <inheritdoc/>
   public CommonGraphicsSettingsModel() { }
   #endregion

   #region Methods

   #endregion

   #region Full Props
   /// <summary>
   /// Cairo anti-aliasing mode
   /// </summary>
   [JsonProperty("cairo_antialiasing_mode")]
   public int CairoAAMode
   {
      get => _cairoAAMode;
      set
      {
         _cairoAAMode = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// OpenGL anti-aliasing mode
   /// </summary>
   [JsonProperty("opengl_antialiasing_mode")]
   public int OpenGlAAMode
   {
      get => _openglAAMode;
      set
      {
         _openglAAMode = value;
         OnPropertyChanged();
      }
   }
   #endregion
}
