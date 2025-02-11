using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KiCadFileParserLibrary.KiCad;

/// <summary>
/// Type of KiCad project file
/// </summary>
public enum ProjectFileType
{
   /// <inheritdoc/>
   Schematic,
   /// <inheritdoc/>
   PCB,
   /// <inheritdoc/>
   Project,
}

/// <summary>
/// type of KiCad library file
/// </summary>
public enum LibraryFileType
{
   /// <inheritdoc/>
   Footprints,
   /// <inheritdoc/>
   Symbols,
}

/// <summary>
/// Type of PCB layer.
/// <para/>
/// If none, there is an error with parsing
/// </summary>
public enum LayerType
{
   /// <summary>
   /// Not a valid layer, Parsing Error!
   /// </summary>
   None = 0,
   /// <summary>
   /// Layer is used for signals only
   /// </summary>
   signal,
   /// <summary>
   /// Layer is user defined and not a normal layer
   /// </summary>
   user,
   /// <summary>
   /// Layer is a mix of signal and power
   /// </summary>
   mixed,
   /// <summary>
   /// Layer used for power planes only
   /// </summary>
   power,
   /// <summary>
   /// Not sure. Not very common
   /// </summary>
   jumper,
};

/// <summary>
/// PCB fabrication output option
/// </summary>
public enum FabOutputType
{
   /// <summary>
   /// HP Graphics Language File output
   /// </summary>
   HPGL = 0,
   /// <summary>
   /// Gerber File output
   /// </summary>
   Gerber = 1,
   /// <summary>
   /// Postscript vector graphics file output
   /// </summary>
   PostScript = 2,
   /// <summary>
   /// Common vector file format used by CAD software
   /// </summary>
   DXF = 3,
   /// <summary>
   /// Standard PDF file output
   /// </summary>
   PDF = 4,
   /// <summary>
   /// Standard Vector Graphics file output
   /// </summary>
   SVG = 5,
}

/// <summary>
/// PCB contains an edge connector
/// </summary>
public enum EdgeConnectorType
{
   /// <summary>
   /// PCB does not have any edge connectors
   /// </summary>
   No,
   /// <summary>
   /// PCB has an edge connector
   /// </summary>
   Yes,
   /// <summary>
   /// The edge connector has bevelled edges, common on PCI-e cards.
   /// </summary>
   Bevelled,
}

/// <summary>
/// The type of footprint
/// </summary>
public enum FootprintType
{
   /// <summary>
   /// Used for labels and graphics
   /// </summary>
   None = 0,
   /// <summary>
   /// Footprint contains surface-mount pads
   /// </summary>
   SMD,
   /// <summary>
   /// Footprint contains through-hole pads
   /// </summary>
   through_hole
}

/// <summary>
/// The method used to connect the zone to pads
/// </summary>
public enum ZoneConnectType
{
   /// <summary>
   /// The zone does not connect anywhere (floating)
   /// <para/>
   /// This is not normally a good idea.
   /// </summary>
   None = 0,
   /// <summary>
   /// The zone is used to thermally separate the pad
   /// <para/>
   /// Usually to make soldering easier.
   /// </summary>
   ThermalReleif = 1,
   /// <summary>
   /// The zone fully connects to the pad
   /// </summary>
   Solid = 2,
   /// <summary>
   /// Uses custom settings described by the user
   /// </summary>
   UseZoneSettings = 3,
}

/// <summary>
/// The types of footprint text groups
/// </summary>
public enum FootprintTextType
{
   /// <summary>
   /// Reference designator for the footprint
   /// </summary>
   Reference,
   /// <summary>
   /// The value of the footprint
   /// </summary>
   value,
   /// <summary>
   /// User defined text
   /// </summary>
   User
}

/// <summary>
/// The render direction of text
/// </summary>
public enum TextJustify
{
   /// <inheritdoc/>
   Center = 0,
   /// <inheritdoc/>
   Mirror,
   /// <inheritdoc/>
   Left,
   /// <inheritdoc/>
   Right,
   /// <inheritdoc/>
   Top,
   /// <inheritdoc/>
   Bottom,
}

/// <summary>
/// The line drawing style
/// </summary>
public enum StrokeType
{
   /// <inheritdoc/>
   Solid = 0,
   /// <inheritdoc/>
   Dash,
   /// <inheritdoc/>
   Dash_Dot,
   /// <inheritdoc/>
   Dash_Dot_Dot,
   /// <inheritdoc/>
   Dot,
   /// <summary>
   /// Use the stroke setting defined by the PCB or schematic.
   /// </summary>
   Default,
}

/// <summary>
/// The fill options for schematic graphics objects
/// </summary>
public enum FillType
{
   /// <inheritdoc/>
   None = 0,
   /// <inheritdoc/>
   Solid,
   /// <inheritdoc/>
   Yes,
   /// <inheritdoc/>
   No,
}

/// <inheritdoc/>
public enum TextPositionMode
{
   /// <inheritdoc/>
   Outside = 0,
   /// <inheritdoc/>
   InLine = 1,
   /// <inheritdoc/>
   Manual = 2,
}

/// <summary>
/// Option for adding a border around text
/// </summary>
public enum TextFrameType
{
   /// <inheritdoc/>
   NoFrame = 0,
   /// <inheritdoc/>
   Rectangle = 1,
   /// <inheritdoc/>
   Circle = 2,
   /// <inheritdoc/>
   RoundRectangle = 3,
}

/// <summary>
/// The type of units used for measurement
/// </summary>
public enum UnitsType
{
   /// <summary>
   /// Use inch units
   /// <para/>
   /// Not very common. (I hate it...)
   /// </summary>
   Inches = 0,
   /// <summary>
   /// Use 1000th of an inch
   /// <para/>
   /// A defacto standard of the industry. (Its better than inches...)
   /// </summary>
   Mils = 1,
   /// <summary>
   /// Use 1000th of a meter.
   /// <para/>
   /// The only units I use.
   /// </summary>
   Millimeters = 2,
   /// <summary>
   /// Not sure, Will probably default to mils.
   /// </summary>
   Auto = 3,
}

/// <summary>
/// Units suffix options
/// </summary>
public enum UnitsFormat
{
   /// <inheritdoc/>
   NoSuffix = 0,
   /// <inheritdoc/>
   BareSuffix = 1,
   /// <summary>
   /// Wrap suffix in parenthesis
   /// </summary>
   WrapSuffix = 2,
}

/// <summary>
/// The type of footprint pad
/// </summary>
public enum PadType
{
   /// <inheritdoc/>
   Thru_Hole,
   /// <inheritdoc/>
   SMD,
   /// <inheritdoc/>
   Connect,
   /// <summary>
   /// Non-Plated through hole
   /// </summary>
   Np_Thru_Hole,
}

/// <summary>
/// The shape of the pad
/// </summary>
public enum PadShapeType
{
   /// <inheritdoc/>
   Circle,
   /// <inheritdoc/>
   Rect,
   /// <inheritdoc/>
   Oval,
   /// <inheritdoc/>
   Trapezoid,
   /// <inheritdoc/>
   RoundRect,
   /// <summary>
   /// Defined by the user
   /// </summary>
   Custom
}

/// <summary>
/// The shape of the hole for through-hole pads
/// <para/>
/// Can only be Circular or oval. Circular is the default and will not be written.
/// </summary>
public enum DrillShapeType
{
   /// <inheritdoc/>
   Oval,
}

/// <summary>
/// Optional properties describing a pad
/// </summary>
public enum PadPropertyType
{
   /// <summary>
   /// The pad connects to a Ball Grid Array
   /// </summary>
   Pad_Prop_BGA,
   /// <summary>
   /// The pad is a global fiducial
   /// </summary>
   Pad_Prop_Fiducial_Glob,
   /// <summary>
   /// The pad is a fiducial used for alignment
   /// </summary>
   Pad_Prop_Fiducial_Loc,
   /// <summary>
   /// The pad is used as test-point
   /// </summary>
   Pad_Prop_Testpoint,
   /// <summary>
   /// The pad is connected to a heat-sink
   /// </summary>
   Pad_Prop_Heatsink,
   /// <summary>
   /// The pad is designed to be cut in half
   /// </summary>
   Pad_Prop_Castellated,
}

/// <summary>
/// Chamfer options for a pad
/// </summary>
public enum ChamferType
{
   /// <inheritdoc/>
   Top_Left,
   /// <inheritdoc/>
   Top_Right,
   /// <inheritdoc/>
   Bottom_Left,
   /// <inheritdoc/>
   Bottom_Right,
}

/// <summary>
/// Custom pad clearance options
/// </summary>
public enum CustomPadClearance
{
   /// <inheritdoc/>
   None = 0,
   /// <inheritdoc/>
   Outline,
   /// <inheritdoc/>
   ConvexHull
}

/// <summary>
/// The anchor point for a pad with a custom shape
/// </summary>
public enum CustomPadAnchor
{
   None = 0,
   Rect,
   Circle,
}

/// <summary>
/// The type dimension
/// </summary>
public enum DimensionType
{
   /// <inheritdoc/>
   None = 0,
   /// <inheritdoc/>
   Aligned,
   /// <inheritdoc/>
   Leader,
   /// <inheritdoc/>
   Center,
   /// <inheritdoc/>
   Orthogonal,
   /// <inheritdoc/>
   Radial,
}

/// <summary>
/// Options for creating hatched zone fills
/// </summary>
public enum HatchType
{
   /// <inheritdoc/>
   None = 0,
   /// <inheritdoc/>
   Edge,
   /// <inheritdoc/>
   Full,
}

/// <summary>
/// Options for keepout zones
/// </summary>
public enum KeepoutType
{
   None = 0,
   Not_Allowed,
   Allowed,
}

/// <summary>
/// Zone fill modes
/// </summary>
public enum FillMode
{
   None = 0,
   Solid,
   Hatched,
}

/// <summary>
/// Options for smoothing zone fills
/// </summary>
public enum SmoothingStyleType
{
   /// <inheritdoc/>
   None = 0,
   /// <summary>
   /// Corners are chanfered, cut at 45 degrees
   /// </summary>
   Chamfer,
   /// <summary>
   /// Corners are rounded off
   /// </summary>
   Fillet,
}

/// <summary>
/// Options for removing copper zones without a connection
/// </summary>
public enum IslandRemovalMode
{
   /// <summary>
   /// Always remove copper islands
   /// </summary>
   AlwaysRemove = 0,
   /// <summary>
   /// Never remove copper islands
   /// </summary>
   NeverRemove = 1,
   /// <summary>
   /// Remove copper islands based on the size of the island
   /// </summary>
   MinimumArea = 2,
}

/// <summary>
/// Hatched zone smoothing level
/// </summary>
public enum HatchSmoothingLevel
{
   /// <inheritdoc/>
   NoSmoothing = 0,
   /// <inheritdoc/>
   Fillet = 1,
   /// <inheritdoc/>
   ArcMin = 2,
   /// <inheritdoc/>
   ArcMax = 3,
}

/// <summary>
/// The hatched zone border algorythm to use
/// </summary>
public enum HatchBorderAlgorythmType
{
   /// <inheritdoc/>
   None = 0,
   /// <inheritdoc/>
   Min_Thickness,
   /// <inheritdoc/>
   Hatch_Thickness,
}

/// <summary>
/// The type of via
/// </summary>
public enum ViaType
{
   /// <summary>
   /// The via is drilled through the board
   /// <para/>
   /// The only option for most board houses
   /// </summary>
   Normal = 0,
   /// <summary>
   /// The via is only connected to 2 adjacent layers
   /// <para/>
   /// Requires special manufacturing techniques and is more expensive
   /// </summary>
   Blind,
   /// <summary>
   /// The via is smaller than the typical via size
   /// <para/>
   /// Requires special manufacturing techniques and is more expensive
   /// </summary>
   Micro,
}

/// <summary>
/// The type of automatically generated trace
/// </summary>
public enum GeneratedType
{
   /// <summary>
   /// The only type of generated trace at the moment.
   /// </summary>
   Tuning_Pattern
}

/// <summary>
/// Visibility of a symbol
/// </summary>
public enum SymbolVisibility
{
   /// <inheritdoc/>
   Hidden,
   /// <inheritdoc/>
   Visible,
}

/// <summary>
/// Visibility of a pad
/// </summary>
public enum PinVisibility
{
   /// <inheritdoc/>
   Hide,
   /// <inheritdoc/>
   Visible,
}

/// <summary>
/// Axis used to mirror the object
/// </summary>
public enum MirrorMode
{
   /// <inheritdoc/>
   X,
   /// <inheritdoc/>
   Y,
}

/// <summary>
/// Pin number visibility option
/// </summary>
public enum PinNumberVisibility
{
   /// <inheritdoc/>
   Hide
}

/// <inheritdoc/>
public enum PinElectricalType
{
   /// <inheritdoc/>
   Input,
   /// <inheritdoc/>
   Output,
   /// <inheritdoc/>
   Bidirectional,
   /// <inheritdoc/>
   Tri_State,
   /// <inheritdoc/>
   Passive,
   /// <inheritdoc/>
   Free,
   /// <inheritdoc/>
   Unspecified,
   /// <inheritdoc/>
   Power_In,
   /// <inheritdoc/>
   Power_Out,
   /// <inheritdoc/>
   Open_Collector,
   /// <inheritdoc/>
   Open_Emitter,
   /// <inheritdoc/>
   No_Connect
}

/// <inheritdoc/>
public enum PinGraphicStyle
{
   /// <inheritdoc/>
   Line,
   /// <inheritdoc/>
   Inverted,
   /// <inheritdoc/>
   Clock,
   /// <inheritdoc/>
   Inverted_Clock,
   /// <inheritdoc/>
   Input_Low,
   /// <inheritdoc/>
   Clock_Low,
   /// <inheritdoc/>
   Output_Low,
   /// <inheritdoc/>
   Edge_Clock_High,
   /// <inheritdoc/>
   Non_Logic
}

/// <inheritdoc/>
public enum SymbolStyleIdentifier
{
   /// <inheritdoc/>
   Default_Style = 0,
}

/// <inheritdoc/>
public enum ZoneFillMode
{
   /// <inheritdoc/>
   Solid = 0,
   /// <inheritdoc/>
   Hatch = 1,
}

/// <inheritdoc/>
public enum TeardropType
{
   /// <inheritdoc/>
   None,
   /// <inheritdoc/>
   PadVia,
}

/// <summary>
/// Output format for plotting PCBs.
/// </summary>
public enum PcbOutputFormat
{
   /// <summary>
   /// Gerber File output
   /// </summary>
   Gerber,
   /// <summary>
   /// Postscript vector graphics file output
   /// </summary>
   PostScript,
   /// <summary>
   /// Standard Vector Graphics file output
   /// </summary>
   SVG,
   /// <summary>
   /// Common vector file format used by CAD software
   /// </summary>
   DXF,
   /// <summary>
   /// HP Graphics Language File output
   /// </summary>
   HPGL,
   /// <summary>
   /// Standard PDF file output
   /// </summary>
   PDF,
}

/// <inheritdoc/>
public enum KnockoutText
{
   /// <inheritdoc/>
   Knockout
}

/// <inheritdoc/>
public enum LabelShape
{
   /// <inheritdoc/>
   Input,
   /// <inheritdoc/>
   Output,
   /// <inheritdoc/>
   Bidirectional,
   /// <inheritdoc/>
   Tri_State,
   /// <inheritdoc/>
   Passive,
}

/// <inheritdoc/>
public enum SymbolFillType
{
   /// <inheritdoc/>
   None,
   /// <inheritdoc/>
   Outline,
   /// <inheritdoc/>
   Background,
}

/// <inheritdoc/>
public enum NetClassShape
{
   /// <inheritdoc/>
   Dot,
   /// <inheritdoc/>
   Circle,
   /// <inheritdoc/>
   Diamond,
   /// <inheritdoc/>
   Rectangle,
}

public enum RuleSeverity
{
   ignore,
   warning,
   error
}