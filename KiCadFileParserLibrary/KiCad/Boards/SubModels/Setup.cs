using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.General;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

using MVVMLibrary;

namespace KiCadFileParserLibrary.KiCad.Boards.SubModels;

/// <summary>
/// <see cref="PcbModel">PCB project</see> setup parameters. Includes stackup, clearances, axis origins, ect..
/// </summary>
[SExprNode("setup")]
public class Setup : Model, IKiCadReadable
{
   #region Local Props
   private Stackup? _stackup;
   private double _padToMaskClearance;
   private double? _solderMaskMinWidth;
   private double? _padToPasteClearance;
   private double? _padToPasteRatio;
   private XyModel? _auxAxisOrigin;
   private XyModel? _gridOrigin;
   private bool _allowMaskBridgeInFp;
   private PcbPlotParameters _plotParams = new();
   #endregion

   #region Constructors
   /// <inheritdoc/>
   public Setup() { }
   #endregion

   #region Methods
   /// <inheritdoc/>
   public void ParseNode(Node node)
   {
      if (node.Children != null)
      {
         var props = GetType().GetProperties();

         KiCadParseUtils.ParseNodes(props, node, this);
         KiCadParseUtils.ParseSubNodes(props, node, this);
      }
   }

   /// <inheritdoc/>
   public override string ToString()
   {
      return $"Setup - Pad-Mask: {PadToMaskClearance} - Mask-Min-Width: {SolderMaskMinWidth} - Pad-Paste: {PadToPasteClearance} - Pad-Paste-Ratio: {PadToPasteRatio} - Allow-Mask-Bridge: {AllowMaskBridgeInFp}";
   }
   #endregion

   #region Full Props
   /// <summary>
   /// Project <see cref="SubModels.Stackup">Stackup</see> settings.
   /// </summary>
   public Stackup? Stackup
   {
      get => _stackup;
      set
      {
         _stackup = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Pad to mask clearance.
   /// </summary>
   [SExprSubNode("pad_to_mask_clearance")]
   public double PadToMaskClearance
   {
      get => _padToMaskClearance;
      set
      {
         _padToMaskClearance = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Solder mask minimum width.
   /// </summary>
   [SExprSubNode("solder_mask_min_width")]
   public double? SolderMaskMinWidth
   {
      get => _solderMaskMinWidth;
      set
      {
         _solderMaskMinWidth = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Pad to paste clearance.
   /// </summary>
   [SExprSubNode("pad_to_paste_clearance")]
   public double? PadToPasteClearance
   {
      get => _padToPasteClearance;
      set
      {
         _padToPasteClearance = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Pad to paste clearance ratio.
   /// </summary>
   [SExprSubNode("pad_to_paste_clearance_ratio")]
   public double? PadToPasteRatio
   {
      get => _padToPasteRatio;
      set
      {
         _padToPasteRatio = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Auxiliary axis origin.
   /// </summary>
   [SExprNode("aux_axis_origin")]
   public XyModel? AuxAxisOrigin
   {
      get => _auxAxisOrigin;
      set
      {
         _auxAxisOrigin = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Grid origin.
   /// </summary>
   [SExprNode("grid_origin")]
   public XyModel? GridOrigin
   {
      get => _gridOrigin;
      set
      {
         _gridOrigin = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Allow solder mask bridges in footprints.
   /// </summary>
   [SExprSubNode("allow_soldermask_bridges_in_footprints")]
   public bool AllowMaskBridgeInFp
   {
      get => _allowMaskBridgeInFp;
      set
      {
         _allowMaskBridgeInFp = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Parameters for plotting the PCB.
   /// </summary>
   public PcbPlotParameters PlotParams
   {
      get => _plotParams;
      set
      {
         _plotParams = value;
         OnPropertyChanged();
      }
   }
   #endregion
}
