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
public class ProjectInstanceModel : Model, IKiCadReadable
{
   #region Local Props
   private string _name = "";
   private SymbolPathModel _path = new();
   #endregion

   #region Constructors
   public ProjectInstanceModel() { }
   #endregion

   #region Methods
   public void ParseNode(Node node)
   {
      if (node.Properties != null && node.Children != null)
      {
         var props = GetType().GetProperties();

         KiCadParseUtils.ParseNodes(props, node, this);
         KiCadParseUtils.ParseProperties(props, node, this);
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

   public SymbolPathModel Path
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
