using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.SExprParser;

using MVVMLibrary;

namespace KiCadFileParserLibrary.KiCad.Symbols.Graphics;

/// <summary>
/// Abstract symbol graphic class
/// </summary>
public abstract class SyGraphicBase : Model, IKiCadReadable
{
   /// <inheritdoc/>
   public abstract void ParseNode(Node node);
}
