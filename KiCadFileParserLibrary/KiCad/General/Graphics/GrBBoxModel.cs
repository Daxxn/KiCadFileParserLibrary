using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

namespace KiCadFileParserLibrary.KiCad.General.Graphics;

/// <summary>
/// General bordered box graphic.
/// </summary>
[SExprNode("gr_bbox")]
public class GrBBoxModel : GraphicBase
{
   #region Local Props
   private XyModel? _start;
   private XyModel? _end;
   #endregion

   #region Constructors
   /// <inheritdoc/>
   public GrBBoxModel() { }
   #endregion

   #region Methods
   /// <inheritdoc/>
   public override void ParseNode(Node node)
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
   /// Start coordinates.
   /// </summary>
   [SExprNode("start")]
   public XyModel? Start
   {
      get => _start;
      set
      {
         _start = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// End coordinates.
   /// </summary>
   [SExprNode("end")]
   public XyModel? End
   {
      get => _end;
      set
      {
         _end = value;
         OnPropertyChanged();
      }
   }
   #endregion
}
