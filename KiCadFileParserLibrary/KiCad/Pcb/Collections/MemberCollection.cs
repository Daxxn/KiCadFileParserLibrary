using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

namespace KiCadFileParserLibrary.KiCad.Pcb.Collections
{
    [SExprListNode("members")]
   public class MemberCollection : IKiCadReadable
   {
      #region Local Props
      public List<string>? Members { get; set; }
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
         }
      }
      #endregion

      #region Full Props

      #endregion
   }
}
