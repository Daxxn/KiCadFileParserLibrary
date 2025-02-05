using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
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
   [SExprNode("title_block")]
   public class TitleBlockModel : Model, IKiCadReadable
   {
      #region Local Props
      private string? _title;

      private DateOnly? _date;

      private string? _rev;

      private string? _company;

      private ObservableCollection<CommentModel>? _comments;
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
      [SExprSubNode("title")]
      public string? Title
      {
         get => _title;
         set
         {
            _title = value;
            OnPropertyChanged();
         }
      }

      [SExprSubNode("date")]
      public DateOnly? Date
      {
         get => _date;
         set
         {
            _date = value;
            OnPropertyChanged();
         }
      }

      [SExprSubNode("rev")]
      public string? Revision
      {
         get => _rev;
         set
         {
            _rev = value;
            OnPropertyChanged();
         }
      }

      [SExprSubNode("company")]
      public string? Company
      {
         get => _company;
         set
         {
            _company = value;
            OnPropertyChanged();
         }
      }

      public ObservableCollection<CommentModel>? Comments
      {
         get => _comments;
         set
         {
            _comments = value;
            OnPropertyChanged();
         }
      }
      #endregion
   }
}
