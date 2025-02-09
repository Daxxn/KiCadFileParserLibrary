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

[SExprNode("project")]
public class SheetInstanceModel : Model, IKiCadReadable
{
   #region Local Props
   private string _name = "";
   private ProjectPathModel _path = new();
   #endregion

   #region Constructors
   public SheetInstanceModel() { }
   #endregion

   #region Methods
   public void ParseNode(Node node)
   {
      if (node.Children is null) return;

      var props = GetType().GetProperties();
      KiCadParseUtils.ParseProperties(props, node, this);
      KiCadParseUtils.ParseNodes(props, node, this);
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

   public ProjectPathModel Path
   {
      get => _path;
      set
      {
         _path = value;
         OnPropertyChanged();
      }
   }
   #endregion
}
