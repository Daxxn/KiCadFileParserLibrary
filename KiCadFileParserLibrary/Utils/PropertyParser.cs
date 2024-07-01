using System;
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
         switch (prop.PropertyType.Name)
         {
            case "String":
               return value;
            case "Int32":
               if (int.TryParse(value, out int i))
               {
                  return i;
               }
               return -1;
            case "Double":
               if (double.TryParse(value, out double d))
               {
                  return d;
               }
               return 0;
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
   }
}
