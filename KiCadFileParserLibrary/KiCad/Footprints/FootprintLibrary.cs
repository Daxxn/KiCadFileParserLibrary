using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.Pcb;
using KiCadFileParserLibrary.SExprParser;

namespace KiCadFileParserLibrary.KiCad.Footprints
{
   public class FootprintLibrary
   {
      #region Local Props
      public List<Footprint>? Footprints { get; set; }
      #endregion

      #region Constructors
      public FootprintLibrary() { }
      #endregion

      #region Methods
      public static FootprintLibrary? ParseLibrary(string folder)
      {
         if (Directory.Exists(folder))
         {
            var paths = Directory.GetFiles(folder, "*.kicad_mod");
            if (paths.Length == 0) return null;
            FootprintLibrary newLib = new();
            newLib.Footprints = [];
            foreach (var path in paths)
            {
               Footprint footprint = new Footprint();
               SExprFileReader reader = new();
               var rootNode = reader.Read(path)?.GetNode("footprint");
               if (rootNode is null) return null;
               footprint.ParseNode(rootNode);
               newLib.Footprints.Add(footprint);
            }
         }
         return null;
      }
      #endregion

      #region Full Props

      #endregion
   }
}
