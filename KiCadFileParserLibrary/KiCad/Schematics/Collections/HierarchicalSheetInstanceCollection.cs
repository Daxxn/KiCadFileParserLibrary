using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.KiCad.Schematics.SubModels;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

using MVVMLibrary;

namespace KiCadFileParserLibrary.KiCad.Schematics.Collections;

[SExprListNode("project")]
public class HierarchicalSheetInstanceCollection : Model, IKiCadReadable, IKiCadWriteableCollection
{
   #region Local Props
   private ObservableCollection<SheetInstanceModel> _instances = [];
   #endregion

   #region Constructors
   public HierarchicalSheetInstanceCollection() { }
   #endregion

   #region Methods
   public void ParseNode(Node node)
   {
      if (node.Children is null) return;

      var rootNode = node.GetNode("instances");
      var instNodes = rootNode?.GetNodes("project");
      if (instNodes is null) return;
      Instances = [];
      foreach (var instNode in instNodes)
      {
         var inst = new SheetInstanceModel();
         inst.ParseNode(instNode);
         Instances.Add(inst);
      }
   }

   public void WriteCollection(StringBuilder builder, int indent)
   {
      builder.Append('\t', indent);
      builder.AppendLine("(instances");

      foreach (var inst in Instances)
      {
         KiCadWriteUtils2.WriteNode(inst, builder, indent + 1);
      }

      builder.Append('\t', indent);
      builder.AppendLine(")");
   }
   #endregion

   #region Full Props
   public ObservableCollection<SheetInstanceModel> Instances
   {
      get => _instances;
      set
      {
         _instances = value;
         OnPropertyChanged();
      }
   }
   #endregion
}
