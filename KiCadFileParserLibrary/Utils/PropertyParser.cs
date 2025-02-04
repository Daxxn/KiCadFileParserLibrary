﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace KiCadFileParserLibrary.Utils
{
   public static class PropertyParser
   {
      public static object? Parse(string value, PropertyInfo prop)
      {
         switch (GetTypeName(prop))
         {
            case "String":
               return value;
            case "Double":
               if (double.TryParse(value, out double d))
               {
                  return d;
               }
               return 0;
            case "Int32":
               if (int.TryParse(value, out int i))
               {
                  return i;
               }
               return -1;
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
            default:
               if (prop.PropertyType.IsEnum)
               {
                  // May not work...
                  if (int.TryParse(value, out int enumI))
                  {
                     return enumI;
                  }
                  if (Enum.TryParse(prop.PropertyType, value, true, out object? en))
                  {
                     return en;
                  }
               }
               return null;
         }
      }

      private static string GetTypeName(PropertyInfo prop)
      {
         if (prop.PropertyType.IsEnum)
         {

         }
         if (prop.PropertyType.Name == "Nullable`1")
         {
            var newName = prop.PropertyType.FullName!.Replace("System.Nullable`1[[System.", "");
            return newName.Remove(newName.IndexOf(","));
         }
         return prop.PropertyType.Name;
      }
   }
}
