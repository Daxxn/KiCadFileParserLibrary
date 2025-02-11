using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MVVMLibrary;

namespace KiCadFileParserLibrary.KiCad.Symbols;

/// <summary>
/// 
/// </summary>
public class SymbolLibraryCollection : Model
{
   #region Local Props
   private string? _folder = null;
   private ObservableCollection<SymbolLibrary>? _libraries;
   #endregion

   #region Constructors
   /// <inheritdoc/>
   public SymbolLibraryCollection() { }
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
   #endregion

   #region Full Props
   public string? Folder
   {
      get => _folder;
      set
      {
         _folder = value;
         OnPropertyChanged();
      }
   }

   public ObservableCollection<SymbolLibrary> Libraries
   {
      get => _libraries;
      set
      {
         _libraries = value;
         OnPropertyChanged();
      }
   }
   #endregion
}
