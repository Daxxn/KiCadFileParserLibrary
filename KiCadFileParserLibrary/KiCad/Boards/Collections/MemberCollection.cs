using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.SExprParser;

using MVVMLibrary;

namespace KiCadFileParserLibrary.KiCad.Boards.Collections;

/// <summary>
/// List of all the member IDs in a <see cref="General.GroupModel">Group.</see>
/// </summary>
[SExprListNode("members")]
public class MemberCollection : Model, IKiCadReadable, IKiCadWriteableCollection
{
   #region Local Props
   private ObservableCollection<string> _members = [];

   private bool UseQuotes { get; set; }
   #endregion

   #region Constructors
   /// <inheritdoc/>
   public MemberCollection() { }
   #endregion

   #region Methods
   /// <inheritdoc/>
   public void ParseNode(Node node)
   {
      if (node.Children != null)
      {
         var memberNode = node.GetNode("members");
         if (memberNode?.Properties is null) return;
         Members = [];
         foreach (var member in memberNode.Properties[1..])
         {
            Members.Add(member);
         }

         if (node.Type == "group")
         {
            UseQuotes = true;
         }
      }
   }

   /// <inheritdoc/>
   public void WriteCollection(StringBuilder builder, int indent)
   {
      builder.Append('\t', indent);
      builder.AppendLine("(members");
      foreach (var member in Members)
      {
         builder.Append('\t', indent + 1);
         if (UseQuotes)
         {
            builder.AppendLine($"\"{member}\"");
         }
         else
         {
            builder.AppendLine(member);
         }
      }
      builder.Append('\t', indent);
      builder.AppendLine(")");
   }

   /// <inheritdoc/>
   public override string ToString() => $"Member Coll - {Members.Count}";
   #endregion

   #region Full Props
   /// <summary>
   /// List of all the member IDs in a <see cref="General.GroupModel">Group.</see>
   /// </summary>
   public ObservableCollection<string> Members
   {
      get => _members;
      set
      {
         _members = value;
         OnPropertyChanged();
      }
   }
   #endregion
}
