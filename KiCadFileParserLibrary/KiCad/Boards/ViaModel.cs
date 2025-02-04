using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.General;
using KiCadFileParserLibrary.KiCad.General.Collections;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.KiCad.Boards.SubModels;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

namespace KiCadFileParserLibrary.KiCad.Boards
{
   [SExprNode("via")]
   public class ViaModel : IKiCadReadable
   {
      #region Local Props
      [SExprSubNode("type")]
      public ViaType Type { get; set; }

      public LocationModel? Location { get; set; }

      [SExprSubNode("size")]
      public double Size { get; set; }

      [SExprSubNode("drill")]
      public double Drill { get; set; }

      public LayerCollection? Layers { get; set; }

      [SExprToken("remove_unused_layers")]
      public bool RemoveUnusedLayers { get; set; }

      [SExprToken("keep_end_layers")]
      public bool KeepEndLayers { get; set; }

      [SExprSubNode("free")]
      public bool IsFree { get; set; }

      [SExprSubNode("zone_layer_connections")]
      public string ZoneLayerConnections { get; set; } = "";

      [SExprSubNode("net")]
      public int Net { get; set; } = -1;

      [SExprSubNode("uuid")]
      public string ID { get; set; } = "";

      public TeardropModel? Teardrops { get; set; }
      #endregion

      #region Constructors
      public ViaModel() { }
      #endregion

      #region Methods
      public void ParseNode(Node node)
      {
         if (node.Properties != null && node.Children != null)
         {
            var props = GetType().GetProperties();

            KiCadParseUtils.ParseTokens(props, node, this);
            KiCadParseUtils.ParseNodes(props, node, this);
            KiCadParseUtils.ParseSubNodes(props, node, this);
            KiCadParseUtils.ParseListNodes(props, node, this);
         }
      }

      public void WriteNode(StringBuilder builder, int indent, string? auxName = null)
      {
         builder.Append('\t', indent);
         builder.AppendLine($"(via");

         Location?.WriteNode(builder, indent + 1);

         builder.Append('\t', indent + 1);
         builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("size", Size));

         builder.Append('\t', indent + 1);
         builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("drill", Drill));

         Layers?.WriteNode(builder, indent + 1);

         if (RemoveUnusedLayers)
         {
            builder.Append('\t', indent + 1);
            builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("remove_unused_layers", RemoveUnusedLayers));
         }

         if (KeepEndLayers)
         {
            builder.Append('\t', indent + 1);
            builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("keep_end_layers", KeepEndLayers));
         }

         if (IsFree)
         {
            builder.Append('\t', indent + 1);
            builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("free", IsFree));
         }

         if (!string.IsNullOrEmpty(ZoneLayerConnections))
         {
            builder.Append('\t', indent + 1);
            builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("zone_layer_connections", ZoneLayerConnections));
         }

         Teardrops?.WriteNode(builder, indent + 1);

         builder.Append('\t', indent + 1);
         builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("net", Net));

         if (ID != null)
         {
            builder.Append('\t', indent + 1);
            builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("uuid", ID));
         }

         builder.Append('\t', indent);
         builder.AppendLine($")");
      }
      #endregion

      #region Full Props

      #endregion
   }
}
