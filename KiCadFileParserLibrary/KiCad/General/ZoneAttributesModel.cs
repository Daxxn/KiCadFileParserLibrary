using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

using MVVMLibrary;

namespace KiCadFileParserLibrary.KiCad.General;

/// <summary>
/// <see cref="ZoneModel">Zone</see> attributes.
/// </summary>
[SExprNode("attr")]
public class ZoneAttributesModel : Model, IKiCadReadable
{
   #region Local Props
   private ZoneTeardropModel? _teardrop;
   #endregion

   #region Constructors
   /// <inheritdoc/>
   public ZoneAttributesModel() { }
   #endregion

   #region Methods
   /// <inheritdoc/>
   public void ParseNode(Node node)
   {
      if (node.Children != null)
      {
         var props = GetType().GetProperties();
         KiCadParseUtils.ParseNodes(props, node, this);
      }
   }
   #endregion

   #region Full Props
   /// <summary>
   /// Teardrop data.
   /// </summary>
   public ZoneTeardropModel? Teardrop
   {
      get => _teardrop;
      set
      {
         _teardrop = value;
         OnPropertyChanged();
      }
   }
   #endregion
}
