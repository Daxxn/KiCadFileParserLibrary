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

namespace KiCadFileParserLibrary.KiCad.Boards.SubModels;

[SExprNode("origin")]
public class OriginModel : Model, IKiCadReadable
{
   #region Local Props
   private XyModel _origin = new();
   #endregion

   #region Constructors
   public OriginModel() { }

   #endregion

   #region Methods
   public void ParseNode(Node node)
   {
      if (node.Children != null)
      {
         var props = GetType().GetProperties();

         KiCadParseUtils.ParseNodes(props, node, this);
      }
   }
   #endregion

   #region Full Props
   public XyModel Origin
   {
      get => _origin;
      set
      {
         _origin = value;
         OnPropertyChanged();
      }
   }
   #endregion
}
