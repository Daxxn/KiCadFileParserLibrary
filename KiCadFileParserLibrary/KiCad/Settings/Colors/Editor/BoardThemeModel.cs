using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Utils.JsonConverters;

using MVVMLibrary;

using Newtonsoft.Json;

namespace KiCadFileParserLibrary.KiCad.Settings.Colors.Editor;

/// <summary>
/// 
/// </summary>
public class BoardThemeModel : Model
{
   #region Local Props
   private RgbaColorModel _anchor = new();
   private RgbaColorModel _auxItems = new();
   private RgbaColorModel _botAdhesive = new();
   private RgbaColorModel _botCrtyd = new();
   private RgbaColorModel _botFab = new();
   private RgbaColorModel _botMask = new();
   private RgbaColorModel _botPaste = new();
   private RgbaColorModel _botSilk = new();
   private RgbaColorModel _background = new();
   private RgbaColorModel _userCmmnts = new();
   private RgbaColorModel _conflitShadow = new();
   private RgbaColorModel _cursor = new();
   private RgbaColorModel _drcError = new();
   private RgbaColorModel _drcExclusion = new();
   private RgbaColorModel _drcWarning = new();
   private RgbaColorModel _dwgsUser = new();
   private RgbaColorModel _eco1User = new();
   private RgbaColorModel _eco2User = new();
   private RgbaColorModel _edgeCuts = new();
   private RgbaColorModel _topAdhesive = new();
   private RgbaColorModel _topCrtyd = new();
   private RgbaColorModel _topFab = new();
   private RgbaColorModel _topMask = new();
   private RgbaColorModel _topPaste = new();
   private RgbaColorModel _topSilk = new();
   private RgbaColorModel _fpTextInvisible = new();
   private RgbaColorModel _grid = new();
   private RgbaColorModel _gridAxis = new();
   private RgbaColorModel _lockedShadow = new();
   private RgbaColorModel _margin = new();
   private RgbaColorModel _padPlatedHole = new();
   private RgbaColorModel _padThroughHole = new();
   private RgbaColorModel _pageLimits = new();
   private RgbaColorModel _platedHole = new();
   private RgbaColorModel _ratsnest = new();
   private RgbaColorModel _user1 = new();
   private RgbaColorModel _user2 = new();
   private RgbaColorModel _user3 = new();
   private RgbaColorModel _user4 = new();
   private RgbaColorModel _user5 = new();
   private RgbaColorModel _user6 = new();
   private RgbaColorModel _user7 = new();
   private RgbaColorModel _user8 = new();
   private RgbaColorModel _user9 = new();
   private RgbaColorModel _viaBlindBuried = new();
   private RgbaColorModel _viaHole = new();
   private RgbaColorModel _viaMicro = new();
   private RgbaColorModel _viaThrough = new();
   private RgbaColorModel _worksheet = new();
   private CopperColorsModel _copper = new();
   #endregion

   #region Constructors
   /// <inheritdoc/>
   public BoardThemeModel() { }
   #endregion

   #region Methods

   #endregion

   #region Full Props
   /// <summary>
   /// </summary>
   [JsonProperty("anchor")]
   [JsonConverter(typeof(RgbaColorJsonConverter))]
   public RgbaColorModel Anchor
   {
      get => _anchor;
      set
      {
         _anchor = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// </summary>
   [JsonProperty("aux_items")]
   [JsonConverter(typeof(RgbaColorJsonConverter))]
   public RgbaColorModel AuxItems
   {
      get => _auxItems;
      set
      {
         _auxItems = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// </summary>
   [JsonProperty("b_adhes")]
   [JsonConverter(typeof(RgbaColorJsonConverter))]
   public RgbaColorModel BottomAdhesive
   {
      get => _botAdhesive;
      set
      {
         _botAdhesive = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// </summary>
   [JsonProperty("b_crtyd")]
   [JsonConverter(typeof(RgbaColorJsonConverter))]
   public RgbaColorModel BottomCourtyard
   {
      get => _botCrtyd;
      set
      {
         _botCrtyd = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// </summary>
   [JsonProperty("b_fab")]
   [JsonConverter(typeof(RgbaColorJsonConverter))]
   public RgbaColorModel BottomFabrication
   {
      get => _botFab;
      set
      {
         _botFab = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// </summary>
   [JsonProperty("b_mask")]
   [JsonConverter(typeof(RgbaColorJsonConverter))]
   public RgbaColorModel BottomSolderMask
   {
      get => _botMask;
      set
      {
         _botMask = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// </summary>
   [JsonProperty("b_paste")]
   [JsonConverter(typeof(RgbaColorJsonConverter))]
   public RgbaColorModel BottomSolderPaste
   {
      get => _botPaste;
      set
      {
         _botPaste = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// </summary>
   [JsonProperty("b_silks")]
   [JsonConverter(typeof(RgbaColorJsonConverter))]
   public RgbaColorModel BottomSilkscreen
   {
      get => _botSilk;
      set
      {
         _botSilk = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// </summary>
   [JsonProperty("background")]
   [JsonConverter(typeof(RgbaColorJsonConverter))]
   public RgbaColorModel Background
   {
      get => _background;
      set
      {
         _background = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// </summary>
   [JsonProperty("cmts_user")]
   [JsonConverter(typeof(RgbaColorJsonConverter))]
   public RgbaColorModel UserComments
   {
      get => _userCmmnts;
      set
      {
         _userCmmnts = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// </summary>
   [JsonProperty("conflicts_shadow")]
   [JsonConverter(typeof(RgbaColorJsonConverter))]
   public RgbaColorModel ConflictShadow
   {
      get => _conflitShadow;
      set
      {
         _conflitShadow = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// </summary>
   [JsonProperty("cursor")]
   [JsonConverter(typeof(RgbaColorJsonConverter))]
   public RgbaColorModel Cursor
   {
      get => _cursor;
      set
      {
         _cursor = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// </summary>
   [JsonProperty("drc_error")]
   [JsonConverter(typeof(RgbaColorJsonConverter))]
   public RgbaColorModel DRCError
   {
      get => _drcError;
      set
      {
         _drcError = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// </summary>
   [JsonProperty("drc_exclusion")]
   [JsonConverter(typeof(RgbaColorJsonConverter))]
   public RgbaColorModel DRCExclusion
   {
      get => _drcExclusion;
      set
      {
         _drcExclusion = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// </summary>
   [JsonProperty("drc_warning")]
   [JsonConverter(typeof(RgbaColorJsonConverter))]
   public RgbaColorModel DRCWarning
   {
      get => _drcWarning;
      set
      {
         _drcWarning = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// </summary>
   [JsonProperty("dwgs_user")]
   [JsonConverter(typeof(RgbaColorJsonConverter))]
   public RgbaColorModel UserDrawings
   {
      get => _dwgsUser;
      set
      {
         _dwgsUser = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// </summary>
   [JsonProperty("eco1_user")]
   [JsonConverter(typeof(RgbaColorJsonConverter))]
   public RgbaColorModel Eco1User
   {
      get => _eco1User;
      set
      {
         _eco1User = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// </summary>
   [JsonProperty("eco2_user")]
   [JsonConverter(typeof(RgbaColorJsonConverter))]
   public RgbaColorModel Eco2User
   {
      get => _eco2User;
      set
      {
         _eco2User = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// </summary>
   [JsonProperty("edge_cuts")]
   [JsonConverter(typeof(RgbaColorJsonConverter))]
   public RgbaColorModel EdgeCuts
   {
      get => _edgeCuts;
      set
      {
         _edgeCuts = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// </summary>
   [JsonProperty("f_adhes")]
   [JsonConverter(typeof(RgbaColorJsonConverter))]
   public RgbaColorModel TopAdhesive
   {
      get => _topAdhesive;
      set
      {
         _topAdhesive = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// </summary>
   [JsonProperty("f_crtyd")]
   [JsonConverter(typeof(RgbaColorJsonConverter))]
   public RgbaColorModel TopCourtyard
   {
      get => _topCrtyd;
      set
      {
         _topCrtyd = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// </summary>
   [JsonProperty("f_fab")]
   [JsonConverter(typeof(RgbaColorJsonConverter))]
   public RgbaColorModel TopFabrication
   {
      get => _topFab;
      set
      {
         _topFab = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// </summary>
   [JsonProperty("f_mask")]
   [JsonConverter(typeof(RgbaColorJsonConverter))]
   public RgbaColorModel TopSolderMask
   {
      get => _topMask;
      set
      {
         _topMask = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// </summary>
   [JsonProperty("f_paste")]
   [JsonConverter(typeof(RgbaColorJsonConverter))]
   public RgbaColorModel TopSolderPaste
   {
      get => _topPaste;
      set
      {
         _topPaste = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// </summary>
   [JsonProperty("f_silks")]
   [JsonConverter(typeof(RgbaColorJsonConverter))]
   public RgbaColorModel TopSilkscreen
   {
      get => _topSilk;
      set
      {
         _topSilk = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// </summary>
   [JsonProperty("footprint_text_invisible")]
   [JsonConverter(typeof(RgbaColorJsonConverter))]
   public RgbaColorModel FootprintTextInvisible
   {
      get => _fpTextInvisible;
      set
      {
         _fpTextInvisible = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// </summary>
   [JsonProperty("grid")]
   [JsonConverter(typeof(RgbaColorJsonConverter))]
   public RgbaColorModel Grid
   {
      get => _grid;
      set
      {
         _grid = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// </summary>
   [JsonProperty("grid_axes")]
   [JsonConverter(typeof(RgbaColorJsonConverter))]
   public RgbaColorModel GridAxis
   {
      get => _gridAxis;
      set
      {
         _gridAxis = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// </summary>
   [JsonProperty("locked_shadow")]
   [JsonConverter(typeof(RgbaColorJsonConverter))]
   public RgbaColorModel LockedShadow
   {
      get => _lockedShadow;
      set
      {
         _lockedShadow = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// </summary>
   [JsonProperty("margin")]
   [JsonConverter(typeof(RgbaColorJsonConverter))]
   public RgbaColorModel Margin
   {
      get => _margin;
      set
      {
         _margin = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// </summary>
   [JsonProperty("pad_plated_hole")]
   [JsonConverter(typeof(RgbaColorJsonConverter))]
   public RgbaColorModel PadPlatedHole
   {
      get => _padPlatedHole;
      set
      {
         _padPlatedHole = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// </summary>
   [JsonProperty("pad_through_hole")]
   [JsonConverter(typeof(RgbaColorJsonConverter))]
   public RgbaColorModel PadThroughHole
   {
      get => _padThroughHole;
      set
      {
         _padThroughHole = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// </summary>
   [JsonProperty("page_limits")]
   [JsonConverter(typeof(RgbaColorJsonConverter))]
   public RgbaColorModel PageLimits
   {
      get => _pageLimits;
      set
      {
         _pageLimits = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// </summary>
   [JsonProperty("plated_hole")]
   [JsonConverter(typeof(RgbaColorJsonConverter))]
   public RgbaColorModel PlatedHole
   {
      get => _platedHole;
      set
      {
         _platedHole = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// </summary>
   [JsonProperty("ratsnest")]
   [JsonConverter(typeof(RgbaColorJsonConverter))]
   public RgbaColorModel RatsNest
   {
      get => _ratsnest;
      set
      {
         _ratsnest = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// </summary>
   [JsonProperty("user_1")]
   [JsonConverter(typeof(RgbaColorJsonConverter))]
   public RgbaColorModel User1
   {
      get => _user1;
      set
      {
         _user1 = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// </summary>
   [JsonProperty("user_2")]
   [JsonConverter(typeof(RgbaColorJsonConverter))]
   public RgbaColorModel User2
   {
      get => _user2;
      set
      {
         _user2 = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// </summary>
   [JsonProperty("user_3")]
   [JsonConverter(typeof(RgbaColorJsonConverter))]
   public RgbaColorModel User3
   {
      get => _user3;
      set
      {
         _user3 = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// </summary>
   [JsonProperty("user_4")]
   [JsonConverter(typeof(RgbaColorJsonConverter))]
   public RgbaColorModel User4
   {
      get => _user4;
      set
      {
         _user4 = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// </summary>
   [JsonProperty("user_5")]
   [JsonConverter(typeof(RgbaColorJsonConverter))]
   public RgbaColorModel User5
   {
      get => _user5;
      set
      {
         _user5 = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// </summary>
   [JsonProperty("user_6")]
   [JsonConverter(typeof(RgbaColorJsonConverter))]
   public RgbaColorModel User6
   {
      get => _user6;
      set
      {
         _user6 = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// </summary>
   [JsonProperty("user_7")]
   [JsonConverter(typeof(RgbaColorJsonConverter))]
   public RgbaColorModel User7
   {
      get => _user7;
      set
      {
         _user7 = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// </summary>
   [JsonProperty("user_8")]
   [JsonConverter(typeof(RgbaColorJsonConverter))]
   public RgbaColorModel User8
   {
      get => _user8;
      set
      {
         _user8 = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// </summary>
   [JsonProperty("user_9")]
   [JsonConverter(typeof(RgbaColorJsonConverter))]
   public RgbaColorModel User9
   {
      get => _user9;
      set
      {
         _user9 = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// </summary>
   [JsonProperty("via_blind_buried")]
   [JsonConverter(typeof(RgbaColorJsonConverter))]
   public RgbaColorModel ViaBlindBurried
   {
      get => _viaBlindBuried;
      set
      {
         _viaBlindBuried = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// </summary>
   [JsonProperty("via_hole")]
   [JsonConverter(typeof(RgbaColorJsonConverter))]
   public RgbaColorModel ViaHole
   {
      get => _viaHole;
      set
      {
         _viaHole = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// </summary>
   [JsonProperty("via_micro")]
   [JsonConverter(typeof(RgbaColorJsonConverter))]
   public RgbaColorModel ViaMicro
   {
      get => _viaMicro;
      set
      {
         _viaMicro = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// </summary>
   [JsonProperty("via_through")]
   [JsonConverter(typeof(RgbaColorJsonConverter))]
   public RgbaColorModel ViaThrough
   {
      get => _viaThrough;
      set
      {
         _viaThrough = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// </summary>
   [JsonProperty("worksheet")]
   [JsonConverter(typeof(RgbaColorJsonConverter))]
   public RgbaColorModel Worksheet
   {
      get => _worksheet;
      set
      {
         _worksheet = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// </summary>
   [JsonProperty("copper")]
   public CopperColorsModel Copper
   {
      get => _copper;
      set
      {
         _copper = value;
         OnPropertyChanged();
      }
   }
   #endregion
}
