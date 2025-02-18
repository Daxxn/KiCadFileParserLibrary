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
/// Sheet instance model
/// </summary>
[SExprNode("project")]
public class SheetInstanceModel : Model, IKiCadReadable
{
   #region Local Props
   private string _name = "";
   private ProjectPathModel _path = new();
   #endregion

   #region Constructors
   /// <inheritdoc/>
   public SheetInstanceModel() { }
   #endregion

   #region Methods
   /// <inheritdoc/>
   public void ParseNode(Node node)
   {
      if (node.Children is null) return;

      var props = GetType().GetProperties();
      KiCadParseUtils.ParseProperties(props, node, this);
      KiCadParseUtils.ParseNodes(props, node, this);
   }
   #endregion

   #region Full Props
   /// <summary>
   /// Name
   /// </summary>
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

   /// <summary>
   /// Path
   /// </summary>
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
