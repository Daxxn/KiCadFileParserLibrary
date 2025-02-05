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

namespace KiCadFileParserLibrary.KiCad.Boards
{
   [SExprNode("kicad_pcb")]
   public class PcbModel : Model, IKiCadReadable
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
      public PcbModel() { }
      #endregion

      #region Methods
      public override string ToString()
      {
         return $"PCB - Ver: {Version} - Gen: {Generator} - GenVer: {GeneratorVersion}";
      }
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

      public void Write(string path)
      {
         StringBuilder builder = new();
         WriteNode(builder, 0);
         File.WriteAllText(path, builder.ToString());
      }

      public void WriteNode(StringBuilder builder, int indent, string? auxName = null)
      {
         builder.Append('\t', indent); // Will probably error out...
         builder.Append("(kicad_pcb");
         builder.AppendLine();

         builder.Append('\t', indent + 1);
         builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("version", Version));

         builder.Append('\t', indent + 1);
         builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("generator", Generator));

         builder.Append('\t', indent + 1);
         builder.AppendLine(KiCadWriteUtils.WriteSubNodeData("generator_version", GeneratorVersion));

         General.WriteNode(builder, indent + 1);
         Paper.WriteNode(builder, indent + 1);
         TitleBlock?.WriteNode(builder, indent + 1);
         Layers.WriteNode(builder, indent + 1);
         Setup.WriteNode(builder, indent + 1);
         TextVariables?.WriteNode(builder, indent + 1);
         Nets?.WriteNode(builder, indent + 1);
         Footprints?.WriteNode(builder, indent + 1);
         Graphics?.WriteNode(builder, indent + 1);
         Images?.WriteNode(builder, indent + 1);
         Traces?.WriteNode(builder, indent + 1);
         Zones?.WriteNode(builder, indent + 1);
         Groups?.WriteNode(builder, indent + 1);
         TunedLengths?.WriteNode(builder, indent + 1);

         builder.Append('\t', indent);
         builder.AppendLine(")");

         //var props = GetType().GetProperties();

         //var pProps = props.Where(p => p.GetCustomAttribute<SExprPropertyAttribute>() != null);
         //foreach (var prop in pProps)
         //{
         //   var value = prop.GetValue(this);
         //   if (value is null) continue;
         //   builder.Append(" ");
         //   if (value is string)
         //   {
         //      builder.Append('"');
         //      builder.Append(value);
         //      builder.Append('"');
         //   }
         //}

         //KiCadWriteUtils.WriteSubNodes(builder, props, this, 1);
         //KiCadWriteUtils.WriteNodes(builder, props, this, 1);

         //var tokenProps = props.Where(p => p.GetCustomAttribute<SExprTokenAttribute>() != null);
         //foreach (var prop in tokenProps)
         //{
         //   var value = prop.GetValue(this);
         //   if (value is bool val)
         //   {
         //      if (val)
         //      {
         //         builder.Append(prop.GetCustomAttribute<SExprTokenAttribute>()!.TokenName);
         //      }
         //   }
         //}
      }
      #endregion

      #region Full Props
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

      [SExprIndex(6)]
      public LayerDefCollection? Layers
      {
         get => _layers;
         set
         {
            _layers = value;
            OnPropertyChanged();
         }
      }

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
      public NetCollection Nets
      {
         get => _nets;
         set
         {
            _nets = value;
            OnPropertyChanged();
         }
      }

      public FootprintCollection? Footprints
      {
         get => _footprints;
         set
         {
            _footprints = value;
            OnPropertyChanged();
         }
      }

      public GrGraphicsCollection? Graphics
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

      public TraceCollection? Traces
      {
         get => _traces;
         set
         {
            _traces = value;
            OnPropertyChanged();
         }
      }

      public ZoneCollection? Zones
      {
         get => _zones;
         set
         {
            _zones = value;
            OnPropertyChanged();
         }
      }

      public GroupCollection? Groups
      {
         get => _groups;
         set
         {
            _groups = value;
            OnPropertyChanged();
         }
      }

      public TextVariableCollection? TextVariables
      {
         get => _textVariables;
         set
         {
            _textVariables = value;
            OnPropertyChanged();
         }
      }

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
}
