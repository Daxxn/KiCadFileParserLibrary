using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.KiCad.Settings.Colors;

using Newtonsoft.Json;

namespace KiCadFileParserLibrary.Utils.JsonConverters;

/// <summary>
/// Converts a list of <see cref="RgbaColorModel">Colors</see> to and from JSON.
/// </summary>
public class RgbaColorListJsonConverter : JsonConverter<IEnumerable<RgbaColorModel>>
{
   /// <summary>
   /// Reads the JSON representation of the objects.
   /// </summary>
   /// <param name="reader">The <see cref="JsonReader"/> to read from.</param>
   /// <param name="objectType">Type of the object.</param>
   /// <param name="existingValue">The existing list of <see cref="RgbaColorModel">Colors</see> being read.</param>
   /// <param name="hasExistingValue">The existing value has a value.</param>
   /// <param name="serializer">The calling serializer.</param>
   /// <returns>The list of <see cref="RgbaColorModel">Colors.</see></returns>
   public override IEnumerable<RgbaColorModel>? ReadJson(JsonReader reader, Type objectType, IEnumerable<RgbaColorModel>? existingValue, bool hasExistingValue, JsonSerializer serializer)
   {
      if (!hasExistingValue) return null;
      if (reader.TokenType == JsonToken.StartArray)
      {
         ObservableCollection<RgbaColorModel> output = [];
         while (reader.TokenType != JsonToken.EndArray)
         {
            reader.Read();
            if (reader.ValueType == typeof(string))
            {
               var color = RgbaColorModel.ParseColor((string)reader.Value!);
               if (color != null)
               {
                  output.Add(color);
               }
            }
         }
         return output;
      }
      return null;
   }

   /// <summary>
   /// Writes the JSON representation of the <see cref="RgbaColorModel">Colors.</see>
   /// </summary>
   /// <param name="writer">The <see cref="JsonWriter"/> to write to.</param>
   /// <param name="value">The list of <see cref="RgbaColorModel">Colors.</see></param>
   /// <param name="serializer">The calling serializer.</param>
   public override void WriteJson(JsonWriter writer, IEnumerable<RgbaColorModel>? value, JsonSerializer serializer)
   {
      if (value == null) return;
      writer.WriteStartArray();
      foreach (var color in value)
      {
         writer.WriteValue(color.ToString());
      }
      writer.WriteEndArray();
   }
}
