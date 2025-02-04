using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

namespace KiCadFileParserLibrary.KiCad.Boards.Collections
{
   [SExprListNode("members")]
   public class MemberCollection : IKiCadReadable
   {
      #region Local Props
      public List<string> Members { get; set; } = [];

      private bool UseQuotes { get; set; }
      #endregion

      #region Constructors
      public MemberCollection() { }
      #endregion

      #region Methods
      public void ParseNode(Node node)
      {
         if (node.Children != null)
         {
            var memberNode = node.GetNode("members");
            if (memberNode?.Properties is null) return;
            Members = [];
            foreach (var member in memberNode.Properties[1..])
            {
               Members.Add(member);
            }

            if (node.Type == "group")
            {
               UseQuotes = true;
            }
         }
      }

      public void WriteNode(StringBuilder builder, int indent, string? auxName = null)
      {
         builder.Append('\t', indent);
         builder.AppendLine("(members");
         foreach (var member in Members)
         {
            builder.Append('\t', indent + 1);
            if (UseQuotes)
            {
               builder.AppendLine($"\"{member}\"");
            }
            else
            {
               builder.AppendLine(member);
            }
         }
         builder.Append('\t', indent);
         builder.AppendLine(")");
      }
      #endregion

      #region Full Props

      #endregion
   }
}
