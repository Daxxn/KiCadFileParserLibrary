using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.KiCad.Boards.SubModels;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;
using System.Collections.ObjectModel;
using MVVMLibrary;

namespace KiCadFileParserLibrary.KiCad.General
{
   [SExprNode("effects")]
   public class EffectsModel : Model, IKiCadReadable
   {
      #region Local Props
      private FontModel? _fonts;
      private ObservableCollection<TextJustify>? _justify;
      private bool _hide;
      #endregion

      #region Constructors
      public EffectsModel() { }
      #endregion

      #region Methods
      public void ParseNode(Node node)
      {
         if (node.Children != null)
         {
            var props = GetType().GetProperties();
            KiCadParseUtils.ParseNodes(props, node, this);
            KiCadParseUtils.ParseTokens(props, node, this);
            KiCadParseUtils.ParsePropLists(props, node, this);

            //var justNode = node.GetNode("justify");
            //if (justNode is null) return;
            //if (justNode.Properties!.Count <= 1) return;
            //Justify = [];
            //foreach (var p in justNode.Properties[1..])
            //{
            //   if (Enum.TryParse(p, true, out TextJustify output))
            //   {
            //      Justify.Add(output);
            //   }
            //}
         }
      }

      public void WriteNode(StringBuilder builder, int indent, string? auxName = null)
      {
         builder.Append('\t', indent);
         builder.AppendLine($"(effects");

         Font?.WriteNode(builder, indent + 1);

         if (Justify != null)
         {
            builder.Append('\t', indent + 1);
            builder.Append($"(justify");

            foreach (var jst in Justify)
            {
               builder.Append($" {jst.ToString().ToLower()}");
            }
            builder.AppendLine($")");
         }

         builder.Append('\t', indent);
         builder.AppendLine(")");
      }
      #endregion

      #region Full Props
      public FontModel? Font
      {
         get => _fonts;
         set
         {
            _fonts = value;
            OnPropertyChanged();
         }
      }

      //[SExprSubNode("justify")]
      [SExprPropArray("justify")]
      public ObservableCollection<TextJustify>? Justify
      {
         get => _justify;
         set
         {
            _justify = value;
            OnPropertyChanged();
         }
      }

      [SExprToken("hide")]
      public bool Hide // I cant find this prop anymore...
      {
         get => _hide;
         set
         {
            _hide = value;
            OnPropertyChanged();
         }
      }
      #endregion
   }
}
