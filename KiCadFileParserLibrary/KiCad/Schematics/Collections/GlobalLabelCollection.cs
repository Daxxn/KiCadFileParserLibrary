using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.KiCad.Schematics.SubModels;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

using MVVMLibrary;

namespace KiCadFileParserLibrary.KiCad.Schematics.Collections;

/// <summary>
/// List of global labels.
/// </summary>
[SExprListNode("global_label")]
public class GlobalLabelCollection : Model, IKiCadReadable, IKiCadWriteableCollection
{
   #region Local Props
   private ObservableCollection<GlobalLabelModel> _globalLabels = [];
   #endregion

   #region Constructors
   /// <inheritdoc/>
   public GlobalLabelCollection() { }
   #endregion

   #region Methods
   /// <inheritdoc/>
   public void ParseNode(Node node)
   {
      if (node.Children is null) return;
      var labelNodes = node.GetNodes(GetType().GetCustomAttribute<SExprListNodeAttribute>()!.Name);
      if (labelNodes is null) return;
      GlobalLabels = [];
      foreach (var labelNode in labelNodes)
      {
         var symbol = new GlobalLabelModel();
         symbol.ParseNode(labelNode);
         GlobalLabels.Add(symbol);
      }
   }

   /// <inheritdoc/>
   public void WriteCollection(StringBuilder builder, int indent)
   {
      if (GlobalLabels is null) return;
      foreach (var label in GlobalLabels)
      {
         KiCadWriteUtils.WriteNode(label, builder, indent);
      }
   }
   #endregion

   #region Full Props
   /// <summary>
   /// List of global labels.
   /// </summary>
   public ObservableCollection<GlobalLabelModel> GlobalLabels
   {
      get => _globalLabels;
      set
      {
         _globalLabels = value;
         OnPropertyChanged();
      }
   }
   #endregion
}
