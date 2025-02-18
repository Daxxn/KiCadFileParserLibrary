using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
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
/// Model of a straight trace.
/// </summary>
[SExprNode("segment")]
public class TraceSegmentModel : Model, IKiCadReadable
{
   #region Local Props
   private LocationModel _start = new();
   private LocationModel _end = new();
   private double _width;
   private string _layer = "";
   private bool _locked;
   private int _netIndex = -1;
   private string _id = "";

   #endregion

   #region Constructors
   /// <inheritdoc/>
   public TraceSegmentModel() { }
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

   /// <summary>
   /// Net id number.
   /// </summary>
   [SExprSubNode("net")]
   public int NetIndex
   {
      get => _netIndex;
      set
      {
         _netIndex = value;
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
   #endregion
}
