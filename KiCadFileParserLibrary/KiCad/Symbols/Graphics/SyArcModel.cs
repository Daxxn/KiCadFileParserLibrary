using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.General;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

namespace KiCadFileParserLibrary.KiCad.Symbols.Graphics
{
   [SExprNode("arc")]
   public class SyArcModel : SyGraphicBase
   {
      #region Local Props
      private XyModel? _start;
      private XyModel? _middle;
      private XyModel? _end;
      private bool _isPrivate;
      private StrokeModel? _stroke;
      private FillType _fill;
      #endregion

      #region Constructors
      public SyArcModel() { }
      #endregion

      #region Methods
      public override void ParseNode(Node node)
      {
         if (node.Properties != null && node.Children != null)
         {
            var props = GetType().GetProperties();
            KiCadParseUtils.ParseNodes(props, node, this);
            KiCadParseUtils.ParseSubNodes(props, node, this);
            KiCadParseUtils.ParseProperties(props, node, this);
            KiCadParseUtils.ParseTokens(props, node, this);
         }
      }

      public override void WriteNode(StringBuilder builder, int indent, string? auxName = null)
      {
         throw new NotImplementedException();
      }
      #endregion

      #region Full Props
      [SExprNode("start")]
      public XyModel? Start
      {
         get => _start;
         set
         {
            _start = value;
            OnPropertyChanged();
         }
      }

      [SExprNode("mid")]
      public XyModel? Middle
      {
         get => _middle;
         set
         {
            _middle = value;
            OnPropertyChanged();
         }
      }

      [SExprNode("end")]
      public XyModel? End
      {
         get => _end;
         set
         {
            _end = value;
            OnPropertyChanged();
         }
      }

      [SExprToken("private")]
      public bool IsPrivate
      {
         get => _isPrivate;
         set
         {
            _isPrivate = value;
            OnPropertyChanged();
         }
      }

      public StrokeModel? Stroke
      {
         get => _stroke;
         set
         {
            _stroke = value;
            OnPropertyChanged();
         }
      }

      [SExprSubNode("fill")]
      public FillType Fill
      {
         get => _fill;
         set
         {
            _fill = value;
            OnPropertyChanged();
         }
      }
      #endregion
   }
}
