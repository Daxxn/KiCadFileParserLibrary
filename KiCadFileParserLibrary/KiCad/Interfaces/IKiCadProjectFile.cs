using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KiCadFileParserLibrary.KiCad.Interfaces;

/// <summary>
/// Defines an object as a KiCad project file.
/// <para/>
/// Can be a <see cref="Boards.PcbModel">PCB</see>, <see cref="Schematics.Schematic">Schematic</see>, or
/// <see cref="Project.ProjectSettings">Project</see> file.
/// </summary>
public interface IKiCadProjectFile
{
   /// <summary>
   /// Write the project file out to the provided path.
   /// </summary>
   /// <param name="filePath">The path string to where the file will be saved.</param>
   void Write(string filePath);
}
