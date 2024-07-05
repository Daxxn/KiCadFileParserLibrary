using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.Boards.SubModels;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.KiCad.Schematics.SubModels;
using KiCadFileParserLibrary.SExprParser;

namespace KiCadFileParserLibrary.KiCad.Schematics.Collections
{
   [SExprListNode("junction")]
   public class JunctionCollection : IKiCadReadable
   {
      #region Local Props
      public List<JunctionModel>? Junctions { get; set; }
      #endregion

      #region Constructors
      public JunctionCollection() { }
      #endregion

      #region Methods
      public void ParseNode(Node node)
      {
         if (node.Children is null) return;
         Junctions = [];
         foreach (var child in node.Children)
         {
            var junction = new JunctionModel();
            junction.ParseNode(child);
            Junctions.Add(junction);
         }
      }

      public void WriteNode(StringBuilder builder, int indent, string? auxName = null)
      {
         throw new NotImplementedException();
      }
      #endregion

      #region Full Props

      #endregion
   }
}
