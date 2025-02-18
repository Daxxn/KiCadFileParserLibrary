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
/// List of <see cref="ProjectInstanceModel">Project Instances</see>
/// </summary>
[SExprListNode("project")]
public class ProjectInstanceCollection : Model, IKiCadReadable, IKiCadWriteableCollection
{
   #region Local Props
   private ObservableCollection<ProjectInstanceModel> _instances = [];
   #endregion

   #region Constructors
   /// <inheritdoc/>
   public ProjectInstanceCollection() { }
   #endregion

   #region Methods
   /// <inheritdoc/>
   public void ParseNode(Node node)
   {
      if (node.Children is null) return;
      var projNodes = node.GetNodes(GetType().GetCustomAttribute<SExprListNodeAttribute>()!.Name);
      if (projNodes is null) return;
      Instances = [];
      foreach (var projNode in projNodes)
      {
         var projInst = new ProjectInstanceModel();
         projInst.ParseNode(projNode);
         Instances.Add(projInst);
      }
   }

   /// <inheritdoc/>
   public void WriteCollection(StringBuilder builder, int indent)
   {
      if (Instances is null) return;
      foreach (var symbol in Instances)
      {
         KiCadWriteUtils2.WriteNode(symbol, builder, indent);
      }
   }
   #endregion

   #region Full Props
   /// <summary>
   /// List of <see cref="ProjectInstanceModel">Project Instances</see>
   /// </summary>
   public ObservableCollection<ProjectInstanceModel> Instances
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
