using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.Footprints.SubModels;
using KiCadFileParserLibrary.KiCad.General;
using KiCadFileParserLibrary.KiCad.General.Graphics;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

namespace KiCadFileParserLibrary.KiCad.Footprints.Graphics
{
   [SExprNode("fp_text_box")]
   public class FpTextBoxModel : GraphicBase
   {
      #region Local Props
      private bool _locked;
      private string _text = "";
      private XyModel _start = new();
      private XyModel _end = new();
      private CoordinateModel? _point;
      private double? _angle;
      private bool _hasBorder = false;
      private string _layer = "";
      private string _id = "";
      private EffectsModel _effect = new();
      private StrokeModel? _stroke;
      private RenderCacheModel? _renderCache;
      #endregion

      #region Constructors
      public FpTextBoxModel() { }
      #endregion

      #region Methods
      public override void ParseNode(Node node)
      {
         if (node.Properties != null && node.Children != null)
         {
            var props = GetType().GetProperties();

            KiCadParseUtils.ParseProperties(props, node, this);
            KiCadParseUtils.ParseSubNodes(props, node, this);
            KiCadParseUtils.ParseNodes(props, node, this);
            KiCadParseUtils.ParseTokens(props, node, this);
         }
      }

      public override void WriteNode(StringBuilder builder, int indent, string? auxName = null)
      {
         builder.Append('\t', indent);
         builder.AppendLine($"(fp_text_box \"{Text}\"");

         Start.WriteNode(builder, indent + 1, "start");
         End.WriteNode(builder, indent + 1, "end");

         if (Angle != null)
         {
            builder.Append('\t', indent + 1);
            builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("angle", Angle));
         }

         Points?.WriteNode(builder, indent + 1);

         builder.Append('\t', indent + 1);
         builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("layer", Layer));

         builder.Append('\t', indent + 1);
         builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("uuid", ID));

         Effects?.WriteNode(builder, indent + 1);

         if (HasBorder)
         {
            builder.Append('\t', indent + 1);
            builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("border", HasBorder));
         }

         Stroke?.WriteNode(builder, indent + 1);

         if (Locked)
         {
            builder.Append('\t', indent + 1);
            builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("locked", Locked));
         }

         RenderCache?.WriteNode(builder, indent + 1);

         builder.Append('\t', indent);
         builder.AppendLine(")");
      }
      #endregion

      #region Full Props
      [SExprToken("locked")]
      public bool Locked
      {
         get => _locked;
         set
         {
            _locked = value;
            OnPropertyChanged();
         }
      }

      [SExprProperty(1, true)]
      public string Text
      {
         get => _text;
         set
         {
            _text = value;
            OnPropertyChanged();
         }
      }

      [SExprNode("start")]
      public XyModel Start
      {
         get => _start;
         set
         {
            _start = value;
            OnPropertyChanged();
         }
      }

      [SExprNode("end")]
      public XyModel End
      {
         get => _end;
         set
         {
            _end = value;
            OnPropertyChanged();
         }
      }

      public CoordinateModel? Points
      {
         get => _point;
         set
         {
            _point = value;
            OnPropertyChanged();
         }
      }

      [SExprSubNode("angle")]
      public double? Angle
      {
         get => _angle;
         set
         {
            _angle = value;
            OnPropertyChanged();
         }
      }

      [SExprSubNode("border")]
      public bool HasBorder
      {
         get => _hasBorder;
         set
         {
            _hasBorder = value;
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

      public EffectsModel Effects
      {
         get => _effect;
         set
         {
            _effect = value;
            OnPropertyChanged();
         }
      }

      public StrokeModel? Stroke
      {
         get => _stroke;
         set
         {
            _stroke = value;
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
