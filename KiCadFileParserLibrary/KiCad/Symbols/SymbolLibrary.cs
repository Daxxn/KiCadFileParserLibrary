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

using MVVMLibrary;

namespace KiCadFileParserLibrary.KiCad.Symbols
{
   [SExprNode("kicad_symbol_lib")]
   public class SymbolLibrary : Model, IKiCadReadable
   {
      #region Local Props
      private int _version;
      private string _generator;
      private string _generatorVersion;
      private SymbolCollection? _symbols;
      #endregion

      #region Constructors
      public SymbolLibrary() { }
      #endregion

      #region Methods
      public static SymbolLibrary? ParseLibrary(string path)
      {
         var reader = new SExprFileReader();
         var rootNode = reader.Read(path)?.GetNode("kicad_symbol_lib");
         if (rootNode is null) return null;
         var lib = new SymbolLibrary();
         lib.ParseNode(rootNode);
         return lib;
      }

      public void ParseNode(Node node)
      {
         if (node.Children is null) return;
         var props = GetType().GetProperties();
         KiCadParseUtils.ParseSubNodes(props, node, this);
      }

      public void WriteNode(StringBuilder builder, int indent, string? auxName = null)
      {
         throw new NotImplementedException();
      }
      #endregion

      #region Full Props
      [SExprSubNode("version")]
      public int Version
      {
         get => _version;
         set
         {
            _version = value;
            OnPropertyChanged();
         }
      }

      [SExprSubNode("generator")]
      public string? Generator
      {
         get => _generator;
         set
         {
            _generator = value;
            OnPropertyChanged();
         }
      }

      [SExprSubNode("generator_version")]
      public string? GeneratorVersion
      {
         get => _generatorVersion;
         set
         {
            _generatorVersion = value;
            OnPropertyChanged();
         }
      }

      public SymbolCollection? Symbols
      {
         get => _symbols;
         set
         {
            _symbols = value;
            OnPropertyChanged();
         }
      }
      #endregion
   }
}
