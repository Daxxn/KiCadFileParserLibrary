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

/// <summary>
/// List of <see cref="PinLinkModel">Pin Links</see>
/// </summary>
[SExprListNode("pin")]
public class PinLinkCollection : Model, IKiCadReadable, IKiCadWriteableCollection
{
   #region Local Props
   private ObservableCollection<PinLinkModel> _pins = [];
   #endregion

   #region Constructors
   /// <inheritdoc/>
   public PinLinkCollection() { }
   #endregion

   #region Methods
   /// <inheritdoc/>
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

   /// <inheritdoc/>
   public void WriteCollection(StringBuilder builder, int indent)
   {
      foreach (var pin in Pins)
      {
         KiCadWriteUtils.WriteNode(pin, builder, indent);
      }
   }
   #endregion

   #region Full Props
   /// <summary>
   /// List of <see cref="PinLinkModel">Pin Links</see>
   /// </summary>
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
