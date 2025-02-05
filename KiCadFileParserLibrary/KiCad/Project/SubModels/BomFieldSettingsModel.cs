using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MVVMLibrary;

using Newtonsoft.Json;

namespace KiCadFileParserLibrary.KiCad.Project.SubModels;

public class BomFieldSettingsModel : Model
{
   #region Local Props
   private bool _groupBy;
   private string? _label;
   private string? _name;
   private bool _show;
   #endregion

   #region Constructors
   public BomFieldSettingsModel() { }
   #endregion

   #region Methods

   #endregion

   #region Full Props
   [JsonProperty(PropertyName = "group_by")]
   public bool GroupBy
   {
      get => _groupBy;
      set
      {
         _groupBy = value;
         OnPropertyChanged();
      }
   }

   [JsonProperty(PropertyName = "label")]
   public string? Label
   {
      get => _label;
      set
      {
         _label = value;
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

   [JsonProperty(PropertyName = "show")]
   public bool Show
   {
      get => _show;
      set
      {
         _show = value;
         OnPropertyChanged();
      }
   }
   #endregion
}
