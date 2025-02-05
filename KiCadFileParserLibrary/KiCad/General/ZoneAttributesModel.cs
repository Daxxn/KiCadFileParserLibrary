using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

using MVVMLibrary;

namespace KiCadFileParserLibrary.KiCad.General
{
   [SExprNode("attr")]
   public class ZoneAttributesModel : Model, IKiCadReadable
   {
      #region Local Props
      private ZoneTeardropModel? _teardrop;
      #endregion

      #region Constructors
      public ZoneAttributesModel() { }
      #endregion

      #region Methods
      public void ParseNode(Node node)
      {
         if (node.Children != null)
         {
            var props = GetType().GetProperties();
            KiCadParseUtils.ParseNodes(props, node, this);
         }
      }

      public void WriteNode(StringBuilder builder, int indent, string? auxName = null)
      {
         builder.Append('\t', indent);
         builder.AppendLine("(attr");

         Teardrop?.WriteNode(builder, indent + 1);

         builder.Append('\t', indent);
         builder.AppendLine(")");
      }
      #endregion

      #region Full Props
      public ZoneTeardropModel? Teardrop
      {
         get => _teardrop;
         set
         {
            _teardrop = value;
            OnPropertyChanged();
         }
      }
      #endregion
   }
}
