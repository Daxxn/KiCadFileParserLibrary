using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.KiCad.Footprints;
using KiCadFileParserLibrary.KiCad.Symbols;

using MVVMLibrary;

namespace KiCadFileParserLibrary.KiCad;

/// <summary>
/// A collecion of KiCad libraries.
/// </summary>
public class KiCadLibraries : Model
{
   #region Local Props
   private string _rootFolder = "";
   private string _kicadFolder = "";
   private SymbolLibraryCollection? _symbols;
   private SymbolLibraryCollection? _kicadSymbols;
   private FootprintLibraryCollection? _footprints;
   private FootprintLibraryCollection? _kicadFootprints;
   private ObservableCollection<FileInfo>? _models;
   private ObservableCollection<FileInfo>? _kicadModels;
   #endregion

   #region Constructors
   /// <inheritdoc/>
   public KiCadLibraries() { }
   #endregion

   #region Methods
   /// <summary>
   /// Parse the KiCad libraries in the provided location.
   /// </summary>
   /// <param name="rootFolder">The location to parse.</param>
   /// <param name="kicadLibrariesFolder">The folder containing the KiCad default libraries.</param>
   /// <returns>The parsed library data.</returns>
   public static KiCadLibraries? Parse(string rootFolder, string kicadLibrariesFolder)
   {
      if (!Directory.Exists(rootFolder)) return null;
      KiCadLibraries libs = new()
      {
         RootFolder = rootFolder,
         KiCadFolder = kicadLibrariesFolder,
         SymbolLibraries = SymbolLibraryCollection.ParseLibraries(Path.Combine(rootFolder, "Symbols")),
         KiCadSymbolLibraries = SymbolLibraryCollection.ParseLibraries(Path.Combine(kicadLibrariesFolder, "symbols")),
         FootprintLibraries = FootprintLibraryCollection.ParseLibraries(Path.Combine(rootFolder, "Footprints")),
         KiCadFootprintLibraries = FootprintLibraryCollection.ParseLibraries(Path.Combine(kicadLibrariesFolder, "footprints"))
      };

      var files = Directory.GetFiles(Path.Combine(rootFolder, "Models"), "*.st", SearchOption.AllDirectories);
      if (files.Length > 0)
      {
         libs.Models = [];
         foreach (var file in files)
         {
            libs.Models.Add(new FileInfo(file));
         }
      }

      files = Directory.GetFiles(Path.Combine(kicadLibrariesFolder, "3dmodels"), "*.step", SearchOption.AllDirectories);
      if (files.Length > 0)
      {
         libs.KiCadModels = [];
         foreach (var file in files)
         {
            libs.KiCadModels.Add(new FileInfo(file));
         }
      }

      return libs;
   }

   /// <summary>
   /// Save the library data.
   /// </summary>
   public void Save()
   {
      if (string.IsNullOrEmpty(RootFolder)) return;
      SymbolLibraries?.WriteAllLibraries();
      FootprintLibraries?.WriteAllLibraries();
   }

   /// <summary>
   /// Create a copy of all the libraries in the provided location.
   /// </summary>
   /// <param name="newLibFolder">The new library location.</param>
   /// <param name="overwrite">Overwrite any data in the new location.</param>
   /// <exception cref="Exception">Throws if the location already exists and overwrite is false.</exception>
   public void Copy(string newLibFolder, bool overwrite = false)
   {
      if (!Directory.Exists(newLibFolder))
      {
         Directory.CreateDirectory(newLibFolder);
      }
      else if (!overwrite)
      {
         throw new Exception("Library already exists and overwrite is not allowed.");
      }

      SymbolLibraries?.WriteCopy(newLibFolder, overwrite);
   }

   /// <summary>
   /// Search all libraries for a matching symbol. Can exclude kicad default libraries.
   /// <para/>
   /// Uses the name delimiter ( <c>:</c> ) to split the library and symbol names.
   /// <para/>
   /// Example: "Library:Symbol"
   /// </summary>
   /// <param name="name">The name of the symbol.</param>
   /// <param name="excludeDefaults">Will exclude KiCad default symbols if true.</param>
   /// <returns>The matching symbol, otherwise null.</returns>
   public Symbol? FindSymbol(string name, bool excludeDefaults = false)
   {
      if (string.IsNullOrEmpty(name)) return null;
      var foundSymbol = SymbolLibraries?.FindSymbol(name);
      if (foundSymbol != null) return foundSymbol;
      if (excludeDefaults) return null;
      return KiCadSymbolLibraries?.FindSymbol(name);
   }

   /// <summary>
   /// Search all libraries for a matching footprint. Can exclude KiCad default libraries.
   /// <para/>
   /// Uses the name delimiter ( <c>:</c> ) to split the library and footprint names.
   /// <para/>
   /// Example: "Library:Footprint"
   /// </summary>
   /// <param name="name">The name of the footprint.</param>
   /// <param name="excludeDefaults">Will exclude KiCad default symbols if true.</param>
   /// <returns>The matching footprint, otherwise null.</returns>
   public Footprint? FindFootprint(string name, bool excludeDefaults = false)
   {
      if (string.IsNullOrEmpty(name)) return null;
      var foundFootprint = FootprintLibraries?.FindFootprint(name);
      if (foundFootprint != null) return foundFootprint;
      if (excludeDefaults) return null;
      return KiCadFootprintLibraries?.FindFootprint(name);
   }

   /// <summary>
   /// Search for a matching symbol library. Can exclude KiCad default libraries.
   /// </summary>
   /// <param name="name">The name of the library.</param>
   /// <param name="excludeDefaults">Will exclude KiCad default symbols if true.</param>
   /// <returns>The matching symbol library, otherwise null.</returns>
   public SymbolLibrary? FindSymbolLibrary(string name, bool excludeDefaults = false)
   {
      if (string.IsNullOrEmpty(name)) return null;
      var foundLib = SymbolLibraries?.FindLibrary(name);
      if (foundLib != null) return foundLib;
      if (excludeDefaults) return null;
      return KiCadSymbolLibraries?.FindLibrary(name);
   }

   /// <summary>
   /// Search for a matching footprint library. Can exclude KiCad default libraries.
   /// </summary>
   /// <param name="name">The name of the library.</param>
   /// <param name="excludeDefaults">Will exclude KiCad default symbols if true.</param>
   /// <returns>The matching footprint library, otherwise null.</returns>
   public FootprintLibrary? FindFootprintLibrary(string name, bool excludeDefaults = false)
   {
      if (string.IsNullOrEmpty(name)) return null;
      var foundLib = FootprintLibraries?.FindLibrary(name);
      if (foundLib != null) return foundLib;
      if (excludeDefaults) return null;
      return KiCadFootprintLibraries?.FindLibrary(name);
   }
   #endregion

   #region Full Props
   /// <summary>
   /// Path to the folder containing the libraries.
   /// </summary>
   public string RootFolder
   {
      get => _rootFolder;
      set
      {
         _rootFolder = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Path to the KiCad install folder.
   /// </summary>
   public string KiCadFolder
   {
      get => _kicadFolder;
      set
      {
         _kicadFolder = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Your symbol libraries.
   /// </summary>
   public SymbolLibraryCollection? SymbolLibraries
   {
      get => _symbols;
      set
      {
         _symbols = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// KiCad default symbol libraries.
   /// </summary>
   public SymbolLibraryCollection? KiCadSymbolLibraries
   {
      get => _kicadSymbols;
      set
      {
         _kicadSymbols = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Your footprint libraries.
   /// </summary>
   public FootprintLibraryCollection? FootprintLibraries
   {
      get => _footprints;
      set
      {
         _footprints = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// KiCad default footprint libraries.
   /// </summary>
   public FootprintLibraryCollection? KiCadFootprintLibraries
   {
      get => _kicadFootprints;
      set
      {
         _kicadFootprints = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// List of your 3D model files
   /// </summary>
   public ObservableCollection<FileInfo>? Models
   {
      get => _models;
      set
      {
         _models = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// List of KiCad default 3D model files.
   /// </summary>
   public ObservableCollection<FileInfo>? KiCadModels
   {
      get => _kicadModels;
      set
      {
         _kicadModels = value;
         OnPropertyChanged();
      }
   }
   #endregion
}
