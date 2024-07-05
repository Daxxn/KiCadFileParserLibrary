using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

namespace KiCadFileParserLibrary.KiCad.General
{
   [SExprNode("at")]
   public class LocationModel : IKiCadReadable
   {
      #region Local Props
      [SExprProperty(1)]
      public double? X { get; set; }

      [SExprProperty(2)]
      public double? Y { get; set; }

      [SExprProperty(3)]
      public double? Angle { get; set; }
      #endregion

      #region Constructors
      public LocationModel() { }
      #endregion

      #region Methods
      public void ParseNode(Node node)
      {
         var props = GetType().GetProperties();
         KiCadParseUtils.ParseProperties(props, node, this);
      }

      public void WriteNode(StringBuilder builder, int indent, string? auxName = null)
      {
         builder.Append('\t', indent);
         builder.Append($"({auxName ?? "at"} {X} {Y}");
         if (Angle != null)
         {
            builder.Append(' ');
            builder.Append(Math.Round((double)Angle));
         }

         builder.AppendLine(")");
      }
      #endregion

      #region Full Props

      #endregion
   }
}
