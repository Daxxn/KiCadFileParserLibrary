using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.SExprParser;

namespace KiCadFileParserLibrary.Utils;

/// <summary>
/// KiCad file parser utilities
/// </summary>
internal static class KiCadParseUtils
{
   #region Methods
   /// <summary>
   /// Parse the current <see cref="Node">SExpression Node</see> and write the data to the provided object.
   /// </summary>
   /// <param name="props">List of properties for the current object.</param>
   /// <param name="node">The current <see cref="Node"/>.</param>
   /// <param name="obj">The object to write to.</param>
   public static void ParseNodes(PropertyInfo[] props, Node node, object obj)
   {
      var classProps = props.Where(p => p.PropertyType.GetCustomAttribute<SExprNodeAttribute>() != null).ToArray();
      foreach (var cProp in classProps)
      {
         var objNode = node.GetNode(GetXPath(cProp)!);
         if (objNode != null)
         {
            var newObj = cProp.PropertyType.GetConstructor([])!.Invoke(null);
            if (newObj is IKiCadReadable readableProp)
            {
               readableProp.ParseNode(objNode);
            }
            cProp.SetValue(obj, newObj);
         }
      }
   }

   /// <summary>
   /// Parse a list of <see cref="Node">SExpression Nodes</see> and add them to the provided object.
   /// </summary>
   /// <param name="props">List of properties for the current object.</param>
   /// <param name="node">The current <see cref="Node"/>.</param>
   /// <param name="obj">The object to write to.</param>
   public static void ParseListNodes(PropertyInfo[] props, Node node, object obj)
   {
      var classProps = props.Where(p => p.PropertyType.GetCustomAttribute<SExprListNodeAttribute>() != null).ToArray();
      foreach (var cProp in classProps)
      {
         var newObj = cProp.PropertyType.GetConstructor([])!.Invoke(null);
         if (newObj is IKiCadReadable readableProp)
         {
            readableProp.ParseNode(node);
         }
         cProp.SetValue(obj, newObj);
      }
   }

   /// <summary>
   /// Parse all <see cref="Node">Sub-Nodes</see> and write the data to the provided object.
   /// </summary>
   /// <param name="props">List of properties for the current object.</param>
   /// <param name="node">The parent <see cref="Node"/>.</param>
   /// <param name="obj">The object to write to.</param>
   public static void ParseSubNodes(PropertyInfo[] props, Node node, object obj)
   {
      var subNodeProps = props.Where(p => p.GetCustomAttribute<SExprSubNodeAttribute>() != null);
      foreach (var prop in subNodeProps)
      {
         var subNodeAttr = prop.GetCustomAttribute<SExprSubNodeAttribute>()!;
         var subNode = node.GetNode(subNodeAttr.XPath);
         if (subNode != null)
         {
            if (subNode.Properties != null)
            {
               prop.SetValue(obj, PropertyParser.Parse(subNode.Properties[1], prop));
            }
         }
      }
   }

   /// <summary>
   /// Parse all <see cref="Node"/> properties and write the data to the provided object.
   /// </summary>
   /// <param name="props">List of properties for the current object.</param>
   /// <param name="node">The parent <see cref="Node"/>.</param>
   /// <param name="obj">The object to write to.</param>
   public static void ParseProperties(PropertyInfo[] props, Node node, object obj)
   {
      foreach (var prop in props)
      {
         var attr = prop.GetCustomAttribute<SExprPropertyAttribute>();
         if (attr != null)
         {
            if (node.Properties!.Count > attr.PropertyIndex.Value)
            {
               prop.SetValue(obj, PropertyParser.Parse(node.Properties[attr.PropertyIndex], prop));
            }
         }
      }
   }

   /// <summary>
   /// A specialized version of <seealso cref="ParseSubNodes(PropertyInfo[], Node, object)"/> that parses all properties as a list.
   /// </summary>
   /// <param name="props">List of properties for the current object.</param>
   /// <param name="node">The parent <see cref="Node"/>.</param>
   /// <param name="obj">The object to write to.</param>
   public static void ParsePropLists(PropertyInfo[] props, Node node, object obj)
   {
      foreach (var prop in props)
      {
         var attr = prop.GetCustomAttribute<SExprPropArrayAttribute>();
         if (attr != null)
         {
            var propNode = node.GetNode(attr.XPath);
            if (propNode?.Properties?.Count > 1)
            {
               if (prop.PropertyType.GenericTypeArguments.Length == 1 && prop.PropertyType.Name == "ObservableCollection`1")
               {
                  var addMethod = prop.PropertyType.BaseType?.GetMethod("Add");
                  var ctor = prop.PropertyType.GetConstructor([]);
                  if (addMethod != null && ctor != null)
                  {
                     var newList = ctor.Invoke([]);
                     foreach (var item in propNode.Properties[1..])
                     {
                        var val = PropertyParser.Parse(item, prop.PropertyType.GenericTypeArguments[0]);
                        if (val != null)
                        {
                           addMethod.Invoke(newList, [val]);
                        }
                     }
                     prop.SetValue(obj, newList);
                  }
               }
            }
         }
      }
   }

   /// <summary>
   /// Parse all individual tokens from the <see cref="Node">Parent Node</see> and write the data to the provided object.
   /// </summary>
   /// <param name="props">List of properties for the current object.</param>
   /// <param name="node">The parent <see cref="Node"/>.</param>
   /// <param name="obj">The object to write to.</param>
   public static void ParseTokens(PropertyInfo[] props, Node node, object obj)
   {
      var tokenProps = props.Where(p => p.GetCustomAttribute<SExprTokenAttribute>() != null);
      foreach (var tProp in tokenProps)
      {
         if (node.Properties!.Contains(tProp.GetCustomAttribute<SExprTokenAttribute>()!.TokenName))
         {
            tProp.SetValue(obj, true);
         }
      }
   }
   #endregion

   #region Helper Methods
   private static string GetXPath(PropertyInfo prop)
   {
      if (prop.GetCustomAttribute<SExprNodeAttribute>() is null)
      {
         return prop.PropertyType.GetCustomAttribute<SExprNodeAttribute>()!.XPath;
      }
      else
      {
         return prop.GetCustomAttribute<SExprNodeAttribute>()!.XPath;
      }
   }
   #endregion
}
