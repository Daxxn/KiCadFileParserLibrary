using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.Interfaces;

using Newtonsoft.Json.Linq;

namespace KiCadFileParserLibrary.Utils;
internal static class KiCadWriteUtils2
{
   #region Private Classes
   private class KiCadNodeSortAttributes
   {
      public PropertyInfo Prop { get; set; } = null!;
      public string? Name { get; set; }

      public KiCadNodeSortAttributes(PropertyInfo prop, string? name)
      {
         Prop = prop;
         Name = name;
      }
   }
   #endregion

   #region Local Props

   #endregion

   #region Methods
   public static void WriteNode(IKiCadReadable obj, StringBuilder builder, int indent, string? xPath = null)
   {
      var props = obj.GetType().GetProperties();
      var nodeAttr = obj.GetType().GetCustomAttribute<SExprNodeAttribute>() ?? throw new Exception("Unable to find SExpression Node Attribute");
      var kiPropsInlineProps = props.Where(p => p.GetCustomAttribute<SExprPropertyAttribute>() != null).ToList();
      var kiPropsChildNodes = props.Where(p => p.PropertyType.GetCustomAttribute<SExprNodeAttribute>() != null).ToList();
      var kiPropsSubNodes = props.Where(p => p.GetCustomAttribute<SExprSubNodeAttribute>() != null).ToList();
      var kiPropsTokens = props.Where(p => p.GetCustomAttribute<SExprTokenAttribute>() != null).ToList();
      var kiPropsListNodes = props.Where(p => p.PropertyType.GetCustomAttribute<SExprListNodeAttribute>() != null).ToList();
      var kiPropsPropListNodes = props.Where(p => p.GetCustomAttribute<SExprPropArrayAttribute>() != null).ToList();

      builder.Append('\t', indent);
      builder.Append($"({xPath ?? nodeAttr.XPath}");

      if (kiPropsInlineProps != null)
      {
         WriteProps(obj, builder, kiPropsInlineProps);
      }

      if (kiPropsTokens != null)
      {
         WriteTokens(obj, builder, kiPropsTokens);
      }

      if (kiPropsSubNodes.Count == 0 && kiPropsChildNodes.Count == 0 && kiPropsListNodes.Count == 0)
      {
         builder.AppendLine(")");
         return;
      }

      builder.AppendLine();

      // Write SubNodes:
      Dictionary<int, KiCadNodeSortAttributes> tempChildren = [];
      int currentCount = 0;
      int fullCount = kiPropsSubNodes.Count + kiPropsChildNodes.Count;
      if (kiPropsSubNodes != null)
      {
         foreach (var prop in kiPropsSubNodes)
         {
            var value = prop.GetValue(obj);
            var subNodeAttr = prop.GetCustomAttribute<SExprSubNodeAttribute>() ?? prop.PropertyType.GetCustomAttribute<SExprSubNodeAttribute>();
            if (subNodeAttr is null) throw new Exception("Unable to find SExpression Subnode Attribute.");

            if (value != null)
            {
               if (subNodeAttr?.Index == -1)
               {
                  tempChildren.Add(fullCount + currentCount, new(prop, subNodeAttr?.XPath ?? prop.Name.ToLower()));
                  currentCount++;
               }
               else
               {
                  tempChildren.Add(subNodeAttr!.Index, new(prop, subNodeAttr?.XPath ?? prop.Name.ToLower()));
               }
            }
         }
      }

      // Write Prop Lists
      if (kiPropsPropListNodes != null)
      {
         foreach (var prop in kiPropsPropListNodes)
         {
            var value = prop.GetValue(obj);
            var listpropAttr = prop.GetCustomAttribute<SExprPropArrayAttribute>();
            if (listpropAttr is null) throw new Exception("Unable to find SExpression Prop Array Attribute.");

            if (value != null)
            {
               if (listpropAttr.Index == -1)
               {
                  tempChildren.Add(fullCount + currentCount, new(prop, listpropAttr.XPath));
                  currentCount++;
               }
               else
               {
                  tempChildren.Add(listpropAttr!.Index, new(prop, listpropAttr.XPath));
               }
            }
         }
      }

      // Write Nodes:
      if (kiPropsChildNodes != null)
      {
         foreach (var prop in kiPropsChildNodes)
         {
            var value = prop.GetValue(obj);
            var childAttr = prop.GetCustomAttribute<SExprNodeAttribute>() ?? prop.PropertyType.GetCustomAttribute<SExprNodeAttribute>();
            if (childAttr is null) throw new Exception("Unable to find SExpression Node Attribute.");

            if (value is IKiCadReadable childObj)
            {
               if (childAttr?.Index == -1)
               {
                  tempChildren.Add(fullCount + currentCount, new(prop, childAttr?.XPath));
                  currentCount++;
               }
               else
               {
                  tempChildren.Add(childAttr!.Index, new(prop, childAttr?.XPath));
               }
            }
         }
      }

      if (kiPropsListNodes != null)
      {
         foreach (var prop in kiPropsListNodes)
         {
            var value = prop.GetValue(obj);
            var childAttr = prop.GetCustomAttribute<SExprListNodeAttribute>() ?? prop.PropertyType.GetCustomAttribute<SExprListNodeAttribute>();
            if (childAttr is null) throw new Exception("Unable to find SExpression List Node Attribute.");

            if (value is IKiCadReadable childObj)
            {
               if (childAttr?.Index == -1)
               {
                  tempChildren.Add(fullCount + currentCount, new(prop, childAttr?.Name));
                  currentCount++;
               }
               else
               {
                  tempChildren.Add(childAttr!.Index, new(prop, childAttr?.Name));
               }
            }
         }
      }

      if (tempChildren.Count != 0)
      {
         foreach (var k in tempChildren.Keys.Order())
         {
            var value = tempChildren[k].Prop.GetValue(obj)!;
            if (value is IKiCadReadable kiObj)
            {
               if (value is IKiCadWriteableCollection kiColl)
               {
                  var listObj = tempChildren[k].Prop.GetValue(obj);
                  if (listObj is IKiCadWriteableCollection childObj)
                  {
                     childObj.WriteCollection(builder, indent + 1);
                  }
               }
               else
               {
                  WriteNode(kiObj, builder, indent + 1, tempChildren[k].Name);
               }
            }
            else
            {
               var options = tempChildren[k].Prop.GetCustomAttribute<SExprFormattingAttribute>();
               if (options != null)
               {
                  WriteSubNode(builder, tempChildren[k].Name!, value, indent + 1, options);
                  //builder.Append('\t', indent + 1);
                  //builder.AppendLine(WriteSubNode(tempChildren[k].Name!, value));
               }
               else
               {
                  builder.Append('\t', indent + 1);
                  builder.AppendLine(WriteSubNode(tempChildren[k].Name!, value));
               }
            }
         }
      }

      //if (kiPropsListNodes != null)
      //{
      //   foreach (var prop in kiPropsListNodes)
      //   {
      //      var listObj = prop.GetValue(obj);
      //      if (listObj is IKiCadWriteableCollection childObj)
      //      {
      //         childObj.WriteCollection(builder, indent + 1);
      //      }
      //   }
      //}

      builder.Append('\t', indent);
      builder.AppendLine(")");
   }

   private static void WriteProps(IKiCadReadable obj, StringBuilder builder, List<PropertyInfo> props)
   {
      foreach (var prop in props)
      {
         var val = prop.GetValue(obj);
         if (val != null)
         {
            builder.Append(' ');
            builder.Append(WriteValue(val));
         }
      }
   }

   private static void WriteSubNode(StringBuilder sb, string name, object? value, int indent, SExprFormattingAttribute options)
   {
      if (options.IgnoreIfNull && value is null) return;
      if (value is null) return;
      sb.Append('\t', indent);
      if (options.ExportAsInt)
      {
         sb.AppendLine($"({name} {(int)value})");
      }
      else
      {
         sb.AppendLine($"({name} {WriteValue(value)})");
      }
   }

   private static string WriteSubNode(string name, object value)
   {
      return $"({name} {WriteValue(value)})";
   }

   private static string? WriteValue(object value)
   {
      if (value is string str)
      {
         return $"\"{str}\"";
      }
      else if (value is bool b)
      {
         return b ? "yes" : "no";
      }
      else if (value is double d)
      {
         return $"{d}";
      }
      else if (value is ulong num)
      {
         if (num == 0)
         {
            return "0x0000000_00000000";
         }
         return $"0x{(num >> 32 & 0xFFFFFFF):X7}_{(num & 0xFFFFFFFF):X8}".ToLower();
      }
      else if (value is DateOnly date)
      {
         return $"\"{date:yyyy-MM-dd}\"";
      }
      else if (value.GetType().Name == "ObservableCollection`1")
      {
         List<string> values = [];
         var enumr = value.GetType().BaseType?.GetMethod("GetEnumerator");
         if (enumr?.Invoke(value, []) is IEnumerator enumerator)
         {
            while(enumerator.MoveNext())
            {
               var strItem = WriteValue(enumerator.Current);
               if (strItem != null)
               {
                  values.Add(strItem);
               }
            }
         }
         return string.Join(" ", values);
      }

      return value.ToString()?.ToLower();
   }



   private static void WriteTokens(IKiCadReadable obj, StringBuilder builder, List<PropertyInfo> props)
   {
      foreach (var prop in props)
      {
         var value = prop.GetValue(obj);
         if (value is bool val)
         {
            if (val)
            {
               builder.Append(' ');
               builder.Append(prop.GetCustomAttribute<SExprTokenAttribute>()!.TokenName);
            }
         }
         else throw new Exception("Unable to write token. Type is not a boolean. ALL tokens must be a bool.");
      }
   }
   #endregion
}
