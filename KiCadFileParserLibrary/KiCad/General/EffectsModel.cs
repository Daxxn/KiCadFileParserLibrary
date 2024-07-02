using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.Pcb;
using KiCadFileParserLibrary.KiCad.Pcb.SubModels;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

namespace KiCadFileParserLibrary.KiCad.General
{
   [SExprNode("effects")]
   public class EffectsModel : IKiCadReadable
   {
      #region Local Props
      public FontModel? Font { get; set; }

      [SExprSubNode("justify")]
      public List<TextJustify>? Justify { get; set; }

      [SExprToken("hide")]
      public bool Hide { get; set; }
      #endregion

      #region Constructors
      public EffectsModel() { }
      #endregion

      #region Methods
      public void ParseNode(Node node)
      {
         if (node.Children != null)
         {
            var props = GetType().GetProperties();
            KiCadParseUtils.ParseNodes(props, node, this);

            var justNode = node.GetNode("justify");
            if (justNode is null) return;
            if (justNode.Properties is null) return;
            Justify = [];
            foreach (var p in justNode.Properties)
            {
               if (Enum.TryParse(p, out TextJustify output))
               {
                  Justify.Add(output);
               }
            }
         }
      }
      #endregion

      #region Full Props

      #endregion
   }
}
