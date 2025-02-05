using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MVVMLibrary;

using Newtonsoft.Json;

namespace KiCadFileParserLibrary.KiCad.Project.SubModels;

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
   public BomSettingsModel() { }
   #endregion

   #region Methods

   #endregion

   #region Full Props
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
