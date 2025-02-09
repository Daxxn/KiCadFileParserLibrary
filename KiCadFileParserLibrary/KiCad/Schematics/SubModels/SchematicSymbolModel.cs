using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.General;
using KiCadFileParserLibrary.KiCad.Interfaces;
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
      private bool _inBom = true;
      private bool _onBoard = true;
      private bool _exludeFromSim = false;
      private string _id = "";
      private SymbolPropertyCollection _props = new();
      private PinLinkModel _pinLink = new();
      private ProjectInstanceModel _instance = new();
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
      [SExprSubNode("lib_id")]
      public string LibID
      {
         get => _libID;
         set
         {
            _libID = value;
            OnPropertyChanged();
         }
      }

      public LocationModel Location
      {
         get => _location;
         set
         {
            _location = value;
            OnPropertyChanged();
         }
      }

      [SExprSubNode("unit")]
      public int Unit
      {
         get => _unit;
         set
         {
            _unit = value;
            OnPropertyChanged();
         }
      }

      [SExprSubNode("in_bom")]
      public bool InBOM
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

      [SExprSubNode("exclude_from_sim")]
      public bool ExcludeFromSim
      {
         get => _exludeFromSim;
         set
         {
            _exludeFromSim = value;
            OnPropertyChanged();
         }
      }

      [SExprSubNode("uuid")]
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

      public PinLinkModel PinLink
      {
         get => _pinLink;
         set
         {
            _pinLink = value;
            OnPropertyChanged();
         }
      }

      public ProjectInstanceModel Instance
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
