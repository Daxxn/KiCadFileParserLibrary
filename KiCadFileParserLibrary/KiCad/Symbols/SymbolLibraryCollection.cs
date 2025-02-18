using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MVVMLibrary;

namespace KiCadFileParserLibrary.KiCad.Symbols;

/// <summary>
/// A list of symbol libraries from a folder on disk.
/// </summary>
public class SymbolLibraryCollection : Model
{
   #region Local Props
   private string? _folder = null;
   private ObservableCollection<SymbolLibrary> _libraries = [];
   private bool _readonly = false;
   #endregion

   #region Constructors
   /// <inheritdoc/>
   public SymbolLibraryCollection() { }

   /// <summary>
   /// Used for the KiCad symbol libraries.
   /// <para/>
   /// As the KiCad libraries are not writable.
   /// </summary>
   /// <param name="isKiCadLibs">True for KiCad default libraries.</param>
   public SymbolLibraryCollection(bool isKiCadLibs) => _readonly = isKiCadLibs;
   #endregion

   #region Methods
   /// <summary>
   /// 
   /// </summary>
   /// <param name="folder"></param>
   /// <returns></returns>
   public static SymbolLibraryCollection? ParseLibraries(string folder)
   {
      if (!Directory.Exists(folder)) return null;

      var files = Directory.GetFiles(folder, "*.kicad_sym");

      if (files == null) return null;
      SymbolLibraryCollection libs = new();
      foreach (var file in files)
      {
         var newLib = SymbolLibrary.ParseLibrary(file);
         if (newLib == null) continue;
         libs.Libraries.Add(newLib);
      }
      return libs;
   }

   /// <summary>
   /// 
   /// </summary>
   /// <exception cref="DirectoryNotFoundException">Thrown when unable to find the symbol library folder.</exception>
   public void WriteAllLibraries()
   {
      if (string.IsNullOrEmpty(Folder)) throw new DirectoryNotFoundException("Unable to find symbol library folder");
      var rootDir = new DirectoryInfo(Folder);
      if (!rootDir.Exists)
      {
         rootDir.Create();
      }

      if (Libraries.Count > 0)
      {
         foreach (var lib in Libraries)
         {
            if (!string.IsNullOrEmpty(lib.Name))
            {
               lib.WriteLibrary(rootDir.FullName);
            }
         }
      }
   }

   /// <summary>
   /// Create a copy of the folder in the specified location.
   /// <para/>
   /// Does NOT change the origina folder and <see cref="WriteAllLibraries"/> will use the original folder.
   /// </summary>
   /// <param name="newFolder">The location where the copy will be created.</param>
   /// <param name="overwrite">Overwrite any files in the folder if <see langword="true"/>.</param>
   /// <exception cref="DirectoryNotFoundException">Thrown when unable to find the symbol library folder.</exception>
   public void WriteCopy(string newFolder, bool overwrite = false)
   {
      if (string.IsNullOrEmpty(Folder)) throw new DirectoryNotFoundException("Unable to find symbol library folder");
      var rootDir = new DirectoryInfo(newFolder);
      if (!rootDir.Exists)
      {
         rootDir.Create();
      }
      else if (!overwrite)
      {
         if (Directory.GetFiles(newFolder).Length != 0)
         {
            return;
         }
      }

      if (Libraries.Count > 0)
      {
         foreach (var lib in Libraries)
         {
            if (!string.IsNullOrEmpty(lib.Name))
            {
               lib.WriteLibrary(rootDir.FullName);
            }
         }
      }
   }

   /// <summary>
   /// Search for a matching symbol library.
   /// </summary>
   /// <param name="name">The name of the symbol library.</param>
   /// <returns>The matching symbol library, otherwise null.</returns>
   public SymbolLibrary? FindLibrary(string name)
   {
      if (Libraries.Count == 0) return null;
      foreach (var lib in Libraries)
      {
         if (lib.Name == name) return lib;
      }
      return null;
   }

   /// <summary>
   /// Search the symbol libraries for a matching symbol.
   /// <para/>
   /// Uses the name delimiter ( <c>:</c> ) to split the library and symbol names.
   /// <para/>
   /// Example: "Library:Symbol"
   /// </summary>
   /// <param name="name">The name of the symbol.</param>
   /// <returns>The matching symbol, otherwise null.</returns>
   public Symbol? FindSymbol(string name)
   {
      if (Libraries.Count == 0) return null;
      if (string.IsNullOrEmpty(name)) return null;

      if (name.Contains(':'))
      {
         var nameSplit = name.Split(':', StringSplitOptions.RemoveEmptyEntries);
         if (nameSplit.Length > 1)
         {
            var foundLib = FindLibrary(nameSplit[0]);
            return foundLib?.FindSymbol(nameSplit[1]);
         }
      }
      else
      {
         foreach (var lib in Libraries)
         {
            var foundFp = lib.FindSymbol(name);
            if (foundFp != null) return foundFp;
         }
      }

      return null;
   }
   #endregion

   #region Full Props
   /// <summary>
   /// Path to the libraries folder.
   /// </summary>
   public string? Folder
   {
      get => _folder;
      set
      {
         _folder = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// List of symbol libraries.
   /// </summary>
   public ObservableCollection<SymbolLibrary> Libraries
   {
      get => _libraries;
      set
      {
         _libraries = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Is library readonly
   /// <para/>
   /// KiCad default symbol libraries are readonly.
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
