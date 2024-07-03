﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.SExprParser;

namespace KiCadFileParserLibrary.KiCad.Pcb.Collections
{
    [SExprListNode("generated")]
   public class TunedLengthCollection : IKiCadReadable
   {
      #region Local Props
      public List<TunedLengthModel>? TunedLengths { get; set; }
      #endregion

      #region Constructors
      public TunedLengthCollection() { }
      #endregion

      #region Methods
      public void ParseNode(Node node)
      {
         if (node.Children != null)
         {
            var children = node.GetNodes("generated");
            if (children is null) return;
            TunedLengths = [];
            foreach (var child in children)
            {
               TunedLengthModel tl = new();
               tl.ParseNode(child);
               TunedLengths.Add(tl);
            }
         }
      }
      #endregion

      #region Full Props

      #endregion
   }
}
