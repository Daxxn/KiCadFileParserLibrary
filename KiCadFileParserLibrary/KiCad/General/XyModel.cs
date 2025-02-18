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
/// 2D coordinate model.
/// </summary>
[SExprNode("xy")]
public class XyModel : Model, IKiCadReadable
{
   #region Local Props
   private double _x;
   private double _y;
   #endregion

   #region Constructors
   /// <inheritdoc/>
   public XyModel() { }
   #endregion

   #region Methods
   /// <inheritdoc/>
   public void ParseNode(Node node)
   {
      if (node.Properties != null)
      {
         var props = GetType().GetProperties();
         KiCadParseUtils.ParseProperties(props, node, this);
      }
   }

   /// <inheritdoc/>
   public override string ToString()
   {
      return $"XY - X: {X} - Y: {Y}";
   }
   #endregion

   #region Full Props
   /// <summary>
   /// Horizontal coordinate.
   /// </summary>
   [SExprProperty(1)]
   public double X
   {
      get => _x;
      set
      {
         _x = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Vertical coordinate.
   /// </summary>
   [SExprProperty(2)]
   public double Y
   {
      get => _y;
      set
      {
         _y = value;
         OnPropertyChanged();
      }
   }
   #endregion
}
