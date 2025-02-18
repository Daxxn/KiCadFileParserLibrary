using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MVVMLibrary;

namespace KiCadFileParserLibrary.KiCad.Schematics;

/// <summary>
/// Collection of <see cref="Schematic">Schematics</see> from a KiCad project.
/// </summary>
public class ProjectSchematics : Model
{
   #region Local Props
   private ObservableCollection<Schematic> _schematics = [];
   private Schematic? _root = null;

   /// <summary>
   /// The number of project schematics.
   /// </summary>
   public int Count => _schematics?.Count ?? 0;
   #endregion

   #region Constructors
   /// <inheritdoc/>
   public ProjectSchematics() { }
   #endregion

   #region Methods
   /// <summary>
   /// Parse the schematic file from the KiCad project folder.
   /// </summary>
   /// <param name="projectFolder">the root project folder</param>
   /// <returns></returns>
   public static ProjectSchematics? ParseSchematics(string? projectFolder)
   {
      if (!Directory.Exists(projectFolder)) return null;

      var files = Directory.GetFiles(projectFolder, "*.kicad_sch", SearchOption.AllDirectories);
      if (files == null) return null;
      var projSchematics = new ProjectSchematics();
      foreach (var file in files)
      {
         var schematic = Schematic.Parse(file);
         if (schematic == null) continue;
         projSchematics.Schematics.Add(schematic);
         if (Path.GetFileNameWithoutExtension(file) == Path.GetFileName(projectFolder))
         {
            projSchematics.Root = schematic;
         }
      }
      return projSchematics;
   }

   /// <summary>
   /// Find the root schematic based on the provided ID.
   /// <para/>
   /// If found, <seealso cref="Root"/> will now contain the root schematic.
   /// </summary>
   /// <param name="rootID">The UUID for the root schematic.</param>
   public void SetRootSchematic(string? rootID)
   {
      if (string.IsNullOrEmpty(rootID)) return;
      if (!(Schematics?.Count > 0)) return;

      foreach (var sch in Schematics)
      {
         if (sch.ID == rootID)
         {
            Root = sch;
            return;
         }
      }
      Root = null;
   }

   /// <summary>
   /// Write the list of schematics to the KiCad project folder.
   /// </summary>
   /// <param name="projectFolder">The path to the project folder.</param>
   public void Write(string projectFolder)
   {
      foreach (var sch in Schematics)
      {
         sch.Write(projectFolder);
      }
   }

   /// <summary>
   /// Get index of the provided schematic.
   /// </summary>
   /// <param name="item">Schematic to search for.</param>
   /// <returns>The index of the schematic in the list. -1 if not found.</returns>
   public int IndexOf(Schematic item)
   {
      return Schematics?.IndexOf(item) ?? -1;
   }

   /// <summary>
   /// Insert the schematic at the desired index.
   /// </summary>
   /// <param name="index">The index to insert the schematic at.</param>
   /// <param name="item">The schematic to insert.</param>
   public void Insert(int index, Schematic item)
   {
      Schematics?.Insert(index, item);
   }

   /// <summary>
   /// Remove a schematic at the provided index.
   /// </summary>
   /// <param name="index">The index of the schematic to remove.</param>
   public void RemoveAt(int index)
   {
      Schematics?.RemoveAt(index);
   }

   /// <summary>
   /// Add a schematic to the end of the list.
   /// </summary>
   /// <param name="item">The schematic to add.</param>
   public void Add(Schematic item)
   {
      Schematics?.Add(item);
   }

   /// <summary>
   /// Clear all schematics.
   /// </summary>
   public void Clear()
   {
      Schematics?.Clear();
   }

   /// <summary>
   /// Check if the list of schematics contains the provided schematic.
   /// </summary>
   /// <param name="item">The schematic to search for.</param>
   /// <returns>True if the schematic can be found in the list.</returns>
   public bool Contains(Schematic item)
   {
      return Schematics?.Contains(item) == true;
   }

   /// <summary>
   /// Remove the provided schematic from the list.
   /// </summary>
   /// <param name="item">The schematic to remove.</param>
   /// <returns>True if the schematic was removed.</returns>
   public bool Remove(Schematic item)
   {
      return Schematics?.Remove(item) == true;
   }
   #endregion

   #region Full Props
   /// <inheritdoc/>
   public Schematic this[int index]
   {
      get => Schematics is null
            ? throw new NullReferenceException("No schematics found. Unable to find schematic at index.")
            : Schematics[index];
      set => Schematics![index] = value;
   }

   /// <summary>
   /// List of <see cref="Schematic">Schematics.</see>
   /// </summary>
   public ObservableCollection<Schematic> Schematics
   {
      get => _schematics;
      set
      {
         _schematics = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// The main schematic of the project
   /// </summary>
   public Schematic? Root
   {
      get => _root;
      set
      {
         _root = value;
         OnPropertyChanged();
      }
   }
   #endregion
}
