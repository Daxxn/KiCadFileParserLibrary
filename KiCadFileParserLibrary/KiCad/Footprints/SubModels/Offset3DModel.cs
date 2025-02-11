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

[SExprNode("offset")]
public class Offset3DModel : Model, IKiCadReadable
{
   #region Local Props
   private XyzModel _offset = new();
   #endregion

   #region Constructors
   public Offset3DModel() { }
   #endregion

   #region Methods
   public void ParseNode(Node node)
   {
      if (node.Children is null) return;

      var props = GetType().GetProperties();

      KiCadParseUtils.ParseNodes(props, node, this);
   }
   #endregion

   #region Full Props
   public XyzModel Offset
   {
      get => _offset;
      set
      {
         _offset = value;
         OnPropertyChanged();
      }
   }

   #endregion
}
