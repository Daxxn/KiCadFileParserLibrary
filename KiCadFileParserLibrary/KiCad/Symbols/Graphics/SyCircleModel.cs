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
   [SExprNode("circle")]
   public class SyCircleModel : SyGraphicBase
   {
      #region Local Props
      private XyModel? _center;
      private double? _radius;
      private bool _isPrivate;
      private StrokeModel? _stroke;
      private FillType _fill;
      #endregion

      #region Constructors
      public SyCircleModel() { }
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
      [SExprNode("center")]
      public XyModel? Center
      {
         get => _center;
         set
         {
            _center = value;
            OnPropertyChanged();
         }
      }

      [SExprSubNode("radius")]
      public double? Radius
      {
         get => _radius;
         set
         {
            _radius = value;
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
