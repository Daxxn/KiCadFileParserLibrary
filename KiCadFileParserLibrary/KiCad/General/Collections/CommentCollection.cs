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

/// <summary>
/// List of <see cref="CommentModel">Comments.</see>
/// </summary>
[SExprListNode("comment")]
public class CommentCollection : Model, IKiCadReadable, IKiCadWriteableCollection
{
   #region Local Props
   private ObservableCollection<CommentModel> _comments = [];

   /// <inheritdoc/>
   public int Count => _comments.Count;
   #endregion

   #region Constructors
   /// <inheritdoc/>
   public CommentCollection() { }
   #endregion

   #region Methods
   /// <inheritdoc/>
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

   /// <inheritdoc/>
   public void WriteCollection(StringBuilder builder, int indent)
   {
      foreach (var comment in Comments)
      {
         KiCadWriteUtils.WriteNode(comment, builder, indent);
      }
   }
   #endregion

   #region Full Props
   /// <summary>
   /// List of <see cref="CommentModel">Comments.</see>
   /// </summary>
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
