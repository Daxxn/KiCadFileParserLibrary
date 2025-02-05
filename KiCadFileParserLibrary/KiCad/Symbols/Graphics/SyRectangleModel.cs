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
   [SExprNode("rectangle")]
   public class SyRectangleModel : SyGraphicBase
   {
      #region Local Props
      private XyModel? _start;
      private XyModel? _end;
      private StrokeModel? _stroke;
      private FillType _fill;
      private bool _isPrivate;
      #endregion

      #region Constructors
      public SyRectangleModel() { }
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
      #endregion
   }
}
