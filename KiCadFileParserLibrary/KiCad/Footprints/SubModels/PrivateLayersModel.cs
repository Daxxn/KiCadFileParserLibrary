using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.SExprParser;

using MVVMLibrary;

namespace KiCadFileParserLibrary.KiCad.Footprints.SubModels;

/// <summary>
/// List of layers not used by the <see cref="Boards.PcbModel">PCB.</see>
/// <para/>
/// TODO: May not work and should probably move to the collections namespace.
/// </summary>
[SExprNode("private_layers")]
public class PrivateLayersModel : Model, IKiCadReadable
{
   #region Local Props
   private ObservableCollection<string>? _layers;
   #endregion

   #region Constructors
   /// <inheritdoc/>
   public PrivateLayersModel() { }
   #endregion

   #region Methods
   /// <inheritdoc/>
   public void ParseNode(Node node)
   {
      if (node.Properties is null) return;
      if (node.Properties.Count > 1)
      {
         Layers = [];
         foreach (var layer in node.Properties[1..])
         {
            Layers.Add(layer);
         }
      }
   }

   /// <inheritdoc/>
   public override string ToString()
   {
      return $"Private-Layers - {Layers?.Count}";
   }
   #endregion

   #region Full Props
   /// <summary>
   /// List of private layers.
   /// </summary>
   public ObservableCollection<string>? Layers
   {
      get => _layers;
      set
      {
         _layers = value;
         OnPropertyChanged();
      }
   }
   #endregion
}
