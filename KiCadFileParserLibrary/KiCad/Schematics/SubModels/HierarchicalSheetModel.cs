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

/// <summary>
/// Hierarchical sheet model
/// </summary>
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
   /// <inheritdoc/>
   public HierarchicalSheetModel() { }
   #endregion

   #region Methods
   /// <inheritdoc/>
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
   /// <summary>
   /// Location coordinates
   /// </summary>
   public LocationModel Location
   {
      get => _location;
      set
      {
         _location = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Size
   /// </summary>
   public SizeModel Size
   {
      get => _size;
      set
      {
         _size = value;
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
   /// Fill data
   /// </summary>
   public FillModel Fill
   {
      get => _fill;
      set
      {
         _fill = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Unique ID.
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

   /// <summary>
   /// List of properties.
   /// </summary>
   public SchematicPropertyCollection Properties
   {
      get => _props;
      set
      {
         _props = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// List of pins.
   /// </summary>
   public HierarchicalPinCollection? Pins
   {
      get => _pins;
      set
      {
         _pins = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// List of project instances
   /// </summary>
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
