using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.General;
using KiCadFileParserLibrary.KiCad.General.Collections;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

using MVVMLibrary;

namespace KiCadFileParserLibrary.KiCad.Boards.SubModels;

/// <summary>
/// List of base line coupled <see cref="CoordinateModel">Coordinates.</see>
/// </summary>
[SExprNode("base_line_coupled")]
public class BaselineCoupledModel : Model, IKiCadReadable
{
   #region Local Props
   private CoordinateModel _points = new();
   #endregion

   #region Constructors
   /// <inheritdoc/>
   public BaselineCoupledModel() { }
   #endregion

   #region Methods
   /// <inheritdoc/>
   public void ParseNode(Node node)
   {
      if (node.Children != null)
      {
         var props = GetType().GetProperties();

         KiCadParseUtils.ParseListNodes(props, node, this);
         KiCadParseUtils.ParseNodes(props, node, this);
      }
   }

   /// <inheritdoc/>
   public override string ToString() => $"Baseline Coupled Model - Points: {Coordinates.Points.Points.Count}";
   #endregion

   #region Full Props
   /// <summary>
   /// List of <see cref="CoordinateModel">Coordinates.</see>
   /// </summary>
   public CoordinateModel Coordinates
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
