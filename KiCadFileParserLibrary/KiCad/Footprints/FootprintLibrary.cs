using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.SExprParser;

using MVVMLibrary;

namespace KiCadFileParserLibrary.KiCad.Footprints
{
   public class FootprintLibrary : Model
   {
      #region Local Props
      private string _libPath;
      public Dictionary<string, Footprint>? Footprints { get; set; }
      #endregion

      #region Constructors
      public FootprintLibrary(string folder) => LibraryPath = folder;
      #endregion

      #region Methods
      public static FootprintLibrary? ParseLibrary(string folder)
      {
         if (Directory.Exists(folder))
         {
            var paths = Directory.GetFiles(folder, "*.kicad_mod");
            if (paths.Length == 0) return null;
            FootprintLibrary newLib = new(folder);
            newLib.Footprints = [];
            foreach (var path in paths)
            {
               Footprint footprint = new Footprint();
               SExprFileReader reader = new();
               var rootNode = reader.Read(path)?.GetNode("footprint");
               if (rootNode is null) return null;
               footprint.ParseNode(rootNode);
               newLib.Footprints.Add(Path.GetFileNameWithoutExtension(path), footprint);
            }
         }
         return null;
      }

      public void WriteLibrary()
      {
         if (Footprints is null) return;
         foreach (var footprint in Footprints)
         {
            StringBuilder builder = new();
            footprint.Value.WriteNode(builder, 0);
            if (builder.Length > 0)
            {
               File.WriteAllText(Path.Combine(LibraryPath, footprint.Key), builder.ToString());
            }
         }
      }
      #endregion

      #region Full Props
      public string LibraryPath
      {
         get => _libPath;
         set
         {
            _libPath = value;
            OnPropertyChanged();
         }
      }
      #endregion
   }
}
