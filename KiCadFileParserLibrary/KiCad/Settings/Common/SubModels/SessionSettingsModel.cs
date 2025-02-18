using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MVVMLibrary;

using Newtonsoft.Json;

namespace KiCadFileParserLibrary.KiCad.Settings.Common.SubModels;

/// <summary>
/// Session settings
/// </summary>
public class SessionSettingsModel : Model
{
   #region Local Props
   private ObservableCollection<string> _pinnedFpLibs = [];
   private ObservableCollection<string> _pinnedSymLibs = [];
   private bool _rememberOpenFiles;
   #endregion

   #region Constructors
   /// <inheritdoc/>
   public SessionSettingsModel() { }
   #endregion

   #region Methods

   #endregion

   #region Full Props
   /// <summary>
   /// Pinned footprint libraries
   /// </summary>
   [JsonProperty("pinned_fp_libs")]
   public ObservableCollection<string> PinnedFootprintLibs
   {
      get => _pinnedFpLibs;
      set
      {
         _pinnedFpLibs = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Pinned symbol libraries
   /// </summary>
   [JsonProperty("pinned_symbol_libs")]
   public ObservableCollection<string> PinnedSymbolLibs
   {
      get => _pinnedSymLibs;
      set
      {
         _pinnedSymLibs = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Remember opened files on start
   /// </summary>
   [JsonProperty("remember_open_files")]
   public bool RememberOpenFiles
   {
      get => _rememberOpenFiles;
      set
      {
         _rememberOpenFiles = value;
         OnPropertyChanged();
      }
   }
   #endregion
}
