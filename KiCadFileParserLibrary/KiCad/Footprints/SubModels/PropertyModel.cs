using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.General;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

namespace KiCadFileParserLibrary.KiCad.Footprints.SubModels
{
   [SExprNode("property")]
   public class PropertyModel : IKiCadReadable
   {
      #region Local Props
      [SExprProperty(1)]
      public string Key { get; set; } = "";

      [SExprProperty(2)]
      public string Value { get; set; } = "";

      public LocationModel Location { get; set; } = new();

      [SExprSubNode("unlocked")]
      public bool Unlocked { get; set; }

      [SExprSubNode("hide")]
      public bool Hide { get; set; }

      [SExprSubNode("layer")]
      public string Layer { get; set; } = "";

      [SExprSubNode("uuid")]
      public string ID { get; set; } = "";

      public EffectsModel Effects { get; set; } = new();
      #endregion

      #region Constructors
      public PropertyModel() { }
      #endregion

      #region Methods
      public void ParseNode(Node node)
      {
         if (node.Properties != null && node.Children != null)
         {
            var props = GetType().GetProperties();
            KiCadParseUtils.ParseProperties(props, node, this);
            KiCadParseUtils.ParseNodes(props, node, this);
            KiCadParseUtils.ParseSubNodes(props, node, this);
         }
      }

      public void WriteNode(StringBuilder builder, int indent, string? auxName = null)
      {
         builder.Append('\t', indent);
         builder.AppendLine($"(property \"{Key}\" \"{Value}\"");

         Location?.WriteNode(builder, indent + 1);

         if (Unlocked)
         {
            builder.Append('\t', indent + 1);
            builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("unlocked", Unlocked));
         }

         builder.Append('\t', indent + 1);
         builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("layer", Layer));

         if (Hide)
         {
            builder.Append('\t', indent + 1);
            builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("hide", Hide));
         }

         builder.Append('\t', indent + 1);
         builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("uuid", ID));

         Effects?.WriteNode(builder, indent + 1);

         builder.Append('\t', indent);
         builder.AppendLine(")");
      }
      #endregion

      #region Full Props

      #endregion
   }
}
