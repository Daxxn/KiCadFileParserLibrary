using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MVVMLibrary;

using Newtonsoft.Json;

namespace KiCadFileParserLibrary.KiCad.Project.SubModels;

/// <summary>
/// Pinned Libraries
/// <para/>
/// NOTE: These are best edited in KiCad. It's not really necessary to edit this from here.
/// </summary>
public class LibrariesModel : Model
{
   #region Local Props
   private ObservableCollection<string>? _pinnedFootprintLibs;
   private ObservableCollection<string>? _pinnedSymbolLibs;
   #endregion

   #region Constructors
   /// <inheritdoc/>
   public LibrariesModel() { }
   #endregion

   #region Methods

   #endregion

   #region Full Props
   /// <summary>
   /// List of pinned footprint libraries.
   /// </summary>
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

   /// <summary>
   /// List of pinned symbol libraries.
   /// </summary>
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
