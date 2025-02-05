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

using MVVMLibrary;

namespace KiCadFileParserLibrary.KiCad.Footprints.Collections
{
   [SExprListNode("pad")]
   public class PadCollection : Model, IKiCadReadable
   {
      #region Local Props
      private ObservableCollection<PadModel> _pads = [];
      #endregion

      #region Constructors
      public PadCollection() { }
      #endregion

      #region Methods
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

      public void WriteNode(StringBuilder builder, int indent, string? auxName = null)
      {
         foreach (var pad in Pads)
         {
            pad.WriteNode(builder, indent);
         }
      }

      public override string ToString()
      {
         return $"Pads - {Pads.Count}";
      }
      #endregion

      #region Full Props
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
}
