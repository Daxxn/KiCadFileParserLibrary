using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlTypes;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace KiCadFileParserLibrary.Utils
{
   public static class PropertyParser
   {
      //public static object? Parse(string value, PropertyInfo prop)
      //{
      //   var (typeName, isNullable) = GetTypeName(prop);
      //   switch (typeName)
      //   {
      //      case "String":
      //         return value;
      //      case "Double":
      //         if (double.TryParse(value, out double d))
      //         {
      //            return d;
      //         }
      //         return isNullable ? null : 0;
      //      case "Int32":
      //         if (int.TryParse(value, out int i))
      //         {
      //            return i;
      //         }
      //         return isNullable ? null : -1;
      //      case "UInt64":
      //         try
      //         {
      //            var cleaned = value.Replace("_", "");
      //            return Convert.ToUInt64(cleaned, 16);
      //         }
      //         catch (Exception)
      //         {
      //            return null;
      //         }
      //      case "Boolean":
      //         return value == "yes";
      //      case "DateTime":
      //         if (DateTime.TryParse(value, out DateTime date))
      //         {
      //            return date;
      //         }
      //         return isNullable ? null : DateTime.MinValue;
      //      case "DateOnly":
      //         if (DateOnly.TryParse(value, out DateOnly dateOnly))
      //         {
      //            return dateOnly;
      //         }
      //         return isNullable ? null : DateOnly.MinValue;
      //      default:
      //         if (prop.PropertyType.IsEnum)
      //         {
      //            // May not work...
      //            if (int.TryParse(value, out int enumI))
      //            {
      //               return enumI;
      //            }
      //            if (Enum.TryParse(prop.PropertyType, value, true, out object? en))
      //            {
      //               return en;
      //            }
      //         }
      //         return isNullable ? null : 0;
      //   }
      //}

      //private static (string, bool) GetTypeName(PropertyInfo prop)
      //{
      //   if (prop.PropertyType.Name == "Nullable`1")
      //   {
      //      if (prop.PropertyType.GenericTypeArguments.Length == 1)
      //      {
      //         return (prop.PropertyType.GenericTypeArguments[0].Name, true);
      //      }
      //   }
      //   return (prop.PropertyType.Name, false);
      //}


      public static object? Parse(string value, PropertyInfo prop)
      {
         Type? type = null;
         bool isNullable = false;
         if (prop.PropertyType.Name == "Nullable`1")
         {
            if (prop.PropertyType.GenericTypeArguments.Length == 1)
            {
               type = prop.PropertyType.GenericTypeArguments[0];
               isNullable = true;
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
}
