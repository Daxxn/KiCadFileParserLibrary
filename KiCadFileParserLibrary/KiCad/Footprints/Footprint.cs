using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.Footprints.Collections;
using KiCadFileParserLibrary.KiCad.Footprints.SubModels;
using KiCadFileParserLibrary.KiCad.General;
using KiCadFileParserLibrary.KiCad.General.Collections;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.KiCad.Boards.Collections;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;
using MVVMLibrary;

namespace KiCadFileParserLibrary.KiCad.Footprints
{
   [SExprNode("footprint")]
   public class Footprint : Model, IKiCadReadable
   {
      #region Local Props
      private string _libPath;
      private bool _locked;
      private bool _placed;
      private string _layerName;
      private string? _id;
      private LocationModel _coords;
      private string? _desc;
      private string? _tags;
      private PropertyCollection? _props;
      private string? _path;
      private string? _sheetName;
      private string? _sheetFile;
      private double? _autoplaceCostHorz;
      private double? _autoplaceCostVert;
      private double? _solderMaskMargin;
      private double? _solderPasteMargin;
      private double? _solderPasteRatio;
      private double? _clearance;
      private ZoneConnectType _type;
      private double? _thermalWidth;
      private double? _thermalGap;
      private FootprintAttributeModel? _attributes;
      private PrivateLayersModel? _privateLayers;
      private NetTieGroupModel? _netTieGroups;
      private FpGraphicsCollection? _graphics;
      private PadCollection? _pads;
      private GroupCollection? _groups;
      private ModelCollection? _models;
      private ZoneCollection? _zones;
      private ImageCollection? _images;

      #endregion

      #region Constructors
      public Footprint() { }
      #endregion

      #region Methods
      public void ParseNode(Node node)
      {
         if (node.Properties != null && node.Children != null)
         {
            var props = GetType().GetProperties();

            KiCadParseUtils.ParseProperties(props, node, this);
            KiCadParseUtils.ParseSubNodes(props, node, this);
            KiCadParseUtils.ParseNodes(props, node, this);
            KiCadParseUtils.ParseTokens(props, node, this);
            KiCadParseUtils.ParseListNodes(props, node, this);
         }
      }

      public void WriteNode(StringBuilder builder, int indent, string? auxName = null)
      {
         builder.Append('\t', indent);
         builder.AppendLine($"(footprint \"{LibraryPath}\"");

         if(Locked)
         {
            builder.Append(" locked");
         }
         if (Placed)
         {
            builder.Append(" placed");
         }

         builder.Append('\t', indent + 1);
         builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("layer", LayerName));

         if (ID != null)
         {
            builder.Append('\t', indent + 1);
            builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("uuid", ID));
         }

         Coordinates.WriteNode(builder, indent + 1);

         if (Description != null)
         {
            builder.Append('\t', indent + 1);
            builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("descr", Description));
         }

         if (Tags != null)
         {
            builder.Append('\t', indent + 1);
            builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("tags", Tags));
         }

         Properties?.WriteNode(builder, indent + 1);

         if (Path != null)
         {
            builder.Append('\t', indent + 1);
            builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("path", Path));
         }

         if (AutoplaceCostHorz != null)
         {
            builder.Append('\t', indent + 1);
            builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("autoplace_cost90", AutoplaceCostHorz));
         }

         if (AutoplaceCostVert != null)
         {
            builder.Append('\t', indent + 1);
            builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("autoplace_cost180", AutoplaceCostVert));
         }

         if (SolderMaskMargin != null)
         {
            builder.Append('\t', indent + 1);
            builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("solder_mask_margin", SolderMaskMargin));
         }

         if (SolderPasteMargin != null)
         {
            builder.Append('\t', indent + 1);
            builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("solder_paste_margin", SolderPasteMargin));
         }

         if (SolderPasteRatio != null)
         {
            builder.Append('\t', indent + 1);
            builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("solder_paste_ratio", SolderPasteRatio));
         }

         if (Clearance != null)
         {
            builder.Append('\t', indent + 1);
            builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("clearance", Clearance));
         }

         if (ZoneConnect != ZoneConnectType.None)
         {
            builder.Append('\t', indent + 1);
            builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("zone_connect", (int)ZoneConnect));
         }

         if (SheetName != null)
         {
            builder.Append('\t', indent + 1);
            builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("sheetname", SheetName));
         }

         if (SheetFile != null)
         {
            builder.Append('\t', indent + 1);
            builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("sheetfile", SheetFile));
         }

         Attributes?.WriteNode(builder, indent + 1);

         PrivateLayers?.WriteNode(builder, indent + 1);

         NetTieGroups?.WriteNode(builder, indent + 1);

         Graphics?.WriteNode(builder, indent + 1);

         Images?.WriteNode(builder, indent + 1);

         Pads?.WriteNode(builder, indent + 1);

         Zones?.WriteNode(builder, indent + 1);

         Groups?.WriteNode(builder, indent + 1);

         Models?.WriteNode(builder, indent + 1);

         builder.Append('\t', indent);
         builder.AppendLine(")");
      }

      public override string ToString()
      {
         return $"Footprint - Lib: {LibraryPath} - Locked: {Locked} - Placed: {Placed} - Layer: {LayerName} - ID: {ID} - Private-Layers: {PrivateLayers?.Layers?.Count} - Net-Ties: {NetTieGroups?.Groups?.Count} - Graphics: {Graphics?.Graphics?.Count} - Imgs: {Images?.Images?.Count} - Pads: {Pads?.Pads.Count} - Zones: {Zones?.Zones.Count} - Groups: {Groups?.Groups.Count} - Models: {Models?.Models.Count}";
      }
      #endregion

      #region Full Props
      [SExprProperty(1)]
      public string LibraryPath
      {
         get => _libPath;
         set
         {
            _libPath = value;
            OnPropertyChanged();
         }
      }

      [SExprToken("locked")]
      public bool Locked
      {
         get => _locked;
         set
         {
            _locked = value;
            OnPropertyChanged();
         }
      }

      [SExprToken("placed")]
      public bool Placed
      {
         get => _placed;
         set
         {
            _placed = value;
            OnPropertyChanged();
         }
      }

      [SExprSubNode("layer")]
      public string LayerName
      {
         get => _layerName;
         set
         {
            _layerName = value;
            OnPropertyChanged();
         }
      }

      [SExprSubNode("uuid")]
      public string? ID
      {
         get => _id;
         set
         {
            _id = value;
            OnPropertyChanged();
         }
      }

      //[SExprSubNode("at")]
      public LocationModel Coordinates
      {
         get => _coords;
         set
         {
            _coords = value;
            OnPropertyChanged();
         }
      }

      [SExprSubNode("descr")]
      public string? Description
      {
         get => _desc;
         set
         {
            _desc = value;
            OnPropertyChanged();
         }
      }

      [SExprSubNode("tags")]
      public string? Tags
      {
         get => _tags;
         set
         {
            _tags = value;
            OnPropertyChanged();
         }
      }

      //[SExprSubNode("uuid")]
      //public List<PropertyModel>? Properties { get; set; }

      public PropertyCollection? Properties
      {
         get => _props;
         set
         {
            _props = value;
            OnPropertyChanged();
         }
      }

      [SExprSubNode("path")]
      public string? Path
      {
         get => _path;
         set
         {
            _path = value;
            OnPropertyChanged();
         }
      }

      [SExprSubNode("sheetname")]
      public string? SheetName
      {
         get => _sheetName;
         set
         {
            _sheetName = value;
            OnPropertyChanged();
         }
      }

      [SExprSubNode("sheetfile")]
      public string? SheetFile
      {
         get => _sheetFile;
         set
         {
            _sheetFile = value;
            OnPropertyChanged();
         }
      }

      [SExprSubNode("autoplace_cost90")]
      public double? AutoplaceCostHorz
      {
         get => _autoplaceCostHorz;
         set
         {
            _autoplaceCostHorz = value;
            OnPropertyChanged();
         }
      }

      [SExprSubNode("autoplace_cost180")]
      public double? AutoplaceCostVert
      {
         get => _autoplaceCostVert;
         set
         {
            _autoplaceCostVert = value;
            OnPropertyChanged();
         }
      }

      [SExprSubNode("solder_mask_margin")]
      public double? SolderMaskMargin
      {
         get => _solderMaskMargin;
         set
         {
            _solderMaskMargin = value;
            OnPropertyChanged();
         }
      }

      [SExprSubNode("solder_paste_margin")]
      public double? SolderPasteMargin
      {
         get => _solderPasteMargin;
         set
         {
            _solderPasteMargin = value;
            OnPropertyChanged();
         }
      }

      [SExprSubNode("solder_paste_ratio")]
      public double? SolderPasteRatio
      {
         get => _solderPasteRatio;
         set
         {
            _solderPasteRatio = value;
            OnPropertyChanged();
         }
      }

      [SExprSubNode("clearance")]
      public double? Clearance
      {
         get => _clearance;
         set
         {
            _clearance = value;
            OnPropertyChanged();
         }
      }

      [SExprSubNode("zone_connect")]
      public ZoneConnectType ZoneConnect
      {
         get => _type;
         set
         {
            _type = value;
            OnPropertyChanged();
         }
      }

      [SExprSubNode("thermal_width")]
      public double? ThermalWidth
      {
         get => _thermalWidth;
         set
         {
            _thermalWidth = value;
            OnPropertyChanged();
         }
      }

      [SExprSubNode("thermal_gap")]
      public double? ThermalGap
      {
         get => _thermalGap;
         set
         {
            _thermalGap = value;
            OnPropertyChanged();
         }
      }

      public FootprintAttributeModel? Attributes
      {
         get => _attributes;
         set
         {
            _attributes = value;
            OnPropertyChanged();
         }
      }

      public PrivateLayersModel? PrivateLayers
      {
         get => _privateLayers;
         set
         {
            _privateLayers = value;
            OnPropertyChanged();
         }
      }

      public NetTieGroupModel? NetTieGroups
      {
         get => _netTieGroups;
         set
         {
            _netTieGroups = value;
            OnPropertyChanged();
         }
      }

      public FpGraphicsCollection? Graphics
      {
         get => _graphics;
         set
         {
            _graphics = value;
            OnPropertyChanged();
         }
      }

      public PadCollection? Pads
      {
         get => _pads;
         set
         {
            _pads = value;
            OnPropertyChanged();
         }
      }

      public GroupCollection? Groups
      {
         get => _groups;
         set
         {
            _groups = value;
            OnPropertyChanged();
         }
      }

      public ModelCollection? Models
      {
         get => _models;
         set
         {
            _models = value;
            OnPropertyChanged();
         }
      }

      public ZoneCollection? Zones
      {
         get => _zones;
         set
         {
            _zones = value;
            OnPropertyChanged();
         }
      }

      public ImageCollection? Images
      {
         get => _images;
         set
         {
            _images = value;
            OnPropertyChanged();
         }
      }
      #endregion
   }
}
