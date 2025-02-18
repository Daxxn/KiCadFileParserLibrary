using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.General.Collections;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

using MVVMLibrary;

namespace KiCadFileParserLibrary.KiCad.General;

/// <summary>
/// List of points.
/// </summary>
[SExprNode("pts")]
public class CoordinateModel : Model, IKiCadReadable
{
   #region Local Props
   private PointCollection _points = new();
   #endregion

   #region Constructors
   /// <inheritdoc/>
   public CoordinateModel() { }
   #endregion

   #region Methods
   /// <inheritdoc/>
   public void ParseNode(Node node)
   {
      if (node.Children != null)
      {
         var props = GetType().GetProperties();

         KiCadParseUtils.ParseListNodes(props, node, this);
      }
   }
   #endregion

   #region Full Props
   /// <summary>
   /// List of points.
   /// </summary>
   public PointCollection Points
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
