using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MVVMLibrary;

using Newtonsoft.Json;

namespace KiCadFileParserLibrary.KiCad.Project.SubModels;

/// <summary>
/// KiCad project BOM field settings.
/// </summary>
public class BomFieldSettingsModel : Model
{
   #region Local Props
   private bool _groupBy;
   private string? _label;
   private string? _name;
   private bool _show;
   #endregion

   #region Constructors
   /// <inheritdoc/>
   public BomFieldSettingsModel() { }
   #endregion

   #region Methods

   #endregion

   #region Full Props
   /// <summary>
   /// Group BOM field.
   /// </summary>
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

   /// <summary>
   /// BOM field label
   /// </summary>
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

   /// <summary>
   /// BOM field name.
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
   /// Show field.
   /// </summary>
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
