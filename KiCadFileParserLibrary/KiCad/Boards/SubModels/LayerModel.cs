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
   [SExprNode("layer")]
   public class LayerModel : Model, IKiCadReadable
   {
      #region Local Props
      private int _index = -1;
      private string? _name = null;
      private LayerType _type;
      private string? _userName = null;
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
      [SExprProperty(0)]
      public int Index
      {
         get => _index;
         set
         {
            _index = value;
            OnPropertyChanged();
         }
      }

      [SExprProperty(1)]
      public string? Name
      {
         get => _name;
         set
         {
            _name = value;
            OnPropertyChanged();
         }
      }

      [SExprProperty(2)]
      public LayerType Type
      {
         get => _type;
         set
         {
            _type = value;
            OnPropertyChanged();
         }
      }

      [SExprProperty(3)]
      public string? UserName
      {
         get => _userName;
         set
         {
            _userName = value;
            OnPropertyChanged();
         }
      }
      #endregion
   }
}
