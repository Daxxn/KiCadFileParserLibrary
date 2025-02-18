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
/// General color data.
/// </summary>
[SExprNode("color")]
public class ColorModel : Model, IKiCadReadable
{
   #region Local Props
   private double _red;
   private double _green;
   private double _blue;
   private double _alpha;
   #endregion

   #region Constructors
   /// <inheritdoc/>
   public ColorModel() { }
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
   #endregion

   #region Full Props
   /// <summary>
   /// Red percentage.
   /// </summary>
   [SExprProperty(1)]
   public double Red
   {
      get => _red;
      set
      {
         _red = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Green percentage.
   /// </summary>
   [SExprProperty(2)]
   public double Green
   {
      get => _green;
      set
      {
         _green = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Blue percentage.
   /// </summary>
   [SExprProperty(3)]
   public double Blue
   {
      get => _blue;
      set
      {
         _blue = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Alpha percentage.
   /// </summary>
   [SExprProperty(4)]
   public double Alpha
   {
      get => _alpha;
      set
      {
         _alpha = value;
         OnPropertyChanged();
      }
   }
   #endregion
}
