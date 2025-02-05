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

namespace KiCadFileParserLibrary.KiCad.Boards
{
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
      private int _outputFormat;
      private bool _mirror;
      private int _drillShape;
      private int _scaleSelection;
      private string? _outputDirectory;
      #endregion

      #region Constructors
      public PcbPlotParameters() { }
      #endregion

      #region Methods
      public void ParseNode(Node node)
      {
         if (node.Children != null)
         {
            var props = GetType().GetProperties();

            KiCadParseUtils.ParseSubNodes(props, node, this);
         }
      }

      public void WriteNode(StringBuilder builder, int indent, string? auxName = null)
      {
         builder.Append('\t', indent);
         builder.AppendLine("(pcbplotparams");

         var props = GetType().GetProperties();
         foreach (var prop in props)
         {
            var name = prop.GetCustomAttribute<SExprSubNodeAttribute>()?.XPath;
            if (name != null)
            {
               builder.Append('\t', indent + 1);
               builder.AppendLine(KiCadWriteUtils.WriteSubNodeData(name, prop.GetValue(this)!));
            }
         }
         builder.Append('\t', indent);
         builder.AppendLine(")");
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
      private double _dashedLineGapRatio;

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

      [SExprSubNode("outputformat")]
      public int OutputFormat
      {
         get => _outputFormat;
         set
         {
            _outputFormat = value;
            OnPropertyChanged();
         }
      }

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
}
