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

/// <summary>
/// List of <see cref="GenericProperty">Properties.</see>
/// </summary>
[SExprListNode("property")]
public class GenericPropertyCollection : Model, IKiCadReadable, IKiCadWriteableCollection
{
   #region Local Props
   private ObservableCollection<GenericProperty> _props = new();
   #endregion

   #region Constructors
   /// <inheritdoc/>
   public GenericPropertyCollection() { }
   #endregion

   #region Methods
   /// <inheritdoc/>
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

   /// <inheritdoc/>
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
   /// <summary>
   /// List of <see cref="GenericProperty">Properties.</see>
   /// </summary>
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
