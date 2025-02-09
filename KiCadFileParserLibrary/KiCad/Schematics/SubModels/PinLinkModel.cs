using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

using MVVMLibrary;

namespace KiCadFileParserLibrary.KiCad.Schematics.SubModels;

[SExprNode("pin")]
public class PinLinkModel : Model, IKiCadReadable
{
   #region Local Props
   private string _id = "";
   #endregion

   #region Constructors
   public PinLinkModel() { }
   #endregion

   #region Methods
   public void ParseNode(Node node)
   {
      if (node.Children != null)
      {
         var props = GetType().GetProperties();

         KiCadParseUtils.ParseSubNodes(props, node, this);
      }
   }

   public void WriteNode(StringBuilder builder, int indent, string? auxName = null)
   {
      throw new NotImplementedException();
   }
   #endregion

   #region Full Props
   [SExprSubNode("uuid")]
   public string ID
   {
      get => _id;
      set
      {
         _id = value;
         OnPropertyChanged();
      }
   }
   #endregion
}
