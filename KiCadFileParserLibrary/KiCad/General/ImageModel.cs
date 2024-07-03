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
    [SExprNode("image")]
   public class ImageModel : IKiCadReadable
   {
      #region Local Props
      public LocationModel? Location { get; set; }

      [SExprSubNode("layer")]
      public string? Layer { get; set; }

      [SExprSubNode("uuid")]
      public string? ID { get; set; }

      public List<string>? Data { get; set; }
      #endregion

      #region Constructors
      public ImageModel() { }
      #endregion

      #region Methods
      public void ParseNode(Node node)
      {
         if (node.Children != null)
         {
            var props = GetType().GetProperties();

            KiCadParseUtils.ParseNodes(props, node, this);
            KiCadParseUtils.ParseSubNodes(props, node, this);

            // Read all the image data:
            var dataNode = node.GetNode("data");
            if (dataNode != null)
            {
               if (dataNode.Properties != null)
               {
                  Data = [];
                  foreach (var p in dataNode.Properties[1..])
                  {
                     Data.Add(p);
                  }
               }
            }
         }
      }
      #endregion

      #region Full Props

      #endregion
   }
}
