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

using static System.Net.Mime.MediaTypeNames;

namespace KiCadFileParserLibrary.KiCad.General;

/// <summary>
/// Image data model.
/// </summary>
[SExprNode("image")]
public class ImageModel : Model, IKiCadReadable
{
   #region Local Props
   private LocationModel _location = new();
   private string _layer = "";
   private double? _scale;
   private string _id = "";
   private ObservableCollection<string> _data = [];
   #endregion

   #region Constructors
   /// <inheritdoc/>
   public ImageModel() { }
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

         // Read all the image data:
         var dataNode = node.GetNode("data");
         if (dataNode != null)
         {
            if (dataNode.Properties != null)
            {
               Data = [];
               foreach (var p in dataNode.Properties[1..])
               {
                  Data.Add(p);
               }
            }
         }
      }
   }
   #endregion

   #region Full Props
   /// <summary>
   /// Location coordinates.
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
   /// Layer name.
   /// </summary>
   [SExprSubNode("layer")]
   public string Layer
   {
      get => _layer;
      set
      {
         _layer = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Image scale.
   /// </summary>
   [SExprSubNode("scale")]
   public double? Scale
   {
      get => _scale;
      set
      {
         _scale = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Unique ID.
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
   /// Base-64 encoded image data.
   /// </summary>
   public ObservableCollection<string> Data
   {
      get => _data;
      set
      {
         _data = value;
         OnPropertyChanged();
      }
   }
   #endregion
}
