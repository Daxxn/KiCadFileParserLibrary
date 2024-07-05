using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

using static System.Net.Mime.MediaTypeNames;

namespace KiCadFileParserLibrary.KiCad.General
{
   [SExprNode("image")]
   public class ImageModel : IKiCadReadable
   {
      #region Local Props
      public LocationModel Location { get; set; } = new();

      [SExprSubNode("layer")]
      public string Layer { get; set; } = "";

      [SExprSubNode("scale")]
      public double? Scale { get; set; }

      [SExprSubNode("uuid")]
      public string ID { get; set; } = "";

      public List<string> Data { get; set; } = [];
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

      #endregion
   }
}
