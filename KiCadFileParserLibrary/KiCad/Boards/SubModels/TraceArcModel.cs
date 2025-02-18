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

namespace KiCadFileParserLibrary.KiCad.Boards.SubModels;

/// <summary>
/// Model of a curved trace.
/// </summary>
[SExprNode("arc")]
public class TraceArcModel : Model, IKiCadReadable
{
   #region Local Props
   private LocationModel _start = new();
   private LocationModel _middle = new();
   private LocationModel _end = new();
   private double _width = 0;
   private string _layer = "";
   private int _net = -1;
   private string _id = "";
   private bool _locked = false;

   #endregion

   #region Constructors
   /// <inheritdoc/>
   public TraceArcModel() { }
   #endregion

   #region Methods
   /// <inheritdoc/>
   public void ParseNode(Node node)
   {
      if (node.Properties != null && node.Children != null)
      {
         var props = GetType().GetProperties();

         KiCadParseUtils.ParseNodes(props, node, this);
         KiCadParseUtils.ParseSubNodes(props, node, this);
         KiCadParseUtils.ParseTokens(props, node, this);
      }
   }
   #endregion

   #region Full Props
   /// <summary>
   /// Start coordinates.
   /// </summary>
   [SExprNode("start")]
   public LocationModel Start
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
   [SExprNode("mid")]
   public LocationModel Middle
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
   [SExprNode("end")]
   public LocationModel End
   {
      get => _end;
      set
      {
         _end = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Trace width.
   /// </summary>
   [SExprSubNode("width")]
   public double Width
   {
      get => _width;
      set
      {
         _width = value;
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
   /// Net ID number.
   /// </summary>
   [SExprSubNode("net")]
   public int Net
   {
      get => _net;
      set
      {
         _net = value;
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
