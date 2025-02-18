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
/// Zone Teardrop attributes model.
/// </summary>
[SExprNode("teardrop")]
public class ZoneTeardropModel : Model, IKiCadReadable
{
   #region Local Props
   private TeardropType _type;
   #endregion

   #region Constructors
   /// <inheritdoc/>
   public ZoneTeardropModel() { }
   #endregion

   #region Methods
   /// <inheritdoc/>
   public void ParseNode(Node node)
   {
      if (node.Children != null)
      {
         var props = GetType().GetProperties();
         KiCadParseUtils.ParseSubNodes(props, node, this);
      }
   }
   #endregion

   #region Full Props
   /// <summary>
   /// Teardrop type.
   /// </summary>
   [SExprSubNode("type")]
   public TeardropType Type
   {
      get => _type;
      set
      {
         _type = value;
         OnPropertyChanged();
      }
   }
   #endregion
}
