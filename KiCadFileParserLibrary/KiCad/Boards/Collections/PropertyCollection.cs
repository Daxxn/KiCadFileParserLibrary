using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.Footprints.SubModels;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.SExprParser;

namespace KiCadFileParserLibrary.KiCad.Boards.Collections
{
   [SExprListNode("property")]
   public class PropertyCollection : IKiCadReadable
   {
      #region Local Props
      public List<PropertyModel> Properties { get; set; } = [];

      public string FilterProp { get; set; } = "";
      #endregion

      #region Constructors
      public PropertyCollection() { }
      #endregion

      #region Methods
      public void ParseNode(Node node)
      {
         var children = node.GetNodes("property");
         if (children is null) return;
         Properties = [];
         foreach (var child in children)
         {
            if (child.Properties![1] == "ki_fp_filters")
            {
               FilterProp = child.Properties[2];
            }
            else
            {
               PropertyModel prop = new();
               prop.ParseNode(child);
               Properties.Add(prop);
            }
         }
      }

      public void WriteNode(StringBuilder builder, int indent, string? auxName = null)
      {
         foreach (var prop in Properties)
         {
            prop.WriteNode(builder, indent);
         }
         if (string.IsNullOrEmpty(FilterProp)) return;
         builder.Append('\t', indent);
         builder.AppendLine($"(property ki_fp_filters \"{FilterProp}\")");
      }
      #endregion

      #region Full Props

      #endregion
   }
}
