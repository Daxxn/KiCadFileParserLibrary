using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KiCadFileParserLibrary.SExprParser
{
   public class SExprFileWriter
   {
      #region Local Props
      private SExprFileOptions Options { get; set; } = new();
      #endregion

      #region Constructors
      public SExprFileWriter() { }
      public SExprFileWriter(SExprFileOptions options) => Options = options;
      #endregion

      #region Methods
      public void Write(string path, Node rootNode)
      {

      }
      #endregion

      #region Full Props

      #endregion
   }
}
