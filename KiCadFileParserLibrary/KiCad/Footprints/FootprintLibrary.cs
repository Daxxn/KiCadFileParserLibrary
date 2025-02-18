using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;

using MVVMLibrary;

using Newtonsoft.Json.Linq;

namespace KiCadFileParserLibrary.KiCad.Footprints;

/// <summary>
/// A Library of KiCad <see cref="Footprint">Footprints.</see>
/// </summary>
public class FootprintLibrary : Model, IKiCadLibrary
{
   #region Local Props
   private string _libName = "";
   private ObservableCollection<Footprint> _footprints = [];
   private bool _readonly = false;
   #endregion

   #region Constructors
   /// <inheritdoc/>
   public FootprintLibrary() { }
   #endregion

   #region Methods
   /// <summary>
   /// Parse the footprint files in the library folder.
   /// </summary>
   /// <param name="folder">The path of the footprint library folder.</param>
   /// <returns>The parsed footprint library.</returns>
   public static FootprintLibrary? ParseLibrary(string folder)
   {
      if (Directory.Exists(folder))
      {
         var ext = Path.GetExtension(folder);
         if (ext != ".pretty") return null;
         var paths = Directory.GetFiles(folder, "*.kicad_mod");
         if (paths.Length == 0) return null;
         FootprintLibrary newLib = new()
         {
            LibraryFullName = Path.GetFileName(folder),
            Footprints = []
         };
         foreach (var path in paths)
         {
            Footprint footprint = new Footprint();
            SExprFileReader reader = new();
            var rootNode = reader.Read(path)?.GetNode("footprint");
            if (rootNode is null) return null;
            footprint.ParseNode(rootNode);
            newLib.Footprints.Add(footprint);
         }
         return newLib;
      }
      return null;
   }

   /// <inheritdoc/>
   public void WriteLibrary(string rootFolder)
   {
      if (Footprints is null) return;
      var fullPath = Path.Combine(rootFolder, LibraryFullName);
      if (!Directory.Exists(fullPath))
      {
         Directory.CreateDirectory(fullPath);
      }

      foreach (var footprint in Footprints)
      {
         StringBuilder builder = new();
         KiCadWriteUtils2.WriteNode(footprint, builder, 0);
         if (builder.Length > 0)
         {
            File.WriteAllText(Path.Combine(fullPath, $"{footprint.Name}.kicad_mod"), builder.ToString());
         }
      }
   }

   /// <summary>
   /// Search the footprint libraries for a matching footprint.
   /// </summary>
   /// <param name="name">The name of the footprint.</param>
   /// <returns>The matching footprint, otherwise null.</returns>
   public Footprint? FindFootprint(string name)
   {
      if (string.IsNullOrEmpty(name)) return null;
      if (Footprints.Count == 0) return null;
      foreach (var fp in Footprints)
      {
         if (fp.Name == name) return fp;
      }
      return null;
   }

   /// <inheritdoc/>
   public override string ToString() => $"Footprint Lib {LibraryName} - Footprints: {Footprints.Count}";
   #endregion

   #region Full Props
   /// <summary>
   /// Full name of the library, including the extension.
   /// </summary>
   public string LibraryFullName
   {
      get => $"{_libName}.pretty";
      set
      {
         _libName = value.Replace(".pretty", "");
         OnPropertyChanged(nameof(LibraryName));
      }
   }

   /// <summary>
   /// The name of the library.
   /// </summary>
   public string LibraryName
   {
      get => _libName;
      set
      {
         _libName = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// List of all the <see cref="Footprint">Footprints.</see>
   /// </summary>
   public ObservableCollection<Footprint> Footprints
   {
      get => _footprints;
      set
      {
         _footprints = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// The default KiCad libraries are read-only and cannot be changed.
   /// <para/>
   /// True if the libraries are from the KiCad default library.
   /// </summary>
   public bool Readonly
   {
      get => _readonly;
      set
      {
         _readonly = value;
         OnPropertyChanged();
      }
   }
   #endregion
}
