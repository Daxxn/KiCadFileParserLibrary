using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

using MVVMLibrary;

namespace KiCadFileParserLibrary.KiCad.General.Collections;

[SExprListNode("comment")]
public class CommentCollection : Model, IKiCadReadable, IKiCadWriteableCollection
{
   #region Local Props
   private ObservableCollection<CommentModel> _comments = [];

   public int Count => _comments.Count;
   #endregion

   #region Constructors
   public CommentCollection() { }
   #endregion

   #region Methods
   public void ParseNode(Node node)
   {
      var commentNodes = node.GetNodes("comment");
      if (commentNodes is null) return;

      foreach (var commentNode in commentNodes)
      {
         var comment = new CommentModel();
         comment.ParseNode(commentNode);
         Comments.Add(comment);
      }
   }

   public void WriteNode(StringBuilder builder, int indent, string? auxName = null)
   {
      foreach (var comment in Comments)
      {
         comment.WriteNode(builder, indent);
      }
   }

   public void WriteCollection(StringBuilder builder, int indent)
   {
      foreach (var comment in Comments)
      {
         KiCadWriteUtils2.WriteNode(comment, builder, indent);
      }
   }
   #endregion

   #region Full Props
   public ObservableCollection<CommentModel> Comments
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
