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
/// General arc graphic.
/// </summary>
[SExprNode("gr_arc")]
public class GrArcModel : GraphicBase
{
   #region Local Props
   private XyModel _start = new();
   private XyModel _middle = new();
   private XyModel _end = new();
   private StrokeModel _stroke = new();
   private string _layer = "";
   private string _id = "";
   private bool _locked;
   #endregion

   #region Constructors
   /// <inheritdoc/>
   public GrArcModel() { }
   #endregion

   #region Methods
   /// <inheritdoc/>
   public override void ParseNode(Node node)
   {
      if (node.Children != null)
      {
         var props = GetType().GetProperties();

         KiCadParseUtils.ParseSubNodes(props, node, this);
         KiCadParseUtils.ParseNodes(props, node, this);
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
   /// Mid-point coordinates.
   /// </summary>
   [SExprNode("mid", 1)]
   public XyModel Middle
   {
      get => _middle;
      set
      {
         _middle = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// End coordinates.
   /// </summary>
   [SExprNode("end", 2)]
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
   /// Stroke data.
   /// </summary>
   public StrokeModel Stroke
   {
      get => _stroke;
      set
      {
         _stroke = value;
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
   /// Is locked.
   /// </summary>
   [SExprSubNode("locked")]
   public bool Locked
   {
      get => _locked;
      set
      {
         _locked = value;
         OnPropertyChanged();
      }
   }
   #endregion
}
