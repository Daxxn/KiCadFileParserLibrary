using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.Footprints;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

namespace KiCadFileParserLibrary.KiCad.General
{
    [SExprNode("group")]
   public class GroupModel : IKiCadReadable
   {
      #region Local Props
      [SExprProperty(1)]
      public string? Name { get; set; }

      [SExprSubNode("uuid")]
      public string? ID { get; set; }

      [SExprPropArray("members")]
      public List<string>? Members { get; set; }
      #endregion

      #region Constructors
      public GroupModel() { }
      #endregion

      #region Methods
      public void ParseNode(Node node)
      {
         if (node.Properties != null && node.Children != null)
         {
            var props = GetType().GetProperties();
            KiCadParseUtils.ParseProperties(props, node, this);
            KiCadParseUtils.ParseSubNodes(props, node, this);

            var memberNode = node.GetNode("members");
            if (memberNode is null) return;
            if (memberNode.Properties is null || memberNode.Properties?.Count > 1) return;
            Members = [];
            foreach (var p in memberNode.Properties![1..])
            {
               Members.Add(p);
            }
         }
      }
      #endregion

      #region Full Props

      #endregion
   }
}
