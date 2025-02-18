using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.Boards.SubModels;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

using MVVMLibrary;

namespace KiCadFileParserLibrary.KiCad.Boards.Collections;

/// <summary>
/// List of all the <see cref="TunedLengthModel">Tuned Length</see> traces in the <see cref="PcbModel">PCB.</see>
/// </summary>
[SExprListNode("generated")]
public class TunedLengthCollection : Model, IKiCadReadable, IKiCadWriteableCollection
{
   #region Local Props
   private ObservableCollection<TunedLengthModel> _tunedLengths = [];
   #endregion

   #region Constructors
   /// <inheritdoc/>
   public TunedLengthCollection() { }
   #endregion

   #region Methods
   /// <inheritdoc/>
   public void ParseNode(Node node)
   {
      if (node.Children != null)
      {
         var children = node.GetNodes("generated");
         if (children is null) return;
         TunedLengths = [];
         foreach (var child in children)
         {
            TunedLengthModel tl = new();
            tl.ParseNode(child);
            TunedLengths.Add(tl);
         }
      }
   }

   //public void WriteNode(StringBuilder builder, int indent, string? auxName = null)
   //{
   //   foreach (var tl in TunedLengths)
   //   {
   //      tl.WriteNode(builder, indent);
   //   }
   //}

   /// <inheritdoc/>
   public void WriteCollection(StringBuilder builder, int indent)
   {
      foreach (var tl in TunedLengths)
      {
         KiCadWriteUtils.WriteNode(tl, builder, indent);
      }
   }

   /// <inheritdoc/>
   public override string ToString() => $"Tuned-Length Coll - {TunedLengths.Count}";
   #endregion

   #region Full Props
   /// <summary>
   /// List of all the <see cref="TunedLengthModel">Tuned Length</see> traces in the <see cref="PcbModel">PCB.</see>
   /// </summary>
   public ObservableCollection<TunedLengthModel> TunedLengths
   {
      get => _tunedLengths;
      set
      {
         _tunedLengths = value;
         OnPropertyChanged();
      }
   }
   #endregion
}
