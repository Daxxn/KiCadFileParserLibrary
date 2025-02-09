using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

using MVVMLibrary;

namespace KiCadFileParserLibrary.KiCad.General.Collections;

[SExprListNode("property")]
public class GenericPropertyCollection : Model, IKiCadReadable, IKiCadWriteableCollection
{
   #region Local Props
   private ObservableCollection<GenericProperty> _props = new();
   #endregion

   #region Constructors
   public GenericPropertyCollection() { }
   #endregion

   #region Methods
   public void ParseNode(Node node)
   {
      if (node.Children is null) return;

      var propNodes = node.GetNodes("property");
      if (propNodes is null) return;
      Properties = [];
      foreach (var n in propNodes)
      {
         var prop = new GenericProperty();
         prop.ParseNode(n);
         Properties.Add(prop);
      }
   }

   public void WriteNode(StringBuilder builder, int indent, string? auxName = null)
   {
      throw new NotImplementedException();
   }

   public void WriteCollection(StringBuilder builder, int indent)
   {
      if (Properties is null) return;
      foreach (var prop in Properties)
      {
         KiCadWriteUtils2.WriteNode(prop, builder, indent);
      }
   }
   #endregion

   #region Full Props
   public ObservableCollection<GenericProperty> Properties
   {
      get => _props;
      set
      {
         _props = value;
         OnPropertyChanged();
      }
   }
   #endregion
}
