using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.General;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

using MVVMLibrary;

namespace KiCadFileParserLibrary.KiCad.Footprints.Collections;

/// <summary>
/// List of <see cref="GroupModel">Groups.</see>
/// </summary>
[SExprListNode("group")]
public class GroupCollection : Model, IKiCadReadable, IKiCadWriteableCollection
{
   #region Local Props
   private ObservableCollection<GroupModel> _groups = [];
   #endregion

   #region Constructors
   /// <inheritdoc/>
   public GroupCollection() { }
   #endregion

   #region Methods
   /// <inheritdoc/>
   public void ParseNode(Node node)
   {
      var children = node.GetNodes("group");
      if (children is null) return;
      Groups = [];
      foreach (var child in children)
      {
         GroupModel fp = new();
         fp.ParseNode(child);
         Groups.Add(fp);
      }
   }

   /// <inheritdoc/>
   public override string ToString()
   {
      return $"Groups - {Groups.Count}";
   }

   /// <inheritdoc/>
   public void WriteCollection(StringBuilder builder, int indent)
   {
      foreach (var group in Groups)
      {
         KiCadWriteUtils2.WriteNode(group, builder, indent);
      }
   }
   #endregion

   #region Full Props
   /// <summary>
   /// List of <see cref="GroupModel">Groups.</see>
   /// </summary>
   public ObservableCollection<GroupModel> Groups
   {
      get => _groups;
      set
      {
         _groups = value;
         OnPropertyChanged();
      }
   }
   #endregion
}
