using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MVVMLibrary;

using Newtonsoft.Json;

namespace KiCadFileParserLibrary.KiCad.Project.SubModels
{
   public class MetadataModel : Model
   {
      #region Local Props
      private string? _fileName;
      private int _version;
      #endregion

      #region Constructors
      public MetadataModel() { }
      #endregion

      #region Methods

      #endregion

      #region Full Props
      [JsonProperty(PropertyName = "filename", NullValueHandling = NullValueHandling.Ignore)]
      public string? FileName
      {
         get => _fileName;
         set
         {
            _fileName = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "version")]
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
}
