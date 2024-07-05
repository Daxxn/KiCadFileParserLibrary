using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.SExprParser;

namespace KiCadFileParserLibrary.KiCad.Boards.Collections
{
   // Not Used. Keep just in case the via "zone_layer_connections" node is actually an array.
   // Nothing is documented so good luck!!
   [SExprNode("zone_layer_connections")]
   public class ZoneLayerCollection : IKiCadReadable
   {
      #region Local Props
      public List<string> Layers { get; set; } = [];
      #endregion

      #region Constructors
      public ZoneLayerCollection() { }

      public void ParseNode(Node node)
      {
         if (node.Properties != null)
         {
            Layers = [];
            foreach (var prop in node.Properties)
            {
               Layers.Add(prop);
            }
         }
      }

      public void WriteNode(StringBuilder builder, int indent, string? auxName = null)
      {
         builder.Append('\t', indent);
         builder.Append("(zone_layer_connections");
         foreach (var layer in Layers)
         {
            builder.Append($" \"{layer}\"");
         }
         builder.AppendLine(")");
      }
      #endregion

      #region Methods

      #endregion

      #region Full Props

      #endregion
   }
}
