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
   private string _name = "1";
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
         KiCadParseUtils.ParseProperties(props, node, this);
         KiCadParseUtils.ParseSubNodes(props, node, this);
      }
   }
   #endregion

   #region Full Props
   [SExprProperty(1)]
   public string Name
   {
      get => _name;
      set
      {
         _name = value;
         OnPropertyChanged();
      }
   }

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
