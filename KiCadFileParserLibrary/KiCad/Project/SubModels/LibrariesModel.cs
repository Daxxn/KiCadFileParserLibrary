using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MVVMLibrary;

using Newtonsoft.Json;

namespace KiCadFileParserLibrary.KiCad.Project.SubModels
{
   public class LibrariesModel : Model
   {
      #region Local Props
      private ObservableCollection<string>? _pinnedFootprintLibs;
      private ObservableCollection<string>? _pinnedSymbolLibs;
      #endregion

      #region Constructors
      public LibrariesModel() { }
      #endregion

      #region Methods

      #endregion

      #region Full Props
      [JsonProperty(PropertyName = "pinned_footprint_libs")]
      public ObservableCollection<string>? PinnedFootprintLibs
      {
         get => _pinnedFootprintLibs;
         set
         {
            _pinnedFootprintLibs = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "pinned_symbol_libs")]
      public ObservableCollection<string>? PinnedSymbolLibs
      {
         get => _pinnedSymbolLibs;
         set
         {
            _pinnedSymbolLibs = value;
            OnPropertyChanged();
         }
      }
      #endregion
   }
}
