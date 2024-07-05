using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.General;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.KiCad.Symbols.Collections;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

namespace KiCadFileParserLibrary.KiCad.Schematics
{
   [SExprNode("kicad_sch")]
   public class Schematic : IKiCadReadable
   {
      #region Local Props
      [SExprSubNode("version")]
      public int Version { get; set; }

      [SExprSubNode("generator")]
      public string? Generator { get; set; }

      [SExprSubNode("generator_version")]
      public string? GeneratorVersion { get; set; }

      [SExprSubNode("uuid")]
      public string? ID { get; set; }

      public PaperModel? Paper { get; set; }

      [SExprListNode("lib_symbols")]
      public SymbolCollection? Symbols { get; set; }
      #endregion

      #region Constructors
      public Schematic() { }
      #endregion

      #region Methods
      public static Schematic? Parse(string path)
      {
         var reader = new SExprFileReader();
         var rootNode = reader.Read(path)?.GetNode("kicad_sch");
         if (rootNode is null) return null;
         var sch = new Schematic();
         sch.ParseNode(rootNode);
         return sch;
      }

      public void ParseNode(Node node)
      {
         if (node.Children is null) return;
         var props = GetType().GetProperties();
         KiCadParseUtils.ParseNodes(props, node, this);
         KiCadParseUtils.ParseSubNodes(props, node, this);
         KiCadParseUtils.ParseListNodes(props, node, this);
      }

      public void Write(string path)
      {
         StringBuilder sb = new StringBuilder();
         WriteNode(sb, 0);
         File.WriteAllText(path, sb.ToString());
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
