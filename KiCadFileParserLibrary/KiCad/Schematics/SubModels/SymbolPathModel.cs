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

namespace KiCadFileParserLibrary.KiCad.Schematics.SubModels;

[SExprNode("path")]
public class SymbolPathModel : Model, IKiCadReadable
{
   #region Local Props
   private string _path = "";
   private string _reference = "";
   private int _unit = -1;
   #endregion

   #region Constructors
   public SymbolPathModel() { }
   #endregion

   #region Methods
   public void ParseNode(Node node)
   {
      if (node.Properties != null && node.Children != null)
      {
         var props = GetType().GetProperties();

         KiCadParseUtils.ParseSubNodes(props, node, this);
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
   public string Path
   {
      get => _path;
      set
      {
         _path = value;
         OnPropertyChanged();
      }
   }

   [SExprSubNode("reference")]
   public string Reference
   {
      get => _reference;
      set
      {
         _reference = value;
         OnPropertyChanged();
      }
   }

   [SExprSubNode("unit")]
   public int Unit
   {
      get => _unit;
      set
      {
         _unit = value;
         OnPropertyChanged();
      }
   }
   #endregion
}
