using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.Footprints.SubModels;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

using MVVMLibrary;

namespace KiCadFileParserLibrary.KiCad.Footprints.Collections;

/// <summary>
/// List of <see cref="PropertyModel">Properties.</see>
/// </summary>
[SExprListNode("property")]
public class PropertyCollection : Model, IKiCadReadable, IKiCadWriteableCollection
{
   #region Local Props
   private ObservableCollection<PropertyModel> _properties = [];

   private string _filterProp = "";
   #endregion

   #region Constructors
   /// <inheritdoc/>
   public PropertyCollection() { }
   #endregion

   #region Methods
   /// <inheritdoc/>
   public void ParseNode(Node node)
   {
      var children = node.GetNodes("property");
      if (children is null) return;
      Properties = [];
      foreach (var child in children)
      {
         if (child.Properties![1] == "ki_fp_filters")
            FilterProp = child.Properties[2];
         else
         {
            PropertyModel prop = new();
            prop.ParseNode(child);
            Properties.Add(prop);
         }
      }
   }

   /// <inheritdoc/>
   public void WriteCollection(StringBuilder builder, int indent)
   {
      foreach (var prop in Properties)
      {
         //prop.WriteNode(builder, indent);
         KiCadWriteUtils2.WriteNode(prop, builder, indent);
      }
      if (string.IsNullOrEmpty(FilterProp)) return;
      builder.Append('\t', indent);
      builder.AppendLine($"(property ki_fp_filters \"{FilterProp}\")");
   }
   #endregion

   #region Full Props
   /// <summary>
   /// List of <see cref="PropertyModel">Properties.</see>
   /// </summary>
   public ObservableCollection<PropertyModel> Properties
   {
      get => _properties;
      set
      {
         _properties = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Property filter string.
   /// </summary>
   public string FilterProp
   {
      get => _filterProp;
      set
      {
         _filterProp = value;
         OnPropertyChanged();
      }
   }
   #endregion
}
