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

namespace KiCadFileParserLibrary.KiCad.General;

/// <summary>
/// General comment model.
/// </summary>
[SExprNode("comment")]
public class CommentModel : Model, IKiCadReadable
{
   #region Local Props
   private int _index = -1;
   private string _comment = "";
   #endregion

   #region Constructors
   /// <inheritdoc/>
   public CommentModel() { }
   #endregion

   #region Methods
   /// <inheritdoc/>
   public void ParseNode(Node node)
   {
      if (node.Properties != null)
      {
         var props = GetType().GetProperties();
         KiCadParseUtils.ParseProperties(props, node, this);
      }
   }
   #endregion

   #region Full Props
   /// <summary>
   /// Comment index.
   /// </summary>
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

   /// <summary>
   /// Comment text data.
   /// </summary>
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
   #endregion
}
