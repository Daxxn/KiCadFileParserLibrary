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
/// Bill of materials settings.
/// </summary>
public class BomSettingsModel : Model
{
   #region Local Props
   private bool _excludeDnp;
   private ObservableCollection<BomFieldSettingsModel>? _fieldSettings;
   private string? _filterString;
   private bool _groupSymbols;
   private string? _name;
   private bool _sortAscending;
   private string? _sortField;
   #endregion

   #region Constructors
   /// <inheritdoc/>
   public BomSettingsModel() { }
   #endregion

   #region Methods

   #endregion

   #region Full Props
   /// <summary>
   /// Exclude "Do Not Populate" parts from the BOM.
   /// </summary>
   [JsonProperty(PropertyName = "exclude_dnp")]
   public bool ExcludeDNP
   {
      get => _excludeDnp;
      set
      {
         _excludeDnp = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// List of fields and their order used in the BOM.
   /// </summary>
   [JsonProperty(PropertyName = "fields_ordered")]
   public ObservableCollection<BomFieldSettingsModel>? FieldSettings
   {
      get => _fieldSettings;
      set
      {
         _fieldSettings = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Filter
   /// </summary>
   [JsonProperty(PropertyName = "filter_string")]
   public string? FilterString
   {
      get => _filterString;
      set
      {
         _filterString = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Group symbols
   /// </summary>
   [JsonProperty(PropertyName = "group_symbols")]
   public bool GroupSymbols
   {
      get => _groupSymbols;
      set
      {
         _groupSymbols = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Name
   /// </summary>
   [JsonProperty(PropertyName = "name")]
   public string? Name
   {
      get => _name;
      set
      {
         _name = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Sort the BOM in ascending order
   /// </summary>
   [JsonProperty(PropertyName = "sort_asc")]
   public bool SortAscending
   {
      get => _sortAscending;
      set
      {
         _sortAscending = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// The field used to sort the BOM.
   /// </summary>
   [JsonProperty(PropertyName = "sort_field")]
   public string? SortField
   {
      get => _sortField;
      set
      {
         _sortField = value;
         OnPropertyChanged();
      }
   }
   #endregion
}
