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

using MVVMLibrary;

namespace KiCadFileParserLibrary.KiCad.Symbols.SubModels;

/// <summary>
/// Pin text model
/// </summary>
[SExprNode("name|number")]
public class PinTextModel : Model, IKiCadReadable
{
   #region Local Props
   private string? _value;
   private EffectsModel? _effect;
   #endregion

   #region Constructors
   /// <inheritdoc/>
   public PinTextModel() { }
   #endregion

   #region Methods
   /// <inheritdoc/>
   public void ParseNode(Node node)
   {
      if (node.Properties != null && node.Children != null)
      {
         var props = GetType().GetProperties();

         KiCadParseUtils.ParseProperties(props, node, this);
         KiCadParseUtils.ParseNodes(props, node, this);
      }
   }
   #endregion

   #region Full Props
   /// <summary>
   /// Pin text
   /// </summary>
   [SExprProperty(1)]
   public string? Value
   {
      get => _value;
      set
      {
         _value = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Font effects
   /// </summary>
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
