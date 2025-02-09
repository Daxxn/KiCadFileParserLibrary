using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.KiCad.Schematics.SubModels;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

using MVVMLibrary;

namespace KiCadFileParserLibrary.KiCad.Schematics.Collections;

[SExprListNode("property")]
public class SchematicPropertyCollection : Model, IKiCadReadable, IKiCadWriteableCollection
{
   #region Local Props
   private ObservableCollection<SchematicProperty> _props = [];
   #endregion

   #region Constructors
   public SchematicPropertyCollection() { }
   #endregion

   #region Methods
   public void ParseNode(Node node)
   {
      if (node.Children is null) return;
      var propNodes = node.GetNodes(GetType().GetCustomAttribute<SExprListNodeAttribute>()!.Name);
      if (propNodes is null) return;
      Properties = [];
      foreach (var propNode in propNodes)
      {
         var prop = new SchematicProperty();
         prop.ParseNode(propNode);
         Properties.Add(prop);
      }
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
   public ObservableCollection<SchematicProperty> Properties
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
