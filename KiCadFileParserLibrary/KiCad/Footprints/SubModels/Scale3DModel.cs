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

[SExprNode("scale")]
public class Scale3DModel : Model, IKiCadReadable
{
   #region Local Props
   private XyzModel _scale = new();
   #endregion

   #region Constructors
   public Scale3DModel() { }
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
   public XyzModel Scale
   {
      get => _scale;
      set
      {
         _scale = value;
         OnPropertyChanged();
      }
   }
   #endregion
}
