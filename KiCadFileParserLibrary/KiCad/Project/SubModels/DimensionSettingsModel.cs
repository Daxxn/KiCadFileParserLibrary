using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MVVMLibrary;

using Newtonsoft.Json;

namespace KiCadFileParserLibrary.KiCad.Project.SubModels
{
   public class DimensionSettingsModel : Model
   {
      #region Local Props
      private int _arrowLength;
      private int _extensionOffset;
      private bool _keepTextAligned;
      private bool _suppressZeroes;
      private int _textPosition;
      private UnitsType _unitFormat;
      #endregion

      #region Constructors
      public DimensionSettingsModel() { }
      #endregion

      #region Methods

      #endregion

      #region Full Props
      [JsonProperty(PropertyName = "arrow_length")]
      public int ArrowLength
      {
         get => _arrowLength;
         set
         {
            _arrowLength = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "extension_offset")]
      public int ExtensionOffset
      {
         get => _extensionOffset;
         set
         {
            _extensionOffset = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "keep_text_aligned")]
      public bool KeepTextAligned
      {
         get => _keepTextAligned;
         set
         {
            _keepTextAligned = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "suppress_zeroes")]
      public bool SuppressZeroes
      {
         get => _suppressZeroes;
         set
         {
            _suppressZeroes = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "text_position")]
      public int TextPosition // I think this is an enum. Need to check the dimension object.
      {
         get => _textPosition;
         set
         {
            _textPosition = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "units_format")]
      public UnitsType UnitFormat
      {
         get => _unitFormat;
         set
         {
            _unitFormat = value;
            OnPropertyChanged();
         }
      }
      #endregion
   }
}
