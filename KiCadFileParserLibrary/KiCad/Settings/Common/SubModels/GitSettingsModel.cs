using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MVVMLibrary;

using Newtonsoft.Json;

namespace KiCadFileParserLibrary.KiCad.Settings.Common.SubModels;

/// <summary>
/// Git settings
/// </summary>
public class GitSettingsModel : Model
{
   #region Local Props
   private string _email = "";
   private string _name = "";
   private object? _repos = null;
   private bool _useDefaultAuthor;
   #endregion

   #region Constructors
   /// <inheritdoc/>
   public GitSettingsModel() { }
   #endregion

   #region Methods

   #endregion

   #region Full Props
   /// <summary>
   /// Git author email
   /// </summary>
   [JsonProperty("authorEmail")]
   public string Email
   {
      get => _email;
      set
      {
         _email = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Git author name
   /// </summary>
   [JsonProperty("authorName")]
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
   /// Git repositories
   /// <para/>
   /// Unknown. Can't get any documentation.
   /// </summary>
   [JsonProperty("repositories")]
   public object? Repos
   {
      get => _repos;
      set
      {
         _repos = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Use default author
   /// </summary>
   [JsonProperty("useDefaultAuthor")]
   public bool UseDefaultAuthor
   {
      get => _useDefaultAuthor;
      set
      {
         _useDefaultAuthor = value;
         OnPropertyChanged();
      }
   }
   #endregion
}
