using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MVVMLibrary;

using Newtonsoft.Json;

namespace KiCadFileParserLibrary.KiCad.Project.SubModels;

/// <summary>
/// Settings used by the footprint association wizard to automatically asign footprints.
/// <para/>
/// Note: The only documentation about this is from 2015. This may be redundant now. also, the
/// default footprint is probably better. otherwise, separate files need to be created and kept up to date. ANOYING!
/// <para/>
/// This is mostly here for completeness.
/// </summary>
public class CvPcbModel : Model
{
   #region Local Props
   private ObservableCollection<string>? _equivalenceFiles;
   #endregion

   #region Constructors
   /// <inheritdoc/>
   public CvPcbModel() { }
   #endregion

   #region Methods

   #endregion

   #region Full Props
   /// <summary>
   /// List of paths to the footprint equivalence files.
   /// <para/>
   /// Note: The only documentation about this is from 2015. This may be redundant now. also, the
   /// default footprint is probably better. otherwise, separate files need to be created and kept up to date. ANOYING!
   /// <para/>
   /// This is mostly here for completeness.
   /// </summary>
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
