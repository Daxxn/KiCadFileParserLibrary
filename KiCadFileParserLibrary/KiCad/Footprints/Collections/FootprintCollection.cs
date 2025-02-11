using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.KiCad.Interfaces;
using MVVMLibrary;
using System.Collections.ObjectModel;
using KiCadFileParserLibrary.Utils;

namespace KiCadFileParserLibrary.KiCad.Footprints.Collections
{
   [SExprListNode("footprint")]
   public class FootprintCollection : Model, IKiCadReadable, IKiCadWriteableCollection
   {
      #region Local Props
      private ObservableCollection<Footprint> _footprints = [];
      #endregion

      #region Constructors
      public FootprintCollection() { }
      #endregion

      #region Methods
      public void ParseNode(Node node)
      {
         var children = node.GetNodes("footprint");
         if (children is null) return;
         Footprints = [];
         foreach (var child in children)
         {
            Footprint fp = new();
            fp.ParseNode(child);
            Footprints.Add(fp);
         }
      }

      //public void WriteNode(StringBuilder builder, int indent, string? auxName = null)
      //{
      //   foreach (var fp in Footprints)
      //   {
      //      fp.WriteNode(builder, indent);
      //   }
      //}

      public override string ToString()
      {
         return $"Footprints - {Footprints.Count}";
      }

      public void WriteCollection(StringBuilder builder, int indent)
      {
         foreach (var fp in Footprints)
         {
            KiCadWriteUtils2.WriteNode(fp, builder, indent);
         }
      }
      #endregion

      #region Full Props
      public ObservableCollection<Footprint> Footprints
      {
         get => _footprints;
         set
         {
            _footprints = value;
            OnPropertyChanged();
         }
      }
      #endregion
   }
}
