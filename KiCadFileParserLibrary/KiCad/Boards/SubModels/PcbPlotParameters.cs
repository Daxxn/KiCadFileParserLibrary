using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

using MVVMLibrary;

namespace KiCadFileParserLibrary.KiCad.Boards.SubModels;

/// <summary>
/// The plotting parameters for the <see cref="PcbModel">PCB.</see>
/// </summary>
[SExprNode("pcbplotparams")]
public class PcbPlotParameters : Model, IKiCadReadable
{
   #region Local Props
   private ulong _layerSelectionMask;
   private ulong _plotOnAllSelectionMask;
   private bool _disableApertMacros;
   private bool _useGerberExtensions;
   private bool _useGerberAttributes;
   private bool _useGerberAdvancedAttributes;
   private bool _createGerberJobFile;
   private double _dashedLineDashRatio;
   private double _dashedLineGapRatio;
   private int _svgPrecision;
   private bool _plotFrameRefernece;
   private bool _viasOnMask;
   private int _mode;
   private bool _useAuxOrigin;
   private int _hpglPenNumber;
   private int _hpglPenSpeed;
   private double _hpglPenDiameter;
   private bool _pdfFrontFpPropertyPopups;
   private bool _pdfBackFpPropertyPopups;
   private bool _dxfPolygonMode;
   private bool _dxfImperialUnits;
   private bool _dxfUsePcbnewFont;
   private bool _psNegative;
   private bool _psa4Output;
   private bool _plotReference;
   private bool _plotValue;
   private bool _plotFpText;
   private bool _plotInvisibleText;
   private bool _sketchPadsOnFab;
   private bool _subtractMaskFromSilk;
   private PcbOutputFormat _outputFormat;
   private bool _mirror;
   private int _drillShape;
   private int _scaleSelection;
   private string? _outputDirectory;
   #endregion

   #region Constructors
   /// <inheritdoc/>
   public PcbPlotParameters() { }
   #endregion

   #region Methods
   /// <inheritdoc/>
   public void ParseNode(Node node)
   {
      if (node.Children != null)
      {
         var props = GetType().GetProperties();

         KiCadParseUtils.ParseSubNodes(props, node, this);
      }
   }
   #endregion

   #region Full Props
   /// <summary>
   /// Bit mask defining what layers will be plotted when generating fab outputs.
   /// </summary>
   [SExprSubNode("layerselection")]
   public ulong LayerSelectionMask
   {
      get => _layerSelectionMask;
      set
      {
         _layerSelectionMask = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Bit mask defining what layers will be plotted in every fab output layer.
   /// </summary>
   [SExprSubNode("plot_on_all_layers_selection")]
   public ulong PlotOnAllSelectionMask
   {
      get => _plotOnAllSelectionMask;
      set
      {
         _plotOnAllSelectionMask = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// I Have no idea. Is it a typo?
   /// </summary>
   [SExprSubNode("disableapertmacros")]
   public bool DisableApertMacros
   {
      get => _disableApertMacros;
      set
      {
         _disableApertMacros = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Enable gerber extensions in the fab output.
   /// </summary>
   [SExprSubNode("usegerberextensions")]
   public bool UseGerberExtensions
   {
      get => _useGerberExtensions;
      set
      {
         _useGerberExtensions = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Enable gerber attributes in the fab output.
   /// </summary>
   [SExprSubNode("usegerberattributes")]
   public bool UseGerberAttributes
   {
      get => _useGerberAttributes;
      set
      {
         _useGerberAttributes = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Enable gerber advanced attributes in the fab output.
   /// </summary>
   [SExprSubNode("usegerberadvancedattributes")]
   public bool UseGerberAdvancedAttributes
   {
      get => _useGerberAdvancedAttributes;
      set
      {
         _useGerberAdvancedAttributes = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Generate a Gerber job file with the normal gerber fab outputs.
   /// </summary>
   [SExprSubNode("creategerberjobfile")]
   public bool CreateGerberJobFile
   {
      get => _createGerberJobFile;
      set
      {
         _createGerberJobFile = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// The ratio of dashes to dots.
   /// </summary>
   [SExprSubNode("dashed_line_dash_ratio")]
   public double DashedLineDashRatio
   {
      get => _dashedLineDashRatio;
      set
      {
         _dashedLineDashRatio = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// The ratio gaps to lines.
   /// </summary>
   [SExprSubNode("dashed_line_gap_ratio")]
   public double DashedLineGapRatio
   {
      get => _dashedLineGapRatio;
      set
      {
         _dashedLineGapRatio = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// The precision used for SVG file output.
   /// </summary>
   [SExprSubNode("svgprecision")]
   public int SvgPrecision
   {
      get => _svgPrecision;
      set
      {
         _svgPrecision = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// 
   /// </summary>
   [SExprSubNode("plotframeref")]
   public bool PlotFrameRefernece
   {
      get => _plotFrameRefernece;
      set
      {
         _plotFrameRefernece = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Plot vias on the mask layer.
   /// <para/>
   /// True = Non-tented vias.
   /// <para/>
   /// False = Tented vias.
   /// </summary>
   [SExprSubNode("viasonmask")]
   public bool ViasOnMask
   {
      get => _viasOnMask;
      set
      {
         _viasOnMask = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// ???
   /// </summary>
   [SExprSubNode("mode")]
   public int Mode
   {
      get => _mode;
      set
      {
         _mode = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Use the auxiliary origin instead of the page origin.
   /// </summary>
   [SExprSubNode("useauxorigin")]
   public bool UseAuxOrigin
   {
      get => _useAuxOrigin;
      set
      {
         _useAuxOrigin = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// ??? - Ive never used HPLG files.
   /// </summary>
   [SExprSubNode("hpglpennumber")]
   public int HpglPenNumber
   {
      get => _hpglPenNumber;
      set
      {
         _hpglPenNumber = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// ??? - Ive never used HPLG files.
   /// </summary>
   [SExprSubNode("hpglpenspeed")]
   public int HpglPenSpeed
   {
      get => _hpglPenSpeed;
      set
      {
         _hpglPenSpeed = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// ??? - Ive never used HPLG files.
   /// </summary>
   [SExprSubNode("hpglpendiameter")]
   public double HpglPenDiameter
   {
      get => _hpglPenDiameter;
      set
      {
         _hpglPenDiameter = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// ???
   /// </summary>
   [SExprSubNode("pdf_front_fp_property_popups")]
   public bool PdfFrontFpPropertyPopups
   {
      get => _pdfFrontFpPropertyPopups;
      set
      {
         _pdfFrontFpPropertyPopups = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// ???
   /// </summary>
   [SExprSubNode("pdf_back_fp_property_popups")]
   public bool PdfBackFpPropertyPopups
   {
      get => _pdfBackFpPropertyPopups;
      set
      {
         _pdfBackFpPropertyPopups = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Use polygon mode when plotting DXF files.
   /// </summary>
   [SExprSubNode("dxfpolygonmode")]
   public bool DxfPolygonMode
   {
      get => _dxfPolygonMode;
      set
      {
         _dxfPolygonMode = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Use US Imperial units in DXF files.
   /// </summary>
   [SExprSubNode("dxfimperialunits")]
   public bool DxfImperialUnits
   {
      get => _dxfImperialUnits;
      set
      {
         _dxfImperialUnits = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Use KiCad default font in DXF files.
   /// </summary>
   [SExprSubNode("dxfusepcbnewfont")]
   public bool DxfUsePcbnewFont
   {
      get => _dxfUsePcbnewFont;
      set
      {
         _dxfUsePcbnewFont = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// ???
   /// </summary>
   [SExprSubNode("psnegative")]
   public bool PsNegative
   {
      get => _psNegative;
      set
      {
         _psNegative = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// ???
   /// </summary>
   [SExprSubNode("psa4output")]
   public bool Psa4Output
   {
      get => _psa4Output;
      set
      {
         _psa4Output = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Plot component reference designators.
   /// </summary>
   [SExprSubNode("plotreference")]
   public bool PlotReference
   {
      get => _plotReference;
      set
      {
         _plotReference = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Plot component values.
   /// </summary>
   [SExprSubNode("plotvalue")]
   public bool PlotValue
   {
      get => _plotValue;
      set
      {
         _plotValue = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Plot footprint text.
   /// </summary>
   [SExprSubNode("plotfptext")]
   public bool PlotFpText
   {
      get => _plotFpText;
      set
      {
         _plotFpText = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Plot hidden text.
   /// </summary>
   [SExprSubNode("plotinvisibletext")]
   public bool PlotInvisibleText
   {
      get => _plotInvisibleText;
      set
      {
         _plotInvisibleText = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Add pads to fabrication layers.
   /// </summary>
   [SExprSubNode("sketchpadsonfab")]
   public bool SketchPadsOnFab
   {
      get => _sketchPadsOnFab;
      set
      {
         _sketchPadsOnFab = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Remove silkscreen elements if overlapping openings in solder mask.
   /// </summary>
   [SExprSubNode("subtractmaskfromsilk")]
   public bool SubtractMaskFromSilk
   {
      get => _subtractMaskFromSilk;
      set
      {
         _subtractMaskFromSilk = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// The format used when plotting the <see cref="PcbModel">PCB.</see>
   /// </summary>
   [SExprSubNode("outputformat")]
   [SExprFormatting(true, false)]
   public PcbOutputFormat OutputFormat
   {
      get => _outputFormat;
      set
      {
         _outputFormat = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Mirror the <see cref="PcbModel">PCB.</see>
   /// </summary>
   [SExprSubNode("mirror")]
   public bool Mirror
   {
      get => _mirror;
      set
      {
         _mirror = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// The type of drill marks used for drill files.
   /// </summary>
   [SExprSubNode("drillshape")]
   public int DrillShape
   {
      get => _drillShape;
      set
      {
         _drillShape = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// ??? - Even the KiCad documentation isn't clear on what this is.
   /// </summary>
   [SExprSubNode("scaleselection")]
   public int ScaleSelection
   {
      get => _scaleSelection;
      set
      {
         _scaleSelection = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// The path where the <see cref="PcbModel">PCB</see> plot output will be written to.
   /// <para/>
   /// Relative to the current project folder.
   /// </summary>
   [SExprSubNode("outputdirectory")]
   public string? OutputDirectory
   {
      get => _outputDirectory;
      set
      {
         _outputDirectory = value;
         OnPropertyChanged();
      }
   }
   #endregion
}
