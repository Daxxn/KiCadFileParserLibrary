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
   #endregion

   #region Constructors
   /// <inheritdoc/>
   public FootprintLibraryCollection() { }
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
   #endregion
}
