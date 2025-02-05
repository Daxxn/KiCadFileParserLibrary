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

using MVVMLibrary;

namespace KiCadFileParserLibrary.KiCad.Boards.SubModels
{
   [SExprNode("comment")]
   public class CommentModel : Model, IKiCadReadable
   {
      private int _index = -1;
      private string _comment = "";

      public void ParseNode(Node node)
      {
         if (node.Properties != null)
         {
            var props = GetType().GetProperties();
            KiCadParseUtils.ParseProperties(props, node, this);
         }
      }

      public void WriteNode(StringBuilder builder, int indent, string? auxName = null)
      {
         builder.Append('\t', indent);
         builder.AppendLine($"(comment {Index} \"{Comment}\")");
      }

      [SExprProperty(1)]
      public int Index
      {
         get => _index;
         set
         {
            _index = value;
            OnPropertyChanged();
         }
      }

      [SExprProperty(2)]
      public string Comment
      {
         get => _comment;
         set
         {
            _comment = value;
            OnPropertyChanged();
         }
      }
   }
}
