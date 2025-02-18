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

/// <summary>
/// List of symbol <see cref="ProjectInstanceModel">Project References</see>
/// </summary>
[SExprListNode("instances")]
public class SymbolProjectReferenceCollection : Model, IKiCadReadable, IKiCadWriteableCollection
{
   #region Local Props
   private ObservableCollection<ProjectInstanceModel> _insts = [];
   #endregion

   #region Constructors
   /// <inheritdoc/>
   public SymbolProjectReferenceCollection() { }
   #endregion

   #region Methods
   /// <inheritdoc/>
   public void ParseNode(Node node)
   {
      if (node.Children is null) return;
      var instNode = node.GetNode("instances");
      var projNodes = instNode?.GetNodes("project");
      if (projNodes is null) return;
      foreach ( var projNode in projNodes )
      {
         var project = new ProjectInstanceModel();
         project.ParseNode(projNode);
         Instances.Add(project);
      }
   }

   /// <inheritdoc/>
   public void WriteCollection(StringBuilder builder, int indent)
   {
      builder.Append('\t', indent);
      builder.AppendLine("(instances");

      foreach ( var project in Instances )
      {
         KiCadWriteUtils.WriteNode(project, builder, indent + 1);
      }

      builder.Append('\t', indent);
      builder.AppendLine(")");
   }
   #endregion

   #region Full Props
   /// <summary>
   /// List of symbol <see cref="ProjectInstanceModel">Project References</see>
   /// </summary>
   public ObservableCollection<ProjectInstanceModel> Instances
   {
      get => _insts;
      set
      {
         _insts = value;
         OnPropertyChanged();
      }
   }
   #endregion
}
