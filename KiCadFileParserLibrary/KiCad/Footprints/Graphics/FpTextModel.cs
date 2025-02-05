using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.General;
using KiCadFileParserLibrary.KiCad.General.Graphics;
using KiCadFileParserLibrary.KiCad.Boards;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

namespace KiCadFileParserLibrary.KiCad.Footprints.Graphics
{
    [SExprNode("fp_text")]
   public class FpTextModel : GraphicBase
   {
      #region Local Props
      private FootprintTextType _type;
      private string _text = "";
      private LocationModel? _location;
      private bool _isUnlocked;
      private bool _knockout;
      private string _layer;
      private string _id;
      private EffectsModel? _effects;
      private RenderCacheModel? _renderCache;
      #endregion

      #region Constructors
      public FpTextModel() { }
      #endregion

      #region Methods
      public override void ParseNode(Node node)
      {
         if (node.Children != null && node.Properties != null)
         {
            var props = GetType().GetProperties();

            KiCadParseUtils.ParseNodes(props, node, this);
            KiCadParseUtils.ParseSubNodes(props, node, this);
            KiCadParseUtils.ParseProperties(props, node, this);

            // Added check for knockout param.
            // For some stupid reason, its in the "layer" node...
            var layerNode = node.GetNode("layer");
            if (layerNode?.Properties is null) return;
            if (layerNode?.Properties.Contains("knockout") == true)
            {
               var knockoutProp = props.FirstOrDefault(p => p.Name == "Knockout");
               knockoutProp?.SetValue(this, true);
            }
         }
      }

      public override void WriteNode(StringBuilder builder, int indent, string? auxName = null)
      {
         builder.Append('\t', indent);
         builder.AppendLine($"(fp_text {Type.ToString().ToLower()} \"{Text}\"");

         Location?.WriteNode(builder, indent + 1);

         if (IsUnlocked)
         {
            builder.Append('\t', indent + 1);
            builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("unlocked", IsUnlocked));
         }

         if (Knockout)
         {
            builder.Append('\t', indent + 1);
            builder.AppendLine($"(layer \"{Layer}\" knockout)");
         }
         else
         {
            builder.Append('\t', indent + 1);
            builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("layer", Layer));
         }

         builder.Append('\t', indent + 1);
         builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("uuid", ID));

         Effects?.WriteNode(builder, indent + 1);

         RenderCache?.WriteNode(builder, indent + 1);

         builder.Append('\t', indent);
         builder.AppendLine(")");
      }
      #endregion

      #region Full Props
      [SExprProperty(1)]
      public FootprintTextType Type
      {
         get => _type;
         set
         {
            _type = value;
            OnPropertyChanged();
         }
      }

      [SExprProperty(2)]
      public string Text
      {
         get => _text;
         set
         {
            _text = value;
            OnPropertyChanged();
         }
      }

      public LocationModel? Location
      {
         get => _location;
         set
         {
            _location = value;
            OnPropertyChanged();
         }
      }

      [SExprSubNode("unlocked")]
      public bool IsUnlocked
      {
         get => _isUnlocked;
         set
         {
            _isUnlocked = value;
            OnPropertyChanged();
         }
      }

      public bool Knockout
      {
         get => _knockout;
         set
         {
            _knockout = value;
            OnPropertyChanged();
         }
      }

      [SExprSubNode("layer")]
      public string Layer
      {
         get => _layer;
         set
         {
            _layer = value;
            OnPropertyChanged();
         }
      }

      [SExprSubNode("uuid")]
      public string ID
      {
         get => _id;
         set
         {
            _id = value;
            OnPropertyChanged();
         }
      }

      public EffectsModel? Effects
      {
         get => _effects;
         set
         {
            _effects = value;
            OnPropertyChanged();
         }
      }

      public RenderCacheModel? RenderCache
      {
         get => _renderCache;
         set
         {
            _renderCache = value;
            OnPropertyChanged();
         }
      }
      #endregion
   }
}
