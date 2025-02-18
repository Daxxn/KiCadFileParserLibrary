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
/// <see cref="Boards.PcbModel">PCB</see> dimension graphic.
/// </summary>
[SExprNode("dimension")]
public class DimensionModel : GraphicBase
{
   #region Local Props
   private bool _locked;
   private DimensionType? _type;
   private string _layer = "";
   private double _height;
   private string _id = "";
   private CoordinateModel? _points;
   private double _leaderLength;
   private GrTextModel? _text;
   private DimensionStyleModel? _style;
   private DimensionFormatModel? _format;
   #endregion

   #region Constructors
   /// <inheritdoc/>
   public DimensionModel() { }
   #endregion

   #region Methods
   /// <inheritdoc/>
   public override void ParseNode(Node node)
   {
      if (node.Properties != null && node.Children != null)
      {
         var props = GetType().GetProperties();
         KiCadParseUtils.ParseSubNodes(props, node, this);
         KiCadParseUtils.ParseNodes(props, node, this);
         KiCadParseUtils.ParseTokens(props, node, this);
      }
   }
   #endregion

   #region Full Props
   /// <summary>
   /// Is locked.
   /// </summary>
   [SExprToken("locked")]
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
   /// Dimension type.
   /// </summary>
   [SExprSubNode("type")]
   public DimensionType? Type
   {
      get => _type;
      set
      {
         _type = value;
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
   /// Dimension offset height
   /// </summary>
   [SExprSubNode("height")]
   public double Height
   {
      get => _height;
      set
      {
         _height = value;
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
   /// List object containing dimension coordinates.
   /// </summary>
   public CoordinateModel? Points
   {
      get => _points;
      set
      {
         _points = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Length of the dimension leads from the measured points.
   /// </summary>
   [SExprSubNode("leader_length")]
   public double LeaderLength
   {
      get => _leaderLength;
      set
      {
         _leaderLength = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// <see cref="GrTextModel">Text</see> data.
   /// </summary>
   public GrTextModel? Text
   {
      get => _text;
      set
      {
         _text = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// <see cref="DimensionStyleModel">Style</see> data.
   /// </summary>
   public DimensionStyleModel? Style
   {
      get => _style;
      set
      {
         _style = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// <see cref="DimensionFormatModel">Format</see> data.
   /// </summary>
   public DimensionFormatModel? Format
   {
      get => _format;
      set
      {
         _format = value;
         OnPropertyChanged();
      }
   }
   #endregion
}
