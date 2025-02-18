using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.General.Collections;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

using MVVMLibrary;

namespace KiCadFileParserLibrary.KiCad.General;

/// <summary>
/// Zone model.
/// </summary>
[SExprNode("zone")]
public class ZoneModel : Model, IKiCadReadable
{
   #region Local Props
   private int _net;
   private string _netName = "";
   private string _layer = "";
   private LayerCollection? _layers;
   private string _id = "";
   private string? _name;
   private HatchModel? _hatch;
   private int _priority;
   private ConnectPadsModel? _connectPads;
   private double? _minThickness;
   private bool _filledAreaThick;
   private ZoneFillSettingsModel? _fill;
   private ZoneKeepoutModel? _keepout;
   private PolygonModel? _polygon;
   private ZoneFillPolygonModel? _polygonFill;
   private ZoneFillSegments? _segments;
   private ZoneAttributesModel? _attributes;
   #endregion

   #region Constructors
   /// <inheritdoc/>
   public ZoneModel() { }
   #endregion

   #region Methods
   /// <inheritdoc/>
   public void ParseNode(Node node)
   {
      if (node.Properties != null && node.Children != null)
      {
         var props = GetType().GetProperties();

         KiCadParseUtils.ParseSubNodes(props, node, this);
         KiCadParseUtils.ParseNodes(props, node, this);
         KiCadParseUtils.ParseListNodes(props, node, this);
      }
   }
   #endregion

   #region Full Props
   /// <summary>
   /// Zone net ID.
   /// </summary>
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

   /// <summary>
   /// Net name.
   /// </summary>
   [SExprSubNode("net_name")]
   public string NetName
   {
      get => _netName;
      set
      {
         _netName = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Layer name.
   /// </summary>
   [SExprSubNode("layer")]
   public string Layer
   {
      get => _layer;
      set
      {
         _layer = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// List of layer names.
   /// </summary>
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
   /// Unique ID.
   /// </summary>
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

   /// <summary>
   /// Zone name.
   /// </summary>
   [SExprSubNode("name")]
   public string? Name
   {
      get => _name;
      set
      {
         _name = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Zone hatch data.
   /// </summary>
   public HatchModel? Hatch
   {
      get => _hatch;
      set
      {
         _hatch = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Fill priority
   /// </summary>
   [SExprSubNode("priority")]
   public int Priority
   {
      get => _priority;
      set
      {
         _priority = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Connected pads.
   /// </summary>
   public ConnectPadsModel? ConnectPads
   {
      get => _connectPads;
      set
      {
         _connectPads = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Minimum thickness.
   /// </summary>
   [SExprSubNode("min_thickness")]
   public double? MinThickness
   {
      get => _minThickness;
      set
      {
         _minThickness = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Filled area thickness.
   /// </summary>
   [SExprSubNode("filled_areas_thickness")]
   public bool FilledAreasThickness
   {
      get => _filledAreaThick;
      set
      {
         _filledAreaThick = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Zone fill settings data.
   /// </summary>
   public ZoneFillSettingsModel? Fill
   {
      get => _fill;
      set
      {
         _fill = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Zone keepout settings.
   /// </summary>
   public ZoneKeepoutModel? Keepout
   {
      get => _keepout;
      set
      {
         _keepout = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Zone polygon data.
   /// </summary>
   public PolygonModel? Polygon
   {
      get => _polygon;
      set
      {
         _polygon = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Zone fill polygon data.
   /// </summary>
   public ZoneFillPolygonModel? PolygonFill
   {
      get => _polygonFill;
      set
      {
         _polygonFill = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Zone fill segments.
   /// </summary>
   public ZoneFillSegments? Segments
   {
      get => _segments;
      set
      {
         _segments = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Zone attributes.
   /// </summary>
   public ZoneAttributesModel? Attributes
   {
      get => _attributes;
      set
      {
         _attributes = value;
         OnPropertyChanged();
      }
   }
   #endregion
}
