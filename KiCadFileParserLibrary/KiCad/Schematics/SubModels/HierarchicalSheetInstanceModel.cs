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
/// Hierarchical sheet instance model
/// </summary>
[SExprNode("instances")]
public class HierarchicalSheetInstanceModel : Model, IKiCadReadable
{
   #region Local Props
   private ProjectInstanceModel _instance = new();
   #endregion

   #region Constructors
   /// <inheritdoc/>
   public HierarchicalSheetInstanceModel() { }
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
   /// Project instance
   /// </summary>
   public ProjectInstanceModel Instance
   {
      get => _instance;
      set
      {
         _instance = value;
         OnPropertyChanged();
      }
   }
   #endregion
}
