using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MVVMLibrary;

using Newtonsoft.Json;

namespace KiCadFileParserLibrary.KiCad.Project.SubModels;
public class Viewport3DModel : Model
{
   #region Local Props
   private string _name = "3D Viewport";
   private double _ww;
   private double _wx;
   private double _wy;
   private double _wz;
   private double _xw;
   private double _xx;
   private double _xy;
   private double _xz;
   private double _yw;
   private double _yx;
   private double _yy;
   private double _yz;
   private double _zw;
   private double _zx;
   private double _zy;
   private double _zz;
   #endregion

   #region Constructors
   public Viewport3DModel() { }
   #endregion

   #region Methods

   #endregion

   #region Full Props
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

   [JsonProperty(PropertyName = "ww")]
   public double WW
   {
      get => _ww;
      set
      {
         _ww = value;
         OnPropertyChanged();
      }
   }

   [JsonProperty(PropertyName = "wx")]
   public double WX
   {
      get => _wx;
      set
      {
         _wx = value;
         OnPropertyChanged();
      }
   }

   [JsonProperty(PropertyName = "wy")]
   public double WY
   {
      get => _wy;
      set
      {
         _wy = value;
         OnPropertyChanged();
      }
   }

   [JsonProperty(PropertyName = "wz")]
   public double WZ
   {
      get => _wz;
      set
      {
         _wz = value;
         OnPropertyChanged();
      }
   }

   [JsonProperty(PropertyName = "xw")]
   public double XW
   {
      get => _xw;
      set
      {
         _xw = value;
         OnPropertyChanged();
      }
   }

   [JsonProperty(PropertyName = "xx")]
   public double XX
   {
      get => _xx;
      set
      {
         _xx = value;
         OnPropertyChanged();
      }
   }

   [JsonProperty(PropertyName = "xy")]
   public double XY
   {
      get => _xy;
      set
      {
         _xy = value;
         OnPropertyChanged();
      }
   }

   [JsonProperty(PropertyName = "xz")]
   public double XZ
   {
      get => _xz;
      set
      {
         _xz = value;
         OnPropertyChanged();
      }
   }

   [JsonProperty(PropertyName = "yw")]
   public double YW
   {
      get => _yw;
      set
      {
         _yw = value;
         OnPropertyChanged();
      }
   }

   [JsonProperty(PropertyName = "yx")]
   public double YX
   {
      get => _yx;
      set
      {
         _yx = value;
         OnPropertyChanged();
      }
   }

   [JsonProperty(PropertyName = "yy")]
   public double YY
   {
      get => _yy;
      set
      {
         _yy = value;
         OnPropertyChanged();
      }
   }

   [JsonProperty(PropertyName = "yz")]
   public double YZ
   {
      get => _yz;
      set
      {
         _yz = value;
         OnPropertyChanged();
      }
   }

   [JsonProperty(PropertyName = "zw")]
   public double ZW
   {
      get => _zw;
      set
      {
         _zw = value;
         OnPropertyChanged();
      }
   }

   [JsonProperty(PropertyName = "zx")]
   public double ZX
   {
      get => _zx;
      set
      {
         _zx = value;
         OnPropertyChanged();
      }
   }

   [JsonProperty(PropertyName = "zy")]
   public double ZY
   {
      get => _zy;
      set
      {
         _zy = value;
         OnPropertyChanged();
      }
   }

   [JsonProperty(PropertyName = "zz")]
   public double ZZ
   {
      get => _zz;
      set
      {
         _zz = value;
         OnPropertyChanged();
      }
   }
   #endregion
}
