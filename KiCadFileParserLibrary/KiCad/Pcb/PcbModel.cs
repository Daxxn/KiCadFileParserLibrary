using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.Footprints.Collections;
using KiCadFileParserLibrary.KiCad.General.Collections;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.KiCad.Pcb.Collections;
using KiCadFileParserLibrary.KiCad.Pcb.SubModels;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

namespace KiCadFileParserLibrary.KiCad.Pcb
{
   [SExprNode("kicad_pcb")]
   public class PcbModel : IKiCadReadable
   {
      #region Local Props
      [SExprSubNode("version")]
      public int Version { get; set; } = -1;

      [SExprSubNode("generator")]
      public string? Generator { get; set; }

      [SExprSubNode("generator_version")]
      public string? GeneratorVersion { get; set; }

      public GeneralModel? General { get; set; }

      public PaperModel? Paper { get; set; }

      public TitleBlockModel? TitleBlock { get; set; }

      public LayerDefCollection? Layers { get; set; }

      public Setup? Setup { get; set; }

      public NetCollection? Nets { get; set; }

      public FootprintCollection? Footprints { get; set; }

      public GrGraphicsCollection? Graphics { get; set; }

      public ImageCollection? Images { get; set; }

      public TraceCollection? Traces { get; set; }

      public ZoneCollection? Zones { get; set; }

      public GroupCollection? Groups { get; set; }

      public PropertyCollection? TextVariables { get; set; }

      public TunedLengthCollection? TunedLengths { get; set; }
      #endregion

      #region Constructors
      public PcbModel() { }
      #endregion

      #region Methods
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

            //var listProps = props.Where(p => p.PropertyType.GetCustomAttribute<SExprListNodeAttribute>() != null);
            //foreach (var lProp in listProps)
            //{
            //   var newObj = lProp.PropertyType.GetConstructor([])!.Invoke(null);
            //   if (newObj is IKiCadReadable readableProp)
            //   {
            //      readableProp.ParseNode(node);
            //   }
            //   lProp.SetValue(this, newObj);
            //}
         }
      }

      #endregion

      #region Full Props

      #endregion
   }
}
