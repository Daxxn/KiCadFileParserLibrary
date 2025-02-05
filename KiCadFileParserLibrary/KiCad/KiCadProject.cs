using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.KiCad.Boards;
using KiCadFileParserLibrary.KiCad.Project;
using KiCadFileParserLibrary.KiCad.Schematics;

using MVVMLibrary;

namespace KiCadFileParserLibrary.KiCad
{
   public class KiCadProject : Model
   {
      #region Local Props
      private string? _projFolder;
      private ProjectSettings? _projSettings;
      private PcbModel? _pcb;
      private ProjectSchematics? _schematics;
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
      public string? ProjectFolder
      {
         get => _projFolder;
         set
         {
            _projFolder = value;
            OnPropertyChanged();
         }
      }

      public ProjectSettings? ProjectSettings
      {
         get => _projSettings;
         set
         {
            _projSettings = value;
            OnPropertyChanged();
         }
      }

      public PcbModel? PCB
      {
         get => _pcb;
         set
         {
            _pcb = value;
            OnPropertyChanged();
         }
      }

      public ProjectSchematics? Schematics
      {
         get => _schematics;
         set
         {
            _schematics = value;
            OnPropertyChanged();
         }
      }
      #endregion
   }
}
