using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.KiCad.Boards.SubModels;
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
      public bool Hide { get; set; } // I cant find prop this anymore...
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
            KiCadParseUtils.ParseTokens(props, node, this);

            var justNode = node.GetNode("justify");
            if (justNode is null) return;
            if (justNode.Properties!.Count <= 1) return;
            Justify = [];
            foreach (var p in justNode.Properties[1..])
            {
               if (Enum.TryParse(p, true, out TextJustify output))
               {
                  Justify.Add(output);
               }
            }
         }
      }

      public void WriteNode(StringBuilder builder, int indent, string? auxName = null)
      {
         builder.Append('\t', indent);
         builder.AppendLine($"(effects");

         Font?.WriteNode(builder, indent + 1);

         if (Justify != null)
         {
            builder.Append('\t', indent + 1);
            builder.Append($"(justify");

            foreach (var jst in Justify)
            {
               builder.Append($" {jst.ToString().ToLower()}");
            }
            builder.AppendLine($")");
         }

         builder.Append('\t', indent);
         builder.AppendLine(")");
      }
      #endregion

      #region Full Props

      #endregion
   }
}
