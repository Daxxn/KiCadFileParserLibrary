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
/// Project ERC settings model.
/// </summary>
public class ErcModel : Model
{
   #region Local Props
   private ObservableCollection<string>? _exclusions;
   private MetadataModel? _metadata;
   private PinMappingModel _pinMap = new();
   private SchRuleSeverityModel? _ruleSeverities;
   #endregion

   #region Constructors
   /// <inheritdoc/>
   public ErcModel() { }
   #endregion

   #region Methods

   #endregion

   #region Full Props
   /// <summary>
   /// List of exclusions.
   /// </summary>
   [JsonProperty(PropertyName = "erc_exclusions")]
   public ObservableCollection<string>? Exclusions
   {
      get => _exclusions;
      set
      {
         _exclusions = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Metadata
   /// </summary>
   [JsonProperty(PropertyName = "meta")]
   public MetadataModel? Metadata
   {
      get => _metadata;
      set
      {
         _metadata = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Pin map save model.
   /// <para/>
   /// Used to save to the project file. Use <see cref="PinMap"/>
   /// </summary>
   [JsonProperty(PropertyName = "pin_map")]
   public int[][] PinMapData
   {
      get => PinMap.ConvertFromMap();
      set
      {
         PinMap.ConvertToMap(value);
      }
   }

   /// <summary>
   /// Pin map
   /// </summary>
   [JsonIgnore]
   public PinMappingModel PinMap
   {
      get => _pinMap;
      set
      {
         _pinMap = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Schematic rule severities.
   /// </summary>
   [JsonProperty(PropertyName = "rule_severities")]
   public SchRuleSeverityModel? RuleSeverities
   {
      get => _ruleSeverities;
      set
      {
         _ruleSeverities = value;
         OnPropertyChanged();
      }
   }
   #endregion
}
