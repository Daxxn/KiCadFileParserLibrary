using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.General;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.SExprParser;

namespace KiCadFileParserLibrary.KiCad.Footprints.Collections
{
   [SExprListNode("group")]
   public class GroupCollection : IKiCadReadable
   {
      #region Local Props
      public List<GroupModel> Groups { get; set; } = [];
      #endregion

      #region Constructors
      public GroupCollection() { }
      #endregion

      #region Methods
      public void ParseNode(Node node)
      {
         var children = node.GetNodes("group");
         if (children is null) return;
         Groups = [];
         foreach (var child in children)
         {
            GroupModel fp = new();
            fp.ParseNode(child);
            Groups.Add(fp);
         }
      }

      public void WriteNode(StringBuilder builder, int indent, string? auxName = null)
      {
         foreach (var group in Groups)
         {
            group.WriteNode(builder, indent);
         }
      }
      #endregion

      #region Full Props

      #endregion
   }
}
