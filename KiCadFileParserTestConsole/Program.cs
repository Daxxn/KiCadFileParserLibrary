using KiCadFileParserLibrary.KiCad.Footprints;
using KiCadFileParserLibrary.KiCad.Boards;
using KiCadFileParserLibrary.KiCad.Project;
using KiCadFileParserLibrary.KiCad.Schematics;
using KiCadFileParserLibrary.KiCad.Symbols;
using KiCadFileParserLibrary.KiCad;
using System.Text;

namespace KiCadFileParserTestConsole
{
   public enum TestMode
   {
      PCB_FILE,
      SCHEMATIC_FILE,
      PROJECT_FILE,
      FOOTPRINT_LIBRARY,
      SYMBOL_LIBRARY,
      FULL_PROJECT,
      PCB_OUTPUT_DEBUG
   };

   internal class Program
   {
      private static string PcbFile = @"F:\Electrical\Designs\Testing\ParserTestPCB\ParserTestPCB.kicad_pcb";
      private static string PcbOutFile = @"F:\Electrical\Designs\Testing\ParserTestPCBOutput\ParserTestPCBOutput.kicad_pcb";
      private static string SchematicFile = @"F:\Electrical\Designs\Testing\ParserTestPCB\ParserTestPCB.kicad_sch";
      private static string SchematicOutputFile = @"F:\Electrical\Designs\Testing\ParserTestPCB\ParserTestPCB_OUT.kicad_sch";
      private static string FootprintFolder = @"F:\Electrical\KiCad\Libraries\Footprints\Daxxn_TestLibrary.pretty";
      private static string SymbolLibFile = @"F:\Electrical\KiCad\Libraries\Symbols\Daxxn_Testing.kicad_sym";
      private static string ProjectFile = @"F:\Electrical\Designs\Testing\ParserTestPCB\ParserTestPCB.kicad_pro";
      private static string ProjectOutputFile = @"F:\Electrical\Designs\Testing\ParserTestPCB\ParserTestPCB_Output.kicad_pro";
      private static string ProjectFolder = @"F:\Electrical\Designs\Testing\ParserTestPCB";
      private static TestMode Test = TestMode.PCB_FILE;

      private static PcbModel? pcb;
      private static Schematic? schematic;
      private static FootprintLibrary? footprints;
      private static SymbolLibrary? symbols;
      private static ProjectSettings? projectSettings;
      private static KiCadProject? project;

      static void Main(string[] args)
      {
         Console.WriteLine("KiCad File Parser Testing");

         Console.WriteLine($"Reading {Test}");
         switch (Test)
         {
            case TestMode.PCB_FILE:
               pcb = PcbModel.Parse(PcbFile);
               break;
            case TestMode.SCHEMATIC_FILE:
               schematic = Schematic.Parse(SchematicFile);
               break;
            case TestMode.FOOTPRINT_LIBRARY:
               footprints = FootprintLibrary.ParseLibrary(FootprintFolder);
               break;
            case TestMode.SYMBOL_LIBRARY:
               symbols = SymbolLibrary.ParseLibrary(SymbolLibFile);
               break;
            case TestMode.PROJECT_FILE:
               projectSettings = ProjectSettings.Parse(ProjectFile);

               projectSettings?.Write(ProjectOutputFile);
               break;
            case TestMode.FULL_PROJECT:
               project = KiCadProject.Build(ProjectFolder);
               break;
            case TestMode.PCB_OUTPUT_DEBUG:
               var pcbA = PcbModel.Parse(PcbFile);
               var pcbB = PcbModel.Parse(PcbOutFile);
               if (ComparePCBs(pcbA, pcbB)) {
                  Console.WriteLine("PCBs Match");
               } else
               {
                  Console.WriteLine("PCBs DONT Match!!");
               }
               break;
            default:
               break;
         }

         Console.WriteLine($"Writing {Test}");
         switch (Test)
         {
            case TestMode.PCB_FILE:
               Console.WriteLine(pcb);
               Console.WriteLine();
               if (pcb is null) break;
               StringBuilder pcbBuilder = new();
               pcb.WriteNode(pcbBuilder, 0);
               Console.WriteLine(pcbBuilder.ToString());
               WriteFile(PcbOutFile, pcbBuilder.ToString());
               break;
            case TestMode.SCHEMATIC_FILE:
               Console.WriteLine(schematic);
               Console.WriteLine();
               if (schematic is null) break;
               StringBuilder schBuilder = new();
               schematic.WriteNode(schBuilder, 0);
               Console.WriteLine(schBuilder.ToString());
               WriteFile(SchematicOutputFile, schBuilder.ToString());
               break;
            case TestMode.PROJECT_FILE:
               Console.WriteLine(projectSettings);
               Console.WriteLine();
               if (projectSettings is null) break;
               break;
            case TestMode.FOOTPRINT_LIBRARY:
               Console.WriteLine(footprints);
               Console.WriteLine();
               if (footprints is null) break;
               footprints.WriteLibrary();
               Console.WriteLine("Written Footprint Library");
               break;
            case TestMode.SYMBOL_LIBRARY:
               break;
            case TestMode.FULL_PROJECT:
               break;
            default:
               break;
         }

         //Console.WriteLine("Done!");
         //Console.ReadKey();
      }

      private static void WriteFile(string path, string data)
      {
         File.WriteAllText(path, data);
      }

      private static bool ComparePCBs(PcbModel? pcbA, PcbModel? pcbB)
      {
         return pcbA == pcbB;
      }
   }
}
