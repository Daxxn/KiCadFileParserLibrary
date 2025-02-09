using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KiCadFileParserLibrary.Attributes;

[AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
sealed class SExprFormattingAttribute : Attribute
{
   private readonly bool _exportAsInt = true;
   private readonly bool _ignoreIfNull = true;

   public SExprFormattingAttribute(bool exportAsInt, bool ignoreIfNull)
   {
      _exportAsInt = exportAsInt;
      _ignoreIfNull = ignoreIfNull;
   }

   public bool ExportAsInt => _exportAsInt;
   public bool IgnoreIfNull => _ignoreIfNull;
}
