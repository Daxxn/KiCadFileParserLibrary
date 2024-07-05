using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

namespace KiCadFileParserLibrary.KiCad.General
{
   [SExprNode("keepout")]
   public class ZoneKeepoutModel : IKiCadReadable
   {
      #region Local Props
      [SExprSubNode("tracks")]
      public KeepoutType Tracks { get; set; }

      [SExprSubNode("vias")]
      public KeepoutType Vias { get; set; }

      [SExprSubNode("pads")]
      public KeepoutType Pads { get; set; }

      [SExprSubNode("copperpour")]
      public KeepoutType Copper { get; set; }

      [SExprSubNode("footprints")]
      public KeepoutType Footprints { get; set; }
      #endregion

      #region Constructors
      public ZoneKeepoutModel() { }
      #endregion

      #region Methods
      public void ParseNode(Node node)
      {
         if (node.Children != null)
         {
            var props = GetType().GetProperties();
            KiCadParseUtils.ParseSubNodes(props, node, this);
         }
      }

      public void WriteNode(StringBuilder builder, int indent, string? auxName = null)
      {
         builder.Append('\t', indent);
         builder.AppendLine("(keepout");

         builder.Append('\t', indent + 1);
         builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("tracks", Tracks));

         builder.Append('\t', indent + 1);
         builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("vias", Vias));

         builder.Append('\t', indent + 1);
         builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("pads", Pads));

         builder.Append('\t', indent + 1);
         builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("copperpour", Copper));

         builder.Append('\t', indent + 1);
         builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("footprints", Footprints));

         builder.Append('\t', indent);
         builder.AppendLine(")");
      }
      #endregion

      #region Full Props

      #endregion
   }
}
