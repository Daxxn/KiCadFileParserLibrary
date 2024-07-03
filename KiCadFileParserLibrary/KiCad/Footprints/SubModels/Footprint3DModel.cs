using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.General;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.KiCad.Pcb.SubModels;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

namespace KiCadFileParserLibrary.KiCad.Footprints.SubModels
{
    [SExprNode("model")]
   public class Footprint3DModel : IKiCadReadable
   {
      #region Local Props
      [SExprProperty(1)]
      public string? Path { get; set; }

      [SExprSubNode("opacity")]
      public double Opacity { get; set; }

      [SExprNode("offset/xyz")]
      public XyzModel? Offset { get; set; }

      [SExprNode("scale/xyz")]
      public XyzModel? Scale { get; set; }

      [SExprNode("rotate/xyz")]
      public XyzModel? Rotation { get; set; }
      #endregion

      #region Constructors
      public Footprint3DModel() { }
      #endregion

      #region Methods
      public void ParseNode(Node node)
      {
         if (node.Children != null && node.Properties != null)
         {
            var props = GetType().GetProperties();
            KiCadParseUtils.ParseProperties(props, node, this);
            KiCadParseUtils.ParseSubNodes(props, node, this);
            KiCadParseUtils.ParseNodes(props, node, this);
         }
      }
      #endregion

      #region Full Props

      #endregion
   }
}
