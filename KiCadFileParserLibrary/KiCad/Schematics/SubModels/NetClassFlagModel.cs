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
/// Net class flag model
/// </summary>
[SExprNode("netclass_flag")]
public class NetClassFlagModel : Model, IKiCadReadable
{
   #region Local Props
   private string _name = "";
   private double _len = 0;
   private NetClassShape _shape = NetClassShape.Circle;
   private LocationModel _location = new();
   private EffectsModel _effects = new();
   private string _id = "";
   private SchematicPropertyCollection _props = new();
   #endregion

   #region Constructors
   /// <inheritdoc/>
   public NetClassFlagModel() { }
   #endregion

   #region Methods
   /// <inheritdoc/>
   public void ParseNode(Node node)
   {
      if (node.Children != null && node.Properties != null)
      {
         var props = GetType().GetProperties();
         KiCadParseUtils.ParseNodes(props, node, this);
         KiCadParseUtils.ParseProperties(props, node, this);
         KiCadParseUtils.ParseSubNodes(props, node, this);
         KiCadParseUtils.ParseListNodes(props, node, this);
      }
   }
   #endregion

   #region Full Props
   /// <summary>
   /// Net class name
   /// </summary>
   [SExprProperty(1)]
   public string Name
   {
      get => _name;
      set
      {
         _name = value;
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
   /// Flag shape
   /// </summary>
   [SExprSubNode("shape")]
   public NetClassShape Shape
   {
      get => _shape;
      set
      {
         _shape = value;
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
   /// Font effects
   /// </summary>
   public EffectsModel Effects
   {
      get => _effects;
      set
      {
         _effects = value;
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

   /// <summary>
   /// List of properties
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
   #endregion
}
