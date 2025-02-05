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

namespace KiCadFileParserLibrary.KiCad.Symbols.SubModels
{
   [SExprNode("pin")]
   public class PinModel : Model, IKiCadReadable
   {
      #region Local Props
      private PinElectricalType _electType;
      private PinGraphicStyle _graphStyle;
      private LocationModel? _location;
      private double? _len;
      private PinTextModel? _name;
      private PinTextModel? _number;
      #endregion

      #region Constructors
      public PinModel() { }
      #endregion

      #region Methods
      public void ParseNode(Node node)
      {
         if (node.Properties != null && node.Children != null)
         {
            var props = GetType().GetProperties();
            KiCadParseUtils.ParseNodes(props, node, this);
            KiCadParseUtils.ParseSubNodes(props, node, this);
            KiCadParseUtils.ParseProperties(props, node, this);
         }
      }

      public void WriteNode(StringBuilder builder, int indent, string? auxName = null)
      {
         throw new NotImplementedException();
      }
      #endregion

      #region Full Props
      [SExprProperty(1)]
      public PinElectricalType ElectricalType
      {
         get => _electType;
         set
         {
            _electType = value;
            OnPropertyChanged();
         }
      }

      [SExprProperty(2)]
      public PinGraphicStyle GraphicalStyle
      {
         get => _graphStyle;
         set
         {
            _graphStyle = value;
            OnPropertyChanged();
         }
      }

      public LocationModel? Location
      {
         get => _location;
         set
         {
            _location = value;
            OnPropertyChanged();
         }
      }

      [SExprSubNode("length")]
      public double? Length
      {
         get => _len;
         set
         {
            _len = value;
            OnPropertyChanged();
         }
      }

      [SExprNode("name")]
      public PinTextModel? Name
      {
         get => _name;
         set
         {
            _name = value;
            OnPropertyChanged();
         }
      }

      [SExprNode("number")]
      public PinTextModel? Number
      {
         get => _number;
         set
         {
            _number = value;
            OnPropertyChanged();
         }
      }
      #endregion
   }
}
