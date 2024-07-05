using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.General;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.SExprParser;

namespace KiCadFileParserLibrary.KiCad.Boards.Collections
{
   [SExprListNode("net")]
   public class NetCollection : IKiCadReadable
   {
      #region Local Props
      public List<NetModel> Nets { get; set; } = [];
      #endregion

      #region Constructors
      public NetCollection() { }
      #endregion

      #region Methods
      public void ParseNode(Node node)
      {
         var children = node.GetNodes("net");
         if (children is null) return;
         Nets = [];
         foreach (var child in children)
         {
            NetModel newNet = new();
            newNet.ParseNode(child);
            Nets.Add(newNet);
         }
      }

      public void WriteNode(StringBuilder builder, int indent, string? auxName = null)
      {
         foreach (var net in Nets)
         {
            net.WriteNode(builder, indent);
         }
      }
      #endregion

      #region Full Props

      #endregion
   }
}
