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
   [SExprNode("general")]
   public class GeneralModel : Model, IKiCadReadable
   {
      #region Local Props
      private double _thick = 0;
      private bool _useLegacyTd = false;
      #endregion

      #region Constructors
      public GeneralModel() { }
      #endregion

      #region Methods
      public void ParseNode(Node node)
      {
         if (node.Children != null)
         {
            var props = GetType().GetProperties();
            KiCadParseUtils.ParseSubNodes(props, node, this);
         }
      }

      public void WriteNode(StringBuilder builder, int indent, string? auxName = null)
      {
         builder.Append('\t', indent);
         builder.AppendLine("(general");

         builder.Append('\t', indent + 1);
         builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("thickness", Thickness));

         builder.Append('\t', indent + 1);
         builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("legacy_teardrops", UseLegacyTeardrop));

         builder.Append('\t', indent);
         builder.AppendLine(")");
      }

      public override string ToString()
      {
         return $"General - Thick: {Thickness} - UseLegTD: {UseLegacyTeardrop}";
      }
      #endregion

      #region Full Props
      [SExprSubNode("thickness")]
      public double Thickness
      {
         get => _thick;
         set
         {
            _thick = value;
            OnPropertyChanged();
         }
      }

      [SExprSubNode("legacy_teardrops")]
      public bool UseLegacyTeardrop
      {
         get => _useLegacyTd;
         set
         {
            _useLegacyTd = value;
            OnPropertyChanged();
         }
      }
      #endregion
   }
}
