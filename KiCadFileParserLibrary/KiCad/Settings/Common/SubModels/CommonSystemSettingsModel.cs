using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MVVMLibrary;

using Newtonsoft.Json;

namespace KiCadFileParserLibrary.KiCad.Settings.Common.SubModels;

/// <summary>
/// KiCad common system setting
/// </summary>
public class CommonSystemSettingsModel : Model
{
   #region Local Props
   private int _autosaveInterval;
   private int _clear3dCacheInterval;
   private int _fileHistSize;
   private string _language = "";
   private string _pdfViewerPath = "";
   private string _textEditorPath = "";
   private bool _useSystemPdfViewer;
   private string _workingDir = "";
   #endregion

   #region Constructors
   /// <inheritdoc/>
   public CommonSystemSettingsModel() { }
   #endregion

   #region Methods

   #endregion

   #region Full Props
   /// <summary>
   /// Autosave interval in seconds
   /// </summary>
   [JsonProperty("autosave_interval")]
   public int AutosaveInterval
   {
      get => _autosaveInterval;
      set
      {
         _autosaveInterval = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Clear 3D file cache interval in days
   /// </summary>
   [JsonProperty("clear_3d_cache_interval")]
   public int Clear3DCacheInterval
   {
      get => _clear3dCacheInterval;
      set
      {
         _clear3dCacheInterval = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Project file history size
   /// </summary>
   [JsonProperty("file_history_size")]
   public int FileHistorySize
   {
      get => _fileHistSize;
      set
      {
         _fileHistSize = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// System language
   /// </summary>
   [JsonProperty("language")]
   public string Language
   {
      get => _language;
      set
      {
         _language = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// PDF viewer file path
   /// </summary>
   [JsonProperty("pdf_viewer_name")]
   public string PDFViewerPath
   {
      get => _pdfViewerPath;
      set
      {
         _pdfViewerPath = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Text editor file path
   /// </summary>
   [JsonProperty("text_editor")]
   public string TextEditorPath
   {
      get => _textEditorPath;
      set
      {
         _textEditorPath = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Use the system default PDF viewer
   /// </summary>
   [JsonProperty("use_system_pdf_viewer")]
   public bool UseSystemPDFViewer
   {
      get => _useSystemPdfViewer;
      set
      {
         _useSystemPdfViewer = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Working directory for scripting and other actions.
   /// </summary>
   [JsonProperty("working_dir")]
   public string WorkingDirectory
   {
      get => _workingDir;
      set
      {
         _workingDir = value;
         OnPropertyChanged();
      }
   }
   #endregion
}
