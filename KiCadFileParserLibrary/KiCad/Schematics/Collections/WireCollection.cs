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

using MVVMLibrary;

namespace KiCadFileParserLibrary.KiCad.Schematics.Collections
{
   [SExprListNode("wire")]
   public class WireCollection : Model, IKiCadReadable
   {
      #region Local Props
      private ObservableCollection<WireModel>? _wires;
      #endregion

      #region Constructors
      public WireCollection() { }
      #endregion

      #region Methods
      public void ParseNode(Node node)
      {
         throw new NotImplementedException();
      }

      public void WriteNode(StringBuilder builder, int indent, string? auxName = null)
      {
         throw new NotImplementedException();
      }
      #endregion

      #region Full Props
      public ObservableCollection<WireModel>? Wires
      {
         get => _wires;
         set
         {
            _wires = value;
            OnPropertyChanged();
         }
      }
      #endregion
   }
}
