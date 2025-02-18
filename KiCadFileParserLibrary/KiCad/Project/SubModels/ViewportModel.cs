using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MVVMLibrary;

using Newtonsoft.Json;

namespace KiCadFileParserLibrary.KiCad.Project.SubModels;

/// <summary>
/// Viewport model
/// </summary>
public class ViewportModel : Model
{
   #region Local Props
   private string _name = "";
   private double _height = 0;
   private double _width = 0;
   private double _x = 0;
   private double _y = 0;
   #endregion

   #region Constructors
   /// <inheritdoc/>
   public ViewportModel() { }
   #endregion

   #region Methods

   #endregion

   #region Full Props
   /// <summary>
   /// Name
   /// </summary>
   [JsonProperty(PropertyName = "name")]
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
   /// Height
   /// </summary>
   [JsonProperty(PropertyName = "h")]
   public double Height
   {
      get => _height;
      set
      {
         _height = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Width
   /// </summary>
   [JsonProperty(PropertyName = "w")]
   public double Width
   {
      get => _width;
      set
      {
         _width = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// X
   /// </summary>
   [JsonProperty(PropertyName = "x")]
   public double X
   {
      get => _x;
      set
      {
         _x = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Y
   /// </summary>
   [JsonProperty(PropertyName = "y")]
   public double Y
   {
      get => _y;
      set
      {
         _y = value;
         OnPropertyChanged();
      }
   }
   #endregion
}
