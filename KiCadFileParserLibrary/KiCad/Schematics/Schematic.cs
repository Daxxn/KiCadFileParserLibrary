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

namespace KiCadFileParserLibrary.KiCad.Schematics;

/// <summary>
/// The model describing a KiCad schematic.
/// </summary>
[SExprNode("kicad_sch")]
public class Schematic : Model, IKiCadReadable, IKiCadWriteable, IKiCadProjectFile
{
   #region Local Props
   private string _filePath = "";
   private int _version;
   private string _generator = "";
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
   /// <inheritdoc/>
   public Schematic() { }
   #endregion

   #region Methods
   /// <summary>
   /// Parse the KiCad schematic file.
   /// </summary>
   /// <param name="path">The path to the schematic</param>
   /// <returns>The model of the schematic.</returns>
   public static Schematic? Parse(string path)
   {
      var reader = new SExprFileReader();
      var rootNode = reader.Read(path)?.GetNode("kicad_sch");
      if (rootNode is null) return null;
      var sch = new Schematic();
      sch.ParseNode(rootNode);
      sch.FilePath = path;
      return sch;
   }

   /// <inheritdoc/>
   public void ParseNode(Node node)
   {
      if (node.Children is null) return;
      var props = GetType().GetProperties();
      KiCadParseUtils.ParseNodes(props, node, this);
      KiCadParseUtils.ParseSubNodes(props, node, this);
      KiCadParseUtils.ParseListNodes(props, node, this);
   }

   /// <inheritdoc/>
   public void Write(string path)
   {
      StringBuilder sb = new StringBuilder();
      WriteNode(sb, 0);
      File.WriteAllText(path, sb.ToString());
   }

   /// <inheritdoc/>
   public void WriteNode(StringBuilder builder, int indent, string? auxName = null)
   {
      KiCadWriteUtils2.WriteNode(this, builder, indent);
   }

   /// <summary>
   /// Updates the sheet file property in the Hierarchical Sheets.
   /// </summary>
   /// <param name="newProjName">The new name of the project.</param>
   /// <exception cref="Exception">Throw if any sheet file names dont conform to the project name schema.</exception>
   public void ChangeHierSheetFile(string newProjName)
   {
      if (Sheets is null) return;

      foreach (var sheet in Sheets.Sheets)
      {
         var fileProp = sheet.Properties.GetProperty(KiCadConstants.DefaultPropertyKeys.SheetFile);
         if (fileProp?.Value != null)
         {
            var nameSplit = Path.GetFileNameWithoutExtension(fileProp.Value).Split(KiCadConstants.ProjectNameDelimiter);
            if (nameSplit.Length > 1)
            {
               fileProp.Value = $"{newProjName}_{string.Join(KiCadConstants.ProjectNameDelimiter, nameSplit[1..])}.{KiCadConstants.Extensions.Schematic}";
            }
            else if (nameSplit.Length == 1)
            {
               var nameProp = sheet.Properties.GetProperty(KiCadConstants.DefaultPropertyKeys.SheetName);
               if (nameSplit[0] == nameProp?.Value)
               {
                  fileProp.Value = $"{newProjName}_{nameProp.Value}.{KiCadConstants.Extensions.Schematic}";
               }
            }
            else
               throw new Exception("The sheet file name doesnt conform to the sheet suffix model.");
         }
      }
   }

   /// <summary>
   /// Change the name of the project.
   /// <para/>
   /// Updates the properties in the Hierarchical sheets and the symbol instance fields.
   /// <para/>
   /// Note: <see cref="ChangeHierSheetFile"/> is called here. Theres no need to call it separatly.
   /// </summary>
   /// <param name="newProjName">The new name of the project.</param>
   public void ChangeProjectName(string newProjName)
   {
      ChangeHierSheetFile(newProjName);

      foreach (var symbol in SymbolRefs.Symbols)
      {
         foreach (var inst in symbol.Instance.Instances)
         {
            if (!string.IsNullOrEmpty(inst.Name))
            {
               inst.Name = newProjName;
            }
         }
      }
   }
   #endregion

   #region Full Props
   /// <summary>
   /// The file path for this schematic.
   /// </summary>
   public string FilePath
   {
      get => _filePath;
      set
      {
         _filePath = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// The version of the KiCad schematic file.
   /// <para/>
   /// Do NOT modify this unless you know what will happen.
   /// </summary>
   [SExprSubNode("version", 0)]
   public int Version
   {
      get => _version;
      set
      {
         _version = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// The KiCad generator that created the file.
   /// <para/>
   /// Do NOT modify this unless you know what will happen.
   /// </summary>
   [SExprSubNode("generator", 1)]
   public string? Generator
   {
      get => _generator;
      set
      {
         _generator = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// The version of the KiCad generator that created the file.
   /// <para/>
   /// Do NOT modify this unless you know what will happen.
   /// </summary>
   [SExprSubNode("generator_version", 2)]
   public string? GeneratorVersion
   {
      get => _generatorVersion;
      set
      {
         _generatorVersion = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// The ID of the schematic
   /// </summary>
   [SExprSubNode("uuid", 3)]
   public string? ID
   {
      get => _id;
      set
      {
         _id = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// The size and orientation of the paper used when printing the schematic.
   /// </summary>
   [SExprNode("paper", 4)]
   public PaperModel? Paper
   {
      get => _paper;
      set
      {
         _paper = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// The title information displayed in the corner of the page.
   /// </summary>
   [SExprNode("title_block", 5)]
   public TitleBlockModel? Title
   {
      get => _title;
      set
      {
         _title = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// List of the symbols used in the schematic
   /// </summary>
   public SchematicSymbolCollection? LibSymbols
   {
      get => _libSymbols;
      set
      {
         _libSymbols = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// List of junctions used in the schematic
   /// </summary>
   public JunctionCollection? Junctions
   {
      get => _junctions;
      set
      {
         _junctions = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// List of no-connect nodes used in the schematic
   /// </summary>
   public NoConnectCollection? NoConnects
   {
      get => _ncs;
      set
      {
         _ncs = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// List of wires used in the schematic
   /// </summary>
   public WireCollection Wires
   {
      get => _wires;
      set
      {
         _wires = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// List of Busses used in the schematic
   /// </summary>
   public BusCollection? Busses
   {
      get => _busses;
      set
      {
         _busses = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// List of bus entries used in the schematic
   /// </summary>
   public BusEntryCollection? BusEntries
   {
      get => _busEntries;
      set
      {
         _busEntries = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// List of images used in the schematic
   /// </summary>
   public ImageCollection? Images
   {
      get => _images;
      set
      {
         _images = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// List of graphics used in the schematic
   /// </summary>
   public SyGraphicsCollection? Graphics
   {
      get => _graphics;
      set
      {
         _graphics = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// List of labels used in the schematic
   /// </summary>
   public LocalLabelCollection? LocalLabels
   {
      get => _localLabels;
      set
      {
         _localLabels = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// List of global labels used in the schematic
   /// </summary>
   public GlobalLabelCollection GlobalLabels
   {
      get => _globalLabels;
      set
      {
         _globalLabels = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// List of symbol references used in the schematic
   /// </summary>
   public SymbolReferenceCollection SymbolRefs
   {
      get => _symbolRefs;
      set
      {
         _symbolRefs = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// List of hierarchical sheets used in the schematic
   /// </summary>
   public HierarchicalSheetCollection? Sheets
   {
      get => _sheets;
      set
      {
         _sheets = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// The "instance-root"
   /// <para/>
   /// Its not clear what this is ued for. The only useful data is the root page number.
   /// </summary>
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
