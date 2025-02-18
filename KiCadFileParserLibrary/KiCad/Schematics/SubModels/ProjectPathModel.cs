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

/// <summary>
/// Project path model
/// </summary>
[SExprNode("path")]
public class ProjectPathModel : Model, IKiCadReadable
{
   #region Local Props
   private string _path = "/";
   private string _page = "1";
   #endregion

   #region Constructors
   /// <inheritdoc/>
   public ProjectPathModel() { }
   #endregion

   #region Methods
   /// <inheritdoc/>
   public void ParseNode(Node node)
   {
      if (node.Children is null) return;

      var props = GetType().GetProperties();
      KiCadParseUtils.ParseSubNodes(props, node, this);
      KiCadParseUtils.ParseProperties(props, node, this);
   }
   #endregion

   #region Full Props
   /// <summary>
   /// Path
   /// </summary>
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

   /// <summary>
   /// Page
   /// </summary>
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
