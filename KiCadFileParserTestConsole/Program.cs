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
      FOOTPRINT_LIBS,
      SYMBOL_LIBS,
      ALL_LIBRARIES,
      FULL_PROJECT,
      RENAME_PROJECT,
   };

   internal class Program
   {
      private static string PcbFile                = @"F:\Electrical\Designs\Testing\ParserTestPCB\ParserTestPCB.kicad_pcb";
      private static string PcbOutFile             = @"F:\Electrical\Designs\Testing\ParserTestPCBOutput\ParserTestPCBOutput.kicad_pcb";
      private static string SchematicFile          = @"F:\Electrical\Designs\Testing\ParserTestPCB\ParserTestPCB.kicad_sch";
      private static string SchematicOutputFile    = @"F:\Electrical\Designs\Testing\ParserTestPCBOutput\ParserTestPCBOutput.kicad_sch";
      private static string FootprintLibFolder     = @"F:\Electrical\KiCad\Libraries\Footprints\Daxxn_TestLibrary.pretty";
      private static string FootprintLibOutFolder  = @"F:\Electrical\KiCad\Libraries\Testing\Footprints";
      private static string SymbolLibFile          = @"F:\Electrical\KiCad\Libraries\Symbols\Daxxn_Testing.kicad_sym";
      private static string SymbolOutputFile       = @"F:\Electrical\KiCad\Libraries\Testing\Symbols";
      private static string ProjectFile            = @"F:\Electrical\Designs\Testing\ParserTestPCB\ParserTestPCB.kicad_pro";
      private static string ProjectOutputFile      = @"F:\Electrical\Designs\Testing\ParserTestPCBOutput\ParserTestPCBOutput.kicad_pro";
      private static string ProjectFolder          = @"F:\Electrical\Designs\Testing\ParserTestPCB";
      private static string ProjectOutputFolder    = @"F:\Electrical\Designs\Testing\ParserTestPCBOutput2";
      private static string RootFootprintFolder    = @"F:\Electrical\KiCad\Libraries\Footprints";
      private static string RootSymbolFolder       = @"F:\Electrical\KiCad\Libraries\Symbols";
      private static string RootLibrariesFolder    = @"F:\Electrical\KiCad\Libraries";
      private static string RootLibsOutputFolder   = @"F:\Electrical\KiCad\Libraries\Testing";

      private static TestMode Test = TestMode.RENAME_PROJECT;
      private static bool Write = false;
      private static bool KeepOpen = false;

      private static PcbModel? pcb;
      private static Schematic? schematic;
      private static FootprintLibrary? footprints;
      private static SymbolLibrary? symbols;
      private static ProjectSettings? projectSettings;
      private static KiCadProjectModel? project;
      private static FootprintLibraryCollection? footprintsCollection;
      private static SymbolLibraryCollection? symbolsCollection;
      private static KiCadLibraries? AllLibraries;

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
               footprints = FootprintLibrary.ParseLibrary(FootprintLibFolder);
               break;
            case TestMode.SYMBOL_LIBRARY:
               symbols = SymbolLibrary.ParseLibrary(SymbolLibFile);
               break;
            case TestMode.PROJECT_FILE:
               projectSettings = ProjectSettings.Parse(ProjectFile);
               break;
            case TestMode.FULL_PROJECT:
               project = KiCadProjectModel.Parse(ProjectFolder);
               break;
            case TestMode.FOOTPRINT_LIBS:
               footprintsCollection = FootprintLibraryCollection.ParseLibraries(RootFootprintFolder);
               break;
            case TestMode.SYMBOL_LIBS:
               symbolsCollection = SymbolLibraryCollection.ParseLibraries(RootSymbolFolder);
               break;
            case TestMode.ALL_LIBRARIES:
               AllLibraries = KiCadLibraries.Parse(RootLibrariesFolder);
               break;
            case TestMode.RENAME_PROJECT:
               project = KiCadProjectModel.Parse(ProjectFolder);
               if (project is null) break;
               project.ChangeProjectName("newTextOutput");
               break;
            default:
               break;
         }

         if (!Write)
         {
            Console.WriteLine("Write Mode Disabled...");
            return;
         }
         else
         {
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
               case TestMode.SCHEMATIC_FILE: // Uses the raw schematic class
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
                  projectSettings?.Write(ProjectOutputFile);
                  break;
               case TestMode.FOOTPRINT_LIBRARY:
                  Console.WriteLine(footprints);
                  Console.WriteLine();
                  if (footprints is null) break;
                  footprints.LibraryName = "Daxxn_TestOutputLibrary";
                  footprints.WriteLibrary(FootprintLibOutFolder);
                  Console.WriteLine("Written Footprint Library");
                  break;
               case TestMode.SYMBOL_LIBRARY:
                  Console.WriteLine();
                  if (symbols is null) break;
                  symbols.Name = "Daxxn_TestingOutput";
                  symbols.WriteLibrary(SymbolOutputFile);
                  Console.WriteLine("Written Symbol Library");
                  break;
               case TestMode.FULL_PROJECT:
                  project?.Copy(ProjectOutputFolder, true);
                  break;
               case TestMode.FOOTPRINT_LIBS:
                  footprintsCollection?.WriteCopy(Path.Combine(RootLibsOutputFolder, "Footprints"));
                  break;
               case TestMode.SYMBOL_LIBS:
                  symbolsCollection?.WriteCopy(Path.Combine(RootLibsOutputFolder, "Symbols"));
                  break;
               case TestMode.ALL_LIBRARIES:
                  AllLibraries?.Copy(RootLibsOutputFolder);
                  break;
               case TestMode.RENAME_PROJECT:
                  project?.Save();
                  break;
               default:
                  break;
            }
         }

         if (KeepOpen)
         {
            Console.WriteLine("Done!");
            Console.ReadKey();
         }
      }

      private static void WriteFile(string path, string data)
      {
         File.WriteAllText(path, data);
      }
   }
}
