using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MVVMLibrary;

using Newtonsoft.Json;

namespace KiCadFileParserLibrary.KiCad.Settings.Common.SubModels;

/// <summary>
/// KiCad common settings auto-backup model
/// </summary>
public class AutoBackupModel : Model
{
   #region Local Props
   private bool _backupOnAutosave;
   private bool _enabled;
   private int _limitDailyFiles;
   private int _limitTotalFiles;
   private int _limitTotalSize;
   private int _minInterval;
   #endregion

   #region Constructors
   /// <inheritdoc/>
   public AutoBackupModel() { }
   #endregion

   #region Methods

   #endregion

   #region Full Props
   /// <summary>
   /// Enable backup on autosave
   /// </summary>
   [JsonProperty("backup_on_autosave")]
   public bool BackupOnAutosave
   {
      get => _backupOnAutosave;
      set
      {
         _backupOnAutosave = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Enable auto-backup
   /// </summary>
   [JsonProperty("enabled")]
   public bool Enabled
   {
      get => _enabled;
      set
      {
         _enabled = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Number of backup files per day
   /// </summary>
   [JsonProperty("limit_daily_files")]
   public int LimitDailyFiles
   {
      get => _limitDailyFiles;
      set
      {
         _limitDailyFiles = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Limit number of total backup files
   /// </summary>
   [JsonProperty("limit_total_files")]
   public int LimitTotalFiles
   {
      get => _limitTotalFiles;
      set
      {
         _limitTotalFiles = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Limit size of backup files
   /// </summary>
   [JsonProperty("limit_total_size")]
   public int LimitTotalSize
   {
      get => _limitTotalSize;
      set
      {
         _limitTotalSize = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Minimum backup interval
   /// </summary>
   [JsonProperty("min_interval")]
   public int MinInterval
   {
      get => _minInterval;
      set
      {
         _minInterval = value;
         OnPropertyChanged();
      }
   }
   #endregion
}
