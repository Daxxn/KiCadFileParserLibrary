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

namespace KiCadFileParserLibrary.KiCad.Footprints.SubModels;

/// <summary>
/// Reference to a 3D model representing the component.
/// </summary>
[SExprNode("model")]
public class Footprint3DModel : Model, IKiCadReadable
{
   #region Local Props
   private string? _path;
   private double? _opacity;
   private Offset3DModel _offset = new();
   private Scale3DModel _scale = new();
   private Rotate3DModel _rotation = new();
   #endregion

   #region Constructors
   /// <inheritdoc/>
   public Footprint3DModel() { }
   #endregion

   #region Methods
   /// <inheritdoc/>
   public void ParseNode(Node node)
   {
      if (node.Children != null && node.Properties != null)
      {
         var props = GetType().GetProperties();
         KiCadParseUtils.ParseProperties(props, node, this);
         KiCadParseUtils.ParseSubNodes(props, node, this);
         KiCadParseUtils.ParseNodes(props, node, this);
      }
   }
   #endregion

   #region Full Props
   /// <summary>
   /// Path to the 3D model file.
   /// </summary>
   [SExprProperty(1)]
   public string? Path
   {
      get => _path;
      set
      {
         _path = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Opacity percentage. ( <c>0 - 1</c> )
   /// <para/>
   /// If equal to 1, is null and not written.
   /// </summary>
   [SExprSubNode("opacity")]
   public double? Opacity
   {
      get => _opacity;
      set
      {
         _opacity = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// 3D model offset.
   /// </summary>
   public Offset3DModel Offset
   {
      get => _offset;
      set
      {
         _offset = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// 3D model scale.
   /// </summary>
   public Scale3DModel Scale
   {
      get => _scale;
      set
      {
         _scale = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// 3D model rotation.
   /// </summary>
   public Rotate3DModel Rotation
   {
      get => _rotation;
      set
      {
         _rotation = value;
         OnPropertyChanged();
      }
   }
   #endregion
}
