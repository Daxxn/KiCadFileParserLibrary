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
   [SExprNode("text_box")]
   public class SyTextBoxModel : SyGraphicBase
   {
      #region Local Props
      private string? _text;
      private LocationModel? _location;
      private XyModel? _size;
      private StrokeModel? _stroke;
      private FillType _fill;
      private EffectsModel? _effects;
      private bool _isPrivate;
      #endregion

      #region Constructors
      public SyTextBoxModel() { }
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
      [SExprProperty(1, true)]
      public string? Text
      {
         get => _text;
         set
         {
            _text = value;
            OnPropertyChanged();
         }
      }

      public LocationModel? Location
      {
         get => _location;
         set
         {
            _location = value;
            OnPropertyChanged();
         }
      }

      [SExprNode("size")]
      public XyModel? Size
      {
         get => _size;
         set
         {
            _size = value;
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

      public EffectsModel? Effects
      {
         get => _effects;
         set
         {
            _effects = value;
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
