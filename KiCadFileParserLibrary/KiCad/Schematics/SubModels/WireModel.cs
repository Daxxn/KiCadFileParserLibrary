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

[SExprNode("wire")]
public class WireModel : Model, IKiCadReadable
{
   #region Local Props
   private CoordinateModel _points = new();
   private StrokeModel _stroke = new();
   private string _id = "";
   #endregion

   #region Constructors
   public WireModel() { }
   #endregion

   #region Methods
   public void ParseNode(Node node)
   {
      if (node.Children != null)
      {
         var props = GetType().GetProperties();

         KiCadParseUtils.ParseNodes(props, node, this);
         KiCadParseUtils.ParseSubNodes(props, node, this);
      }
   }

   public void WriteNode(StringBuilder builder, int indent, string? auxName = null)
   {
      throw new NotImplementedException();
   }
   #endregion

   #region Full Props
   public CoordinateModel Points
   {
      get => _points;
      set
      {
         _points = value;
         OnPropertyChanged();
      }
   }

   public StrokeModel Stroke
   {
      get => _stroke;
      set
      {
         _stroke = value;
         OnPropertyChanged();
      }
   }

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
