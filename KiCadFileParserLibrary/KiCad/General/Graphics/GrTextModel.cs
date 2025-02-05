using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.Footprints.Graphics;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

namespace KiCadFileParserLibrary.KiCad.General.Graphics
{
   [SExprNode("gr_text")]
   public class GrTextModel : GraphicBase
   {
      #region Local Props
      private bool _locked;
      private string _text = "";
      private FpTextLayerModel _layer = new();
      private bool _knockout;
      private LocationModel? _location;
      private string _id = "";
      private EffectsModel? _effect;
      private RenderCacheModel? _renderCache;
      #endregion

      #region Constructors
      public GrTextModel() { }
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
            KiCadParseUtils.ParseListNodes(props, node, this);
         }
      }

      public override void WriteNode(StringBuilder builder, int indent, string? auxName = null)
      {
         builder.Append('\t', indent);
         builder.AppendLine($"(gr_text \"{Text}\"");

         if (Locked)
         {
            builder.Append('\t', indent + 1);
            builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("locked", Locked));
         }

         Location?.WriteNode(builder, indent + 1);

         Layer?.WriteNode(builder, indent + 1);
         //builder.Append('\t', indent + 1);
         //builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("layer", Layer));

         builder.Append('\t', indent + 1);
         builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("uuid", ID));

         Effects?.WriteNode(builder, indent + 1);

         RenderCache?.WriteNode(builder, indent + 1);

         builder.Append('\t', indent);
         builder.AppendLine(")");
      }
      #endregion

      #region Full Props
      [SExprSubNode("locked")]
      public bool Locked
      {
         get => _locked;
         set
         {
            _locked = value;
            OnPropertyChanged();
         }
      }

      [SExprProperty(1)]
      public string Text
      {
         get => _text;
         set
         {
            _text = value;
            OnPropertyChanged();
         }
      }

      public FpTextLayerModel Layer
      {
         get => _layer;
         set
         {
            _layer = value;
            OnPropertyChanged();
         }
      }

      private bool Knockout
      {
         get => _knockout;
         set
         {
            _knockout = value;
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
         get => _effect;
         set
         {
            _effect = value;
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
