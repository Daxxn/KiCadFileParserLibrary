using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MVVMLibrary;

using Newtonsoft.Json;

namespace KiCadFileParserLibrary.KiCad.Settings.Common.SubModels;

/// <summary>
/// Meta settings
/// </summary>
public class MetaSettingsModel : Model
{
   #region Local Props
   private int _version;
   #endregion

   #region Constructors
   /// <inheritdoc/>
   public MetaSettingsModel() { }
   #endregion

   #region Methods

   #endregion

   #region Full Props
   /// <summary>
   /// No idea what this is for.
   /// </summary>
   [JsonProperty("version")]
   public int Version
   {
      get => _version;
      set
      {
         _version = value;
         OnPropertyChanged();
      }
   }
   #endregion
}
