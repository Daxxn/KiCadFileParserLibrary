﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.Pcb;
using KiCadFileParserLibrary.SExprParser;

namespace KiCadFileParserLibrary.Utils
{
   public static class KiCadParseUtils
   {
      #region Methods
      public static void ParseNodes(PropertyInfo[] props, Node node, object obj)
      {
         var classProps = props.Where(p => p.PropertyType.GetCustomAttribute<SExprNodeAttribute>() != null);
         foreach (var cProp in classProps)
         {
            var objNode = node.GetNode(cProp.PropertyType.GetCustomAttribute<SExprNodeAttribute>()!.XPath);
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

      public static void ParseProperties(PropertyInfo[] props, Node node, object obj)
      {
         foreach (var prop in props)
         {
            var attr = prop.GetCustomAttribute<SExprPropertyAttribute>();
            if (attr != null)
            {
               if (node.Properties!.Count > attr.PropertyIndex)
               {
                  prop.SetValue(obj, PropertyParser.Parse(node.Properties[attr.PropertyIndex], prop));
               }
            }
         }
      }

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

      public static void ParseListNodes(PropertyInfo[] props, Node node, object obj)
      {
         var classProps = props.Where(p => p.PropertyType.GetCustomAttribute<SExprListNodeAttribute>() != null);
         foreach (var cProp in classProps)
         {
            //var objNode = node.GetNode(cProp.PropertyType.GetCustomAttribute<SExprListNodeAttribute>()!.Name);
            //if (objNode != null)
            //{
               var newObj = cProp.PropertyType.GetConstructor([])!.Invoke(null);
               if (newObj is IKiCadReadable readableProp)
               {
                  readableProp.ParseNode(node);
               }
               cProp.SetValue(obj, newObj);
            //}
         }
      }
      #endregion
   }
}
