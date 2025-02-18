using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.General;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

using MVVMLibrary;

namespace KiCadFileParserLibrary.KiCad.Schematics.SubModels;

/// <summary>
/// Wire model
/// </summary>
[SExprNode("wire")]
public class WireModel : Model, IKiCadReadable
{
   #region Local Props
   private CoordinateModel _points = new();
   private StrokeModel _stroke = new();
   private string _id = "";
   #endregion

   #region Constructors
   /// <inheritdoc/>
   public WireModel() { }
   #endregion

   #region Methods
   /// <inheritdoc/>
   public void ParseNode(Node node)
   {
      if (node.Children != null)
      {
         var props = GetType().GetProperties();

         KiCadParseUtils.ParseNodes(props, node, this);
         KiCadParseUtils.ParseSubNodes(props, node, this);
      }
   }
   #endregion

   #region Full Props
   /// <summary>
   /// List of points
   /// </summary>
   public CoordinateModel Points
   {
      get => _points;
      set
      {
         _points = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Stroke data
   /// </summary>
   public StrokeModel Stroke
   {
      get => _stroke;
      set
      {
         _stroke = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Unique ID
   /// </summary>
   [SExprSubNode("uuid")]
   public string ID
   {
      get => _id;
      set
      {
         _id = value;
         OnPropertyChanged();
      }
   }
   #endregion
}
