using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.KiCad.Boards;
using KiCadFileParserLibrary.KiCad.Project;
using KiCadFileParserLibrary.KiCad.Schematics;
using KiCadFileParserLibrary.KiCad.Schematics.SubModels;
using KiCadFileParserLibrary.Utils;

using MVVMLibrary;

namespace KiCadFileParserLibrary.KiCad;

/// <summary>
/// A model of a KiCad project.
/// </summary>
public class KiCadProjectModel : Model
{
   #region Local Props
   private string? _projFolder;
   private ProjectSettings? _projSettings;
   private PcbModel? _pcb;
   private ProjectSchematics? _schematics;
   #endregion

   #region Constructors
   /// <inheritdoc/>
   public KiCadProjectModel() { }

   /// <summary>
   /// <inheritdoc/>
   /// </summary>
   /// <param name="projectFolder">The path to the KiCad project folder.</param>
   public KiCadProjectModel(string projectFolder) => ProjectFolder = projectFolder;
   #endregion

   #region Methods
   /// <summary>
   /// Parse the KiCad project.
   /// <para/>
   /// Looks for:
   /// <list type="bullet">
   ///   <item><see cref="Schematic">Schematics</see></item>
   ///   <item><see cref="Project.ProjectSettings">Project File</see></item>
   ///   <item><see cref="PcbModel">PCB File</see></item>
   /// </list>
   /// </summary>
   /// <param name="projectFolderPath"></param>
   /// <returns></returns>
   public static KiCadProjectModel? Parse(string projectFolderPath)
   {
      if (!Directory.Exists(projectFolderPath)) return null;
      var files = Directory.GetFiles(projectFolderPath);
      var newProj = new KiCadProjectModel(projectFolderPath);

      if (newProj.ProjectSettingsPath is null) return null;
      newProj.ProjectSettings = ProjectSettings.Parse(newProj.ProjectSettingsPath);

      newProj.Schematics = ProjectSchematics.ParseSchematics(newProj.ProjectFolder);

      if (newProj.PcbPath is null) return null;
      var pcb = PcbModel.Parse(newProj.PcbPath);
      if (pcb != null)
      {
         newProj.PCB = pcb;
      }

      return newProj;
   }

   /// <summary>
   /// Save the project data.
   /// </summary>
   public void Save()
   {
      if (!Directory.Exists(ProjectFolder)) return;
      ProjectSettings?.Write(ProjectSettingsPath!);
      PCB?.Write(PcbPath!);
      Schematics?.Write(ProjectFolder);
   }

   /// <summary>
   /// Save the project in a different location.
   /// </summary>
   /// <param name="newProjectFolder">The new project location.</param>
   /// <param name="overwrite">Overwrite any data in the new location.</param>
   /// <exception cref="Exception">Throws if the location already exists and overwrite is false.</exception>
   public void SaveAs(string newProjectFolder, bool overwrite = false)
   {
      var newProjectDir = new DirectoryInfo(newProjectFolder);
      if (!newProjectDir.Exists)
      {
         newProjectDir.Create();
      }
      else if (!overwrite)
      {
         throw new Exception("Project already exists and overwrite is not allowed.");
      }

      ProjectSettings?.Write(Path.Combine(newProjectFolder, $"{ProjectName}.{KiCadConstants.Extensions.Project}"));

      PCB?.Write(Path.Combine(newProjectFolder, $"{ProjectName}.{KiCadConstants.Extensions.Board}"));

      Schematics?.Write(newProjectFolder);

      ProjectFolder = newProjectDir.FullName;
   }

   /// <summary>
   /// Copy the project to the provided location.
   /// </summary>
   /// <param name="newProjectFolder">The new project location.</param>
   /// <param name="overwrite">Overwrite any data in the new location.</param>
   /// <exception cref="Exception">Throws if the location already exists and overwrite is false.</exception>
   public void Copy(string newProjectFolder, bool overwrite = false)
   {
      var newProjectDir = new DirectoryInfo(newProjectFolder);
      if (!newProjectDir.Exists)
      {
         newProjectDir.Create();
      }
      else if (!overwrite)
      {
         throw new Exception("Project already exists and overwrite is not allowed.");
      }

      ProjectSettings?.Write(Path.Combine(newProjectFolder, $"{ProjectName}.{KiCadConstants.Extensions.Project}"));

      PCB?.Write(Path.Combine(newProjectFolder, $"{ProjectName}.{KiCadConstants.Extensions.Board}"));

      Schematics?.Write(newProjectFolder);
   }

   /// <summary>
   /// Change the project name.
   /// <para/>
   /// Note: This will rename the project in every place I can find, rename the project folder and files.
   /// </summary>
   /// <param name="newName">The new name of the project.</param>
   public void ChangeProjectName(string newName)
   {
      if (string.IsNullOrEmpty(newName)) return;
      if (newName.Contains(KiCadConstants.ProjectNameDelimiter)) return;
      if (string.IsNullOrEmpty(ProjectFolder)) return;
      if (ProjectSettings is null) return;

      var oldProjectDir = new DirectoryInfo(ProjectFolder);
      if (oldProjectDir.Parent is null) throw new DirectoryNotFoundException("The parent of the project folder can not be found!");
      var newProjectDir = new DirectoryInfo(Path.Combine(oldProjectDir.Parent.FullName!, newName));

      if (!newProjectDir.Exists)
      {
         newProjectDir.Create();
      }

      string newProjPath = Path.Combine(newProjectDir.FullName, $"{newName}.{KiCadConstants.Extensions.Project}");
      string newPcbPath = Path.Combine(newProjectDir.FullName, $"{newName}.{KiCadConstants.Extensions.Board}");

      if (ProjectSettings.Metadata != null)
      {
         ProjectSettings.Metadata.FileName = $"{newName}.{KiCadConstants.Extensions.Schematic}";
      }

      // Rename schematic and properties and write them to the new folder.
      if (Schematics != null && ProjectSettings?.Sheets != null)
      {
         if (Schematics.Root is null)
         {
            Schematics.SetRootSchematic(ProjectSettings?.Sheets?.GetProjectID(ProjectName));
         }

         string newNameWithSuffix = "";
         string newSchematicPath = "";
         foreach (var sch in Schematics.Schematics)
         {
            sch.ChangeProjectName(newName);
            var schematicName = Path.GetFileNameWithoutExtension(sch.FilePath);
            newNameWithSuffix = schematicName.Replace(ProjectName!, newName);
            newSchematicPath = Path.Combine(newProjectDir.FullName, $"{newNameWithSuffix}.{KiCadConstants.Extensions.Schematic}");

            //File.Copy(sch.FilePath, newSchematicPath, true);
            sch.FilePath = newSchematicPath;
            sch.Write(sch.FilePath);
         }
      }

      if (PCB != null)
      {
         PCB.ChangeProjectName(ProjectName!, newName);
         PCB.Write(newPcbPath);
      }

      if (ProjectSettings != null)
      {
         if (ProjectSettings.Metadata != null)
         {
            ProjectSettings.Metadata.FileName = $"{newName}.{KiCadConstants.Extensions.Project}";
         }
         ProjectSettings.Write(newProjPath);
      }
   }
   #endregion

   #region Full Props
   /// <summary>
   /// The name of the project.
   /// <para/>
   /// Note: This is only the name of the project. Use <seealso cref="ProjectFolder"/> for the full path.
   /// </summary>
   public string? ProjectName
   {
      get
      {
         if (ProjectFolder == null) return null;
         return Path.GetFileName(ProjectFolder);
      }
   }

   /// <summary>
   /// The project settings file path. (<c>*.kicad_pro</c>)
   /// </summary>
   public string? ProjectSettingsPath
   {
      get
      {
         if (ProjectFolder == null) return null;
         return Path.Combine(ProjectFolder, $"{ProjectName}.{KiCadConstants.Extensions.Project}");
      }
   }

   /// <summary>
   /// List of schematic file paths.
   /// </summary>
   public string[]? SchematicPaths
   {
      get
      {
         if (ProjectFolder == null) return null;
         //return Directory.GetFiles(ProjectFolder, "*.kicad_sch");
         return Schematics?.Schematics.Select(sch => sch.FilePath).ToArray();
      }
   }

   /// <summary>
   /// Project PCB file path.
   /// </summary>
   public string? PcbPath
   {
      get
      {
         if (ProjectFolder == null) return null;
         return Path.Combine(ProjectFolder, $"{ProjectName}.{KiCadConstants.Extensions.Board}");
      }
   }

   /// <summary>
   /// The root folder for the KiCad project.
   /// </summary>
   public string? ProjectFolder
   {
      get => _projFolder;
      set
      {
         _projFolder = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// The KiCad project settings data.
   /// </summary>
   public ProjectSettings? ProjectSettings
   {
      get => _projSettings;
      set
      {
         _projSettings = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// The PCB data model.
   /// </summary>
   public PcbModel? PCB
   {
      get => _pcb;
      set
      {
         _pcb = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// List of schematic models.
   /// </summary>
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
