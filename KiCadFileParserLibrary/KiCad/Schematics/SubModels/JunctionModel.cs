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
/// Junction model
/// </summary>
[SExprNode("junction")]
public class JunctionModel : Model, IKiCadReadable
{
   #region Local Props
   private LocationModel _position = new();
   private double _diameter = 0;
   private ColorModel _color = new();
   private string _id = "";
   #endregion

   #region Constructors
   /// <inheritdoc/>
   public JunctionModel() { }
   #endregion

   #region Methods
   /// <inheritdoc/>
   public void ParseNode(Node node)
   {
      if (node.Children != null)
      {
         var props = GetType().GetProperties();

         KiCadParseUtils.ParseNodes(props, node, this);
         KiCadParseUtils.ParseSubNodes(props, node, this);
      }
   }
   #endregion

   #region Full Props
   /// <summary>
   /// Location coordinates
   /// </summary>
   public LocationModel Position
   {
      get => _position;
      set
      {
         _position = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Junction diameter
   /// </summary>
   [SExprSubNode("diameter")]
   public double Diameter
   {
      get => _diameter;
      set
      {
         _diameter = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Color
   /// </summary>
   [SExprSubNode("color")]
   public ColorModel Color
   {
      get => _color;
      set
      {
         _color = value;
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
   #endregion
}
