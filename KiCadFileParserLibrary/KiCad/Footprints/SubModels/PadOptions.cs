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

using static System.Runtime.InteropServices.JavaScript.JSType;

namespace KiCadFileParserLibrary.KiCad.Footprints.SubModels;

/// <summary>
/// Options used with custom pads.
/// </summary>
[SExprNode("options")]
public class PadOptions : Model, IKiCadReadable
{
   #region Local Props
   private CustomPadClearance _clearance;
   private CustomPadAnchor _anchor;
   #endregion

   #region Constructors
   /// <inheritdoc/>
   public PadOptions() { }
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
   /// Pad clearance option.
   /// </summary>
   [SExprSubNode("clearance")]
   [SExprFormatting(false, false)]
   public CustomPadClearance Clearance
   {
      get => _clearance;
      set
      {
         _clearance = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Pad achor option.
   /// </summary>
   [SExprSubNode("anchor")]
   [SExprFormatting(false, false)]
   public CustomPadAnchor Anchor
   {
      get => _anchor;
      set
      {
         _anchor = value;
         OnPropertyChanged();
      }
   }
   #endregion
}
