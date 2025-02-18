using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.SExprParser;

using MVVMLibrary;

namespace KiCadFileParserLibrary.KiCad.Boards.Collections;

/// <summary>
/// List of zone layer connections in a <see cref="General.ZoneModel">Zone.</see>
/// <para/>
/// Not Used. Keep just in case the via "zone_layer_connections" node is actually an array.
/// <para/>
/// Nothing is documented so good luck!!
/// </summary>
[SExprNode("zone_layer_connections")]
public class ZoneLayerCollection : Model, IKiCadReadable, IKiCadWriteableCollection
{
   #region Local Props
   private ObservableCollection<string> _layers = [];
   #endregion

   #region Constructors
   /// <inheritdoc/>
   public ZoneLayerCollection() { }
   #endregion

   #region Methods
   /// <inheritdoc/>
   public void ParseNode(Node node)
   {
      if (node.Properties != null)
      {
         Layers = [];
         foreach (var prop in node.Properties)
         {
            Layers.Add(prop);
         }
      }
   }

   //public void WriteNode(StringBuilder builder, int indent, string? auxName = null)
   //{
   //   builder.Append('\t', indent);
   //   builder.Append("(zone_layer_connections");
   //   foreach (var layer in Layers)
   //   {
   //      builder.Append($" \"{layer}\"");
   //   }
   //   builder.AppendLine(")");
   //}

   /// <inheritdoc/>
   public void WriteCollection(StringBuilder builder, int indent)
   {
      builder.Append('\t', indent);
      builder.Append("(zone_layer_connections");
      foreach (var layer in Layers)
      {
         builder.Append($" \"{layer}\"");
      }
      builder.AppendLine(")");
   }

   /// <inheritdoc/>
   public override string ToString() => $"Zone Layer Coll - {Layers.Count}";
   #endregion

   #region Full Props
   /// <inheritdoc/>
   public ObservableCollection<string> Layers
   {
      get => _layers;
      set
      {
         _layers = value;
         OnPropertyChanged();
      }
   }
   #endregion
}
