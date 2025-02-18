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
/// Symbol circle model
/// </summary>
[SExprNode("circle")]
public class SyCircleModel : SyGraphicBase
{
   #region Local Props
   private XyModel? _center;
   private double? _radius;
   private bool _isPrivate;
   private StrokeModel? _stroke;
   private SymbolFillModel? _fill;
   #endregion

   #region Constructors
   /// <inheritdoc/>
   public SyCircleModel() { }
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
   /// Center coordinates
   /// </summary>
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

   /// <summary>
   /// Radius
   /// </summary>
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
