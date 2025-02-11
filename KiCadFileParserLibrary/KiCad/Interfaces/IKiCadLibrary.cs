using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KiCadFileParserLibrary.KiCad.Interfaces;

/// <summary>
/// Defines an object as a KiCad library file.
/// <para/>
/// Can be either a <see cref="Symbols.SymbolLibrary">Symbol</see> or <see cref="Footprints.FootprintLibrary">Footprint</see> file.
/// </summary>
public interface IKiCadLibrary
{
   /// <summary>
   /// Write the library to the provided folder.
   /// </summary>
   /// <param name="path">The folder where the library will be written.</param>
   void WriteLibrary(string path);
}
