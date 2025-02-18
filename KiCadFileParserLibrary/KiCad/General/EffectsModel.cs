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

namespace KiCadFileParserLibrary.KiCad.General;

/// <summary>
/// Font effects.
/// </summary>
[SExprNode("effects")]
public class EffectsModel : Model, IKiCadReadable
{
   #region Local Props
   private FontModel? _fonts;
   private ObservableCollection<TextJustify>? _justify;
   private bool? _hide;
   #endregion

   #region Constructors
   /// <inheritdoc/>
   public EffectsModel() { }
   #endregion

   #region Methods
   /// <inheritdoc/>
   public void ParseNode(Node node)
   {
      if (node.Children != null)
      {
         var props = GetType().GetProperties();
         KiCadParseUtils.ParseNodes(props, node, this);
         KiCadParseUtils.ParseTokens(props, node, this);
         KiCadParseUtils.ParsePropLists(props, node, this);
         KiCadParseUtils.ParseSubNodes(props, node, this);
      }
   }
   #endregion

   #region Full Props
   /// <summary>
   /// Font family name
   /// </summary>
   public FontModel? Font
   {
      get => _fonts;
      set
      {
         _fonts = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Text justification
   /// </summary>
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

   /// <summary>
   /// Is hidden.
   /// </summary>
   [SExprSubNode("hide")]
   public bool? Hide // I cant find this prop anymore...
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
