using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.SExprParser;

namespace KiCadFileParserLibrary.KiCad.General.Collections
{
   [SExprListNode("layers")]
   public class LayerCollection : IKiCadReadable
   {
      #region Local Props
      public List<string> Layers { get; set; } = [];
      #endregion

      #region Constructors
      public LayerCollection() { }
      #endregion

      #region Methods
      public void ParseNode(Node node)
      {
         var layerNode = node.GetNode("layers");
         if (layerNode is null) return;
         if (layerNode.Properties is null) return;
         Layers = [];
         foreach (var layer in layerNode.Properties[1..])
         {
            Layers.Add(layer);
         }
      }

      public void WriteNode(StringBuilder builder, int indent, string? auxName = null)
      {
         builder.Append('\t', indent);
         builder.Append("(layers");
         foreach (var layer in Layers)
         {
            builder.Append($" \"{layer}\"");
         }
         builder.AppendLine(")");
      }
      #endregion

      #region Full Props

      #endregion
   }
}
