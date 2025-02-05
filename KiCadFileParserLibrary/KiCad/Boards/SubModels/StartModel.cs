﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

using MVVMLibrary;

namespace KiCadFileParserLibrary.KiCad.Boards.SubModels
{
   [SExprNode("start")]
   public class StartModel : Model, IKiCadReadable
   {
      #region Local Props
      private double? _x;
      private double? _y;
      #endregion

      #region Constructors
      public StartModel() { }
      #endregion

      #region Methods
      public void ParseNode(Node node)
      {
         if (node.Properties != null)
         {
            var props = GetType().GetProperties();
            KiCadParseUtils.ParseProperties(props, node, this);
         }
      }

      public void WriteNode(StringBuilder builder, int indent, string? auxName = null)
      {
         throw new NotImplementedException();
      }
      #endregion

      #region Full Props
      [SExprProperty(1)]
      public double? X
      {
         get => _x;
         set
         {
            _x = value;
            OnPropertyChanged();
         }
      }

      [SExprProperty(2)]
      public double? Y
      {
         get => _y;
         set
         {
            _y = value;
            OnPropertyChanged();
         }
      }
      #endregion
   }
}
