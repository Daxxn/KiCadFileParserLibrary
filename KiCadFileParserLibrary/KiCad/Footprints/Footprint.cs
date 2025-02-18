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
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

using MVVMLibrary;

namespace KiCadFileParserLibrary.KiCad.Footprints;

/// <summary>
/// Model of a KiCad footprint.
/// </summary>
[SExprNode("footprint")]
public class Footprint : Model, IKiCadReadable
{
   #region Local Props
   private string _libName = null!;
   private int? _version = null;
   private string? _generator = null;
   private string? _genVersion = null;
   private bool _locked;
   private bool _placed;
   private string _layerName = null!;
   private string? _id;
   private LocationModel? _coords;
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
   private int _zoneConnect;
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
   /// <inheritdoc/>
   public Footprint() { }
   #endregion

   #region Methods
   /// <inheritdoc/>
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

   /// <summary>
   /// Change the project file name in the 
   /// </summary>
   /// <param name="newProjName"></param>
   public void ChangeProjectName(string newProjName)
   {
      if (SheetName == KiCadConstants.DefaultRootSchematicName)
      {
         SheetFile = $"{newProjName}.{KiCadConstants.Extensions.Schematic}";
      }
      else
      {
         var nameSplit = System.IO.Path.GetFileNameWithoutExtension(SheetFile)?.Split(KiCadConstants.ProjectNameDelimiter);
         if (nameSplit?.Length > 1)
         {
            SheetFile = $"{newProjName}_{string.Join('_', nameSplit[1..])}.{KiCadConstants.Extensions.Schematic}";
         }
      }
   }

   /// <inheritdoc/>
   public override string ToString() => $"Footprint - Lib: {Name} - Locked: {Locked} - Placed: {Placed} - Layer: {LayerName} - ID: {ID} - Private-Layers: {PrivateLayers?.Layers?.Count} - Net-Ties: {NetTieGroups?.Groups?.Count} - Graphics: {Graphics?.Graphics?.Count} - Imgs: {Images?.Images?.Count} - Pads: {Pads?.Pads.Count} - Zones: {Zones?.Zones.Count} - Groups: {Groups?.Groups.Count} - Models: {Models?.Models.Count}";
   #endregion

   #region Full Props
   /// <summary>
   /// The name of the footprint.
   /// <para/>
   /// The same as the file name if from a library.
   /// </summary>
   [SExprProperty(1)]
   public string Name
   {
      get => _libName;
      set
      {
         _libName = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// The version of the footprint file.
   /// <para/>
   /// Will be null if in a PCB file.
   /// <para/>
   /// Do NOT modify this unless you know what will happen.
   /// </summary>
   [SExprSubNode("version")]
   public int? Version
   {
      get => _version;
      set
      {
         _version = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// The KiCad generator that created this file.
   /// <para/>
   /// Will be null if in a PCB file.
   /// <para/>
   /// Do NOT modify this unless you know what will happen.
   /// </summary>
   [SExprSubNode("generator")]
   public string? Generator
   {
      get => _generator;
      set
      {
         _generator = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// The version of the KiCad generator that created this file.
   /// <para/>
   /// Will be null if in a PCB file.
   /// <para/>
   /// Do NOT modify this unless you know what will happen.
   /// </summary>
   [SExprSubNode("generator_version")]
   public string? GeneratorVersion
   {
      get => _genVersion;
      set
      {
         _genVersion = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Is locked.
   /// </summary>
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

   /// <summary>
   /// Is placed.
   /// </summary>
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

   /// <summary>
   /// Layer name.
   /// </summary>
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

   /// <summary>
   /// Unique ID.
   /// </summary>
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

   /// <summary>
   /// The location of the footprint on the <see cref="Boards.PcbModel">PCB.</see>
   /// <para/>
   /// Will be null if from a library.
   /// </summary>
   public LocationModel? Coordinates
   {
      get => _coords;
      set
      {
         _coords = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Description text
   /// </summary>
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

   /// <summary>
   /// KiCad search tags.
   /// </summary>
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

   /// <summary>
   /// List of footprint properties.
   /// </summary>
   public PropertyCollection? Properties
   {
      get => _props;
      set
      {
         _props = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Library path.
   /// <para/>
   /// Uses the "Library:Footprint" naming schema.
   /// </summary>
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

   /// <summary>
   /// The name of the <see cref="Schematics.Schematic">Schematic</see> sheet where the <see cref="Symbols.Symbol">Symbol</see> is linked to.
   /// </summary>
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

   /// <summary>
   /// The name of the <see cref="Schematics.Schematic">Schematic</see> file where the <see cref="Symbols.Symbol">Symbol</see> is linked to.
   /// </summary>
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

   /// <summary>
   /// Auto-router settings.
   /// <para/>
   /// Not sure if this is even used.
   /// </summary>
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

   /// <summary>
   /// Auto-router settings.
   /// <para/>
   /// Not sure if this is even used.
   /// </summary>
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

   /// <summary>
   /// Solder mask margin.
   /// <para/>
   /// Uses global option if null.
   /// </summary>
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

   /// <summary>
   /// Solder paste margin.
   /// <para/>
   /// Uses global option if null.
   /// </summary>
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

   /// <summary>
   /// Solder paste ratio.
   /// <para/>
   /// Uses global option if null.
   /// </summary>
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

   /// <summary>
   /// Footprint clearance.
   /// <para/>
   /// Uses global option if null.
   /// </summary>
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

   /// <summary>
   /// Zone connection mode.
   /// </summary>
   [SExprSubNode("zone_connect")]
   public int ZoneConnect
   {
      get => _zoneConnect;
      set
      {
         _zoneConnect = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Thermal isolation trace width.
   /// </summary>
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

   /// <summary>
   /// Thermal isolation gap.
   /// </summary>
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

   /// <summary>
   /// Footprint attributes.
   /// </summary>
   public FootprintAttributeModel? Attributes
   {
      get => _attributes;
      set
      {
         _attributes = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Layers not drawn on the PCB.
   /// </summary>
   public PrivateLayersModel? PrivateLayers
   {
      get => _privateLayers;
      set
      {
         _privateLayers = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// List of net-tie groups.
   /// </summary>
   public NetTieGroupModel? NetTieGroups
   {
      get => _netTieGroups;
      set
      {
         _netTieGroups = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// List of footprint graphics.
   /// </summary>
   public FpGraphicsCollection? Graphics
   {
      get => _graphics;
      set
      {
         _graphics = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// List of pads.
   /// </summary>
   public PadCollection? Pads
   {
      get => _pads;
      set
      {
         _pads = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// List of groups.
   /// </summary>
   public GroupCollection? Groups
   {
      get => _groups;
      set
      {
         _groups = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// List of <see cref="Footprint3DModel">3D models</see> representing the component.
   /// </summary>
   public ModelCollection? Models
   {
      get => _models;
      set
      {
         _models = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// List of <see cref="ZoneModel">Zones.</see>
   /// </summary>
   public ZoneCollection? Zones
   {
      get => _zones;
      set
      {
         _zones = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// List of <see cref="ImageModel">Images.</see>
   /// </summary>
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
