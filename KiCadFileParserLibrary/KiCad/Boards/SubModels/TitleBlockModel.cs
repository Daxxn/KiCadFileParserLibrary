using System;
using System.Collections.Generic;
using System.Globalization;
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
   [SExprNode("title_block")]
   public class TitleBlockModel : IKiCadReadable
   {
      #region Local Props
      [SExprSubNode("title")]
      public string? Title { get; set; }

      [SExprSubNode("date")]
      public DateOnly? Date { get; set; }

      [SExprSubNode("rev")]
      public string? Revision { get; set; }

      [SExprSubNode("company")]
      public string? Company { get; set; }

      public List<CommentModel>? Comments { get; set; }
      #endregion

      #region Constructors
      public TitleBlockModel() { }
      #endregion

      #region Methods
      public void ParseNode(Node node)
      {
         if (node.Children != null)
         {
            var props = GetType().GetProperties();

            KiCadParseUtils.ParseSubNodes(props, node, this);

            var dateNode = node.GetNode("date");
            if (dateNode is null) return;
            if (dateNode.Properties!.Count > 1)
            {
               if (DateOnly.TryParse(dateNode.Properties[1], out DateOnly date))
               {
                  Date = date;
               }
            }

            var commentNodes = node.GetNodes("comment");
            if (commentNodes is null) return;
            Comments = [];
            foreach (var commentNode in commentNodes)
            {
               var comment = new CommentModel();
               comment.ParseNode(commentNode);
               Comments.Add(comment);
            }
         }
      }
      public void WriteNode(StringBuilder builder, int indent, string? auxName = null)
      {
         builder.Append('\t', indent);
         builder.AppendLine("(title_block");

         if (Title != null)
         {
            builder.Append('\t', indent + 1);
            builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("title", Title));
         }

         if (Date != null)
         {
            builder.Append('\t', indent + 1);
            builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("date", Date));
         }

         if (Revision != null)
         {
            builder.Append('\t', indent + 1);
            builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("rev", Revision));
         }

         if (Company != null)
         {
            builder.Append('\t', indent + 1);
            builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("company", Company));
         }

         if (Comments != null)
         {
            foreach (var comm in Comments)
            {
               comm.WriteNode(builder, indent + 1);
            }
         }

         builder.Append('\t', indent);
         builder.AppendLine(")");
      }

      public override string ToString()
      {
         return $"Title - {Title} - Rev: {Revision} - Date: {Date:MM-dd-yy} - Comp: {Company} - Comm {Comments?.Count}";
      }
      #endregion

      #region Full Props

      #endregion
   }
}
