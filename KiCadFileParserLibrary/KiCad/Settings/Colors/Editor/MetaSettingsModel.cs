using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MVVMLibrary;

namespace KiCadFileParserLibrary.KiCad.Settings.Colors.Editor;

/// <summary>
/// Theme meta model
/// </summary>
public class MetaSettingsModel : Model
{
   #region Local Props
   private string _name = "";
   private int _version;
   #endregion

   #region Constructors
   /// <inheritdoc/>
   public MetaSettingsModel() { }
   #endregion

   #region Methods

   #endregion

   #region Full Props
   /// <summary>
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
   /// </summary>
   public int Version
   {
      get => _version;
      set
      {
         _version = value;
         OnPropertyChanged();
      }
   }
   #endregion
}
