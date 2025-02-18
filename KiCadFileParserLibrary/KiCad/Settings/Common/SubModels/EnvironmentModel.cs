using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MVVMLibrary;

using Newtonsoft.Json;

namespace KiCadFileParserLibrary.KiCad.Settings.Common.SubModels;

/// <summary>
/// KiCad common environment variables
/// </summary>
public class EnvironmentModel : Model
{
   #region Local Props
   private Dictionary<string, string> _variables = [];
   #endregion

   #region Constructors
   /// <inheritdoc/>
   public EnvironmentModel() { }
   #endregion

   #region Methods

   #endregion

   #region Full Props
   /// <summary>
   /// Environment variable dictionary.
   /// </summary>
   [JsonProperty("vars")]
   public Dictionary<string, string> Variables
   {
      get => _variables;
      set
      {
         _variables = value;
         OnPropertyChanged();
      }
   }
   #endregion
}
