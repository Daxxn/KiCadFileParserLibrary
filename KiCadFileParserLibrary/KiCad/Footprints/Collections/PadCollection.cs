using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.Footprints.SubModels;
using KiCadFileParserLibrary.KiCad.General;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

using MVVMLibrary;

namespace KiCadFileParserLibrary.KiCad.Footprints.Collections;

/// <summary>
/// List of <see cref="PadModel">Pads.</see>
/// </summary>
[SExprListNode("pad")]
public class PadCollection : Model, IKiCadReadable, IKiCadWriteableCollection
{
   #region Local Props
   private ObservableCollection<PadModel> _pads = [];
   #endregion

   #region Constructors
   /// <inheritdoc/>
   public PadCollection() { }
   #endregion

   #region Methods
   /// <inheritdoc/>
   public void ParseNode(Node node)
   {
      var children = node.GetNodes("pad");
      if (children is null) return;
      Pads = [];
      foreach (var child in children)
      {
         PadModel pad = new();
         pad.ParseNode(child);
         Pads.Add(pad);
      }
   }

   /// <inheritdoc/>
   public override string ToString()
   {
      return $"Pads - {Pads.Count}";
   }

   /// <inheritdoc/>
   public void WriteCollection(StringBuilder builder, int indent)
   {
      foreach (var pad in Pads)
      {
         KiCadWriteUtils2.WriteNode(pad, builder, indent);
      }
   }
   #endregion

   #region Full Props
   /// <summary>
   /// List of <see cref="PadModel">Pads.</see>
   /// </summary>
   public ObservableCollection<PadModel> Pads
   {
      get => _pads;
      set
      {
         _pads = value;
         OnPropertyChanged();
      }
   }
   #endregion
}
