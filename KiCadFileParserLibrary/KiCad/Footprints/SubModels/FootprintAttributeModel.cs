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

using MVVMLibrary;

namespace KiCadFileParserLibrary.KiCad.Footprints.SubModels
{
   [SExprNode("attr")]
   public class FootprintAttributeModel : Model, IKiCadReadable
   {
      #region Local Props
      private FootprintType _type;
      private bool _boardOnly;
      private bool _excludeFromposFiles;
      private bool _excludeFromBom;
      private bool _allowMissingCourtyard;
      private bool _allowSoldermaskBridges;
      private bool _dontPopulate;
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
      [SExprProperty(1)]
      public FootprintType Type
      {
         get => _type;
         set
         {
            _type = value;
            OnPropertyChanged();
         }
      }

      [SExprToken("board_only")]
      public bool BoardOnly
      {
         get => _boardOnly;
         set
         {
            _boardOnly = value;
            OnPropertyChanged();
         }
      }

      [SExprToken("exclude_from_pos_files")]
      public bool ExcludeFromposFiles
      {
         get => _excludeFromposFiles;
         set
         {
            _excludeFromposFiles = value;
            OnPropertyChanged();
         }
      }

      [SExprToken("exclude_from_bom")]
      public bool ExcludeFromBom
      {
         get => _excludeFromBom;
         set
         {
            _excludeFromBom = value;
            OnPropertyChanged();
         }
      }

      [SExprToken("allow_missing_courtyard")]
      public bool AllowMissingCourtyard
      {
         get => _allowMissingCourtyard;
         set
         {
            _allowMissingCourtyard = value;
            OnPropertyChanged();
         }
      }

      [SExprToken("allow_soldermask_bridges")]
      public bool AllowSoldermaskBridges
      {
         get => _allowSoldermaskBridges;
         set
         {
            _allowSoldermaskBridges = value;
            OnPropertyChanged();
         }
      }

      [SExprToken("dnp")]
      public bool DontPopulate
      {
         get => _dontPopulate;
         set
         {
            _dontPopulate = value;
            OnPropertyChanged();
         }
      }
      #endregion
   }
}
