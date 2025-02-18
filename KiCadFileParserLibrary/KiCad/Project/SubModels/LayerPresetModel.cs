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
/// Layer preset used in the PCB editor.
/// </summary>
public class LayerPresetModel : Model
{
   #region Local Props
   private string _name = "Layer Preset";
   private int _activeLayer = 0;
   private ObservableCollection<int> _layers = [];
   private ObservableCollection<int> _renderLayers = [];
   #endregion

   #region Constructors
   /// <inheritdoc/>
   public LayerPresetModel() { }
   #endregion

   #region Methods

   #endregion

   #region Full Props
   /// <summary>
   /// Layer preset name.
   /// </summary>
   [JsonProperty(PropertyName = "name")]
   public string Name
   {
      get => _name;
      set
      {
         _name = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Active layer.
   /// </summary>
   [JsonProperty(PropertyName = "activeLayer")]
   public int ActiveLayer
   {
      get => _activeLayer;
      set
      {
         _activeLayer = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// List of layers.
   /// </summary>
   [JsonProperty(PropertyName = "layers")]
   public ObservableCollection<int> Layers
   {
      get => _layers;
      set
      {
         _layers = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Rendered layers.
   /// </summary>
   [JsonProperty(PropertyName = "renderLayers")]
   public ObservableCollection<int> RenderLayers
   {
      get => _renderLayers;
      set
      {
         _renderLayers = value;
         OnPropertyChanged();
      }
   }
   #endregion
}
