using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

namespace KiCadFileParserLibrary.KiCad.Boards.SubModels
{
   [SExprNode("layer")]
   public class LayerModel : IKiCadReadable
   {
      #region Local Props
      [SExprProperty(0)]
      public int Index { get; set; } = -1;

      [SExprProperty(1)]
      public string? Name { get; set; }

      [SExprProperty(2)]
      public LayerType Type { get; set; }

      [SExprProperty(3)]
      public string? UserName { get; set; }
      #endregion

      #region Constructors
      public LayerModel() { }
      #endregion

      #region Methods
      public void ParseNode(Node node)
      {
         if (node.Properties is null) return;
         var props = GetType().GetProperties();
         KiCadParseUtils.ParseProperties(props, node, this);
      }

      public void WriteNode(StringBuilder builder, int indent, string? auxName = null)
      {
         builder.Append('\t', indent);
         builder.Append('(');
         builder.Append(Index);
         builder.Append(" \"");
         builder.Append(Name);
         builder.Append("\" ");
         builder.Append(Type);
         if (UserName != null)
         {
            builder.Append(" \"");
            builder.Append(UserName);
            builder.AppendLine("\")");
         }
         else
         {
            builder.AppendLine(")");
         }
      }
      #endregion

      #region Full Props

      #endregion
   }
}
