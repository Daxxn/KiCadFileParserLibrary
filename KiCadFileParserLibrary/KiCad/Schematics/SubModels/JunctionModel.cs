﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.SExprParser;

namespace KiCadFileParserLibrary.KiCad.Schematics.SubModels
{
   [SExprNode("junction")]
   public class JunctionModel : IKiCadReadable
   {
      #region Local Props

      #endregion

      #region Constructors
      public JunctionModel() { }
      #endregion

      #region Methods
      public void ParseNode(Node node)
      {
         throw new NotImplementedException();
      }

      public void WriteNode(StringBuilder builder, int indent, string? auxName = null)
      {
         throw new NotImplementedException();
      }
      #endregion

      #region Full Props

      #endregion
   }
}
