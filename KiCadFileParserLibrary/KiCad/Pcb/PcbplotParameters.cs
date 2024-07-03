using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

namespace KiCadFileParserLibrary.KiCad.Pcb
{
    [SExprNode("pcbplotparams")]
   public class PcbPlotParameters : IKiCadReadable
   {
      #region Local Props
      /// <summary>
      /// Bit mask defining what layers will be plotted when generating fab outputs.
      /// </summary>
      [SExprSubNode("layerselection")]
      public ulong LayerSelectionMask { get; set; }

      /// <summary>
      /// Bit mask defining what layers will be plotted in every fab output layer.
      /// </summary>
      [SExprSubNode("plot_on_all_layers_selection")]
      public ulong PlotOnAllSelectionMask { get; set; }

      /// <summary>
      /// I Have no idea. Is it a typo?
      /// </summary>
      [SExprSubNode("disableapertmacros")]
      public bool DisableApertMacros { get; set; }

      /// <summary>
      /// Enable gerber extensions in the fab output.
      /// </summary>
      [SExprSubNode("usegerberextensions")]
      public bool UseGerberExtensions { get; set; }

      /// <summary>
      /// Enable gerber attributes in the fab output.
      /// </summary>
      [SExprSubNode("usegerberattributes")]
      public bool UseGerberAttributes { get; set; }

      /// <summary>
      /// Enable gerber advanced attributes in the fab output.
      /// </summary>
      [SExprSubNode("usegerberadvancedattributes")]
      public bool UseGerberAdvancedAttributes { get; set; }

      /// <summary>
      /// Generate a Gerber job file with the normal gerber fab outputs.
      /// </summary>
      [SExprSubNode("creategerberjobfile")]
      public bool CreateGerberJobFile { get; set; }

      [SExprSubNode("dashed_line_dash_ratio")]
      public double DashedLineDashRatio { get; set; }

      [SExprSubNode("dashed_line_gap_ratio")]
      public double DashedLineGapRatio { get; set; }

      [SExprSubNode("svgprecision")]
      public double SvgPrecision { get; set; }

      [SExprSubNode("plotframeref")]
      public bool PlotFrameRefernece { get; set; }

      [SExprSubNode("viasonmask")]
      public bool ViasOnMask { get; set; }

      [SExprSubNode("mode")]
      public int Mode { get; set; }

      [SExprSubNode("useauxorigin")]
      public bool UseAuxOrigin { get; set; }

      [SExprSubNode("hpglpennumber")]
      public int HpglPenNumber { get; set; }

      [SExprSubNode("hpglpenspeed")]
      public double HpglPenSpeed { get; set; }

      [SExprSubNode("hpglpendiameter")]
      public double HpglPenDiameter { get; set; }

      [SExprSubNode("pdf_front_fp_property_popups")]
      public bool PdfFrontFpPropertyPopups { get; set; }

      [SExprSubNode("pdf_back_fp_property_popups")]
      public bool PdfBackFpPropertyPopups { get; set; }

      [SExprSubNode("dxfpolygonmode")]
      public bool DxfPolygonMode { get; set; }

      [SExprSubNode("dxfimperialunits")]
      public bool DxfImperialUnits { get; set; }

      [SExprSubNode("dxfusepcbnewfont")]
      public bool DxfUsePcbnewFont { get; set; }

      [SExprSubNode("psnegative")]
      public bool PsNegative { get; set; }

      [SExprSubNode("psa4output")]
      public bool Psa4Output { get; set; }

      [SExprSubNode("plotreference")]
      public bool PlotReference { get; set; }

      [SExprSubNode("plotvalue")]
      public bool PlotValue { get; set; }

      [SExprSubNode("plotfptext")]
      public bool PlotFpText { get; set; }

      [SExprSubNode("plotinvisibletext")]
      public bool PlotInvisibleText { get; set; }

      [SExprSubNode("sketchpadsonfab")]
      public bool SketchPadsOnFab { get; set; }

      [SExprSubNode("subtractmaskfromsilk")]
      public bool SubtractMaskFromSilk { get; set; }

      [SExprSubNode("outputformat")]
      public int OutputFormat { get; set; }

      [SExprSubNode("mirror")]
      public bool Mirror { get; set; }

      [SExprSubNode("drillshape")]
      public int DrillShape { get; set; }

      [SExprSubNode("scaleselection")]
      public int ScaleSelection { get; set; }

      [SExprSubNode("outputdirectory")]
      public string? OutputDirectory { get; set; }
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
      #endregion

      #region Full Props

      #endregion
   }
}
