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

namespace KiCadFileParserLibrary.KiCad.Schematics.SubModels
{
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
      public SchematicSymbolModel() { }
      #endregion

      #region Methods
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

      public SymbolPropertyCollection Properties
      {
         get => _props;
         set
         {
            _props = value;
            OnPropertyChanged();
         }
      }

      public PinLinkCollection PinLinks
      {
         get => _pinLinks;
         set
         {
            _pinLinks = value;
            OnPropertyChanged();
         }
      }

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
}
