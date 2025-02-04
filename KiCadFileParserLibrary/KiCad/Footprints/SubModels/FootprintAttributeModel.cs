using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

namespace KiCadFileParserLibrary.KiCad.Footprints.SubModels
{
   [SExprNode("attr")]
   public class FootprintAttributeModel : IKiCadReadable
   {
      #region Local Props
      [SExprProperty(1)]
      public FootprintType Type { get; set; }

      [SExprToken("board_only")]
      public bool BoardOnly { get; set; }

      [SExprToken("exclude_from_pos_files")]
      public bool ExcludeFromposFiles { get; set; }

      [SExprToken("exclude_from_bom")]
      public bool ExcludeFromBom { get; set; }

      [SExprToken("allow_missing_courtyard")]
      public bool AllowMissingCourtyard { get; set; }

      [SExprToken("allow_soldermask_bridges")]
      public bool AllowSoldermaskBridges { get; set; }

      [SExprToken("dnp")]
      public bool DontPopulate { get; set; }
      #endregion

      #region Constructors
      public FootprintAttributeModel() { }
      #endregion

      #region Methods
      public void ParseNode(Node node)
      {
         if (node.Properties != null)
         {
            var props = GetType().GetProperties();
            KiCadParseUtils.ParseProperties(props, node, this);
            KiCadParseUtils.ParseTokens(props, node, this);

            //var expProps = props.Where(p => p.GetCustomAttribute<SExprPropertyAttribute>() != null);
            //foreach (var prop in expProps)
            //{
            //   var attr = prop.GetCustomAttribute<SExprPropertyAttribute>();
            //   if (node.Properties.Count > attr!.PropertyIndex)
            //   {
            //      prop.SetValue(this, PropertyParser.ParsePCB(node.Properties[attr!.PropertyIndex], prop));
            //   }
            //}

            //var tokenProps = props.Where(p => p.GetCustomAttribute<SExprTokenAttribute>() != null);
            //foreach (var prop in tokenProps)
            //{
            //   var token = prop.GetCustomAttribute<SExprTokenAttribute>()!.TokenName;
            //   if (node.Properties.Contains(token))
            //   {
            //      prop.SetValue(this, true);
            //   }
            //}
         }
      }

      public void WriteNode(StringBuilder builder, int indent, string? auxName = null)
      {
         builder.Append('\t', indent);
         builder.Append("(attr");

         builder.Append($" {Type.ToString().ToLower()}");

         if (BoardOnly)
         {
            builder.Append($" board_only");
         }

         if (ExcludeFromposFiles)
         {
            builder.Append($" exclude_from_pos_files");
         }

         if (ExcludeFromBom)
         {
            builder.Append($" exclude_from_bom");
         }

         if (AllowMissingCourtyard)
         {
            builder.Append($" allow_missing_courtyard");
         }

         if (DontPopulate)
         {
            builder.Append($" dnp");
         }

         if (AllowSoldermaskBridges)
         {
            builder.Append($" allow_soldermask_bridges");
         }

         builder.AppendLine(")");
      }

      public override string ToString()
      {
         return $"FP Attributes - Type: {Type} - Board-Only: {BoardOnly} - Exclude-From-PosFile: {ExcludeFromposFiles} - Exclude-From-BOM: {ExcludeFromBom} - Allow-Miss-Crtyd: {AllowMissingCourtyard} - Dont-Pop: {DontPopulate} - Allow-Mask-Bridge: {AllowSoldermaskBridges}";
      }
      #endregion

      #region Full Props

      #endregion
   }
}
