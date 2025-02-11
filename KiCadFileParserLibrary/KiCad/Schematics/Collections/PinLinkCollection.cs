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

[SExprListNode("pin")]
public class PinLinkCollection : Model, IKiCadReadable, IKiCadWriteableCollection
{
   #region Local Props
   private ObservableCollection<PinLinkModel> _pins = [];
   #endregion

   #region Constructors
   public PinLinkCollection() { }
   #endregion

   #region Methods
   public void ParseNode(Node node)
   {
      if (node.Children is null) return;
      var pinNodes = node.GetNodes("pin");
      if (pinNodes is null) return;
      foreach ( var pinNode in pinNodes )
      {
         var pin = new PinLinkModel();
         pin.ParseNode(pinNode);
         Pins.Add(pin);
      }
   }

   public void WriteCollection(StringBuilder builder, int indent)
   {
      foreach (var pin in Pins)
      {
         KiCadWriteUtils2.WriteNode(pin, builder, indent);
      }
   }
   #endregion

   #region Full Props
   public ObservableCollection<PinLinkModel> Pins
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
