using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MVVMLibrary;

using Newtonsoft.Json;

namespace KiCadFileParserLibrary.KiCad.Settings.Common.SubModels;

/// <summary>
/// Not sure what these are for.
/// <para/>
/// No touchee!!!
/// </summary>
public class UnknownModel : Model
{
   #region Local Props
   private int _sashPos;
   #endregion

   #region Constructors
   /// <inheritdoc/>
   public UnknownModel() { }
   #endregion

   #region Methods

   #endregion

   #region Full Props
   /// <summary>
   /// No touchee!!!
   /// </summary>
   [JsonProperty("sash_pos")]
   public int SashPos
   {
      get => _sashPos;
      set
      {
         _sashPos = value;
         OnPropertyChanged();
      }
   }
   #endregion
}
