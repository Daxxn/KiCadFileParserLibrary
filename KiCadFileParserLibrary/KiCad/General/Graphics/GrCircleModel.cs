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
   [SExprNode("gr_circle")]
   public class GrCircleModel : GraphicBase
   {
      #region Local Props
      private XyModel _center = new();
      private XyModel _end = new();
      private bool _locked;
      private StrokeModel? _stroke;
      private FillType _fill;
      private string _layer;
      private string _id = "";
      #endregion

      #region Constructors
      public GrCircleModel() { }
      #endregion

      #region Methods
      public override void ParseNode(Node node)
      {
         if (node.Children != null)
         {
            var props = GetType().GetProperties();

            KiCadParseUtils.ParseNodes(props, node, this);
            KiCadParseUtils.ParseSubNodes(props, node, this);
         }
      }

      public override void WriteNode(StringBuilder builder, int indent, string? auxName = null)
      {
         builder.Append('\t', indent);
         builder.AppendLine($"(gr_circle");

         Center.WriteNode(builder, indent + 1, "center");
         End.WriteNode(builder, indent + 1, "end");

         if (Locked)
         {
            builder.Append('\t', indent + 1);
            builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("locked", Locked));
         }

         Stroke?.WriteNode(builder, indent + 1);

         builder.Append('\t', indent + 1);
         builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("fill", Fill));

         builder.Append('\t', indent + 1);
         builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("layer", Layer));

         builder.Append('\t', indent + 1);
         builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("uuid", ID));

         builder.Append('\t', indent);
         builder.AppendLine(")");
      }
      #endregion

      #region Full Props
      [SExprNode("center")]
      public XyModel Center
      {
         get => _center;
         set
         {
            _center = value;
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

      public StrokeModel? Stroke
      {
         get => _stroke;
         set
         {
            _stroke = value;
            OnPropertyChanged();
         }
      }

      [SExprSubNode("fill")]
      public FillType Fill
      {
         get => _fill;
         set
         {
            _fill = value;
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
      #endregion
   }
}
