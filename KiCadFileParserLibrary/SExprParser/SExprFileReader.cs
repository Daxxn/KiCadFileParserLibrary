using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace KiCadFileParserLibrary.SExprParser
{
   public class SExprFileReader
   {
      #region Local Props
      private SExprFileOptions Options { get; set; } = new();
      #endregion

      #region Constructors
      public SExprFileReader() { }
      public SExprFileReader(SExprFileOptions options) => Options = options;
      #endregion

      #region Methods
      public Node? Read(string path)
      {
         using (StreamReader reader = new(path))
         {
            List<char> data = reader.ReadToEnd().ToList();

            Node currentNode = new Node();
            Node rootNode = currentNode;
            rootNode.Depth = 0;

            int index = 0;
            int nodeDepth = 0;
            bool openQuotes = false;
            StringBuilder sb = new();
            foreach (var ch in data)
            {
               if (ch == '"')
               {
                  openQuotes = !openQuotes;
                  if (!openQuotes)
                  {
                     currentNode.Properties ??= new();
                     currentNode.Properties.Add(sb.ToString());
                     sb.Clear();
                  }
               }
               else if (ch == Options.OpenDelimiter && !openQuotes)
               {
                  if (sb.Length > 0)
                  {
                     currentNode.Properties ??= new();
                     currentNode.Properties.Add(sb.ToString());
                     sb.Clear();
                  }
                  nodeDepth++;
                  Node newNode = new()
                  {
                     Parent = currentNode,
                     Depth = nodeDepth,
                  };
                  currentNode.Children ??= new();
                  currentNode.Children.Add(newNode);
                  currentNode = newNode;
               }
               else if (ch == Options.CloseDelimiter && !openQuotes)
               {
                  if (sb.Length > 0)
                  {
                     currentNode.Properties ??= new();
                     currentNode.Properties.Add(sb.ToString());
                     sb.Clear();
                  }
                  if (currentNode.Parent is null)
                  {
                     break;
                  }
                  currentNode = currentNode.Parent;
                  nodeDepth--;
               }
               else
               {
                  if (!Options.ExclusionChars.Contains(ch) || openQuotes)
                  {
                     if (ch == ' ' && !openQuotes)
                     {
                        if (sb.Length > 0)
                        {
                           currentNode.Properties ??= new();
                           currentNode.Properties.Add(sb.ToString());
                           sb.Clear();
                        }
                     }
                     else
                     {
                        sb.Append(ch);
                     }
                  }
                  else
                  {
                     if (sb.Length > 0)
                     {
                        currentNode.Properties ??= new();
                        currentNode.Properties.Add(sb.ToString());
                        sb.Clear();
                     }
                  }
               }
               index++;
            }
            return rootNode;
         }
      }
      #endregion

      #region Full Props

      #endregion
   }
}
