using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.General;
using KiCadFileParserLibrary.KiCad.General.Collections;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.KiCad.Boards.SubModels;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;
using MVVMLibrary;

namespace KiCadFileParserLibrary.KiCad.Boards
{
   [SExprNode("via")]
   public class ViaModel : Model, IKiCadReadable
   {
      #region Local Props
      private ViaType _type;
      private LocationModel? _location;
      private double _size;
      private double _drill;
      private LayerCollection? _layers;
      private bool _removeUnusedLayers;
      private bool _keepEndLayers;
      private bool _isFree;
      private string _zoneLayerConnections;
      private int _net;
      private string _id;
      private TeardropModel? _teardrops;
      #endregion

      #region Constructors
      public ViaModel() { }
      #endregion

      #region Methods
      public void ParseNode(Node node)
      {
         if (node.Properties != null && node.Children != null)
         {
            var props = GetType().GetProperties();

            KiCadParseUtils.ParseTokens(props, node, this);
            KiCadParseUtils.ParseNodes(props, node, this);
            KiCadParseUtils.ParseSubNodes(props, node, this);
            KiCadParseUtils.ParseListNodes(props, node, this);
         }
      }

      public void WriteNode(StringBuilder builder, int indent, string? auxName = null)
      {
         builder.Append('\t', indent);
         builder.AppendLine($"(via");

         Location?.WriteNode(builder, indent + 1);

         builder.Append('\t', indent + 1);
         builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("size", Size));

         builder.Append('\t', indent + 1);
         builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("drill", Drill));

         Layers?.WriteNode(builder, indent + 1);

         if (RemoveUnusedLayers)
         {
            builder.Append('\t', indent + 1);
            builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("remove_unused_layers", RemoveUnusedLayers));
         }

         if (KeepEndLayers)
         {
            builder.Append('\t', indent + 1);
            builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("keep_end_layers", KeepEndLayers));
         }

         if (IsFree)
         {
            builder.Append('\t', indent + 1);
            builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("free", IsFree));
         }

         if (!string.IsNullOrEmpty(ZoneLayerConnections))
         {
            builder.Append('\t', indent + 1);
            builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("zone_layer_connections", ZoneLayerConnections));
         }

         Teardrops?.WriteNode(builder, indent + 1);

         builder.Append('\t', indent + 1);
         builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("net", Net));

         if (ID != null)
         {
            builder.Append('\t', indent + 1);
            builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("uuid", ID));
         }

         builder.Append('\t', indent);
         builder.AppendLine($")");
      }
      #endregion

      #region Full Props
      [SExprSubNode("type")]
      public ViaType Type
      {
         get => _type;
         set
         {
            _type = value;
            OnPropertyChanged();
         }
      }

      public LocationModel? Location
      {
         get => _location;
         set
         {
            _location = value;
            OnPropertyChanged();
         }
      }

      [SExprSubNode("size")]
      public double Size
      {
         get => _size;
         set
         {
            _size = value;
            OnPropertyChanged();
         }
      }

      [SExprSubNode("drill")]
      public double Drill
      {
         get => _drill;
         set
         {
            _drill = value;
            OnPropertyChanged();
         }
      }

      public LayerCollection? Layers
      {
         get => _layers;
         set
         {
            _layers = value;
            OnPropertyChanged();
         }
      }

      [SExprToken("remove_unused_layers")]
      public bool RemoveUnusedLayers
      {
         get => _removeUnusedLayers;
         set
         {
            _removeUnusedLayers = value;
            OnPropertyChanged();
         }
      }

      [SExprToken("keep_end_layers")]
      public bool KeepEndLayers
      {
         get => _keepEndLayers;
         set
         {
            _keepEndLayers = value;
            OnPropertyChanged();
         }
      }

      [SExprSubNode("free")]
      public bool IsFree
      {
         get => _isFree;
         set
         {
            _isFree = value;
            OnPropertyChanged();
         }
      }

      [SExprSubNode("zone_layer_connections")]
      public string ZoneLayerConnections
      {
         get => _zoneLayerConnections;
         set
         {
            _zoneLayerConnections = value;
            OnPropertyChanged();
         }
      }

      [SExprSubNode("net")]
      public int Net
      {
         get => _net;
         set
         {
            _net = value;
            OnPropertyChanged();
         }
      }

      [SExprSubNode("uuid")]
      public string ID
      {
         get => _id;
         set
         {
            _id = value;
            OnPropertyChanged();
         }
      }

      public TeardropModel? Teardrops
      {
         get => _teardrops;
         set
         {
            _teardrops = value;
            OnPropertyChanged();
         }
      }
      #endregion
   }
}
