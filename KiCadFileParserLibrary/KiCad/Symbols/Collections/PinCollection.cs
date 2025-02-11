using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.KiCad.Symbols.SubModels;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

using MVVMLibrary;

namespace KiCadFileParserLibrary.KiCad.Symbols.Collections
{
   [SExprListNode("pin")]
   public class PinCollection : Model, IKiCadReadable, IKiCadWriteableCollection
   {
      #region Local Props
      private ObservableCollection<PinModel> _pins;
      #endregion

      #region Constructors
      public PinCollection() { }
      #endregion

      #region Methods
      public void ParseNode(Node node)
      {
         var children = node.GetNodes("pin");
         if (children is null) return;
         Pins = [];
         foreach (var child in children)
         {
            PinModel pin = new();
            pin.ParseNode(child);
            Pins.Add(pin);
         }
      }

      public void WriteCollection(StringBuilder builder, int indent)
      {
         if (Pins is null) return;
         foreach (var pin in Pins)
         {
            KiCadWriteUtils2.WriteNode(pin, builder, indent);
         }
      }
      #endregion

      #region Full Props
      public ObservableCollection<PinModel> Pins
      {
         get => _pins;
         set
         {
            _pins = value;
            OnPropertyChanged();
         }
      }
      #endregion
   }
}
