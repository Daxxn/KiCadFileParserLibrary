using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.General.Collections;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

using MVVMLibrary;

namespace KiCadFileParserLibrary.KiCad.General;

/// <summary>
/// File title block.
/// </summary>
[SExprNode("title_block")]
public class TitleBlockModel : Model, IKiCadReadable
{
   #region Local Props
   private string? _title;
   private DateOnly? _date;
   private string? _rev;
   private string? _company;
   private CommentCollection _comments = new();
   #endregion

   #region Constructors
   /// <inheritdoc/>
   public TitleBlockModel() { }
   #endregion

   #region Methods
   /// <inheritdoc/>
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
               Date = date;
         }

         Comments.ParseNode(node);
      }
   }

   /// <inheritdoc/>
   public override string ToString()
   {
      return $"Title - {Title} - Rev: {Revision} - Date: {Date:MM-dd-yy} - Comp: {Company} - Comm {Comments.Count}";
   }
   #endregion

   #region Full Props
   /// <summary>
   /// Page title.
   /// </summary>
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

   /// <summary>
   /// Project lock date.
   /// </summary>
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

   /// <summary>
   /// Project revision.
   /// </summary>
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

   /// <summary>
   /// Company name.
   /// </summary>
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

   /// <summary>
   /// List of comments.
   /// </summary>
   public CommentCollection Comments
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
