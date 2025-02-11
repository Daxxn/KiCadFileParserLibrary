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
   private string _rootFolder = null;
   private SymbolLibraryCollection? _symbols;
   private FootprintLibraryCollection? _footprints;
   private ObservableCollection<FileInfo>? _models;
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
   /// <returns>The parsed library data.</returns>
   public static KiCadLibraries? Parse(string rootFolder)
   {
      if (!Directory.Exists(rootFolder)) return null;
      KiCadLibraries libs = new KiCadLibraries();
      libs.RootFolder = rootFolder;
      libs.SymbolLibraries = SymbolLibraryCollection.ParseLibraries(Path.Combine(rootFolder, "Symbols"));
      libs.FootprintLibraries = FootprintLibraryCollection.ParseLibraries(Path.Combine(rootFolder, "Footprints"));
      var files = Directory.GetFiles(Path.Combine(rootFolder, "Models"), "*.st", SearchOption.AllDirectories);
      if (files.Length > 0)
      {
         libs.Models = [];
         foreach (var file in files)
         {
            libs.Models.Add(new FileInfo(file));
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
   #endregion

   #region Full Props
   public string RootFolder
   {
      get => _rootFolder;
      set
      {
         _rootFolder = value;
         OnPropertyChanged();
      }
   }

   public SymbolLibraryCollection? SymbolLibraries
   {
      get => _symbols;
      set
      {
         _symbols = value;
         OnPropertyChanged();
      }
   }

   public FootprintLibraryCollection? FootprintLibraries
   {
      get => _footprints;
      set
      {
         _footprints = value;
         OnPropertyChanged();
      }
   }

   public ObservableCollection<FileInfo> Models
   {
      get => _models;
      set
      {
         _models = value;
         OnPropertyChanged();
      }
   }
   #endregion
}
