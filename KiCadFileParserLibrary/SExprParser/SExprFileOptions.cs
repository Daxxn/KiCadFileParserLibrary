using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KiCadFileParserLibrary.SExprParser
{
   public class SExprFileOptions
   {
      public char OpenDelimiter { get; set; } = '(';
      public char CloseDelimiter { get; set; } = ')';
      public char PropertyDelimiter { get; set; } = '"';
      public char[] ExclusionChars { get; set; } = ['\n', '\r', '\t'];
      public char[] TrimChars { get; set; } = [' ', '"'];
   }
}
