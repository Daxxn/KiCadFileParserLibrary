using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

using MVVMLibrary;

namespace KiCadFileParserLibrary.KiCad.General;

/// <summary>
/// General property.
/// </summary>
[SExprNode("property")]
public class GenericProperty : Model, IKiCadReadable
{
   #region Local Props
   private string? _key;
   private string? _value;
   #endregion

   #region Constructors
   /// <inheritdoc/>
   public GenericProperty() { }
   #endregion

   #region Methods
   /// <inheritdoc/>
   public void ParseNode(Node node)
   {
      if (node.Properties is null) return;
      var props = GetType().GetProperties();
      KiCadParseUtils.ParseProperties(props, node, this);
   }
   #endregion

   #region Full Props
   /// <summary>
   /// Property key.
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
   /// Property value.
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
   #endregion
}
