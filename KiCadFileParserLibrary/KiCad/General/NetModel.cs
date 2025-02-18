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
/// Net definition model
/// </summary>
[SExprNode("net")]
public class NetModel : Model, IKiCadReadable
{
   #region Local Props
   private int _netIndex;
   private string? _netName;
   #endregion

   #region Constructors
   /// <inheritdoc/>
   public NetModel() { }
   #endregion

   #region Methods
   /// <inheritdoc/>
   public void ParseNode(Node node)
   {
      if (node.Properties != null)
      {
         var props = GetType().GetProperties();
         KiCadParseUtils.ParseProperties(props, node, this);
      }
   }

   /// <inheritdoc/>
   public override string ToString()
   {
      return $"Net - {NetIndex} - {NetName}";
   }
   #endregion

   #region Full Props
   /// <summary>
   /// Net id number.
   /// </summary>
   [SExprProperty(1)]
   public int NetIndex
   {
      get => _netIndex;
      set
      {
         _netIndex = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Net name.
   /// </summary>
   [SExprProperty(2)]
   public string? NetName
   {
      get => _netName;
      set
      {
         _netName = value;
         OnPropertyChanged();
      }
   }
   #endregion
}
