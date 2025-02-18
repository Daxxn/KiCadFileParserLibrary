using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MVVMLibrary;

using Newtonsoft.Json;

namespace KiCadFileParserLibrary.KiCad.Settings.Common.SubModels;

/// <summary>
/// 
/// </summary>
public class InputSettingsModel : Model
{
   #region Local Props
   private bool _autoPan;
   private int _autoPanAccel;
   private bool _centerOnZoom;
   private bool _focusFollowSchPcb;
   private bool _horzPan;
   private bool _hotkeyFeedback;
   private bool _immediateActions;
   private int _mouseLeft;
   private int _mouseMiddle;
   private int _mouseRight;
   private bool _revScrollPanH;
   private int _scrollModPanH;
   private int _scrollModPanV;
   private int _scrollModZoom;
   private bool _warpMouseOnMove;
   private bool _zoomAccel;
   private int _zoomSpeed;
   private bool _zoomSpeedAuto;
   #endregion

   #region Constructors
   /// <inheritdoc/>
   public InputSettingsModel() { }
   #endregion

   #region Methods

   #endregion

   #region Full Props
   /// <summary>
   /// Auto pan
   /// </summary>
   [JsonProperty("auto_pan")]
   public bool AutoPan
   {
      get => _autoPan;
      set
      {
         _autoPan = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Auto pan acceleration
   /// </summary>
   [JsonProperty("auto_pan_acceleration")]
   public int AutoPanAcceleration
   {
      get => _autoPanAccel;
      set
      {
         _autoPanAccel = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Center on zoom
   /// </summary>
   [JsonProperty("center_on_zoom")]
   public bool CenterOnZoom
   {
      get => _centerOnZoom;
      set
      {
         _centerOnZoom = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Focus follow schematic / PCB
   /// </summary>
   [JsonProperty("focus_follow_sch_pcb")]
   public bool FocusFollowSchPcb
   {
      get => _focusFollowSchPcb;
      set
      {
         _focusFollowSchPcb = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Horizontal pan
   /// </summary>
   [JsonProperty("horizontal_pan")]
   public bool HorizontalPan
   {
      get => _horzPan;
      set
      {
         _horzPan = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Hotkey feedback
   /// </summary>
   [JsonProperty("hotkey_feedback")]
   public bool HotkeyFeedback
   {
      get => _hotkeyFeedback;
      set
      {
         _hotkeyFeedback = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Immediate actions
   /// </summary>
   [JsonProperty("immediate_actions")]
   public bool ImmediateActions
   {
      get => _immediateActions;
      set
      {
         _immediateActions = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Mouse left
   /// </summary>
   [JsonProperty("mouse_left")]
   public int MouseLeft
   {
      get => _mouseLeft;
      set
      {
         _mouseLeft = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Mouse middle
   /// </summary>
   [JsonProperty("mouse_middle")]
   public int MouseMiddle
   {
      get => _mouseMiddle;
      set
      {
         _mouseMiddle = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Mouse right
   /// </summary>
   [JsonProperty("mouse_right")]
   public int MouseRight
   {
      get => _mouseRight;
      set
      {
         _mouseRight = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Reverse scrll pan horizontal
   /// </summary>
   [JsonProperty("reverse_scroll_pan_h")]
   public bool ReverseScrollPanH
   {
      get => _revScrollPanH;
      set
      {
         _revScrollPanH = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Scroll modifier pan horizontal
   /// </summary>
   [JsonProperty("scroll_modifier_pan_h")]
   public int ScrollModifierPanH
   {
      get => _scrollModPanH;
      set
      {
         _scrollModPanH = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Scroll modifier pan vertical
   /// </summary>
   [JsonProperty("scroll_modifier_pan_v")]
   public int ScrollModifierPanV
   {
      get => _scrollModPanV;
      set
      {
         _scrollModPanV = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Scroll modifier zoom
   /// </summary>
   [JsonProperty("scroll_modifier_zoom")]
   public int ScrollModifierZoom
   {
      get => _scrollModZoom;
      set
      {
         _scrollModZoom = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Warp mouse on move
   /// </summary>
   [JsonProperty("warp_mouse_on_move")]
   public bool WarpMouseOnMove
   {
      get => _warpMouseOnMove;
      set
      {
         _warpMouseOnMove = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// zoom acceleration
   /// </summary>
   [JsonProperty("zoom_acceleration")]
   public bool ZoomAcceleration
   {
      get => _zoomAccel;
      set
      {
         _zoomAccel = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Zoom speed
   /// </summary>
   [JsonProperty("zoom_speed")]
   public int ZoomSpeed
   {
      get => _zoomSpeed;
      set
      {
         _zoomSpeed = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Zoom speed auto
   /// </summary>
   [JsonProperty("zoom_speed_auto")]
   public bool ZoomSpeedAuto
   {
      get => _zoomSpeedAuto;
      set
      {
         _zoomSpeedAuto = value;
         OnPropertyChanged();
      }
   }
   #endregion
}
