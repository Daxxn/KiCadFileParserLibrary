using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.General;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

namespace KiCadFileParserLibrary.KiCad.Symbols.Graphics
{
   [SExprNode("text")]
   public class SyTextModel : SyGraphicBase
   {
      #region Local Props
      private string? _text;
      private bool _isPrivate;
      private LocationModel? _location;
      private EffectsModel? _effects;
      #endregion

      #region Constructors
      public SyTextModel() { }
      #endregion

      #region Methods
      public override void ParseNode(Node node)
      {
         if (node.Properties != null && node.Children != null)
         {
            var props = GetType().GetProperties();
            KiCadParseUtils.ParseNodes(props, node, this);
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

      public LocationModel? Location
      {
         get => _location;
         set
         {
            _location = value;
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
      #endregion
   }
}
