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

namespace KiCadFileParserLibrary.KiCad.Boards
{
   [SExprNode("arc")]
   public class TraceArcModel : Model, IKiCadReadable
   {
      #region Local Props
      private LocationModel _start = new();
      private LocationModel _middle = new();
      private LocationModel _end = new();
      private double _width = 0;
      private string _layer = "";
      private int _net = -1;
      private string _id = "";
      private bool _locked = false;

      #endregion

      #region Constructors
      public TraceArcModel() { }
      #endregion

      #region Methods
      public void ParseNode(Node node)
      {
         if (node.Properties != null && node.Children != null)
         {
            var props = GetType().GetProperties();

            KiCadParseUtils.ParseNodes(props, node, this);
            KiCadParseUtils.ParseSubNodes(props, node, this);
            KiCadParseUtils.ParseTokens(props, node, this);
         }
      }

      public void WriteNode(StringBuilder builder, int indent, string? auxName = null)
      {
         builder.Append('\t', indent);
         builder.AppendLine("(arc");

         Start?.WriteNode(builder, indent + 1, "start");
         Middle?.WriteNode(builder, indent + 1, "mid");
         End?.WriteNode(builder, indent + 1, "end");

         builder.Append('\t', indent + 1);
         builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("width", Width));

         if (Locked)
         {
            builder.Append('\t', indent + 1);
            builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("locked", Locked));
         }

         builder.Append('\t', indent + 1);
         builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("layer", Layer));

         builder.Append('\t', indent + 1);
         builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("net", Net));

         if (ID != null)
         {
            builder.Append('\t', indent + 1);
            builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("uuid", ID));
         }
         builder.Append('\t', indent);
         builder.AppendLine(")");
      }
      #endregion

      #region Full Props
      [SExprNode("start")]
      public LocationModel Start
      {
         get => _start;
         set
         {
            _start = value;
            OnPropertyChanged();
         }
      }

      [SExprNode("mid")]
      public LocationModel Middle
      {
         get => _middle;
         set
         {
            _middle = value;
            OnPropertyChanged();
         }
      }

      [SExprNode("end")]
      public LocationModel End
      {
         get => _end;
         set
         {
            _end = value;
            OnPropertyChanged();
         }
      }

      [SExprSubNode("width")]
      public double Width
      {
         get => _width;
         set
         {
            _width = value;
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

      [SExprSubNode("net")]
      public int Net
      {
         get => _net;
         set
         {
            _net = value;
            OnPropertyChanged();
         }
      }

      [SExprSubNode("uuid")]
      public string? ID
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
