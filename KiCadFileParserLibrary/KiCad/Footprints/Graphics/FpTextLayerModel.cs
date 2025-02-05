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

[SExprNode("layer")]
public class FpTextLayerModel : Model, IKiCadReadable
{
   #region Local Props
   private string _layerName = "";
   private bool _knockout;
   #endregion

   #region Constructors
   public FpTextLayerModel() { }
   #endregion

   #region Methods
   public void ParseNode(Node node)
   {
      if (node.Properties != null)
      {
         var props = GetType().GetProperties();

         KiCadParseUtils.ParseProperties(props, node, this);
      }
   }

   public void WriteNode(StringBuilder builder, int indent, string? auxName = null)
   {
      builder.Append('\t', indent);
      builder.Append($"(layer \"{LayerName}\"");
      if (Knockout)
      {
         builder.Append(" knockout");
      }
      builder.AppendLine(")");
   }
   #endregion

   #region Full Props
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

   [SExprProperty(2)]
   public bool Knockout
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
