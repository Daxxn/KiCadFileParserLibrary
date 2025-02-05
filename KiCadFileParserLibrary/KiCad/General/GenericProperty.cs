using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

using MVVMLibrary;

namespace KiCadFileParserLibrary.KiCad.General
{
   [SExprNode("property")]
   public class GenericProperty : Model, IKiCadReadable
   {
      #region Local Props
      private string? _key;
      private string? _value;
      #endregion

      #region Constructors
      public GenericProperty() { }
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
         builder.AppendLine($"(property \"{Key}\" \"{Value}\")");
      }
      #endregion

      #region Full Props
      [SExprProperty(1)]
      public string? Key
      {
         get => _key;
         set
         {
            _key = value;
            OnPropertyChanged();
         }
      }

      [SExprProperty(2)]
      public string? Value
      {
         get => _value;
         set
         {
            _value = value;
            OnPropertyChanged();
         }
      }
      #endregion
   }
}
