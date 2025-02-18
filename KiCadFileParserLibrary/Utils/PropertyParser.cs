using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlTypes;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace KiCadFileParserLibrary.Utils;

internal static class PropertyParser
{
   public static object? Parse(string value, PropertyInfo prop)
   {
      Type? type = null;
      if (prop.PropertyType.Name == "Nullable`1")
      {
         if (prop.PropertyType.GenericTypeArguments.Length == 1)
         {
            type = prop.PropertyType.GenericTypeArguments[0];
         }
      }
      else
      {
         type = prop.PropertyType;
      }

      if (type == null) { return null; }
      return Parse(value, type);
   }

   public static object? Parse(string value, Type type)
   {
      switch (type.Name)
      {
         case "String":
            return value;
         case "Double":
            if (double.TryParse(value, out double d))
            {
               return d;
            }
            return null;
         case "Int32":
            if (int.TryParse(value, out int i))
            {
               return i;
            }
            return null;
         case "UInt64":
            try
            {
               var cleaned = value.Replace("_", "");
               return Convert.ToUInt64(cleaned, 16);
            }
            catch (Exception)
            {
               return null;
            }
         case "Boolean":
            return value == "yes";
         case "DateTime":
            if (DateTime.TryParse(value, out DateTime date))
            {
               return date;
            }
            return null;
         case "DateOnly":
            if (DateOnly.TryParse(value, out DateOnly dateOnly))
            {
               return dateOnly;
            }
            return null;
         default:
            if (type.IsEnum)
            {
               if (Enum.TryParse(type, value, true, out object? en))
               {
                  return en;
               }
            }
            return null;
      }
   }
}
