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

namespace KiCadFileParserLibrary.KiCad.General
{
   [SExprNode("connect_pads")]
   public class ZoneConnectModel : Model, IKiCadReadable
   {
      #region Local Props
      private bool _isConnected;
      private double? _clearance;
      #endregion

      #region Constructors
      public ZoneConnectModel() { }
      #endregion

      #region Methods
      public void ParseNode(Node node)
      {
         if (node.Properties != null && node.Children != null)
         {
            var props = GetType().GetProperties();

            KiCadParseUtils.ParseProperties(props, node, this);
            KiCadParseUtils.ParseSubNodes(props, node, this);
         }
      }

      public void WriteNode(StringBuilder builder, int indent, string? auxName = null)
      {
         throw new NotImplementedException();
      }
      #endregion

      #region Full Props
      [SExprProperty(1)]
      public bool IsConnected
      {
         get => _isConnected;
         set
         {
            _isConnected = value;
            OnPropertyChanged();
         }
      }

      [SExprSubNode("clearance")]
      public double? Clearance
      {
         get => _clearance;
         set
         {
            _clearance = value;
            OnPropertyChanged();
         }
      }
      #endregion
   }
}
