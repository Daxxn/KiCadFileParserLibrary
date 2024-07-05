using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.General.Collections;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

namespace KiCadFileParserLibrary.KiCad.General
{
    [SExprNode("zone")]
   public class ZoneModel : IKiCadReadable
   {
      #region Local Props
      [SExprSubNode("net")]
      public int Net { get; set; } = -1;

      [SExprSubNode("net_name")]
      public string NetName { get; set; } = "";

      [SExprSubNode("layer")]
      public string? Layer { get; set; }

      public LayerCollection? Layers { get; set; }

      [SExprSubNode("uuid")]
      public string? ID { get; set; }

      [SExprSubNode("name")]
      public string? Name { get; set; }

      public HatchModel? Hatch { get; set; }

      [SExprSubNode("priority")]
      public int Priority { get; set; } = 0;

      public ConnectPadsModel? ConnectPads { get; set; }

      [SExprSubNode("min_thickness")]
      public double? MinThickness { get; set; }

      [SExprSubNode("filled_areas_thickness")]
      public bool FilledAreasThickness { get; set; }

      public ZoneFillSettingsModel? Fill { get; set; }

      public ZoneKeepoutModel? Keepout { get; set; }

      public PolygonModel? Polygon { get; set; }

      public ZoneFillPolygonModel? PolygonFill { get; set; }

      public ZoneFillSegments? Segments { get; set; }
      #endregion

      #region Constructors
      public ZoneModel() { }
      #endregion

      #region Methods
      public void ParseNode(Node node)
      {
         if (node.Properties != null && node.Children != null)
         {
            var props = GetType().GetProperties();

            KiCadParseUtils.ParseSubNodes(props, node, this);
            KiCadParseUtils.ParseNodes(props, node, this);
            KiCadParseUtils.ParseListNodes(props, node, this);
         }
      }

      public void WriteNode(StringBuilder builder, int indent, string? auxName = null)
      {
         builder.Append('\t', indent);
         builder.AppendLine("(zone");

         builder.Append('\t', indent + 1);
         builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("net", Net));

         builder.Append('\t', indent + 1);
         builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("net_name", NetName));

         if (Layer != null)
         {
            builder.Append('\t', indent + 1);
            builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("layer", Layer));
         }
         else
         {
            Layers?.WriteNode(builder, indent + 1);
         }

         if (ID != null)
         {
            builder.Append('\t', indent + 1);
            builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("uuid", ID));
         }

         if (Name != null)
         {
            builder.Append('\t', indent + 1);
            builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("name", Name));
         }

         Hatch?.WriteNode(builder, indent + 1);

         if (Priority != 0)
         {
            builder.Append('\t', indent + 1);
            builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("priority", Priority));
         }

         ConnectPads?.WriteNode(builder, indent + 1);

         if (MinThickness != null)
         {
            builder.Append('\t', indent + 1);
            builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("min_thickness", MinThickness));
         }

         builder.Append('\t', indent + 1);
         builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("filled_areas_thickness", FilledAreasThickness));

         Keepout?.WriteNode(builder, indent + 1);

         Fill?.WriteNode(builder, indent + 1);

         Polygon?.WriteNode(builder, indent + 1);

         PolygonFill?.WriteNode(builder, indent + 1);

         Segments?.WriteNode(builder, indent + 1);

         builder.Append('\t', indent);
         builder.AppendLine(")");
      }
      #endregion

      #region Full Props

      #endregion
   }
}
