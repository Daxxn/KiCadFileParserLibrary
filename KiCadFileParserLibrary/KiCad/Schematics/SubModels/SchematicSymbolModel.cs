using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.General;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.KiCad.Schematics.Collections;
using KiCadFileParserLibrary.KiCad.Symbols.Collections;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

using MVVMLibrary;

namespace KiCadFileParserLibrary.KiCad.Schematics.SubModels;

/// <summary>
/// Schematic symbol model
/// </summary>
[SExprNode("symbol")]
public class SchematicSymbolModel : Model, IKiCadReadable
{
   #region Local Props
   private string _libID = "";
   private LocationModel _location = new();
   private int _unit = 1;
   private MirrorMode? _mirror = null;
   private bool _inBom = true;
   private bool _onBoard = true;
   private bool _exludeFromSim = false;
   private bool _dnp = false;
   private string _id = "";
   private SymbolPropertyCollection _props = new();
   private PinLinkCollection _pinLinks = new();
   private SymbolProjectReferenceCollection _instance = new();
   #endregion

   #region Constructors
   /// <inheritdoc/>
   public SchematicSymbolModel() { }
   #endregion

   #region Methods
   /// <inheritdoc/>
   public void ParseNode(Node node)
   {
      if (node.Properties != null && node.Children != null)
      {
         var props = GetType().GetProperties();

         KiCadParseUtils.ParseNodes(props, node, this);
         KiCadParseUtils.ParseSubNodes(props, node, this);
         KiCadParseUtils.ParseListNodes(props, node, this);
      }
   }
   #endregion

   #region Full Props
   /// <summary>
   /// Library ID
   /// </summary>
   [SExprSubNode("lib_id", 0)]
   public string LibID
   {
      get => _libID;
      set
      {
         _libID = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Location coordinates
   /// </summary>
   [SExprNode("at", 1)]
   public LocationModel Location
   {
      get => _location;
      set
      {
         _location = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Mirror mode
   /// </summary>
   [SExprSubNode("mirror", 2)]
   public MirrorMode? Mirror
   {
      get => _mirror;
      set
      {
         _mirror = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Unit
   /// </summary>
   [SExprSubNode("unit", 3)]
   public int Unit
   {
      get => _unit;
      set
      {
         _unit = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Exclude from simulation
   /// </summary>
   [SExprSubNode("exclude_from_sim", 4)]
   public bool ExcludeFromSim
   {
      get => _exludeFromSim;
      set
      {
         _exludeFromSim = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Include in BOM
   /// </summary>
   [SExprSubNode("in_bom", 5)]
   public bool InBOM
   {
      get => _inBom;
      set
      {
         _inBom = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Include on board
   /// </summary>
   [SExprSubNode("on_board", 6)]
   public bool OnBoard
   {
      get => _onBoard;
      set
      {
         _onBoard = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Do not populate flag
   /// </summary>
   [SExprSubNode("dnp", 7)]
   public bool DNP
   {
      get => _dnp;
      set
      {
         _dnp = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Unique ID
   /// </summary>
   [SExprSubNode("uuid", 8)]
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
   /// List of symbol properties
   /// </summary>
   public SymbolPropertyCollection Properties
   {
      get => _props;
      set
      {
         _props = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// List of pin links
   /// </summary>
   public PinLinkCollection PinLinks
   {
      get => _pinLinks;
      set
      {
         _pinLinks = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Project instance
   /// </summary>
   public SymbolProjectReferenceCollection Instance
   {
      get => _instance;
      set
      {
         _instance = value;
         OnPropertyChanged();
      }
   }
   #endregion
}
