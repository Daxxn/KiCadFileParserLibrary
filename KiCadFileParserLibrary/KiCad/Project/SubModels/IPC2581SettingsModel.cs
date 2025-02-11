using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MVVMLibrary;

using Newtonsoft.Json;

namespace KiCadFileParserLibrary.KiCad.Project.SubModels;

/// <summary>
/// The IPC2581 production file output generator settings.
/// <para/>
/// Node: I'm not sure what the full names of all these properties are. It's not easy to find info on this format without paying $190!
/// </summary>
public class IPC2581SettingsModel : Model
{
   #region Local Props
   private string? _dist;
   private string? _distPn;
   private string? _internalID;
   private string? _mfg;
   private string? _mpn;
   #endregion

   #region Constructors
   public IPC2581SettingsModel() { }
   #endregion

   #region Methods

   #endregion

   #region Full Props
   /// <summary>
   /// Distribution? maybe?
   /// </summary>
   [JsonProperty(PropertyName = "dist")]
   public string? Dist
   {
      get => _dist;
      set
      {
         _dist = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Distribution part number?
   /// </summary>
   [JsonProperty(PropertyName = "distpn")]
   public string? DistPn
   {
      get => _distPn;
      set
      {
         _distPn = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Internal project ID
   /// </summary>
   [JsonProperty(PropertyName = "internal_id")]
   public string? InternalID
   {
      get => _internalID;
      set
      {
         _internalID = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// No idea...
   /// </summary>
   [JsonProperty(PropertyName = "mfg")]
   public string? MFG
   {
      get => _mfg;
      set
      {
         _mfg = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Manufacturer part number?
   /// </summary>
   [JsonProperty(PropertyName = "mpn")]
   public string? MPN
   {
      get => _mpn;
      set
      {
         _mpn = value;
         OnPropertyChanged();
      }
   }
   #endregion
}
