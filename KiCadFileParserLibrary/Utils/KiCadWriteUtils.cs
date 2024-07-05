using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.Interfaces;

namespace KiCadFileParserLibrary.Utils
{
   internal static class KiCadWriteUtils
   {
      #region Methods
      public static void WriteSubNodes(StringBuilder sb, PropertyInfo[] props, IKiCadReadable? instance, int indent)
      {
         var subNodeProps = props.Where(p => p.GetCustomAttribute<SExprSubNodeAttribute>() != null);
         foreach (var prop in subNodeProps)
         {
            var value = prop.GetValue(instance);
            if (value != null)
            {
               IndentNode(sb, indent);
               sb.AppendLine(WriteSubNodeData(prop.Name, value));
            }
         }
      }

      public static void WriteNodes(StringBuilder sb, PropertyInfo[] props, IKiCadReadable? instance, int indent)
      {
         var nodeProps = props.Where(p => GetXPath(p) != null);
         foreach (var prop in nodeProps)
         {
            var value = prop.GetValue(instance);
            if (value is IKiCadReadable val)
            {
               IndentNode(sb, indent);
               val.WriteNode(sb, indent++);
               sb.AppendLine();
            }
         }
      }
      #endregion

      #region Helper Methods
      public static string WriteSubNodeData(string name, object value)
      {
         if (value is string)
         {
            return $"({name} \"{value}\")";
         }
         else if (value is bool val)
         {
            return $"({name} {(val ? "yes" : "no")})";
         }
         else if (value is double fl)
         {
            return $"({name} {fl})";
         }
         else if (value is DateOnly date)
         {
            return $"({name} \"{date:yyyy-MM-dd}\")";
         }
         else if (value is ulong num)
         {
            if (num == 0)
            {
               return $"({name} 0x0000000_00000000)";
            }
            return $"({name} 0x{(num >> 32 & 0xFFFFFFF):X7}_{(num & 0xFFFFFFFF):X8})".ToLower();
         }
         return $"({name} {value.ToString()?.ToLower()})";
      }

      public static string? GetXPath(PropertyInfo prop)
      {
         if (prop.GetCustomAttribute<SExprNodeAttribute>() is null)
         {
            return prop.PropertyType.GetCustomAttribute<SExprNodeAttribute>()?.XPath;
         }
         else
         {
            return prop.GetCustomAttribute<SExprNodeAttribute>()?.XPath;
         }
      }

      public static void IndentNode(StringBuilder builder, int indent)
      {
         for (int i = 0; i < indent; i++)
         {
            builder.Append('\t');
         }
      }

      public static string PrintBool(bool input)
      {
         return input ? "yes" : "no";
      }
      #endregion
   }
}
