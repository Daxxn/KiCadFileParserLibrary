using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.SExprParser;

namespace KiCadFileParserLibrary.KiCad.General.Collections
{
   [SExprListNode("image")]
   public class ImageCollection : IKiCadReadable
   {
      #region Local Props
      public List<ImageModel>? Images { get; set; }
      #endregion

      #region Constructors
      public ImageCollection() { }
      #endregion

      #region Methods
      public void ParseNode(Node node)
      {
         var children = node.GetNodes("image");
         if (children is null) return;
         Images = [];
         foreach (var child in children)
         {
            ImageModel image = new();
            image.ParseNode(child);
            Images.Add(image);
         }
      }

      public void WriteNode(StringBuilder builder, int indent, string? auxName = null)
      {
         if (Images is null) return;
         foreach (var img in Images)
         {
            img.WriteNode(builder, indent);
         }
      }

      public override string ToString()
      {
         return $"Images - {Images?.Count}";
      }
      #endregion

      #region Full Props

      #endregion
   }
}
