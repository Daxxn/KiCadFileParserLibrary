using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.SExprParser;

using MVVMLibrary;

namespace KiCadFileParserLibrary.KiCad.Footprints.SubModels
{
   [SExprNode("private_layers")]
   public class PrivateLayersModel : Model, IKiCadReadable
   {
      #region Local Props
      private ObservableCollection<string>? _layers;
      #endregion

      #region Constructors
      public PrivateLayersModel() { }
      #endregion

      #region Methods
      public void ParseNode(Node node)
      {
         if (node.Properties is null) return;
         if (node.Properties.Count > 1)
         {
            Layers = [];
            foreach (var layer in node.Properties[1..])
            {
               Layers.Add(layer);
            }
         }
      }

      public void WriteNode(StringBuilder builder, int indent, string? auxName = null)
      {
         if (Layers is null) return;

         builder.Append('\t', indent);
         builder.Append("(private_layers");

         foreach (var layer in Layers)
         {
            builder.Append($" \"{layer}\"");
         }

         builder.AppendLine(")");
      }

      public override string ToString()
      {
         return $"Private-Layers - {Layers?.Count}";
      }
      #endregion

      #region Full Props
      public ObservableCollection<string>? Layers
      {
         get => _layers;
         set
         {
            _layers = value;
            OnPropertyChanged();
         }
      }
      #endregion
   }
}
