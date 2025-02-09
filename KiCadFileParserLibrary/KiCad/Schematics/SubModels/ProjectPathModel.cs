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

[SExprNode("path")]
public class ProjectPathModel : Model, IKiCadReadable
{
   #region Local Props
   private string _path = "/";
   private string _page = "1";
   #endregion

   #region Constructors
   public ProjectPathModel() { }
   #endregion

   #region Methods
   public void ParseNode(Node node)
   {
      if (node.Children is null) return;

      var props = GetType().GetProperties();
      KiCadParseUtils.ParseSubNodes(props, node, this);
      KiCadParseUtils.ParseProperties(props, node, this);
   }
   #endregion

   #region Full Props
   [SExprProperty(1)]
   public string Path
   {
      get => _path;
      set
      {
         _path = value;
         OnPropertyChanged();
      }
   }

   [SExprSubNode("page")]
   public string Page
   {
      get => _page;
      set
      {
         _page = value;
         OnPropertyChanged();
      }
   }
   #endregion
}
