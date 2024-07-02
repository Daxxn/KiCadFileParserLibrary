using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

namespace KiCadFileParserLibrary.KiCad.Pcb.SubModels
{
   public class TitleBlockModel : IKiCadReadable
   {
      #region Local Props
      [SExprSubNode("title")]
      public string? Title { get; set; }

      [SExprSubNode("date")]
      public DateTime? Date { get; set; }

      [SExprSubNode("rev")]
      public string? Revision { get; set; }

      [SExprSubNode("company")]
      public string? Company { get; set; }

      public List<CommentModel>? Comments { get; set; }
      #endregion

      #region Constructors
      public TitleBlockModel() { }

      #endregion

      #region Methods
      public void ParseNode(Node node)
      {
         if (node.Children != null)
         {
            var props = GetType().GetProperties();

            KiCadParseUtils.ParseSubNodes(props, node, this);

            //var subNodeProps = props.Where(p => p.GetCustomAttribute<SExprSubNodeAttribute>() != null);
            //foreach (var prop in subNodeProps)
            //{
            //   var propAttr = prop.GetCustomAttribute<SExprSubNodeAttribute>();
            //   var pNode = node.GetNode(propAttr!.XPath);
            //   if (pNode != null)
            //   {
            //      if (pNode.Properties != null)
            //      {
            //         prop.SetValue(this, PropertyParser.Parse(pNode.Properties[1], prop));
            //      }
            //   }
            //}

            // Using this instead of KiCadParseUtils.ParseNodes() due to wierdness with comments.
            var nodeProps = props.Where(p => p.PropertyType.GetCustomAttribute<SExprNodeAttribute>() != null);
            foreach (var prop in nodeProps)
            {
               var propAttr = prop.PropertyType.GetCustomAttribute<SExprNodeAttribute>();
               var pNode = node.GetNode(propAttr!.XPath);
               if (pNode != null)
               {
                  var obj = prop.PropertyType.GetConstructor([])!.Invoke(null);
                  if (obj is CommentModel commentModel)
                  {
                     commentModel.ParseNode(pNode);
                     Comments ??= new();
                     Comments.Add(commentModel);
                  }
               }
            }
         }
      }

      #endregion

      #region Full Props

      #endregion
   }
}
