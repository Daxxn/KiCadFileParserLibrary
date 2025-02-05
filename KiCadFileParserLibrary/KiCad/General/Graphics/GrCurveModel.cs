using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.Footprints.SubModels;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

namespace KiCadFileParserLibrary.KiCad.General.Graphics
{
   [SExprNode("bezier")]
   public class GrCurveModel : GraphicBase
   {
      #region Local Props
      private CoordinateModel? _points;
      private string? _layer;
      private double? _width;
      private string? _id;
      #endregion

      #region Constructors
      public GrCurveModel() { }
      #endregion

      #region Methods
      public override void ParseNode(Node node)
      {
         if (node.Children != null)
         {
            var props = GetType().GetProperties();
            KiCadParseUtils.ParseSubNodes(props, node, this);
            KiCadParseUtils.ParseNodes(props, node, this);
         }
      }

      public override void WriteNode(StringBuilder builder, int indent, string? auxName = null)
      {
         throw new NotImplementedException();
      }
      #endregion

      #region Full Props
      public CoordinateModel? Points
      {
         get => _points;
         set
         {
            _points = value;
            OnPropertyChanged();
         }
      }

      [SExprSubNode("layer")]
      public string? Layer
      {
         get => _layer;
         set
         {
            _layer = value;
            OnPropertyChanged();
         }
      }

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

      [SExprSubNode("uuid")]
      public string? ID
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
