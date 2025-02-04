using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

namespace KiCadFileParserLibrary.KiCad.Footprints.Graphics;

[SExprNode("layer")]
public class FpTextLayerModel : IKiCadReadable
{
   [SExprProperty(1)]
   public string LayerName { get; set; } = "";

   [SExprProperty(2)]
   public bool Knockout { get; set; } = false;

   public void ParseNode(Node node)
   {
      if (node.Properties != null)
      {
         var props = GetType().GetProperties();

         KiCadParseUtils.ParseProperties(props, node, this);
      }
   }

   public void WriteNode(StringBuilder builder, int indent, string? auxName = null)
   {
      builder.Append('\t', indent);
      builder.Append($"(layer \"{LayerName}\"");
      if (Knockout)
      {
         builder.Append(" knockout");
      }
      builder.AppendLine(")");
   }
}
