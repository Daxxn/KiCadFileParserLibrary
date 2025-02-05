using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

namespace KiCadFileParserLibrary.KiCad.General.Graphics
{
   [SExprNode("gr_arc")]
   public class GrArcModel : GraphicBase
   {
      #region Local Props
      private XyModel _start = new();
      private XyModel _middle = new();
      private XyModel _end = new();
      private StrokeModel _stroke = new();
      private string _layer = "";
      private string _id = "";
      private bool _locked;
      #endregion

      #region Constructors
      public GrArcModel() { }
      #endregion

      #region Methods
      public override void ParseNode(Node node)
      {
         if (node.Children != null)
         {
            var props = GetType().GetProperties();

            KiCadParseUtils.ParseSubNodes(props, node, this);
            KiCadParseUtils.ParseNodes(props, node, this);
         }
      }

      public override void WriteNode(StringBuilder builder, int indent, string? auxName = null)
      {
         builder.Append('\t', indent);
         builder.AppendLine($"(gr_arc");

         Start.WriteNode(builder, indent + 1, "start");
         Middle.WriteNode(builder, indent + 1, "mid");
         End.WriteNode(builder, indent + 1, "end");

         if (Locked)
         {
            builder.Append('\t', indent + 1);
            builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("locked", Locked));
         }

         Stroke.WriteNode(builder, indent + 1);

         builder.Append('\t', indent + 1);
         builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("layer", Layer));

         builder.Append('\t', indent + 1);
         builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("uuid", ID));

         builder.Append('\t', indent);
         builder.AppendLine(")");
      }
      #endregion

      #region Full Props
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

      [SExprNode("mid")]
      public XyModel Middle
      {
         get => _middle;
         set
         {
            _middle = value;
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

      public StrokeModel Stroke
      {
         get => _stroke;
         set
         {
            _stroke = value;
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
      #endregion
   }
}
