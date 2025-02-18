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

/// <summary>
/// List of <see cref="SchematicProperty">Properties</see> of a <see cref="Schematic">Schematic.</see>
/// </summary>
[SExprListNode("property")]
public class SchematicPropertyCollection : Model, IKiCadReadable, IKiCadWriteableCollection
{
   #region Local Props
   private ObservableCollection<SchematicProperty> _props = [];
   #endregion

   #region Constructors
   /// <inheritdoc/>
   public SchematicPropertyCollection() { }
   #endregion

   #region Methods
   /// <inheritdoc/>
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

   /// <inheritdoc/>
   public void WriteCollection(StringBuilder builder, int indent)
   {
      if (Properties is null) return;
      foreach (var prop in Properties)
      {
         KiCadWriteUtils.WriteNode(prop, builder, indent);
      }
   }

   /// <summary>
   /// Find the property that matches the provided key.
   /// </summary>
   /// <param name="key">The key to search for.</param>
   /// <returns>The first <see cref="SchematicProperty"/> with that key.</returns>
   public SchematicProperty? GetProperty(string? key)
   {
      if (string.IsNullOrEmpty(key)) return null;

      return Properties.FirstOrDefault(x => x.Key == key);
   }
   #endregion

   #region Full Props
   /// <summary>
   /// List of <see cref="SchematicProperty">Properties</see>
   /// </summary>
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
