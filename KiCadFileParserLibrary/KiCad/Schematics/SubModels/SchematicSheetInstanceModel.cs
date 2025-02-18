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
/// Schematic sheet instance model
/// </summary>
[SExprNode("sheet_instances")]
public class SchematicSheetInstanceModel : Model, IKiCadReadable
{
   #region Local Props
   private ProjectPathModel _sheetInstance = new();
   #endregion

   #region Constructors
   /// <inheritdoc/>
   public SchematicSheetInstanceModel() { }
   #endregion

   #region Methods
   /// <inheritdoc/>
   public void ParseNode(Node node)
   {
      if (node.Children is null) return;
      var props = GetType().GetProperties();
      KiCadParseUtils.ParseNodes(props, node, this);
   }
   #endregion

   #region Full Props
   /// <summary>
   /// Sheet instance
   /// </summary>
   public ProjectPathModel SheetInstance
   {
      get => _sheetInstance;
      set
      {
         _sheetInstance = value;
         OnPropertyChanged();
      }
   }
   #endregion
}
