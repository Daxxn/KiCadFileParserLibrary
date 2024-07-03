using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.KiCad.Symbol.Collections;
using KiCadFileParserLibrary.SExprParser;

namespace KiCadFileParserLibrary.KiCad.Schematic
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
         throw new NotImplementedException();
      }
      #endregion

      #region Full Props

      #endregion
   }
}
