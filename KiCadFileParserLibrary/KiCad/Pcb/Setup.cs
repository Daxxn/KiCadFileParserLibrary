using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

namespace KiCadFileParserLibrary.KiCad.Pcb
{
   [SExprNode("setup")]
   public class Setup : IKiCadReadable
   {
      #region Local Props
      [SExprSubNode("pad_to_mask_clearance")]
      public double? PadToMaskClearance { get; set; }

      [SExprSubNode("allow_soldermask_bridges_in_footprints")]
      public bool AllowMaskBridgeInFp { get; set; }

      public Stackup? Stackup { get; set; }

      public PcbplotParameters? PlotParams { get; set; }
      #endregion

      #region Constructors
      public Setup() { }
      #endregion

      #region Methods
      public void ParseNode(Node node)
      {
         if (node.Children != null)
         {
            var props = GetType().GetProperties();

            KiCadParseUtils.ParseSubNodes(props, node, this);
            KiCadParseUtils.ParseNodes(props, node, this);

            //var subNodeProps = props.Where(p => p.GetCustomAttribute<SExprSubNodeAttribute>() != null);
            //foreach (var subNodeProp in subNodeProps)
            //{
            //   var attr = subNodeProp.GetCustomAttribute<SExprSubNodeAttribute>();
            //   var subNode = node.GetNode(attr!.XPath);
            //   if (subNode != null)
            //   {
            //      if (subNode.Properties != null)
            //      {
            //         subNodeProp.SetValue(this, PropertyParser.Parse(subNode.Properties[1], subNodeProp));
            //      }
            //   }
            //}
            //var nodeProps = props.Where(p => p.PropertyType.GetCustomAttribute<SExprNodeAttribute>() != null);
            //foreach (var nodeProp in nodeProps)
            //{
            //   var attr = nodeProp.GetCustomAttribute<SExprNodeAttribute>();
            //   var n = node.GetNode(attr!.XPath);
            //   if (n != null)
            //   {
            //      var newObj = nodeProp.PropertyType.GetConstructor([])!.Invoke(null);
            //      if (newObj is IKiCadReadable readable)
            //      {
            //         readable.ParseNode(n);
            //      }
            //      nodeProp.SetValue(this, newObj);
            //   }
            //}
         }
      }
      #endregion

      #region Full Props

      #endregion
   }
}
