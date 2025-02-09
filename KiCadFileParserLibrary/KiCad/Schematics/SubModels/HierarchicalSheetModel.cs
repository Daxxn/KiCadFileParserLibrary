using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.General;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.KiCad.Schematics.Collections;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

using MVVMLibrary;

namespace KiCadFileParserLibrary.KiCad.Schematics.SubModels;

[SExprNode("sheet")]
public class HierarchicalSheetModel : Model, IKiCadReadable
{
   #region Local Props
   private LocationModel _location = new();
   private SizeModel _size = new();
   private StrokeModel _stroke = new();
   private FillModel _fill = new();
   private string _id = "";
   private SchematicPropertyCollection _props = new();
   private HierarchicalPinCollection? _pins;
   private HierarchicalSheetInstanceCollection _instances = new();
   #endregion

   #region Constructors
   public HierarchicalSheetModel() { }
   #endregion

   #region Methods
   public void ParseNode(Node node)
   {
      if (node.Children is null) return;

      var props = GetType().GetProperties();
      KiCadParseUtils.ParseNodes(props, node, this);
      KiCadParseUtils.ParseSubNodes(props, node, this);
      KiCadParseUtils.ParseListNodes(props, node, this);
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

   public SizeModel Size
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

   public FillModel Fill
   {
      get => _fill;
      set
      {
         _fill = value;
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

   public SchematicPropertyCollection Properties
   {
      get => _props;
      set
      {
         _props = value;
         OnPropertyChanged();
      }
   }

   public HierarchicalPinCollection? Pins
   {
      get => _pins;
      set
      {
         _pins = value;
         OnPropertyChanged();
      }
   }

   public HierarchicalSheetInstanceCollection ProjectInstances
   {
      get => _instances;
      set
      {
         _instances = value;
         OnPropertyChanged();
      }
   }
   #endregion
}
