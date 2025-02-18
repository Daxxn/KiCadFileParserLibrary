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

namespace KiCadFileParserLibrary.KiCad.Symbols.SubModels;

/// <summary>
/// Pin model
/// </summary>
[SExprNode("pin")]
public class PinModel : Model, IKiCadReadable
{
   #region Local Props
   private PinElectricalType _electType;
   private PinGraphicStyle _graphStyle;
   private LocationModel _location = new();
   private double _len;
   private PinVisibility? _visible = null;
   private PinTextModel _name = new();
   private PinTextModel _number = new();
   #endregion

   #region Constructors
   /// <inheritdoc/>
   public PinModel() { }
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
         KiCadParseUtils.ParseProperties(props, node, this);
      }
   }
   #endregion

   #region Full Props
   /// <summary>
   /// Pin electrical type
   /// </summary>
   [SExprProperty(1)]
   public PinElectricalType ElectricalType
   {
      get => _electType;
      set
      {
         _electType = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Pin display style
   /// </summary>
   [SExprProperty(2)]
   public PinGraphicStyle GraphicalStyle
   {
      get => _graphStyle;
      set
      {
         _graphStyle = value;
         OnPropertyChanged();
      }
   }

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
   /// Length
   /// </summary>
   [SExprSubNode("length")]
   public double Length
   {
      get => _len;
      set
      {
         _len = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Name
   /// </summary>
   [SExprNode("name")]
   public PinTextModel Name
   {
      get => _name;
      set
      {
         _name = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Number
   /// </summary>
   [SExprNode("number")]
   public PinTextModel Number
   {
      get => _number;
      set
      {
         _number = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Pin visibility
   /// </summary>
   [SExprProperty(3)]
   [SExprFormatting(false, true)]
   public PinVisibility? Visible
   {
      get => _visible;
      set
      {
         _visible = value;
         OnPropertyChanged();
      }
   }
   #endregion
}
