using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.Pcb;
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
      #endregion

      #region Full Props

      #endregion
   }
}
