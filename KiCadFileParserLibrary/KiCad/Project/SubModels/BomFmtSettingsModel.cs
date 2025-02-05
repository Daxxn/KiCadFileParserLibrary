using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MVVMLibrary;

using Newtonsoft.Json;

namespace KiCadFileParserLibrary.KiCad.Project.SubModels;

public class BomFmtSettingsModel : Model
{
   #region Local Props
   private string? _fieldDelimiter;
   private bool _keepLineBreaks;
   private bool _keepTabs;
   private string? _name;
   private string? _refDelimiter;
   private string? _refRangeDelimiter;
   private string? _stringDelimiter;

   #endregion

   #region Constructors
   public BomFmtSettingsModel() { }
   #endregion

   #region Methods

   #endregion

   #region Full Props
   [JsonProperty(PropertyName = "field_delimiter")]
   public string? FieldDelimiter
   {
      get => _fieldDelimiter;
      set
      {
         _fieldDelimiter = value;
         OnPropertyChanged();
      }
   }

   [JsonProperty(PropertyName = "keep_line_breaks")]
   public bool KeepLineBreaks
   {
      get => _keepLineBreaks;
      set
      {
         _keepLineBreaks = value;
         OnPropertyChanged();
      }
   }

   [JsonProperty(PropertyName = "keep_tabs")]
   public bool KeepTabs
   {
      get => _keepTabs;
      set
      {
         _keepTabs = value;
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

   [JsonProperty(PropertyName = "ref_delimiter")]
   public string? RefDelimiter
   {
      get => _refDelimiter;
      set
      {
         _refDelimiter = value;
         OnPropertyChanged();
      }
   }

   [JsonProperty(PropertyName = "ref_range_delimiter")]
   public string? RefRangeDelimiter
   {
      get => _refRangeDelimiter;
      set
      {
         _refRangeDelimiter = value;
         OnPropertyChanged();
      }
   }

   [JsonProperty(PropertyName = "string_delimiter")]
   public string? StringDelimiter
   {
      get => _stringDelimiter;
      set
      {
         _stringDelimiter = value;
         OnPropertyChanged();
      }
   }
   #endregion
}
