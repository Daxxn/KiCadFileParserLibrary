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

[SExprNode("size")]
public class SizeModel : Model, IKiCadReadable
{
   #region Local Props
   private double _width;
   private double _height;
   #endregion

   #region Constructors
   public SizeModel() { }
   #endregion

   #region Methods
   public void ParseNode(Node node)
   {
      if (node.Properties != null)
      {
         var props = GetType().GetProperties();
         KiCadParseUtils.ParseProperties(props, node, this);
      }
   }
   public override string ToString()
   {
      return $"Size - W: {Width} - H: {Height}";
   }
   #endregion

   #region Full Props
   [SExprProperty(1)]
   public double Width
   {
      get => _width;
      set
      {
         _width = value;
         OnPropertyChanged();
      }
   }

   [SExprProperty(2)]
   public double Height
   {
      get => _height;
      set
      {
         _height = value;
         OnPropertyChanged();
      }
   }
   #endregion
}
