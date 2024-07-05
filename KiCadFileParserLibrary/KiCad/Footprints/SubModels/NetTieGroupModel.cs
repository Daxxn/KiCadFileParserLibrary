using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.SExprParser;

namespace KiCadFileParserLibrary.KiCad.Footprints.SubModels
{
   [SExprNode("net_tie_pad_groups")]
   public class NetTieGroupModel : IKiCadReadable
   {
      #region Local Props
      public List<string>? Groups { get; set; }
      #endregion

      #region Constructors
      public NetTieGroupModel() { }
      #endregion

      #region Methods
      public void ParseNode(Node node)
      {
         if (node.Properties is null) return;

         Groups = [];
         foreach (var group in node.Properties[1..])
         {
            Groups.Add(group);
         }
      }

      public void WriteNode(StringBuilder builder, int indent, string? auxName = null)
      {
         if (Groups is null) return;

         builder.Append('\t', indent);
         builder.Append("(net_tie_pad_groups");

         foreach (var grp in Groups)
         {
            builder.Append($" \"{grp}\"");
         }

         builder.AppendLine(")");
      }
      #endregion

      #region Full Props

      #endregion
   }
}
