using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MVVMLibrary;

namespace KiCadFileParserLibrary.KiCad.Footprints;

/// <summary>
/// Collection of <see cref="FootprintLibrary">Footprint Libraries</see>
/// </summary>
public class FootprintLibraryCollection : Model
{
   #region Local Props
   private string _rootFolder = null!;
   private ObservableCollection<FootprintLibrary> _libs = [];
   private bool _readonly = false;
   #endregion

   #region Constructors
   /// <inheritdoc/>
   public FootprintLibraryCollection() { }

   /// <summary>
   /// Used for the KiCad footprint libraries.
   /// <para/>
   /// As the KiCad libraries are not writable.
   /// </summary>
   /// <param name="isKiCadLibs">True for KiCad default libraries.</param>
   public FootprintLibraryCollection(bool isKiCadLibs) => _readonly = isKiCadLibs;
   #endregion

   #region Methods
   /// <summary>
   /// Parse all libraries in the provided folder.
   /// </summary>
   /// <param name="rootFolder">The folder to search for libraries.</param>
   /// <returns>The collection of libraries.</returns>
   public static FootprintLibraryCollection? ParseLibraries(string rootFolder)
   {
      if (!Directory.Exists(rootFolder)) return null;

      var libFolders = Directory.GetDirectories(rootFolder, "*.pretty");
      if (libFolders == null) return null;
      var newColl = new FootprintLibraryCollection();
      foreach (var folder in libFolders)
      {
         var newLibrary = FootprintLibrary.ParseLibrary(folder);
         if (newLibrary == null) continue;
         newColl.Libs.Add(newLibrary);
      }
      return newColl;
   }

   /// <summary>
   /// Write all the libraries to the <seealso cref="RootFolder"/> path.
   /// </summary>
   public void WriteAllLibraries()
   {
      var rootDir = new DirectoryInfo(RootFolder);
      if (!rootDir.Exists)
      {
         rootDir.Create();
      }

      if (Libs.Count > 0)
      {
         foreach (var lib in Libs)
         {
            lib.WriteLibrary(rootDir.FullName);
         }
      }
   }

   /// <summary>
   /// Create a copy of the libraries in the provided folder.
   /// </summary>
   /// <param name="newFolder">The folder to copy the libraries into.</param>
   /// <param name="overwrite">Overwrite any files in the folder if <see langword="true"/>.</param>
   public void WriteCopy(string newFolder, bool overwrite = false)
   {
      var rootDir = new DirectoryInfo(newFolder);
      if (!rootDir.Exists)
      {
         rootDir.Create();
      }
      else if (!overwrite)
      {
         if (Directory.GetFiles(newFolder, "*.*", SearchOption.AllDirectories).Length != 0)
         {
            return;
         }
      }

      if (Libs.Count > 0)
      {
         foreach (var lib in Libs)
         {
            lib.WriteLibrary(rootDir.FullName);
         }
      }
   }

   /// <summary>
   /// Search for a matching footprint library.
   /// </summary>
   /// <param name="name">The name of the footprint library.</param>
   /// <returns>The matching footprint library, otherwise null.</returns>
   public FootprintLibrary? FindLibrary(string name)
   {
      if (Libs.Count == 0) return null;
      foreach (var lib in Libs)
      {
         if (lib.LibraryName == name) return lib;
      }
      return null;
   }

   /// <summary>
   /// Search the footprint libraries for a matching footprint.
   /// <para/>
   /// Uses the name delimiter ( <c>:</c> ) to split the library and footprint names.
   /// <para/>
   /// Example: "Library:Footprint"
   /// </summary>
   /// <param name="name">The name of the footprint.</param>
   /// <returns>The matching footprint, otherwise null.</returns>
   public Footprint? FindFootprint(string name)
   {
      if (Libs.Count == 0) return null;
      if (string.IsNullOrEmpty(name)) return null;

      if (name.Contains(':'))
      {
         var nameSplit = name.Split(':', StringSplitOptions.RemoveEmptyEntries);
         if (nameSplit.Length > 1)
         {
            var foundLib = FindLibrary(nameSplit[0]);
            return foundLib?.FindFootprint(nameSplit[1]);
         }
      }
      else
      {
         foreach (var lib in Libs)
         {
            var foundFp = lib.FindFootprint(name);
            if (foundFp != null) return foundFp;
         }
      }

      return null;
   }

   /// <inheritdoc/>
   public override string ToString() => $"Footprint Libraries - {Libs.Count}";
   #endregion

   #region Full Props
   /// <summary>
   /// The folder containing the footprint libraries.
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
   /// List of <see cref="FootprintLibrary">Footprint Libraries.</see>
   /// </summary>
   public ObservableCollection<FootprintLibrary> Libs
   {
      get => _libs;
      set
      {
         _libs = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// The default KiCad libraries are read-only and cannot be changed.
   /// <para/>
   /// True if this library collection is from the KiCad default libraries.
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
