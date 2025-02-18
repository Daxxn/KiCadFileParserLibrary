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
/// Hatched zone fill model.
/// </summary>
[SExprNode("hatch")]
public class HatchModel : Model, IKiCadReadable
{
   #region Local Props
   private HatchType? _type;
   private double? _spacing;
   #endregion

   #region Constructors
   /// <inheritdoc/>
   public HatchModel() { }
   #endregion

   #region Methods
   /// <inheritdoc/>
   public void ParseNode(Node node)
   {
      if (node.Properties != null)
      {
         var props = GetType().GetProperties();
         KiCadParseUtils.ParseProperties(props, node, this);
      }
   }
   #endregion

   #region Full Props
   /// <summary>
   /// Hatch type.
   /// </summary>
   [SExprProperty(1)]
   public HatchType? Type
   {
      get => _type;
      set
      {
         _type = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Hatch spacing.
   /// </summary>
   [SExprProperty(2)]
   public double? Spacing
   {
      get => _spacing;
      set
      {
         _spacing = value;
         OnPropertyChanged();
      }
   }
   #endregion
}
