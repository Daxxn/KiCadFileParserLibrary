using KiCadFileParserLibrary.KiCad.Footprints;
using KiCadFileParserLibrary.KiCad.Pcb;
using KiCadFileParserLibrary.KiCad.Symbol;
using KiCadFileParserLibrary.SExprParser;

namespace KiCadFileParserTestConsole
{
   public enum TestMode
   {
      PCB_SAVE_FILE,
      SCHEMATIC_SAVE_FILE,
      FOOTPRINT_LIBRARY,
      SYMBOL_LIBRARY,
   };

   internal class Program
   {
      private static string KiCadPcbFile = @"F:\Electrical\Designs\Testing\ParserTestPCB\ParserTestPCB.kicad_pcb";
      private static string SchematicFile = @"F:\Electrical\Designs\Testing\ParserTestPCB\ParserTestPCB.kicad_sch";
      private static string FootprintFolder = @"F:\Electrical\KiCad\Libraries\Footprints\Daxxn_TestLibrary.pretty";
      private static string SymbolLibFile = @"F:\Electrical\KiCad\Libraries\Symbols\Daxxn_Testing.kicad_sym";
      private static TestMode Test;

      static void Main(string[] args)
      {
         Console.WriteLine("KiCad File Parser Testing");

         switch (Test)
         {
            case TestMode.PCB_SAVE_FILE:
               var pcb = PcbModel.Parse(KiCadPcbFile);
               Console.WriteLine(pcb);
               break;
            case TestMode.SCHEMATIC_SAVE_FILE:
               var schematic = Schem
               break;
            case TestMode.FOOTPRINT_LIBRARY:
               var footprintLib = FootprintLibrary.ParseLibrary(FootprintFolder);
               break;
            case TestMode.SYMBOL_LIBRARY:
               var symbolLibrary = SymbolLibrary.ParseLibrary(SymbolLibFile);
               break;
            default:
               break;
         }

         Console.WriteLine("Done!");
         Console.ReadKey();
      }
   }
}
