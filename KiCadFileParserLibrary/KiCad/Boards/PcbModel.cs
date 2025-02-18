using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.Footprints.Collections;
using KiCadFileParserLibrary.KiCad.General;
using KiCadFileParserLibrary.KiCad.General.Collections;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.KiCad.Boards.Collections;
using KiCadFileParserLibrary.KiCad.Boards.SubModels;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;
using MVVMLibrary;

namespace KiCadFileParserLibrary.KiCad.Boards;

/// <summary>
/// The model describing a KiCad PCB.
/// </summary>
[SExprNode("kicad_pcb")]
public class PcbModel : Model, IKiCadReadable, IKiCadWriteable, IKiCadProjectFile
{
   #region Local Props
   private int _version = -1;
   private string _generator = "";
   private string _generatorVersion = "";
   private GeneralModel _general = new();
   private PaperModel _paper = new();
   private TitleBlockModel? _titleBlock;
   private LayerDefCollection _layers = new();
   private Setup _setup = new();
   private NetCollection? _nets;
   private FootprintCollection? _footprints;
   private GrGraphicsCollection? _graphics;
   private ImageCollection? _images;
   private TraceCollection? _traces;
   private ZoneCollection? _zones;
   private GroupCollection? _groups;
   private TextVariableCollection? _textVariables;
   private TunedLengthCollection? _tunedLengths;
   #endregion

   #region Constructors
   /// <inheritdoc/>
   public PcbModel() { }
   #endregion

   #region Methods
   /// <inheritdoc/>
   public override string ToString() => $"PCB - Ver: {Version} - Gen: {Generator} - GenVer: {GeneratorVersion}";

   /// <summary>
   /// Parse a KiCad PCB project file. (<c>*.kicad_pcb</c>)
   /// </summary>
   /// <param name="filePath">The path to the PCB file. Must be a <c>.kicad_pcb</c></param>
   /// <returns>A model containing the PCB data.</returns>
   public static PcbModel? Parse(string filePath)
   {
      var reader = new SExprFileReader();
      var rootNode = reader.Read(filePath);
      if (rootNode is null) return null;
      PcbModel model = new();
      var pcbNode = rootNode.GetNode(model.GetType().GetCustomAttribute<SExprNodeAttribute>()!.XPath);
      if (pcbNode is null) return null;
      model.ParseNode(pcbNode);
      return model;
   }

   /// <inheritdoc/>
   public void ParseNode(Node node)
   {
      var props = GetType().GetProperties();
      if (node.Children != null)
      {
         KiCadParseUtils.ParseSubNodes(props, node, this);
         KiCadParseUtils.ParseNodes(props, node, this);
         KiCadParseUtils.ParseListNodes(props, node, this);
      }
   }

   /// <inheritdoc/>
   public void Write(string path)
   {
      StringBuilder builder = new();
      WriteNode(builder, 0);
      File.WriteAllText(path, builder.ToString());
   }

   /// <inheritdoc/>
   public void WriteNode(StringBuilder builder, int indent, string? auxName = null)
   {
      KiCadWriteUtils.WriteNode(this, builder, indent);
   }

   /// <summary>
   /// Change the name of the project.
   /// </summary>
   /// <param name="oldName">Original project name.</param>
   /// <param name="newName">New project name.</param>
   public void ChangeProjectName(string oldName, string newName)
   {
      if (Footprints?.Footprints.Count == 0) return;

      foreach (var fp in Footprints!.Footprints)
      {
         if (fp.SheetFile != null)
         {
            fp.SheetFile = fp.SheetFile.Replace(oldName, newName);
         }
      }
   }
   #endregion

   #region Full Props
   /// <summary>
   /// The version of the PCB file.
   /// <para/>
   /// Do NOT modify this unless you know what will happen.
   /// </summary>
   [SExprSubNode("version")]
   [SExprIndex(0)]
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
   [SExprSubNode("generator")]
   [SExprIndex(1)]
   public string Generator
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
   [SExprSubNode("generator_version")]
   [SExprIndex(2)]
   public string GeneratorVersion
   {
      get => _generatorVersion;
      set
      {
         _generatorVersion = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// General settings for the PCB project.
   /// </summary>
   [SExprIndex(3)]
   public GeneralModel General
   {
      get => _general;
      set
      {
         _general = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// The size and orientation of the paper used when printing the PCB.
   /// </summary>
   [SExprIndex(4)]
   public PaperModel Paper
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
   [SExprIndex(5)]
   public TitleBlockModel? TitleBlock
   {
      get => _titleBlock;
      set
      {
         _titleBlock = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// The layers of the PCB.
   /// </summary>
   [SExprIndex(6)]
   public LayerDefCollection Layers
   {
      get => _layers;
      set
      {
         _layers = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// PCB setup and plotting options
   /// </summary>
   [SExprIndex(7)]
   public Setup Setup
   {
      get => _setup;
      set
      {
         _setup = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// The list of nets from the schematic
   /// </summary>
   public NetCollection? Nets
   {
      get => _nets;
      set
      {
         _nets = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// The list of footprints used in the design.
   /// </summary>
   public FootprintCollection? Footprints
   {
      get => _footprints;
      set
      {
         _footprints = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Extra graphics used in the PCB.
   /// </summary>
   public GrGraphicsCollection? Graphics
   {
      get => _graphics;
      set
      {
         _graphics = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// List of images contained in the PCB project.
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
   /// List of the traces on the PCB.
   /// </summary>
   public TraceCollection? Traces
   {
      get => _traces;
      set
      {
         _traces = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// List of the zones on the PCB.
   /// </summary>
   public ZoneCollection? Zones
   {
      get => _zones;
      set
      {
         _zones = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// List of grouped objects in the project.
   /// </summary>
   public GroupCollection? Groups
   {
      get => _groups;
      set
      {
         _groups = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// List of user defined variables used in the project.
   /// </summary>
   public TextVariableCollection? TextVariables
   {
      get => _textVariables;
      set
      {
         _textVariables = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// List of the tuned length traces in the design.
   /// </summary>
   public TunedLengthCollection? TunedLengths
   {
      get => _tunedLengths;
      set
      {
         _tunedLengths = value;
         OnPropertyChanged();
      }
   }
   #endregion
}
