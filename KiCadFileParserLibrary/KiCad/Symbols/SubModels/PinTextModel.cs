using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.General;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.SExprParser;

using MVVMLibrary;

namespace KiCadFileParserLibrary.KiCad.Symbols.SubModels
{
   [SExprNode("name|number")]
   public class PinTextModel : Model, IKiCadReadable
   {
      #region Local Props
      private string? _value;
      private EffectsModel? _effect;
      #endregion

      #region Constructors
      public PinTextModel() { }
      #endregion

      #region Methods
      public void ParseNode(Node node)
      {
         throw new NotImplementedException();
      }

      public void WriteNode(StringBuilder builder, int indent, string? auxName = null)
      {
         throw new NotImplementedException();
      }
      #endregion

      #region Full Props
      public string? Value
      {
         get => _value;
         set
         {
            _value = value;
            OnPropertyChanged();
         }
      }

      public EffectsModel? Effects
      {
         get => _effect;
         set
         {
            _effect = value;
            OnPropertyChanged();
         }
      }
      #endregion
   }
}
