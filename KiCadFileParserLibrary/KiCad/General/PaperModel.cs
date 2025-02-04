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

namespace KiCadFileParserLibrary.KiCad.General
{
   [SExprNode("paper")]
   public class PaperModel : IKiCadReadable
   {
      #region Local Props
      [SExprProperty(1)]
      public string? Name { get; set; }

      public bool IsCustomSize { get; set; }

      [SExprProperty(2, true)]
      public double? Width { get; set; }

      [SExprProperty(1, true)]
      public double? Height { get; set; }

      [SExprToken("portrait")]
      public bool IsPortrait { get; set; }
      #endregion

      #region Constructors
      public PaperModel() { }
      #endregion

      #region Methods
      public void ParseNode(Node node)
      {
         if (node.Properties != null)
         {
            if (node.Properties.Count > 1)
            {
               if (node.Properties[1] == "User")
               {
                  IsCustomSize = true;
                  var props = GetType().GetProperties();

                  KiCadParseUtils.ParseProperties(props, node, this);
                  KiCadParseUtils.ParseTokens(props, node, this);
               }
            }
         }
      }

      public void WriteNode(StringBuilder builder, int indent, string? auxName = null)
      {
         builder.Append('\t', indent);
         builder.Append("(paper ");

         if (IsCustomSize)
         {
            builder.AppendLine($"\"{Name}\" {Width} {Height})");
         }
         else
         {
            builder.AppendLine($"\"{Name}\")");
         }
      }

      public override string ToString()
      {
         if (IsCustomSize)
         {
            return $"Paper - Name: {Name} - W: {Width} - H: {Height} - Portrait: {IsPortrait}";
         }
         else
         {
            return $"Paper - Name: {Name} - Portrait: {IsPortrait}";
         }
      }
      #endregion

      #region Full Props

      #endregion
   }
}
