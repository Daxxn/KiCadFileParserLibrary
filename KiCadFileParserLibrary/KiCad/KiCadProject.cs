using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.KiCad.Boards;
using KiCadFileParserLibrary.KiCad.Project;
using KiCadFileParserLibrary.KiCad.Schematics;

namespace KiCadFileParserLibrary.KiCad
{
   public class KiCadProject
   {
      #region Local Props
      //public static readonly Dictionary<string, ProjectFileType> KiCadProjectFileTypes = new()
      //{
      //   { "kicad_sch", ProjectFileType.Schematic },
      //   { "kicad_pcb", ProjectFileType.PCB },
      //   { "kicad_pro", ProjectFileType.Project },
      //};

      public string? ProjectFolder { get; set; }

      public ProjectSettings? ProjectSettings { get; set; }

      public PcbModel? PCB { get; set; }

      public ProjectSchematics? Schematics { get; set; }
      #endregion

      #region Constructors
      public KiCadProject(string projectFolder) => ProjectFolder = projectFolder;
      #endregion

      #region Methods
      public static KiCadProject? Build(string projectFolderPath)
      {
         if (!Directory.Exists(projectFolderPath)) return null;
         var files = Directory.GetFiles(projectFolderPath);
         var newProj = new KiCadProject(projectFolderPath);

         if (newProj.ProjectSettingsPath is null) return null;
         newProj.ProjectSettings = ProjectSettings.Parse(newProj.ProjectSettingsPath);

         if (newProj.SchematicPaths is null) return null;
         foreach ( var file in newProj.SchematicPaths)
         {
            var sch = Schematic.Parse(file);
            if (sch != null)
            {
               newProj.Schematics ??= new();
               newProj.Schematics.Add(sch);
            }
         }

         if (newProj.PcbPath is null) return null;
         var pcb = PcbModel.Parse(newProj.PcbPath);
         if (pcb != null)
         {
            newProj.PCB = pcb;
         }

         return newProj;
      }
      #endregion

      #region Full Props
      public string? ProjectName
      {
         get
         {
            if (ProjectFolder == null) return null;
            //return Path.GetFileNameWithoutExtension(ProjectFolder);
            return Path.GetDirectoryName(ProjectFolder);
         }
      }

      public string? ProjectSettingsPath
      {
         get
         {
            if (ProjectFolder == null) return null;
            return Path.Combine(ProjectFolder, $"{ProjectName}.kicad_pro");
         }
      }

      public string[]? SchematicPaths
      {
         get
         {
            if (ProjectFolder == null) return null;
            return Directory.GetFiles(ProjectFolder, "*.kicad_sch");
         }
      }

      public string? PcbPath
      {
         get
         {
            if (ProjectFolder == null) return null;
            return Path.Combine(ProjectFolder, $"{ProjectName}.kicad_pcb");
         }
      }
      #endregion
   }
}
