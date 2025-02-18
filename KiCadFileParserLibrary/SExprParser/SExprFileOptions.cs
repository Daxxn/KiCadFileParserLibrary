using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KiCadFileParserLibrary.SExprParser;

/// <summary>
/// SExpression file parser options
/// </summary>
public class SExprFileOptions
{
   /// <summary>
   /// Move down tree delimiter
   /// <para/>
   /// SExpression should only use parentheses, I put this in just because.
   /// </summary>
   public char OpenDelimiter { get; set; } = '(';
   /// <summary>
   /// Move up tree delimiter
   /// <para/>
   /// SExpression should only use parentheses, I put this in just because.
   /// </summary>
   public char CloseDelimiter { get; set; } = ')';
   /// <summary>
   /// Property string delimiter
   /// </summary>
   public char PropertyDelimiter { get; set; } = '"';
   /// <summary>
   /// File formatting characters not part of the logic of the file.
   /// </summary>
   public char[] ExclusionChars { get; set; } = ['\n', '\r', '\t'];
   /// <summary>
   /// Characters to trim after parsing.
   /// </summary>
   public char[] TrimChars { get; set; } = [' ', '"'];
}
