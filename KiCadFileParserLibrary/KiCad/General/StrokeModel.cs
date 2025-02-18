using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

using MVVMLibrary;

namespace KiCadFileParserLibrary.KiCad.General;

/// <summary>
/// General stroke model.
/// </summary>
[SExprNode("stroke")]
public class StrokeModel : Model, IKiCadReadable
{
   #region Local Props
   private double _width;
   private StrokeType? _type;
   private ColorModel? _color;
   #endregion

   #region Constructors
   /// <inheritdoc/>
   public StrokeModel() { }
   #endregion

   #region Methods
   /// <inheritdoc/>
   public void ParseNode(Node node)
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
   /// Stroke width.
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
   /// Stroke type.
   /// </summary>
   [SExprSubNode("type")]
   public StrokeType? Type
   {
      get => _type;
      set
      {
         _type = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Color
   /// </summary>
   public ColorModel? Color
   {
      get => _color;
      set
      {
         _color = value;
         OnPropertyChanged();
      }
   }
   #endregion
}
