using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.General;
using KiCadFileParserLibrary.KiCad.General.Collections;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.KiCad.Schematics.Collections;
using KiCadFileParserLibrary.KiCad.Schematics.SubModels;
using KiCadFileParserLibrary.KiCad.Symbols.Collections;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

using MVVMLibrary;

namespace KiCadFileParserLibrary.KiCad.Schematics
{
   [SExprNode("kicad_sch")]
   public class Schematic : Model, IKiCadReadable
   {
      #region Local Props
      private int _version;
      private string _generator;
      private string? _generatorVersion;
      private string? _id;
      private PaperModel? _paper;
      private TitleBlockModel? _title = new();
      private SchematicSymbolCollection? _libSymbols;
      private SymbolReferenceCollection? _symbolRefs;
      private JunctionCollection? _junctions;
      private WireCollection? _wires;
      private BusCollection? _busses;
      private BusEntryCollection? _busEntries;
      private NoConnectCollection? _ncs;
      private SyGraphicsCollection? _graphics;
      private ImageCollection? _images;
      private LocalLabelCollection? _localLabels;
      private GlobalLabelCollection? _globalLabels;
      private HierarchicalSheetCollection? _sheets;
      private SchematicSheetInstanceModel _rootInstance = new();
      #endregion

      #region Constructors
      public Schematic() { }
      #endregion

      #region Methods
      public static Schematic? Parse(string path)
      {
         var reader = new SExprFileReader();
         var rootNode = reader.Read(path)?.GetNode("kicad_sch");
         if (rootNode is null) return null;
         var sch = new Schematic();
         sch.ParseNode(rootNode);
         return sch;
      }

      public void ParseNode(Node node)
      {
         if (node.Children is null) return;
         var props = GetType().GetProperties();
         KiCadParseUtils.ParseNodes(props, node, this);
         KiCadParseUtils.ParseSubNodes(props, node, this);
         KiCadParseUtils.ParseListNodes(props, node, this);
      }

      public void Write(string path)
      {
         StringBuilder sb = new StringBuilder();
         WriteNode(sb, 0);
         File.WriteAllText(path, sb.ToString());
      }

      public void WriteNode(StringBuilder builder, int indent, string? auxName = null)
      {
         KiCadWriteUtils2.WriteNode(this, builder, indent);
      }
      #endregion

      #region Full Props
      [SExprSubNode("version")]
      public int Version
      {
         get => _version;
         set
         {
            _version = value;
            OnPropertyChanged();
         }
      }

      [SExprSubNode("generator")]
      public string? Generator
      {
         get => _generator;
         set
         {
            _generator = value;
            OnPropertyChanged();
         }
      }

      [SExprSubNode("generator_version")]
      public string? GeneratorVersion
      {
         get => _generatorVersion;
         set
         {
            _generatorVersion = value;
            OnPropertyChanged();
         }
      }

      [SExprSubNode("uuid")]
      public string? ID
      {
         get => _id;
         set
         {
            _id = value;
            OnPropertyChanged();
         }
      }

      public PaperModel? Paper
      {
         get => _paper;
         set
         {
            _paper = value;
            OnPropertyChanged();
         }
      }

      public TitleBlockModel? Title
      {
         get => _title;
         set
         {
            _title = value;
            OnPropertyChanged();
         }
      }

      public SchematicSymbolCollection? LibSymbols
      {
         get => _libSymbols;
         set
         {
            _libSymbols = value;
            OnPropertyChanged();
         }
      }

      public SymbolReferenceCollection SymbolRefs
      {
         get => _symbolRefs;
         set
         {
            _symbolRefs = value;
            OnPropertyChanged();
         }
      }

      public JunctionCollection? Junctions
      {
         get => _junctions;
         set
         {
            _junctions = value;
            OnPropertyChanged();
         }
      }

      public WireCollection Wires
      {
         get => _wires;
         set
         {
            _wires = value;
            OnPropertyChanged();
         }
      }

      public BusCollection? Busses
      {
         get => _busses;
         set
         {
            _busses = value;
            OnPropertyChanged();
         }
      }

      public BusEntryCollection? BusEntries
      {
         get => _busEntries;
         set
         {
            _busEntries = value;
            OnPropertyChanged();
         }
      }

      public NoConnectCollection? NoConnects
      {
         get => _ncs;
         set
         {
            _ncs = value;
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

      public ImageCollection? Images
      {
         get => _images;
         set
         {
            _images = value;
            OnPropertyChanged();
         }
      }

      public LocalLabelCollection? LocalLabels
      {
         get => _localLabels;
         set
         {
            _localLabels = value;
            OnPropertyChanged();
         }
      }

      public GlobalLabelCollection GlobalLabels
      {
         get => _globalLabels;
         set
         {
            _globalLabels = value;
            OnPropertyChanged();
         }
      }

      public HierarchicalSheetCollection? Sheets
      {
         get => _sheets;
         set
         {
            _sheets = value;
            OnPropertyChanged();
         }
      }

      public SchematicSheetInstanceModel RootInstance
      {
         get => _rootInstance;
         set
         {
            _rootInstance = value;
            OnPropertyChanged();
         }
      }
      #endregion
   }
}
