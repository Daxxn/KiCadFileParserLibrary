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
/// <see cref="ZoneModel">Zone</see> fill segment model.
/// </summary>
[SExprNode("fill_segments")]
public class ZoneFillSegments : Model, IKiCadReadable
{
   #region Local Props
   private string _layer = "";
   private CoordinateModel? _points;
   #endregion

   #region Constructors
   /// <inheritdoc/>
   public ZoneFillSegments() { }
   #endregion

   #region Methods
   /// <inheritdoc/>
   public void ParseNode(Node node)
   {
      if (node.Properties != null && node.Children != null)
      {
         var props = GetType().GetProperties();

         KiCadParseUtils.ParseNodes(props, node, this);
         KiCadParseUtils.ParseSubNodes(props, node, this);
      }
   }
   #endregion

   #region Full Props
   /// <summary>
   /// Layer name.
   /// </summary>
   [SExprSubNode("layer")]
   public string Layer
   {
      get => _layer;
      set
      {
         _layer = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Zone fill points.
   /// </summary>
   public CoordinateModel? Points
   {
      get => _points;
      set
      {
         _points = value;
         OnPropertyChanged();
      }
   }
   #endregion
}
