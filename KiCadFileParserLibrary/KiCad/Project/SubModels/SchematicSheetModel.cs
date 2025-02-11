using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MVVMLibrary;

namespace KiCadFileParserLibrary.KiCad.Project.SubModels;

/// <summary>
/// A model containing the name and ID for a schematic used in the project.
/// </summary>
public class SchematicSheetModel : Model
{
   #region Local Props
   private string _name = "";
   private string _id = "";
   #endregion

   #region Constructors
   /// <inheritdoc/>
   public SchematicSheetModel() { }

   /// <inheritdoc/>
   public SchematicSheetModel(string id, string name)
   {
      ID = id;
      Name = name;
   }
   #endregion

   #region Methods

   #endregion

   #region Full Props
   /// <summary>
   /// The name of the schematic.
   /// </summary>
   public string Name
   {
      get => _name;
      set
      {
         _name = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// The UUID of the schematic.
   /// </summary>
   public string ID
   {
      get => _id;
      set
      {
         _id = value;
         OnPropertyChanged();
      }
   }
   #endregion
}
