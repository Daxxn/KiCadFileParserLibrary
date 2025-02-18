using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MVVMLibrary;

namespace KiCadFileParserLibrary.KiCad.Settings.Colors;

/// <summary>
/// RGBA color used for editor themes.
/// </summary>
public class RgbaColorModel : Model
{
   #region Local Props
   private byte _red;
   private byte _green;
   private byte _blue;
   private double _alpha;
   #endregion

   #region Constructors
   /// <inheritdoc/>
   public RgbaColorModel() { }
   #endregion

   #region Methods
   /// <summary>
   /// Parse JSON value.
   /// </summary>
   /// <param name="input">Raw JSON input.</param>
   /// <returns>The parsed <see cref="RgbaColorModel"/>.</returns>
   public static RgbaColorModel? ParseColor(string input)
   {
      var output = new RgbaColorModel();
      if (input.StartsWith("rgba"))
      {
         var strSplit = input[5..^1].Split(", ", StringSplitOptions.RemoveEmptyEntries);
         if (strSplit.Length == 4)
         {
            if (byte.TryParse(strSplit[0], out var red))
            {
               output.Red = red;
            }
            if (byte.TryParse(strSplit[1], out var green))
            {
               output.Green = green;
            }
            if (byte.TryParse(strSplit[2], out var blue))
            {
               output.Blue = blue;
            }
            if (double.TryParse(strSplit[3], out var alpha))
            {
               output.Alpha = alpha;
            }
            return output;
         }
      }
      else if (input.StartsWith("rgb"))
      {
         var strSplit = input[4..^1].Split(", ", StringSplitOptions.RemoveEmptyEntries);
         if (strSplit.Length == 3)
         {
            if (byte.TryParse(strSplit[0], out var red))
            {
               output.Red = red;
            }
            if (byte.TryParse(strSplit[1], out var green))
            {
               output.Green = green;
            }
            if (byte.TryParse(strSplit[2], out var blue))
            {
               output.Blue = blue;
            }
            output.Alpha = 1;
            return output;
         }
      }
      return null;
   }

   /// <inheritdoc/>
   public override string ToString() => $"rgba({Red}, {Green}, {Blue}, {Alpha})";
   #endregion

   #region Full Props
   /// <summary>
   /// </summary>
   public byte Red
   {
      get => _red;
      set
      {
         _red = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// </summary>
   public byte Green
   {
      get => _green;
      set
      {
         _green = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// </summary>
   public byte Blue
   {
      get => _blue;
      set
      {
         _blue = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// </summary>
   public double Alpha
   {
      get => _alpha;
      set
      {
         _alpha = value;
         OnPropertyChanged();
      }
   }
   #endregion
}
