using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MVVMLibrary;

using Newtonsoft.Json;

namespace KiCadFileParserLibrary.KiCad.Project.SubModels
{
   public class IPC2581SettingsModel : Model
   {
      #region Local Props
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
      private string? _dist;

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
      private string? _distPn;

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
      private string? _internalID;

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
      private string? _mfg;

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
      private string? _mpn;
      #endregion

      #region Constructors
      public IPC2581SettingsModel() { }
      #endregion

      #region Methods

      #endregion

      #region Full Props

      #endregion
   }
}
