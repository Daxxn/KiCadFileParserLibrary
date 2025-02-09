using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KiCadFileParserLibrary.KiCad.Interfaces;
internal interface IKiCadWriteableCollection
{
   void WriteCollection(StringBuilder builder, int indent);
}
