using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

using MVVMLibrary;

namespace KiCadFileParserLibrary.KiCad.General
{
   [SExprNode("paper")]
   public class PaperModel : Model, IKiCadReadable
   {
      #region Local Props
      private string? _name;
      private bool _isCustomSize;
      private double? _width;
      private double? _height;
      private bool _isPortrait;
      #endregion

      #region Constructors
      public PaperModel() { }
      #endregion

      #region Methods
      public void ParseNode(Node node)
      {
         if (node.Properties != null)
         {
            if (node.Properties.Count > 1)
            {
               if (node.Properties[1] == "User")
               {
                  IsCustomSize = true;
                  var props = GetType().GetProperties();

                  KiCadParseUtils.ParseProperties(props, node, this);
                  KiCadParseUtils.ParseTokens(props, node, this);
               }
            }
         }
      }

      public void WriteNode(StringBuilder builder, int indent, string? auxName = null)
      {
         builder.Append('\t', indent);
         builder.Append("(paper ");

         if (IsCustomSize)
         {
            builder.AppendLine($"\"{Name}\" {Width} {Height})");
         }
         else
         {
            builder.AppendLine($"\"{Name}\")");
         }
      }

      public override string ToString()
      {
         if (IsCustomSize)
         {
            return $"Paper - Name: {Name} - W: {Width} - H: {Height} - Portrait: {IsPortrait}";
         }
         else
         {
            return $"Paper - Name: {Name} - Portrait: {IsPortrait}";
         }
      }
      #endregion

      #region Full Props
      [SExprProperty(1)]
      public string? Name
      {
         get => _name;
         set
         {
            _name = value;
            OnPropertyChanged();
         }
      }

      public bool IsCustomSize
      {
         get => _isCustomSize;
         set
         {
            _isCustomSize = value;
            OnPropertyChanged();
         }
      }

      [SExprProperty(2, true)]
      public double? Width
      {
         get => _width;
         set
         {
            _width = value;
            OnPropertyChanged();
         }
      }

      [SExprProperty(1, true)]
      public double? Height
      {
         get => _height;
         set
         {
            _height = value;
            OnPropertyChanged();
         }
      }

      [SExprToken("portrait")]
      public bool IsPortrait
      {
         get => _isPortrait;
         set
         {
            _isPortrait = value;
            OnPropertyChanged();
         }
      }
      #endregion
   }
}
