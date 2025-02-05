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
      private XyModel _position = new();
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

            KiCadParseUtils.ParseSubNodes(props, node, this);
         }
      }

      public void WriteNode(StringBuilder builder, int indent, string? auxName = null)
      {
         throw new NotImplementedException();
      }
      #endregion

      #region Full Props
      [SExprSubNode("at")]
      public XyModel Position
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
