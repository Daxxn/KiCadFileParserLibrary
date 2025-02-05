using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.Footprints.SubModels;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

namespace KiCadFileParserLibrary.KiCad.General.Graphics
{
   [SExprNode("gr_text_box")]
   public class GrTextBoxModel : GraphicBase
   {
      #region Local Props
      private bool _locked;
      private string _text = "";
      private XyModel? _start;
      private XyModel? _end;
      private CoordinateModel? _points;
      private double? _angle;
      private bool _hasBorder;
      private string _layer;
      private string _id;
      private EffectsModel _effect = new();
      private StrokeModel? _stroke;
      private RenderCacheModel? _renderCache;
      #endregion

      #region Constructors
      public GrTextBoxModel() { }
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
         }
      }

      public override void WriteNode(StringBuilder builder, int indent, string? auxName = null)
      {
         builder.Append('\t', indent);
         builder.AppendLine($"(gr_text_box \"{Text}\"");

         if (Locked)
         {
            builder.Append('\t', indent + 1);
            builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("locked", Locked));
         }

         Start?.WriteNode(builder, indent + 1, "start");
         End?.WriteNode(builder, indent + 1, "end");

         Points?.WriteNode(builder, indent + 1);

         if (Angle != null)
         {
            builder.Append('\t', indent + 1);
            builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("angle", Angle));
         }

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
      public XyModel? Start
      {
         get => _start;
         set
         {
            _start = value;
            OnPropertyChanged();
         }
      }

      [SExprNode("end")]
      public XyModel? End
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
         get => _points;
         set
         {
            _points = value;
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
