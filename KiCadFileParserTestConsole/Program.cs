using KiCadFileParserLibrary.SExprParser;

namespace KiCadFileParserTestConsole
{
   internal class Program
   {
      private static string KiCadPcbPath = @"F:\Electrical\Designs\Testing\ParserTestPCB\ParserTestPCB.kicad_pcb";
      static void Main(string[] args)
      {
         Console.WriteLine("KiCad File Parser Testing");
         var reader = new SExprFileReader();
         var root = reader.Read(KiCadPcbPath);
         if (root is null)
         {
            Console.WriteLine("Failed to read save file.");
         }
         else
         {
            reader.Parse(root);
         }

         Console.WriteLine("Done!");
         Console.ReadKey();
      }
   }
}
