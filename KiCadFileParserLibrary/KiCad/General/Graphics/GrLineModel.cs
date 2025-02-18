using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

namespace KiCadFileParserLibrary.KiCad.General.Graphics;

/// <summary>
/// General line graphic.
/// </summary>
[SExprNode("gr_line")]
public class GrLineModel : GraphicBase
{
   #region Local Props
   private XyModel _start = new();
   private XyModel _end = new();
   private string _layer = "";
   private StrokeModel? _stroke;
   private string _id = "";
   private double? _angle;

   #endregion

   #region Constructors
   /// <inheritdoc/>
   public GrLineModel() { }
   #endregion

   #region Methods
   /// <inheritdoc/>
   public override void ParseNode(Node node)
   {
      if (node.Children != null)
      {
         var props = GetType().GetProperties();

         KiCadParseUtils.ParseNodes(props, node, this);
         KiCadParseUtils.ParseSubNodes(props, node, this);
      }
   }
   #endregion

   #region Full Props
   /// <summary>
   /// Start coordinates.
   /// </summary>
   [SExprNode("start", 0)]
   public XyModel Start
   {
      get => _start;
      set
      {
         _start = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// End coordinates.
   /// </summary>
   [SExprNode("end", 1)]
   public XyModel End
   {
      get => _end;
      set
      {
         _end = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Layer name.
   /// </summary>
   [SExprSubNode("layer")]
   public string Layer
   {
      get => _layer;
      set
      {
         _layer = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Stroke data.
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
   /// Unique ID.
   /// </summary>
   [SExprSubNode("uuid")]
   public string ID
   {
      get => _id;
      set
      {
         _id = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Line angle.
   /// </summary>
   [SExprSubNode("angle")]
   public double? Angle
   {
      get => _angle;
      set
      {
         _angle = value;
         OnPropertyChanged();
      }
   }
   #endregion
}
