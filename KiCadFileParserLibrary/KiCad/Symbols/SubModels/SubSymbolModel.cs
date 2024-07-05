using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.KiCad.Symbols.Collections;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

namespace KiCadFileParserLibrary.KiCad.Symbols.SubModels
{
   [SExprNode("symbol")]
   public class SubSymbolModel : IKiCadReadable
   {
      #region Local Props
      private string? _name;
      public int Unit { get; set; }
      public SymbolStyleIdentifier StyleID { get; set; }

      public PinCollection? Pins { get; set; }

      public SyGraphicsCollection? Graphics { get; set; }
      #endregion

      #region Constructors
      public SubSymbolModel() { }
      #endregion

      #region Methods
      public void ParseNode(Node node)
      {
         if (node.Children != null)
         {
            var props = GetType().GetProperties();
            KiCadParseUtils.ParseListNodes(props, node, this);
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
      public string? Name
      {
         get => _name;
         set
         {
            _name = value;
            if (_name != null)
            {
               var spl = _name.Split("_");
               if (spl.Length == 3)
               {
                  if (int.TryParse(spl[1], out int unit))
                  {
                     Unit = unit;
                  }
                  if (int.TryParse(spl[2], out int styleID))
                  {
                     StyleID = (SymbolStyleIdentifier)styleID;
                  }
               }
               else
               {
                  throw new Exception("Symbol name doesnt follow the [NAME_UNIT_STYLE] format. Check the save file.");
               }
            }
         }
      }
      #endregion
   }
}
