using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.General;
using KiCadFileParserLibrary.KiCad.General.Collections;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

using MVVMLibrary;

namespace KiCadFileParserLibrary.KiCad.Boards.SubModels;

[SExprNode("base_line_coupled")]
public class BaselineCoupledModel : Model, IKiCadReadable
{
   #region Local Props
   private CoordinateModel _points = new();
   #endregion

   #region Constructors
   public BaselineCoupledModel() { }
   #endregion

   #region Methods
   public void ParseNode(Node node)
   {
      if (node.Children != null)
      {
         var props = GetType().GetProperties();

         KiCadParseUtils.ParseListNodes(props, node, this);
         KiCadParseUtils.ParseNodes(props, node, this);
      }
   }

   public void WriteNode(StringBuilder builder, int indent, string? auxName = null)
   {
      throw new NotImplementedException();
   }
   #endregion

   #region Full Props
   public CoordinateModel Points
   {
      get => _points;
      set
      {
         _points = value;
         OnPropertyChanged();
      }
   }
   #endregion
}
