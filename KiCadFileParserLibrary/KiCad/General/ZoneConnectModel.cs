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
/// <see cref="ZoneModel">Zone</see> connection model.
/// </summary>
[SExprNode("connect_pads")]
public class ZoneConnectModel : Model, IKiCadReadable
{
   #region Local Props
   private bool _isConnected;
   private double? _clearance;
   #endregion

   #region Constructors
   /// <inheritdoc/>
   public ZoneConnectModel() { }
   #endregion

   #region Methods
   /// <inheritdoc/>
   public void ParseNode(Node node)
   {
      if (node.Properties != null && node.Children != null)
      {
         var props = GetType().GetProperties();

         KiCadParseUtils.ParseProperties(props, node, this);
         KiCadParseUtils.ParseSubNodes(props, node, this);
      }
   }
   #endregion

   #region Full Props
   /// <summary>
   /// Is zone connected.
   /// </summary>
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

   /// <summary>
   /// Zone clearance.
   /// </summary>
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
