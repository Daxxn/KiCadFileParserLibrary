using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

using MVVMLibrary;

namespace KiCadFileParserLibrary.KiCad.General
{
   [SExprNode("at")]
   public class LocationModel : Model, IKiCadReadable
   {
      #region Local Props
      private double? _x;
      private double? _y;
      private double? _angle;
      #endregion

      #region Constructors
      public LocationModel() { }
      #endregion

      #region Methods
      public void ParseNode(Node node)
      {
         var props = GetType().GetProperties();
         KiCadParseUtils.ParseProperties(props, node, this);
      }

      public void WriteNode(StringBuilder builder, int indent, string? auxName = null)
      {
         builder.Append('\t', indent);
         builder.Append($"({auxName ?? "at"} {X} {Y}");
         if (Angle != null)
         {
            builder.Append(' ');
            builder.Append(Math.Round((double)Angle));
         }

         builder.AppendLine(")");
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

      [SExprProperty(3)]
      public double? Angle
      {
         get => _angle;
         set
         {
            _angle = value;
            OnPropertyChanged();
         }
      }
      #endregion
   }
}
