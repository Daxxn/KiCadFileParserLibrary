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

namespace KiCadFileParserLibrary.KiCad.Footprints.SubModels;

/// <summary>
/// <see cref="Footprint"/> attributes.
/// </summary>
[SExprNode("attr")]
public class FootprintAttributeModel : Model, IKiCadReadable
{
   #region Local Props
   private FootprintType? _type;
   private bool _boardOnly;
   private bool _excludeFromposFiles;
   private bool _excludeFromBom;
   private bool _allowMissingCourtyard;
   private bool _allowSoldermaskBridges;
   private bool _dontPopulate;
   #endregion

   #region Constructors
   /// <inheritdoc/>
   public FootprintAttributeModel() { }
   #endregion

   #region Methods
   /// <inheritdoc/>
   public void ParseNode(Node node)
   {
      if (node.Properties != null)
      {
         var props = GetType().GetProperties();
         KiCadParseUtils.ParseProperties(props, node, this);
         KiCadParseUtils.ParseTokens(props, node, this);
      }
   }

   /// <inheritdoc/>
   public override string ToString()
   {
      return $"FP Attributes - Type: {Type} - Board-Only: {BoardOnly} - Exclude-From-PosFile: {ExcludeFromposFiles} - Exclude-From-BOM: {ExcludeFromBom} - Allow-Miss-Crtyd: {AllowMissingCourtyard} - Dont-Pop: {DontPopulate} - Allow-Mask-Bridge: {AllowSoldermaskBridges}";
   }
   #endregion

   #region Full Props
   /// <summary>
   /// <see cref="Footprint"/> type.
   /// </summary>
   [SExprProperty(1)]
   public FootprintType? Type
   {
      get => _type;
      set
      {
         _type = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Is not connected to a schematic <see cref="Symbols.Symbol">Symbol.</see>
   /// </summary>
   [SExprToken("board_only")]
   public bool BoardOnly
   {
      get => _boardOnly;
      set
      {
         _boardOnly = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Exclude the footprint from component position output files.
   /// </summary>
   [SExprToken("exclude_from_pos_files")]
   public bool ExcludeFromposFiles
   {
      get => _excludeFromposFiles;
      set
      {
         _excludeFromposFiles = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Exclude the footprint from the bill of materials.
   /// </summary>
   [SExprToken("exclude_from_bom")]
   public bool ExcludeFromBom
   {
      get => _excludeFromBom;
      set
      {
         _excludeFromBom = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Allows missing courtyards.
   /// </summary>
   [SExprToken("allow_missing_courtyard")]
   public bool AllowMissingCourtyard
   {
      get => _allowMissingCourtyard;
      set
      {
         _allowMissingCourtyard = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Allow soldermask bridges in the footprint.
   /// </summary>
   [SExprToken("allow_soldermask_bridges")]
   public bool AllowSoldermaskBridges
   {
      get => _allowSoldermaskBridges;
      set
      {
         _allowSoldermaskBridges = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Do not populate flag.
   /// </summary>
   [SExprToken("dnp")]
   public bool DontPopulate
   {
      get => _dontPopulate;
      set
      {
         _dontPopulate = value;
         OnPropertyChanged();
      }
   }
   #endregion
}
