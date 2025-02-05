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
   [SExprNode("hatch")]
   public class HatchModel : Model, IKiCadReadable
   {
      #region Local Props
      private HatchType _type;
      private double? _spacing;
      #endregion

      #region Constructors
      public HatchModel() { }
      #endregion

      #region Methods
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
         builder.AppendLine($"(hatch {Type.ToString().ToLower()} {Spacing})");
      }
      #endregion

      #region Full Props
      [SExprProperty(1)]
      public HatchType Type
      {
         get => _type;
         set
         {
            _type = value;
            OnPropertyChanged();
         }
      }

      [SExprProperty(2)]
      public double? Spacing
      {
         get => _spacing;
         set
         {
            _spacing = value;
            OnPropertyChanged();
         }
      }
      #endregion
   }
}
