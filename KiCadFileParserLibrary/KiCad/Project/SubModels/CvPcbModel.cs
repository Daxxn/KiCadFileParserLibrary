using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MVVMLibrary;

using Newtonsoft.Json;

namespace KiCadFileParserLibrary.KiCad.Project.SubModels;

public class CvPcbModel : Model
{
   #region Local Props
   private ObservableCollection<string>? _equivalenceFiles;
   #endregion

   #region Constructors
   public CvPcbModel() { }
   #endregion

   #region Methods

   #endregion

   #region Full Props
   [JsonProperty(PropertyName = "equivalence_files")]
   public ObservableCollection<string>? EquivalenceFiles
   {
      get => _equivalenceFiles;
      set
      {
         _equivalenceFiles = value;
         OnPropertyChanged();
      }
   }
   #endregion
}
