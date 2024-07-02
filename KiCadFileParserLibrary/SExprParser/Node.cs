using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KiCadFileParserLibrary.SExprParser
{
   public class Node
   {
      #region Local Props
      public Node? Parent { get; set; }
      public List<Node>? Children { get; set; }
      public List<string>? Properties { get; set; }
      public int Depth { get; set; } = -1;
      #endregion

      #region Constructors
      public Node() { }
      #endregion

      #region Methods
      /// <summary>
      /// Searches the tree for the node matching the path expression. Depth-First Search.
      /// <para/>
      /// Starts at the calling node and works down the tree for a match.
      /// <para/>
      /// Example Expression:
      /// <para/>
      /// <code>ChildA/ChildB/ChildC</code>
      /// <para/>
      /// gets the first matching child at the end of the expression.
      /// </summary>
      /// <param name="expression">A '/' delimited path.</param>
      /// <returns></returns>
      public Node? GetNode(string expression)
      {
         if (string.IsNullOrEmpty(expression)) return this;

         var stringList = expression.Split('/');
         if (stringList.Length > 0)
         {
            if (Children is null) return null;
            foreach (var child in Children)
            {
               if (child.Type == stringList[0])
               {
                  if (stringList.Length > 1)
                  {
                     return child.GetNode(string.Join("/", stringList[1..]));
                  }
                  else
                  {
                     return child;
                  }
               }
            }
         }
         return null;
      }

      /// <summary>
      /// Get all sub-nodes of the tree that match the provided name.
      /// 
      /// Limitations:
      /// <para/>
      /// Only searches the first level of the tree. Use <see cref="GetNode(string)"/> to get the parent node first.
      /// </summary>
      /// <param name="name">The name of the child node.</param>
      /// <returns>A <see cref="List{T}"/> of the <see cref="Node"/>s that match the provided name.</returns>
      public List<Node>? GetNodes(string name)
      {
         if (Children is null) return null;
         if (string.IsNullOrEmpty(name)) return null;

         List<Node> nodes = [];
         foreach (var child in Children)
         {
            if (child.Type == name)
            {
               nodes.Add(child);
            }
         }
         return nodes.Count != 0 ? nodes : null;
      }

      public override string ToString() => $"Node - {Type} - Ch: {Children?.Count}";
      #endregion

      #region Full Props
      public string Type
      {
         get
         {
            if (Properties == null) return "Node";
            return Properties[0];
         }
      }
      #endregion
   }
}
