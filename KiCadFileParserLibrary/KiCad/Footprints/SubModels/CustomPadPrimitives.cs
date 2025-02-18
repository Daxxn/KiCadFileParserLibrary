using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.Footprints.Collections;
using KiCadFileParserLibrary.KiCad.General.Collections;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

using MVVMLibrary;

namespace KiCadFileParserLibrary.KiCad.Footprints.SubModels;

/// <summary>
/// Shapes used for constructing a custom pad.
/// </summary>
[SExprNode("primitives")]
public class CustomPadPrimitives : Model, IKiCadReadable
{
   #region Local Props
   private GrGraphicsCollection _primitives = new();
   private double? _width = null;
   private bool? _fill = null;
   #endregion

   #region Constructors
   /// <inheritdoc/>
   public CustomPadPrimitives() { }
   #endregion

   #region Methods
   /// <inheritdoc/>
   public void ParseNode(Node node)
   {
      if (node.Children != null)
      {
         var props = GetType().GetProperties();
         KiCadParseUtils.ParseListNodes(props, node, this);
         KiCadParseUtils.ParseSubNodes(props, node, this);
      }
   }
   #endregion

   #region Full Props
   /// <summary>
   /// List of graphics used to construct the pad.
   /// </summary>
   public GrGraphicsCollection Primitives
   {
      get => _primitives;
      set
      {
         _primitives = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Overall width of the pad.
   /// </summary>
   [SExprSubNode("width")]
   public double? Width
   {
      get => _width;
      set
      {
         _width = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Pad is filled.
   /// </summary>
   [SExprSubNode("fill")]
   public bool? Fill
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
