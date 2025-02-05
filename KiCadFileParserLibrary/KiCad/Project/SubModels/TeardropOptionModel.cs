using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MVVMLibrary;

using Newtonsoft.Json;

namespace KiCadFileParserLibrary.KiCad.Project.SubModels
{
   public class TeardropOptionModel : Model
   {
      #region Local Props
      private bool _onPadSmd;
      private bool _onRoundShapesOnly;
      private bool _onTrackEnd;
      private bool _onViaPad;
      #endregion

      #region Constructors
      public TeardropOptionModel() { }
      #endregion

      #region Methods

      #endregion

      #region Full Props
      [JsonProperty(PropertyName = "td_onpadsmd")]
      public bool OnPadSmd
      {
         get => _onPadSmd;
         set
         {
            _onPadSmd = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "td_onroundshapesonly")]
      public bool OnRoundShapesOnly
      {
         get => _onRoundShapesOnly;
         set
         {
            _onRoundShapesOnly = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "td_ontrackend")]
      public bool OnTrackEnd
      {
         get => _onTrackEnd;
         set
         {
            _onTrackEnd = value;
            OnPropertyChanged();
         }
      }

      [JsonProperty(PropertyName = "td_onviapad")]
      public bool OnViaPad
      {
         get => _onViaPad;
         set
         {
            _onViaPad = value;
            OnPropertyChanged();
         }
      }
      #endregion
   }
}
