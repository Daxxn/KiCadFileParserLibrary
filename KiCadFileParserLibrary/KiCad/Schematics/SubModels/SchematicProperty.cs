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
/// Schematic property model
/// </summary>
[SExprNode("property")]
public class SchematicProperty : Model, IKiCadReadable
{
   #region Local Props
   private string _key = "";
   private string _value = "";
   private bool _showName = false;
   private LocationModel _location = new();
   private EffectsModel _effects = new();
   #endregion

   #region Constructors
   /// <inheritdoc/>
   public SchematicProperty() { }
   #endregion

   #region Methods
   /// <inheritdoc/>
   public void ParseNode(Node node)
   {
      if (node.Children is null) return;

      var props = GetType().GetProperties();

      KiCadParseUtils.ParseNodes(props, node, this);
      KiCadParseUtils.ParseSubNodes(props, node, this);
      KiCadParseUtils.ParseProperties(props, node, this);
   }
   #endregion

   #region Full Props
   /// <summary>
   /// Key
   /// </summary>
   [SExprProperty(1)]
   public string Key
   {
      get => _key;
      set
      {
         _key = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Value
   /// </summary>
   [SExprProperty(2)]
   public string Value
   {
      get => _value;
      set
      {
         _value = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Show name
   /// </summary>
   [SExprSubNode("show_name")]
   public bool ShowName
   {
      get => _showName;
      set
      {
         _showName = value;
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
   #endregion
}
