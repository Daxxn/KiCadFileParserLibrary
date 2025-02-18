using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.Boards.SubModels;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.KiCad.Schematics.SubModels;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

using MVVMLibrary;

namespace KiCadFileParserLibrary.KiCad.Schematics.Collections;

/// <summary>
/// List of <see cref="JunctionModel">Junctions</see>
/// </summary>
[SExprListNode("junction")]
public class JunctionCollection : Model, IKiCadReadable, IKiCadWriteableCollection
{
   #region Local Props
   private ObservableCollection<JunctionModel>? _junctions;
   #endregion

   #region Constructors
   /// <inheritdoc/>
   public JunctionCollection() { }
   #endregion

   #region Methods
   /// <inheritdoc/>
   public void ParseNode(Node node)
   {
      if (node.Children is null) return;
      var juncNodes = node.GetNodes("junction");
      if (juncNodes is null) return;
      Junctions = [];
      foreach (var child in juncNodes)
      {
         var junction = new JunctionModel();
         junction.ParseNode(child);
         Junctions.Add(junction);
      }
   }

   /// <inheritdoc/>
   public void WriteCollection(StringBuilder builder, int indent)
   {
      if (Junctions is null) return;

      foreach (var junc in Junctions)
      {
         KiCadWriteUtils2.WriteNode(junc, builder, indent);
      }
   }
   #endregion

   #region Full Props
   /// <summary>
   /// List of <see cref="JunctionModel">Junctions</see>
   /// </summary>
   public ObservableCollection<JunctionModel>? Junctions
   {
      get => _junctions;
      set
      {
         _junctions = value;
         OnPropertyChanged();
      }
   }
   #endregion
}
