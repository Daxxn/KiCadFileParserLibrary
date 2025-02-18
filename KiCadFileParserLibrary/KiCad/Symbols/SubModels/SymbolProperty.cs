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
/// Symbol property
/// </summary>
[SExprNode("property")]
public class SymbolProperty : Model, IKiCadReadable
{
   #region Local Props
   private string? _key;
   private string? _value;
   private LocationModel? _location;
   private EffectsModel? _effects;
   #endregion

   #region Constructors
   /// <inheritdoc/>
   public SymbolProperty() { }
   #endregion

   #region Methods
   /// <inheritdoc/>
   public void ParseNode(Node node)
   {
      if (node.Children != null && node.Properties != null)
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
   /// Key
   /// </summary>
   [SExprProperty(1)]
   public string? Key
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
   public string? Value
   {
      get => _value;
      set
      {
         _value = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Location coordinates
   /// </summary>
   public LocationModel? Location
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
   public EffectsModel? Effects
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
