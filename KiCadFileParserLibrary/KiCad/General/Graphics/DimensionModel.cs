using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.Footprints.SubModels;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

namespace KiCadFileParserLibrary.KiCad.General.Graphics
{
   [SExprNode("dimension")]
   public class DimensionModel : GraphicBase
   {
      #region Local Props
      private bool _locked;
      private DimensionType _type;
      private string _layer;
      private double _height;
      private string _id;
      private CoordinateModel? _points;
      private double _leaderLength;
      private GrTextModel? _text;
      private DimensionStyleModel? _style;
      private DimensionFormatModel? _format;
      #endregion

      #region Constructors
      public DimensionModel() { }
      #endregion

      #region Methods
      public override void ParseNode(Node node)
      {
         if (node.Properties != null && node.Children != null)
         {
            var props = GetType().GetProperties();
            KiCadParseUtils.ParseSubNodes(props, node, this);
            KiCadParseUtils.ParseNodes(props, node, this);
            KiCadParseUtils.ParseTokens(props, node, this);
         }
      }

      public override void WriteNode(StringBuilder builder, int indent, string? auxName = null)
      {
         builder.Append('\t', indent);
         builder.AppendLine("(dimension");

         builder.Append('\t', indent + 1);
         builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("type", Type));

         builder.Append('\t', indent + 1);
         builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("layer", Layer));

         builder.Append('\t', indent + 1);
         builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("uuid", ID));

         Points?.WriteNode(builder, indent + 1);

         if (Height != 0)
         {
            builder.Append('\t', indent + 1);
            builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("height", Height));
         }

         Text?.WriteNode(builder, indent + 1);

         Format?.WriteNode(builder, indent + 1);

         Style?.WriteNode(builder, indent + 1);

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

      [SExprSubNode("type")]
      public DimensionType Type
      {
         get => _type;
         set
         {
            _type = value;
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

      [SExprSubNode("height")]
      public double Height
      {
         get => _height;
         set
         {
            _height = value;
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

      public CoordinateModel? Points
      {
         get => _points;
         set
         {
            _points = value;
            OnPropertyChanged();
         }
      }

      [SExprSubNode("leader_length")]
      public double LeaderLength
      {
         get => _leaderLength;
         set
         {
            _leaderLength = value;
            OnPropertyChanged();
         }
      }

      public GrTextModel? Text
      {
         get => _text;
         set
         {
            _text = value;
            OnPropertyChanged();
         }
      }

      public DimensionStyleModel? Style
      {
         get => _style;
         set
         {
            _style = value;
            OnPropertyChanged();
         }
      }

      public DimensionFormatModel? Format
      {
         get => _format;
         set
         {
            _format = value;
            OnPropertyChanged();
         }
      }
      #endregion
   }
}
