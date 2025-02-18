using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

using MVVMLibrary;

namespace KiCadFileParserLibrary.KiCad.General.Graphics;

/// <summary>
/// Cached font and text render data.
/// </summary>
[SExprNode("render_cache")]
public class RenderCacheModel : Model, IKiCadReadable
{
   #region Local Props
   private string? _text = "";
   private int _angle = 0;
   private ObservableCollection<PolygonModel> _polygon = [];
   #endregion

   #region Constructors
   /// <inheritdoc/>
   public RenderCacheModel() { }
   #endregion

   #region Methods
   /// <inheritdoc/>
   public void ParseNode(Node node)
   {
      if (node.Properties != null && node.Children != null)
      {
         var props = GetType().GetProperties();

         KiCadParseUtils.ParseProperties(props, node, this);

         var polygons = node.GetNodes("polygon");
         if (polygons is null) return;
         foreach (var poly in polygons)
         {
            PolygonModel newPoly = new();
            newPoly.ParseNode(poly);
            Polygon.Add(newPoly);
         }
      }
   }
   #endregion

   #region Full Props
   /// <summary>
   /// Display text.
   /// </summary>
   [SExprProperty(1)]
   public string? Text
   {
      get => _text;
      set
      {
         _text = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Text angle.
   /// </summary>
   [SExprProperty(2)]
   public int Angle
   {
      get => _angle;
      set
      {
         _angle = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// List of text polygons.
   /// </summary>
   public ObservableCollection<PolygonModel> Polygon
   {
      get => _polygon;
      set
      {
         _polygon = value;
         OnPropertyChanged();
      }
   }
   #endregion
}
