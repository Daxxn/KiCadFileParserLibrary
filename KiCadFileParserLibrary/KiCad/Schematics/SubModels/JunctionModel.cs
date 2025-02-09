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

namespace KiCadFileParserLibrary.KiCad.Schematics.SubModels
{
   [SExprNode("junction")]
   public class JunctionModel : Model, IKiCadReadable
   {
      #region Local Props
      private LocationModel _position = new();
      private double _diameter = 0;
      private ColorModel _color = new();
      private string _id = "";
      #endregion

      #region Constructors
      public JunctionModel() { }
      #endregion

      #region Methods
      public void ParseNode(Node node)
      {
         if (node.Children != null)
         {
            var props = GetType().GetProperties();

            KiCadParseUtils.ParseNodes(props, node, this);
            KiCadParseUtils.ParseSubNodes(props, node, this);
         }
      }
      #endregion

      #region Full Props
      public LocationModel Position
      {
         get => _position;
         set
         {
            _position = value;
            OnPropertyChanged();
         }
      }

      [SExprSubNode("diameter")]
      public double Diameter
      {
         get => _diameter;
         set
         {
            _diameter = value;
            OnPropertyChanged();
         }
      }

      [SExprSubNode("color")]
      public ColorModel Color
      {
         get => _color;
         set
         {
            _color = value;
            OnPropertyChanged();
         }
      }

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
}
