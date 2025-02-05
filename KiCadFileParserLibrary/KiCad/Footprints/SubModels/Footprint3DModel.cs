using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.General;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

using MVVMLibrary;

namespace KiCadFileParserLibrary.KiCad.Footprints.SubModels
{
   [SExprNode("model")]
   public class Footprint3DModel : Model, IKiCadReadable
   {
      #region Local Props
      private string? _path;
      private double? _opacity;
      private XyzModel _offset = new();
      private XyzModel _scale = new();
      private XyzModel _rotation = new();
      #endregion

      #region Constructors
      public Footprint3DModel() { }
      #endregion

      #region Methods
      public void ParseNode(Node node)
      {
         if (node.Children != null && node.Properties != null)
         {
            var props = GetType().GetProperties();
            KiCadParseUtils.ParseProperties(props, node, this);
            KiCadParseUtils.ParseSubNodes(props, node, this);
            KiCadParseUtils.ParseNodes(props, node, this);
         }
      }

      public void WriteNode(StringBuilder builder, int indent, string? auxName = null)
      {
         builder.Append('\t', indent);
         builder.AppendLine($"(model \"{Path}\"");

         if (Opacity != null)
         {
            builder.Append('\t', indent + 1);
            builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("opacity", Opacity));
         }

         builder.Append('\t', indent + 1);
         builder.AppendLine("(offset");
         Offset.WriteNode(builder, indent + 2);
         builder.Append('\t', indent + 1);
         builder.AppendLine(")");

         builder.Append('\t', indent + 1);
         builder.AppendLine("(scale");
         Scale.WriteNode(builder, indent + 2);
         builder.Append('\t', indent + 1);
         builder.AppendLine(")");

         builder.Append('\t', indent + 1);
         builder.AppendLine("(rotate");
         Rotation.WriteNode(builder, indent + 2);
         builder.Append('\t', indent + 1);
         builder.AppendLine(")");

         builder.Append('\t', indent);
         builder.AppendLine(")");
      }
      #endregion

      #region Full Props
      [SExprProperty(1)]
      public string? Path
      {
         get => _path;
         set
         {
            _path = value;
            OnPropertyChanged();
         }
      }

      [SExprSubNode("opacity")]
      public double? Opacity
      {
         get => _opacity;
         set
         {
            _opacity = value;
            OnPropertyChanged();
         }
      }

      [SExprNode("offset/xyz")]
      public XyzModel Offset
      {
         get => _offset;
         set
         {
            _offset = value;
            OnPropertyChanged();
         }
      }

      [SExprNode("scale/xyz")]
      public XyzModel Scale
      {
         get => _scale;
         set
         {
            _scale = value;
            OnPropertyChanged();
         }
      }

      [SExprNode("rotate/xyz")]
      public XyzModel Rotation
      {
         get => _rotation;
         set
         {
            _rotation = value;
            OnPropertyChanged();
         }
      }
      #endregion
   }
}
