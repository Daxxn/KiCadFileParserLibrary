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

[SExprNode("bus_entry")]
public class BusEntryModel : Model, IKiCadReadable
{
   #region Local Props
   private LocationModel _location = new();
   private XyModel _size = new();
   private StrokeModel _stroke = new();
   private string _id = "";
   #endregion

   #region Constructors
   public BusEntryModel() { }
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
   #endregion

   #region Full Props
   public LocationModel Location
   {
      get => _location;
      set
      {
         _location = value;
         OnPropertyChanged();
      }
   }

   [SExprNode("size")]
   public XyModel Size
   {
      get => _size;
      set
      {
         _size = value;
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
