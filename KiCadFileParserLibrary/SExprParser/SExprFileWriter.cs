using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KiCadFileParserLibrary.SExprParser;

/// <summary>
/// SExpression file writer
/// </summary>
public class SExprFileWriter
{
   #region Local Props
   private SExprFileOptions Options { get; set; } = new();
   #endregion

   #region Constructors
   /// <inheritdoc/>
   public SExprFileWriter() { }
   /// <summary>
   /// Construct a <see cref="SExprFileWriter"/> with custom parser options.
   /// </summary>
   /// <param name="options">Custom parser options.</param>
   public SExprFileWriter(SExprFileOptions options) => Options = options;
   #endregion

   #region Methods
   /// <summary>
   /// Write the SExpression node to the provided file path.
   /// <para/>
   /// NOT DONE
   /// </summary>
   /// <param name="path">file path</param>
   /// <param name="rootNode">The root node of the SExpression file.</param>
   public void Write(string path, Node rootNode)
   {
      throw new NotImplementedException();
   }
   #endregion

   #region Full Props

   #endregion
}
