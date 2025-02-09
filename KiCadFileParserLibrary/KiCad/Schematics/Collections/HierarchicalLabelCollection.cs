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

[SExprListNode("hierarchical_label")]
public class HierarchicalLabelCollection : Model, IKiCadReadable, IKiCadWriteableCollection
{
   #region Local Props
   private ObservableCollection<HierarchicalLabelModel> _labels = [];
   #endregion

   #region Constructors
   public HierarchicalLabelCollection() { }
   #endregion

   #region Methods
   public void ParseNode(Node node)
   {
      if (node.Children is null) return;
      var labelNodes = node.GetNodes(GetType().GetCustomAttribute<SExprListNodeAttribute>()!.Name);
      if (labelNodes is null) return;
      Labels = [];
      foreach (var labelNode in labelNodes)
      {
         var label = new HierarchicalLabelModel();
         label.ParseNode(labelNode);
         Labels.Add(label);
      }
   }

   public void WriteCollection(StringBuilder builder, int indent)
   {
      if (Labels is null) return;
      foreach (var label in Labels)
      {
         KiCadWriteUtils2.WriteNode(label, builder, indent);
      }
   }
   #endregion

   #region Full Props
   public ObservableCollection<HierarchicalLabelModel> Labels
   {
      get => _labels;
      set
      {
         _labels = value;
         OnPropertyChanged();
      }
   }
   #endregion
}
