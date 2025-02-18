using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

using MVVMLibrary;

namespace KiCadFileParserLibrary.KiCad.General;

/// <summary>
/// Location coordinates model.
/// </summary>
[SExprNode("at")]
public class LocationModel : Model, IKiCadReadable
{
   #region Local Props
   private double? _x;
   private double? _y;
   private double? _angle;
   #endregion

   #region Constructors
   /// <inheritdoc/>
   public LocationModel() { }
   #endregion

   #region Methods
   /// <inheritdoc/>
   public void ParseNode(Node node)
   {
      var props = GetType().GetProperties();
      KiCadParseUtils.ParseProperties(props, node, this);
   }
   #endregion

   #region Full Props
   /// <summary>
   /// Horizontal coordinate.
   /// </summary>
   [SExprProperty(1)]
   public double? X
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
   public double? Y
   {
      get => _y;
      set
      {
         _y = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Angle in degrees.
   /// </summary>
   [SExprProperty(3)]
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
