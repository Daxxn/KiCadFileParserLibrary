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

[SExprListNode("label")]
public class LocalLabelCollection : Model, IKiCadReadable, IKiCadWriteableCollection
{
   #region Local Props
   private ObservableCollection<LabelModel> _localLabels = [];
   #endregion

   #region Constructors
   public LocalLabelCollection() { }
   #endregion

   #region Methods
   public void ParseNode(Node node)
   {
      if (node.Children is null) return;
      var labelNodes = node.GetNodes(GetType().GetCustomAttribute<SExprListNodeAttribute>()!.Name);
      if (labelNodes is null) return;
      LocalLabels = [];
      foreach (var symNode in labelNodes)
      {
         var label = new LabelModel();
         label.ParseNode(symNode);
         LocalLabels.Add(label);
      }
   }

   public void WriteCollection(StringBuilder builder, int indent)
   {
      if (LocalLabels is null) return;
      foreach (var label in LocalLabels)
      {
         KiCadWriteUtils2.WriteNode(label, builder, indent);
      }
   }
   #endregion

   #region Full Props
   public ObservableCollection<LabelModel> LocalLabels
   {
      get => _localLabels;
      set
      {
         _localLabels = value;
         OnPropertyChanged();
      }
   }
   #endregion
}
