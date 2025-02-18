using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

using MVVMLibrary;

namespace KiCadFileParserLibrary.KiCad.Footprints.Graphics;

/// <summary>
/// <see cref="Footprint"/> text layer graphic.
/// </summary>
[SExprNode("layer")]
public class FpTextLayerModel : Model, IKiCadReadable
{
   #region Local Props
   private string _layerName = "";
   private KnockoutText? _knockout;
   #endregion

   #region Constructors
   /// <inheritdoc/>
   public FpTextLayerModel() { }
   #endregion

   #region Methods
   /// <inheritdoc/>
   public void ParseNode(Node node)
   {
      if (node.Properties != null)
      {
         var props = GetType().GetProperties();

         KiCadParseUtils.ParseProperties(props, node, this);
      }
   }
   #endregion

   #region Full Props
   /// <summary>
   /// Layer name.
   /// </summary>
   [SExprProperty(1)]
   public string LayerName
   {
      get => _layerName;
      set
      {
         _layerName = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Inverted text render mode.
   /// </summary>
   [SExprProperty(2)]
   public KnockoutText? Knockout
   {
      get => _knockout;
      set
      {
         _knockout = value;
         OnPropertyChanged();
      }
   }
   #endregion

}
