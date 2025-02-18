using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.SExprParser;

using MVVMLibrary;

namespace KiCadFileParserLibrary.KiCad.General.Graphics;

/// <summary>
/// Base abstract class for general graphics models.
/// </summary>
public abstract class GraphicBase : Model, IKiCadReadable
{
   /// <inheritdoc/>
   public abstract void ParseNode(Node node);
}
