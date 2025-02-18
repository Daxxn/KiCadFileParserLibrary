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

namespace KiCadFileParserLibrary.KiCad.Footprints.SubModels;

/// <summary>
/// 3D model offset coordinates.
/// </summary>
[SExprNode("offset")]
public class Offset3DModel : Model, IKiCadReadable
{
   #region Local Props
   private XyzModel _offset = new();
   #endregion

   #region Constructors
   /// <inheritdoc/>
   public Offset3DModel() { }
   #endregion

   #region Methods
   /// <inheritdoc/>
   public void ParseNode(Node node)
   {
      if (node.Children is null) return;

      var props = GetType().GetProperties();

      KiCadParseUtils.ParseNodes(props, node, this);
   }
   #endregion

   #region Full Props
   /// <summary>
   /// Offset coordinates.
   /// </summary>
   public XyzModel Offset
   {
      get => _offset;
      set
      {
         _offset = value;
         OnPropertyChanged();
      }
   }

   #endregion
}
