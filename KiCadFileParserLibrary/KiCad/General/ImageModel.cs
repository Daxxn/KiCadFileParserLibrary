using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

using MVVMLibrary;

using static System.Net.Mime.MediaTypeNames;

namespace KiCadFileParserLibrary.KiCad.General
{
   [SExprNode("image")]
   public class ImageModel : Model, IKiCadReadable
   {
      #region Local Props
      private LocationModel _location = new();
      private string _layer = "";
      private double? _scale;
      private string _id = "";
      private ObservableCollection<string> _data = [];
      #endregion

      #region Constructors
      public ImageModel() { }
      #endregion

      #region Methods
      public void ParseNode(Node node)
      {
         if (node.Children != null)
         {
            var props = GetType().GetProperties();

            KiCadParseUtils.ParseNodes(props, node, this);
            KiCadParseUtils.ParseSubNodes(props, node, this);

            // Read all the image data:
            var dataNode = node.GetNode("data");
            if (dataNode != null)
            {
               if (dataNode.Properties != null)
               {
                  Data = [];
                  foreach (var p in dataNode.Properties[1..])
                  {
                     Data.Add(p);
                  }
               }
            }
         }
      }

      public void WriteNode(StringBuilder builder, int indent, string? auxName = null)
      {
         builder.Append('\t', indent);
         builder.AppendLine($"(image");

         Location.WriteNode(builder, indent + 1);

         builder.Append('\t', indent + 1);
         builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("layer", Layer));

         if (Scale != null)
         {
            builder.Append('\t', indent + 1);
            builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("scale", Scale)); 
         }

         builder.Append('\t', indent + 1);
         builder.AppendLine("(data");
         foreach (var d in Data)
         {
            builder.Append('\t', indent + 2);
            builder.Append('"');
            builder.Append(d);
            builder.AppendLine("\"");
         }
         builder.Append('\t', indent + 1);
         builder.AppendLine(")");

         builder.Append('\t', indent + 1);
         builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("uuid", ID));

         builder.Append('\t', indent);
         builder.AppendLine(")");
      }
      #endregion

      #region Full Props
      public LocationModel Location
      {
         get => _location;
         set
         {
            _location = value;
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

      [SExprSubNode("scale")]
      public double? Scale
      {
         get => _scale;
         set
         {
            _scale = value;
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

      public ObservableCollection<string> Data
      {
         get => _data;
         set
         {
            _data = value;
            OnPropertyChanged();
         }
      }
      #endregion
   }
}
