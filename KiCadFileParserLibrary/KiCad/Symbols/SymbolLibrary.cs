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

namespace KiCadFileParserLibrary.KiCad.Symbols;

/// <summary>
/// A library of KiCad <see cref="Symbol">Symbols.</see>
/// </summary>
[SExprNode("kicad_symbol_lib")]
public class SymbolLibrary : Model, IKiCadReadable, IKiCadWriteable, IKiCadLibrary
{
   #region Local Props
   private string _name = "";
   private int _version;
   private string _generator = "";
   private string _generatorVersion = "";
   private SymbolCollection? _symbols;
   #endregion

   #region Constructors
   /// <inheritdoc/>
   public SymbolLibrary() { }
   #endregion

   #region Methods
   /// <summary>
   /// Parse all symbols in the provided symbol file (<c>*.kicad_sym</c>).
   /// </summary>
   /// <param name="path">The location of the symbol library file.</param>
   /// <returns>The parsed symbol library data.</returns>
   public static SymbolLibrary? ParseLibrary(string path)
   {
      var reader = new SExprFileReader();
      var rootNode = reader.Read(path)?.GetNode("kicad_symbol_lib");
      if (rootNode is null) return null;
      var lib = new SymbolLibrary();
      lib.ParseNode(rootNode);
      lib.Name = Path.GetFileNameWithoutExtension(path);
      return lib;
   }

   /// <inheritdoc/>
   public void ParseNode(Node node)
   {
      if (node.Children is null) return;
      var props = GetType().GetProperties();
      KiCadParseUtils.ParseSubNodes(props, node, this);
      KiCadParseUtils.ParseListNodes(props, node, this);
   }

   /// <inheritdoc/>
   public void WriteNode(StringBuilder builder, int indent, string? auxName = null)
   {
      KiCadWriteUtils2.WriteNode(this, builder, indent);
   }

   /// <inheritdoc/>
   public void WriteLibrary(string path)
   {
      if (!Directory.Exists(path)) return;
      if (string.IsNullOrEmpty(Name)) return;
      if (Symbols is null) return;

      var sb = new StringBuilder();
      WriteNode(sb, 0);
      if (sb.Length > 0)
      {
         File.WriteAllText(Path.Combine(path, $"{Name}.kicad_sym"), sb.ToString());
      }
   }

   /// <summary>
   /// Search the symbol libraries for a matching symbol.
   /// </summary>
   /// <param name="name">The name of the symbol.</param>
   /// <returns>The matching symbol, otherwise null.</returns>
   public Symbol? FindSymbol(string name)
   {
      if (string.IsNullOrEmpty(name)) return null;
      if (Symbols?.Symbols is null) return null;
      foreach (var symbol in Symbols.Symbols)
      {
         if (symbol.SymbolName == name) return symbol;
      }
      return null;
   }
   #endregion

   #region Full Props
   /// <summary>
   /// The name of the symbol library.
   /// <para/>
   /// Is also the name of the file.
   /// </summary>
   public string Name
   {
      get => _name;
      set
      {
         _name = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// The version of the symbol file.
   /// <para/>
   /// Do NOT modify this unless you know what will happen.
   /// </summary>
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

   /// <summary>
   /// The KiCad generator that created this file.
   /// <para/>
   /// Do NOT modify this unless you know what will happen.
   /// </summary>
   [SExprSubNode("generator")]
   public string Generator
   {
      get => _generator;
      set
      {
         _generator = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// The version of the KiCad generator that created this file.
   /// <para/>
   /// Do NOT modify this unless you know what will happen.
   /// </summary>
   [SExprSubNode("generator_version")]
   public string GeneratorVersion
   {
      get => _generatorVersion;
      set
      {
         _generatorVersion = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// List of symbols
   /// </summary>
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
