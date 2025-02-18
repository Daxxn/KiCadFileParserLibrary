using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.General;
using KiCadFileParserLibrary.KiCad.General.Collections;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

using MVVMLibrary;

namespace KiCadFileParserLibrary.KiCad.Boards.SubModels;

/// <summary>
/// PCB Via model.
/// </summary>
[SExprNode("via")]
public class ViaModel : Model, IKiCadReadable
{
   #region Local Props
   private ViaType? _type;
   private LocationModel? _location;
   private double _size;
   private double _drill;
   private LayerCollection? _layers;
   private bool _removeUnusedLayers;
   private bool _keepEndLayers;
   private bool _isFree;
   private string? _zoneLayerConnections;
   private int _net;
   private string _id = "";
   private TeardropModel? _teardrops;
   #endregion

   #region Constructors
   /// <inheritdoc/>
   public ViaModel() { }
   #endregion

   #region Methods
   /// <inheritdoc/>
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
   #endregion

   #region Full Props
   /// <summary>
   /// The type of via.
   /// </summary>
   [SExprSubNode("type", 0)]
   [SExprFormatting(false, true)]
   public ViaType? Type
   {
      get => _type;
      set
      {
         _type = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Coordinates of the via.
   /// </summary>
   [SExprNode("at", 1)]
   public LocationModel? Location
   {
      get => _location;
      set
      {
         _location = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// The diameter of the via pad.
   /// </summary>
   [SExprSubNode("size", 2)]
   public double Size
   {
      get => _size;
      set
      {
         _size = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// The diameter of the via drill hole.
   /// </summary>
   [SExprSubNode("drill", 3)]
   public double Drill
   {
      get => _drill;
      set
      {
         _drill = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Collection of layers that the via uses.
   /// </summary>
   [SExprListNode("layers", 4)]
   public LayerCollection? Layers
   {
      get => _layers;
      set
      {
         _layers = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// ???
   /// </summary>
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

   /// <summary>
   /// ???
   /// </summary>
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

   /// <summary>
   /// ???
   /// </summary>
   [SExprSubNode("free", 6)]
   public bool IsFree
   {
      get => _isFree;
      set
      {
         _isFree = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// ???
   /// </summary>
   [SExprSubNode("zone_layer_connections")]
   public string? ZoneLayerConnections
   {
      get => _zoneLayerConnections;
      set
      {
         _zoneLayerConnections = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Net ID number.
   /// </summary>
   [SExprSubNode("net", 5)]
   public int Net
   {
      get => _net;
      set
      {
         _net = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Unique ID.
   /// </summary>
   [SExprSubNode("uuid", 7)]
   public string ID
   {
      get => _id;
      set
      {
         _id = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Teardrop model used for connected traces.
   /// </summary>
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
