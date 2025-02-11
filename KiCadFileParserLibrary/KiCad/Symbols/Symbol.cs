using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.KiCad.Symbols.Collections;
using KiCadFileParserLibrary.KiCad.Symbols.SubModels;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

using MVVMLibrary;

namespace KiCadFileParserLibrary.KiCad.Symbols;

/// <summary>
/// A model of a KiCad symbol. Contains info about a component that is used to create a schematic.
/// </summary>
[SExprNode("symbol")]
public class Symbol : Model, IKiCadReadable
{
   #region Local Props
   private string? _symbolName;
   private string? _extendsSymbol;
   private bool _excludeFromSim;
   private PinNumberVisibility? _pinNumberVis;
   private PinNamesModel? _pinNames;
   private bool _inBom;
   private bool _onBoard;
   private SymbolPropertyCollection _props = new();
   private SubSymbolCollection? _subSymbols;
   private SyGraphicsCollection? _graphics;
   private PinCollection? _pins;
   #endregion

   #region Constructors
   /// <inheritdoc/>
   public Symbol() { }
   #endregion

   #region Methods
   /// <inheritdoc/>
   public void ParseNode(Node node)
   {
      if (node.Children != null && node.Properties != null)
      {
         var props = GetType().GetProperties();
         KiCadParseUtils.ParseNodes(props, node, this);
         KiCadParseUtils.ParseSubNodes(props, node, this);
         KiCadParseUtils.ParseProperties(props, node, this);
         KiCadParseUtils.ParseListNodes(props, node, this);
      }
   }
   #endregion

   #region Full Props
   [SExprProperty(1)]
   public string? SymbolName
   {
      get => _symbolName;
      set
      {
         _symbolName = value;
         OnPropertyChanged();
      }
   }

   [SExprSubNode("extends")]
   public string? ExtendsSymbol
   {
      get => _extendsSymbol;
      set
      {
         _extendsSymbol = value;
         OnPropertyChanged();
      }
   }

   [SExprSubNode("exclude_from_sim")]
   public bool ExcludeFromSim
   {
      get => _excludeFromSim;
      set
      {
         _excludeFromSim = value;
         OnPropertyChanged();
      }
   }

   [SExprSubNode("pin_numbers")]
   public PinNumberVisibility? PinNumberVisibility
   {
      get => _pinNumberVis;
      set
      {
         _pinNumberVis = value;
         OnPropertyChanged();
      }
   }

   [SExprNode("pin_names")]
   public PinNamesModel? PinNames
   {
      get => _pinNames;
      set
      {
         _pinNames = value;
         OnPropertyChanged();
      }
   }

   [SExprSubNode("in_bom")]
   public bool InBom
   {
      get => _inBom;
      set
      {
         _inBom = value;
         OnPropertyChanged();
      }
   }

   [SExprSubNode("on_board")]
   public bool OnBoard
   {
      get => _onBoard;
      set
      {
         _onBoard = value;
         OnPropertyChanged();
      }
   }

   public SymbolPropertyCollection Properties
   {
      get => _props;
      set
      {
         _props = value;
         OnPropertyChanged();
      }
   }

   public SubSymbolCollection? SubSymbols
   {
      get => _subSymbols;
      set
      {
         _subSymbols = value;
         OnPropertyChanged();
      }
   }

   public SyGraphicsCollection? Graphics
   {
      get => _graphics;
      set
      {
         _graphics = value;
         OnPropertyChanged();
      }
   }

   public PinCollection? Pins
   {
      get => _pins;
      set
      {
         _pins = value;
         OnPropertyChanged();
      }
   }
   #endregion
}
