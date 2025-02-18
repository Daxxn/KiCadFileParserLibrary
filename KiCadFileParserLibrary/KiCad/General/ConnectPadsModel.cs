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
/// Connected pads.
/// </summary>
[SExprNode("connect_pads")]
public class ConnectPadsModel : Model, IKiCadReadable
{
   #region Local Props
   private bool _connected;
   private double _clearance;
   #endregion

   #region Constructors
   /// <inheritdoc/>
   public ConnectPadsModel() { }
   #endregion

   #region Methods
   /// <inheritdoc/>
   public void ParseNode(Node node)
   {
      if (node.Properties != null && node.Children != null)
      {
         var props = GetType().GetProperties();
         KiCadParseUtils.ParseSubNodes(props, node, this);
         KiCadParseUtils.ParseTokens(props, node, this);
      }
   }
   #endregion

   #region Full Props
   /// <summary>
   /// Is connected.
   /// </summary>
   [SExprToken("yes")]
   public bool Connected
   {
      get => _connected;
      set
      {
         _connected = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Pad clearance.
   /// </summary>
   [SExprSubNode("clearance")]
   public double Clearance
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
