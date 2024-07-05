using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

namespace KiCadFileParserLibrary.KiCad.General.Graphics
{
   [SExprNode("render_cache")]
   public class RenderCacheModel : IKiCadReadable
   {
      #region Local Props
      [SExprProperty(1)]
      public string? Text { get; set; }

      [SExprProperty(2)]
      public int Angle { get; set; }

      public List<PolygonModel> Polygon { get; set; } = [];
      #endregion

      #region Constructors
      public RenderCacheModel() { }
      #endregion

      #region Methods
      public void ParseNode(Node node)
      {
         if (node.Properties != null && node.Children != null)
         {
            var props = GetType().GetProperties();

            KiCadParseUtils.ParseProperties(props, node, this);

            var polygons = node.GetNodes("polygon");
            if (polygons is null) return;
            foreach (var poly in polygons)
            {
               PolygonModel newPoly = new();
               newPoly.ParseNode(poly);
               Polygon.Add(newPoly);
            }
         }
      }

      public void WriteNode(StringBuilder builder, int indent, string? auxName = null)
      {
         builder.Append('\t', indent);
         builder.AppendLine($"(render_cache \"{Text}\" {Angle}");

         foreach (var polys in Polygon)
         {
            polys.WriteNode(builder, indent + 1);
         }

         builder.Append('\t', indent);
         builder.AppendLine(")");
      }
      #endregion

      #region Full Props

      #endregion
   }
}
