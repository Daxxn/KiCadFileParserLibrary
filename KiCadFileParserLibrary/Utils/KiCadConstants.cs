using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KiCadFileParserLibrary.Utils;

/// <summary>
/// Constants used in KiCad projects
/// </summary>
public static class KiCadConstants
{
   /// <summary>
   /// Rule Severity map size
   /// </summary>
   public const int PinMapSize = 12;

   /// <summary>
   /// Default project revision string
   /// </summary>
   public const string DefaultRevision = "REV1";

   /// <summary>
   /// Delimiter used to parse project file names.
   /// </summary>
   public const char ProjectNameDelimiter = '_';

   /// <summary>
   /// Default schematic root sub-sheet name.
   /// </summary>
   public const string DefaultRootSchematicName = "Root";

   /// <summary>
   /// Default libraries folder path.
   /// <para/>
   /// Note: Needs to be formatted with the current KiCad version.
   /// </summary>
   public const string DefaultLibrariesFolder = @"C:\Program Files\KiCad\{0}\share\kicad";

   /// <summary>
   /// Default KiCad file extensions
   /// </summary>
   public static class Extensions
   {
      /// <summary>
      /// Default KiCad project file extension (<c>*.kicad_pro</c>)
      /// </summary>
      public const string Project = "kicad_pro";

      /// <summary>
      /// Default KiCad schematic file extension (<c>*.kicad_sch</c>)
      /// </summary>
      public const string Schematic = "kicad_sch";

      /// <summary>
      /// Default KiCad board file extension (<c>*.kicad_pcb</c>)
      /// </summary>
      public const string Board = "kicad_pcb";

      /// <summary>
      /// Default KiCad symbol library file extension (<c>*.kicad_sym</c>)
      /// </summary>
      public const string SymbolLibrary = "kicad_sym";

      /// <summary>
      /// Default KiCad footprint library folder extension (<c>*.pretty</c>)
      /// </summary>
      public const string FootprintLibrary = ".pretty";

      /// <summary>
      /// Default KiCad footprint library file extension (<c>*.kicad_mod</c>)
      /// </summary>
      public const string FootprintFile = "kicad_mod";
   }

   /// <summary>
   /// Default library sizes and strings.
   /// </summary>
   public static class LibraryDefaults
   {
      /// <summary>
      /// Default reference designator font size
      /// </summary>
      public const double SymbolRefFontSize = 1.6;

      /// <summary>
      /// Default symbol value font size
      /// </summary>
      public const double SymbolValueFontSize = 1.27;

      /// <summary>
      /// Symbol part number property font size
      /// </summary>
      public const double SymbolPartNumberFontSize = 1;

      /// <summary>
      /// Default symbol line width
      /// </summary>
      public const double SymbolLineWidth = 0.254;

      /// <summary>
      /// Default footprint reference designator font size
      /// </summary>
      public const double FootprintRefFontSize = 0.8;

      /// <summary>
      /// Default footprint reference designator font thickness
      /// </summary>
      public const double FootprintRefFontThickness = 0.12;

      /// <summary>
      /// Default footprint fabrication layer font size
      /// </summary>
      public const double FootprintFabFontSize = 0.25;

      /// <summary>
      /// Default footprint fabrication layer font thickness
      /// </summary>
      public const double FootprintFabFontThickness = 0.04;

      /// <summary>
      /// Reference designator silkscreen text
      /// </summary>
      public const string FootprintSilkRefText = "REF**";

      /// <summary>
      /// Footprint fabrication layer reference designator text
      /// </summary>
      public const string FootprintFabRefText = "${REFERENCE}";

      /// <summary>
      /// Reference designator silkscreen line width
      /// </summary>
      public const double FootprintSilkLineWidth = 0.1;

      /// <summary>
      /// Footprint fabrication layer line width
      /// </summary>
      public const double FootprintFabLineWidth = 0.05;

      /// <summary>
      /// Symbol pin name size
      /// </summary>
      public const double SymbolPinNameSize = 1.27;

      /// <summary>
      /// Symbol pin number size
      /// </summary>
      public const double SymbolPinNumberSize = 1;

      /// <summary>
      /// Symbol pin length
      /// </summary>
      public const double SymbolPinLength = 3.81;
   }

   /// <summary>
   /// PCB defaults
   /// </summary>
   public static class BoardDefaults
   {
      /// <summary>
      /// Default PCB trace width
      /// </summary>
      public const double TraceWidth = 0.2;

      /// <summary>
      /// Minimum clearance
      /// </summary>
      public const double MinClearance = 0.09;

      /// <summary>
      /// Minimum trace width
      /// </summary>
      public const double MinTraceWidth = 0.09;

      /// <summary>
      /// Silkscreen clearance
      /// </summary>
      public const double SilkClearance = 0.15;

      /// <summary>
      /// Via diameter
      /// </summary>
      public const double ViaDiameter = 0.45;

      /// <summary>
      /// Via hole size
      /// </summary>
      public const double ViaHoleSize = 0.3;
   }

   /// <summary>
   /// Property keys that are always present.
   /// </summary>
   public static class DefaultPropertyKeys
   {
      /// <summary>
      /// Sheet file name key for hierarchical schematic sheets.
      /// </summary>
      public const string SheetFile = "Sheetfile";

      /// <summary>
      /// Name key for hierarchical schematic sheets.
      /// </summary>
      public const string SheetName = "Sheetname";

      /// <summary>
      /// Reference designator key for symbols and footprints.
      /// </summary>
      public const string RefDesignator = "Reference";

      /// <summary>
      /// Value key for symbols and footprints.
      /// </summary>
      public const string Value = "Value";

      /// <summary>
      /// Footprint key for symbols and footprints.
      /// </summary>
      public const string Footprint = "Footprint";

      /// <summary>
      /// Datasheet key for symbols and footprints.
      /// </summary>
      public const string Datasheet = "Datasheet";

      /// <summary>
      /// Description key for symbols and footprints.
      /// </summary>
      public const string Description = "Description";

      /// <summary>
      /// Search keywords key for symbols.
      /// </summary>
      public const string Keywords = "ki_keywords";

      /// <summary>
      /// Footprint filters key for symbols and footprints.
      /// </summary>
      public const string FootprintFilers = "ki_fp_filters";
   }

   /// <summary>
   /// Default layer name constants
   /// </summary>
   public static class DefaultLayerNames
   {
      /// <summary>
      /// Default top copper layer name.
      /// </summary>
      public const string TopCopper     = "F.cu";

      /// <summary>
      /// Default bottom copper layer name.
      /// </summary>
      public const string BottomCopper  = "B.cu";

      /// <summary>
      /// Default top adhesive later name.
      /// </summary>
      public const string TopAdhesive = "F.Adhes";

      /// <summary>
      /// Default bottom adhesive later name.
      /// </summary>
      public const string BottomAdhesive = "B.Adhes";

      /// <summary>
      /// Default top paste later name.
      /// </summary>
      public const string TopPaste = "F.Paste";

      /// <summary>
      /// Default bottom paste later name.
      /// </summary>
      public const string BottomPaste = "B.Paste";

      /// <summary>
      /// Default top silkscreen later name.
      /// </summary>
      public const string TopSilk = "F.SilkS";

      /// <summary>
      /// Default bottom silkscreen later name.
      /// </summary>
      public const string BottomSilk = "B.SilkS";

      /// <summary>
      /// Default top solder mask later name.
      /// </summary>
      public const string TopMask = "F.Mask";

      /// <summary>
      /// Default bottom solder mask later name.
      /// </summary>
      public const string BottomMask = "B.Mask";

      /// <summary>
      /// Default user drawings layer name.
      /// </summary>
      public const string UserDrawings = "Dwgs.User";

      /// <summary>
      /// Default comments layer name.
      /// </summary>
      public const string Comments = "Cmts.User";

      /// <summary>
      /// Default Eco1 layer name? Not really sure what these layers are for.
      /// </summary>
      public const string Eco1 = "Eco1.User";

      /// <summary>
      /// Default Eco2 layer name? Not really sure what these layers are for.
      /// </summary>
      public const string Eco2 = "Eco2.User";

      /// <summary>
      /// Default PCB edge layer name.
      /// </summary>
      public const string EdgeCuts = "Edge.Cuts";

      /// <summary>
      /// Default margin layer name.
      /// </summary>
      public const string Margin = "Margin";

      /// <summary>
      /// Default top courtyard layer name.
      /// </summary>
      public const string TopCourtyard = "F.CrtYd";

      /// <summary>
      /// Default bottom courtyard layer name.
      /// </summary>
      public const string BottomCourtyard = "B.CrtYd";

      /// <summary>
      /// Default top fabrication layer name.
      /// </summary>
      public const string TopFab = "F.Fab";

      /// <summary>
      /// Default bottom fabrication layer name.
      /// </summary>
      public const string BottomFab = "B.Fab";

      /// <summary>
      /// Default user layer 1 name.
      /// </summary>
      public const string User1 = "User.1";

      /// <summary>
      /// Default user layer 2 name.
      /// </summary>
      public const string User2 = "User.2";

      /// <summary>
      /// Default user layer 3 name.
      /// </summary>
      public const string User3 = "User.3";

      /// <summary>
      /// Default user layer 4 name.
      /// </summary>
      public const string User4 = "User.4";

      /// <summary>
      /// Default user layer 5 name.
      /// </summary>
      public const string User5 = "User.5";

      /// <summary>
      /// Default user layer 6 name.
      /// </summary>
      public const string User6 = "User.6";

      /// <summary>
      /// Default user layer 7 name.
      /// </summary>
      public const string User7 = "User.7";

      /// <summary>
      /// Default user layer 8 name.
      /// </summary>
      public const string User8 = "User.8";

      /// <summary>
      /// Default user layer 9 name.
      /// </summary>
      public const string User9 = "User.9";


      /// <summary>
      /// Default inner copper 1 layer name.
      /// </summary>
      public const string Inner1Copper  = "In1.cu";

      /// <summary>
      /// Default inner copper 2 layer name.
      /// </summary>
      public const string Inner2Copper  = "In2.cu";

      /// <summary>
      /// Default inner copper 3 layer name.
      /// </summary>
      public const string Inner3Copper  = "In3.cu";

      /// <summary>
      /// Default inner copper 4 layer name.
      /// </summary>
      public const string Inner4Copper  = "In4.cu";

      /// <summary>
      /// Default inner copper 5 layer name.
      /// </summary>
      public const string Inner5Copper  = "In5.cu";

      /// <summary>
      /// Default inner copper 6 layer name.
      /// </summary>
      public const string Inner6Copper  = "In6.cu";

      /// <summary>
      /// Default inner copper 7 layer name.
      /// </summary>
      public const string Inner7Copper  = "In7.cu";

      /// <summary>
      /// Default inner copper 8 layer name.
      /// </summary>
      public const string Inner8Copper  = "In8.cu";

      /// <summary>
      /// Default inner copper 9 layer name.
      /// </summary>
      public const string Inner9Copper  = "In9.cu";

      /// <summary>
      /// Default inner copper 10 layer name.
      /// </summary>
      public const string Inner10Copper = "In10.cu";

      /// <summary>
      /// Default inner copper 11 layer name.
      /// </summary>
      public const string Inner11Copper = "In11.cu";

      /// <summary>
      /// Default inner copper 12 layer name.
      /// </summary>
      public const string Inner12Copper = "In12.cu";

      /// <summary>
      /// Default inner copper 13 layer name.
      /// </summary>
      public const string Inner13Copper = "In13.cu";

      /// <summary>
      /// Default inner copper 14 layer name.
      /// </summary>
      public const string Inner14Copper = "In14.cu";

      /// <summary>
      /// Default inner copper 15 layer name.
      /// </summary>
      public const string Inner15Copper = "In15.cu";

      /// <summary>
      /// Default inner copper 16 layer name.
      /// </summary>
      public const string Inner16Copper = "In16.cu";

      /// <summary>
      /// Default inner copper 17 layer name.
      /// </summary>
      public const string Inner17Copper = "In17.cu";

      /// <summary>
      /// Default inner copper 18 layer name.
      /// </summary>
      public const string Inner18Copper = "In18.cu";

      /// <summary>
      /// Default inner copper 19 layer name.
      /// </summary>
      public const string Inner19Copper = "In19.cu";

      /// <summary>
      /// Default inner copper 20 layer name.
      /// </summary>
      public const string Inner20Copper = "In20.cu";

      /// <summary>
      /// Default inner copper 21 layer name.
      /// </summary>
      public const string Inner21Copper = "In21.cu";

      /// <summary>
      /// Default inner copper 22 layer name.
      /// </summary>
      public const string Inner22Copper = "In22.cu";

      /// <summary>
      /// Default inner copper 23 layer name.
      /// </summary>
      public const string Inner23Copper = "In23.cu";

      /// <summary>
      /// Default inner copper 24 layer name.
      /// </summary>
      public const string Inner24Copper = "In24.cu";

      /// <summary>
      /// Default inner copper layer name formatter.
      /// </summary>
      /// <param name="layerNumber">Inner layer number.</param>
      /// <returns>The formatted name of the inner layer.</returns>
      public static string InnerCopper(int layerNumber) => $"In{layerNumber}.cu";
   }
}
