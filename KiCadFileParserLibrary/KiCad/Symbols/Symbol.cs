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

namespace KiCadFileParserLibrary.KiCad.Symbols
{
   [SExprNode("symbol")]
   public class Symbol : Model, IKiCadReadable
   {
      #region Local Props
      private string? _symbolName;
      private string? _extendsSymbol;
      private bool _excludeFromSim;
      private SymbolVisibility _pinVis;
      private PinNamesModel? _pinNames;
      private bool _inBom;
      private bool _onBoard;
      private PropertyCollection? _props;
      private SubSymbolCollection? _subSymbols;
      #endregion

      #region Constructors
      public Symbol() { }
      #endregion

      #region Methods
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

      public void WriteNode(StringBuilder builder, int indent, string? auxName = null)
      {
         throw new NotImplementedException();
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
      public SymbolVisibility PinVisibility
      {
         get => _pinVis;
         set
         {
            _pinVis = value;
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

      public PropertyCollection? Properties
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
      #endregion
   }
}
