using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.Footprints.Collections;
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

      public Layers? Layers { get; set; }

      public Setup? Setup { get; set; }

      public NetCollection? Nets { get; set; }

      public FootprintCollection? Footprints { get; set; }
      #endregion

      #region Constructors
      public PcbModel() { }
      #endregion

      #region Methods
      public void ParseNode(Node node)
      {
         var props = GetType().GetProperties();
         if (node.Children != null)
         {
            KiCadParseUtils.ParseSubNodes(props, node, this);
            //var subNodeProps = props.Where(p => p.GetCustomAttribute<SExprSubNodeAttribute>() != null);
            //foreach (var prop in subNodeProps)
            //{
            //   var subNodeAttr = prop.GetCustomAttribute<SExprSubNodeAttribute>()!;
            //   var subNode = node.GetNode(subNodeAttr.XPath);
            //   if (subNode != null)
            //   {
            //      if (subNode.Properties != null)
            //      {
            //         prop.SetValue(this, PropertyParser.Parse(subNode.Properties[1], prop));
            //      }
            //   }
            //}

            KiCadParseUtils.ParseNodes(props, node, this);
            //var classProps = props.Where(p => p.PropertyType.GetCustomAttribute<SExprNodeAttribute>() != null);
            //foreach (var cProp in classProps)
            //{
            //   var objNode = node.GetNode(cProp.PropertyType.GetCustomAttribute<SExprNodeAttribute>()!.XPath);
            //   if (objNode != null)
            //   {
            //      var newObj = cProp.PropertyType.GetConstructor([])!.Invoke(null);
            //      if (newObj is IKiCadReadable readableProp)
            //      {
            //         readableProp.ParseNode(objNode);
            //      }
            //      cProp.SetValue(this, newObj);
            //   }
            //}

            var listProps = props.Where(p => p.PropertyType.GetCustomAttribute<SExprListNodeAttribute>() != null);
            foreach (var lProp in listProps)
            {
               var newObj = lProp.PropertyType.GetConstructor([])!.Invoke(null);
               if (newObj is IKiCadReadable readableProp)
               {
                  readableProp.ParseNode(node);
               }
               lProp.SetValue(this, newObj);
            }
         }
      }

      #endregion

      #region Full Props

      #endregion
   }
}
