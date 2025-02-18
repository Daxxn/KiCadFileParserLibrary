using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.General;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.KiCad.Symbols.SubModels;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

namespace KiCadFileParserLibrary.KiCad.Symbols.Graphics;

/// <summary>
/// Symbol arc model
/// </summary>
[SExprNode("arc")]
public class SyArcModel : SyGraphicBase
{
   #region Local Props
   private XyModel? _start;
   private XyModel? _middle;
   private XyModel? _end;
   private bool _isPrivate;
   private StrokeModel? _stroke;
   private SymbolFillModel? _fill;
   #endregion

   #region Constructors
   /// <inheritdoc/>
   public SyArcModel() { }
   #endregion

   #region Methods
   /// <inheritdoc/>
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
   #endregion

   #region Full Props
   /// <summary>
   /// Start coordinates
   /// </summary>
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

   /// <summary>
   /// Middle coordinates
   /// </summary>
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

   /// <summary>
   /// End coordinates
   /// </summary>
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

   /// <summary>
   /// Is private
   /// </summary>
   [SExprToken("private", 0)]
   public bool IsPrivate
   {
      get => _isPrivate;
      set
      {
         _isPrivate = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Stroke data
   /// </summary>
   public StrokeModel? Stroke
   {
      get => _stroke;
      set
      {
         _stroke = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Symbol fill data
   /// </summary>
   public SymbolFillModel? Fill
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
