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
/// <see cref="Footprint3DModel">3D Model</see> rotation data.
/// </summary>
[SExprNode("rotate")]
public class Rotate3DModel : Model, IKiCadReadable
{
   #region Local Props
   private XyzModel _rotate = new();
   #endregion

   #region Constructors
   /// <inheritdoc/>
   public Rotate3DModel() { }
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
   /// Rotation data.
   /// </summary>
   public XyzModel Rotate
   {
      get => _rotate;
      set
      {
         _rotate = value;
         OnPropertyChanged();
      }
   }
   #endregion
}
