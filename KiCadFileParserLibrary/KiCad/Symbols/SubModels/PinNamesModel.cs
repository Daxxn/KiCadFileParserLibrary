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
/// Pin names model
/// </summary>
[SExprNode("pin_names")]
public class PinNamesModel : Model, IKiCadReadable
{
   #region Local Props
   private bool _hide;
   private double? _offset;
   #endregion

   #region Constructors
   /// <inheritdoc/>
   public PinNamesModel() { }
   #endregion

   #region Methods
   /// <inheritdoc/>
   public void ParseNode(Node node)
   {
      if (node.Children != null && node.Properties != null)
      {
         var props = GetType().GetProperties();
         KiCadParseUtils.ParseSubNodes(props, node, this);
         KiCadParseUtils.ParseTokens(props, node, this);
      }
   }
   #endregion

   #region Full Props
   /// <summary>
   /// Hide
   /// </summary>
   [SExprToken("hide", true)]
   public bool Hide
   {
      get => _hide;
      set
      {
         _hide = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Offset
   /// </summary>
   [SExprSubNode("offset")]
   public double? Offset
   {
      get => _offset;
      set
      {
         _offset = value;
         OnPropertyChanged();
      }
   }
   #endregion
}
