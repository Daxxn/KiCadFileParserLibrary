using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.General;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

using MVVMLibrary;

namespace KiCadFileParserLibrary.KiCad.Footprints.SubModels;

[SExprNode("rotate")]
public class Rotate3DModel : Model, IKiCadReadable
{
   #region Local Props
   private XyzModel _rotate = new();
   #endregion

   #region Constructors
   public Rotate3DModel() { }
   #endregion

   #region Methods
   public void ParseNode(Node node)
   {
      if (node.Children is null) return;

      var props = GetType().GetProperties();

      KiCadParseUtils.ParseNodes(props, node, this);
   }

   public void WriteNode(StringBuilder builder, int indent, string? auxName = null)
   {
      throw new NotImplementedException();
   }
   #endregion

   #region Full Props
   public XyzModel Rotate
   {
      get => _rotate;
      set
      {
         _rotate = value;
         OnPropertyChanged();
      }
   }
   #endregion
}
