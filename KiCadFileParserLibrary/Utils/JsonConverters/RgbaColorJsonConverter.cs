using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.KiCad.Settings.Colors;

using Newtonsoft.Json;

namespace KiCadFileParserLibrary.Utils.JsonConverters;

/// <summary>
/// Converts a <see cref="RgbaColorModel"/> to and from JSON.
/// </summary>
public class RgbaColorJsonConverter : JsonConverter<RgbaColorModel>
{

   /// <summary>
   /// Reads the JSON representation of the <see cref="RgbaColorModel">Color.</see>
   /// </summary>
   /// <param name="reader">The <see cref="JsonReader"/> to read from.</param>
   /// <param name="objectType">Type of the object.</param>
   /// <param name="existingValue">The existing <see cref="RgbaColorModel">Color</see> being read.</param>
   /// <param name="hasExistingValue">The existing value has a value.</param>
   /// <param name="serializer">The calling serializer.</param>
   /// <returns>The <see cref="RgbaColorModel">Color</see> value.</returns>
   public override RgbaColorModel? ReadJson(JsonReader reader, Type objectType, RgbaColorModel? existingValue, bool hasExistingValue, JsonSerializer serializer)
   {
      if (reader.Value is null) return null;
      if (reader.ValueType == typeof(string))
      {
         var stringData = (string)reader.Value;
         return RgbaColorModel.ParseColor(stringData);
      }

      return null;
   }

   /// <summary>
   /// Writes the JSON representation of the <see cref="RgbaColorModel">RGB color.</see>
   /// </summary>
   /// <param name="writer">The <see cref="JsonWriter"/> to write to.</param>
   /// <param name="value">The <see cref="RgbaColorModel">Color</see> to serialize</param>
   /// <param name="serializer">The calling serializer.</param>
   public override void WriteJson(JsonWriter writer, RgbaColorModel? value, JsonSerializer serializer)
   {
      if (value == null) return;
      writer.WriteValue(value.ToString());
   }
}
