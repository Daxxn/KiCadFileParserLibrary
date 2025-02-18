using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KiCadFileParserLibrary.Attributes;
using KiCadFileParserLibrary.KiCad.Footprints.SubModels;
using KiCadFileParserLibrary.KiCad.General;
using KiCadFileParserLibrary.KiCad.Interfaces;
using KiCadFileParserLibrary.KiCad.Boards.Collections;
using KiCadFileParserLibrary.SExprParser;
using KiCadFileParserLibrary.Utils;
using MVVMLibrary;
using System.Security.Cryptography;

namespace KiCadFileParserLibrary.KiCad.Boards.SubModels;

/// <summary>
/// Tuned length trace model.
/// </summary>
[SExprNode("generated")]
public class TunedLengthModel : Model, IKiCadReadable
{
   #region Local Props
   private string _id = "";
   private GeneratedType _type;
   private string _name = "";
   private string _layer = "";
   private double _cornerRadiusPerc;
   private string _initialSide = "";
   private double _lastDiffPairGap;
   private string _lastNetName = "";
   private string _lastStatus = "";
   private double _lastTrackWidth;
   private string _lastTuning = "";
   private double _maxAmp;
   private double _minAmp;
   private double _minSpaced;
   private bool _overrideCustomRules;
   private bool _rounded;
   private bool _singleSided;
   private double _targetLen;
   private double _targetLenMax;
   private double _targetLenMin;
   private double _targetSkew;
   private double _targetSkewMax;
   private double _targetSkewMin;
   private string _tuningMode = "";
   private BaselineModel? _baseline;
   private BaselineCoupledModel? _baselineCoupled;
   private MemberCollection? _members;
   private OriginModel? _origin;
   private OriginModel? _end;
   #endregion

   #region Constructors
   /// <inheritdoc/>
   public TunedLengthModel() { }
   #endregion

   #region Methods
   /// <inheritdoc/>
   public void ParseNode(Node node)
   {
      if (node.Children != null)
      {
         var props = GetType().GetProperties();

         KiCadParseUtils.ParseNodes(props, node, this);
         KiCadParseUtils.ParseSubNodes(props, node, this);
         KiCadParseUtils.ParseListNodes(props, node, this);
      }
   }
   #endregion

   #region Full Props
   /// <summary>
   /// Unique ID
   /// </summary>
   [SExprSubNode("uuid")]
   public string ID
   {
      get => _id;
      set
      {
         _id = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Type of tuned trace.
   /// </summary>
   [SExprSubNode("type")]
   public GeneratedType Type
   {
      get => _type;
      set
      {
         _type = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Tuned trace name.
   /// </summary>
   [SExprSubNode("name")]
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
   /// Layer name.
   /// </summary>
   [SExprSubNode("layer")]
   public string Layer
   {
      get => _layer;
      set
      {
         _layer = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Percentage ( <c>0%</c> - <c>100%</c> ) of corner radii
   /// </summary>
   [SExprSubNode("corner_radius_percent")]
   public double CornerRadiusPerc
   {
      get => _cornerRadiusPerc;
      set
      {
         _cornerRadiusPerc = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// The start direction when generating the trace.
   /// </summary>
   [SExprSubNode("initial_side")]
   public string InitialSide
   {
      get => _initialSide;
      set
      {
         _initialSide = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Last differential pair gap width.
   /// </summary>
   [SExprSubNode("last_diff_pair_gap")]
   public double LastDiffPairGap
   {
      get => _lastDiffPairGap;
      set
      {
         _lastDiffPairGap = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Last net name.
   /// </summary>
   [SExprSubNode("last_netname")]
   public string LastNetName
   {
      get => _lastNetName;
      set
      {
         _lastNetName = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// ???
   /// </summary>
   [SExprSubNode("last_status")]
   public string LastStatus
   {
      get => _lastStatus;
      set
      {
         _lastStatus = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Last track width
   /// </summary>
   [SExprSubNode("last_track_width")]
   public double LastTrackWidth
   {
      get => _lastTrackWidth;
      set
      {
         _lastTrackWidth = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Last tuning result.
   /// </summary>
   [SExprSubNode("last_tuning")]
   public string LastTuning
   {
      get => _lastTuning;
      set
      {
         _lastTuning = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Maximum generation amplitude.
   /// </summary>
   [SExprSubNode("max_amplitude")]
   public double MaxAmplitude
   {
      get => _maxAmp;
      set
      {
         _maxAmp = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Minimum generation amplitude.
   /// </summary>
   [SExprSubNode("min_amplitude")]
   public double MinAmplitude
   {
      get => _minAmp;
      set
      {
         _minAmp = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Minimum spacing.
   /// </summary>
   [SExprSubNode("min_spacing")]
   public double MinSpacing
   {
      get => _minSpaced;
      set
      {
         _minSpaced = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Override custom generation rules.
   /// </summary>
   [SExprSubNode("override_custom_rules")]
   public bool OverrideCustomRules
   {
      get => _overrideCustomRules;
      set
      {
         _overrideCustomRules = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Round corners.
   /// </summary>
   [SExprSubNode("rounded")]
   public bool Rounded
   {
      get => _rounded;
      set
      {
         _rounded = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Can the generated trace use both sides.
   /// </summary>
   [SExprSubNode("single_sided")]
   public bool SingleSided
   {
      get => _singleSided;
      set
      {
         _singleSided = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// The nominal length the trace is targeting.
   /// </summary>
   [SExprSubNode("target_length")]
   public double TargetLength
   {
      get => _targetLen;
      set
      {
         _targetLen = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// The maximum length the trace is targeting.
   /// </summary>
   [SExprSubNode("target_length_max")]
   public double TargetLengthMax
   {
      get => _targetLenMax;
      set
      {
         _targetLenMax = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// The minimum length the trace is targeting.
   /// </summary>
   [SExprSubNode("target_length_min")]
   public double TargetLengthMin
   {
      get => _targetLenMin;
      set
      {
         _targetLenMin = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// ??? - I forget.
   /// </summary>
   [SExprSubNode("target_skew")]
   public double TargetSkew
   {
      get => _targetSkew;
      set
      {
         _targetSkew = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// ??? - I forget.
   /// </summary>
   [SExprSubNode("target_skew_max")]
   public double TargetSkewMax
   {
      get => _targetSkewMax;
      set
      {
         _targetSkewMax = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// ??? - I forget.
   /// </summary>
   [SExprSubNode("target_skew_min")]
   public double TargetSkewMin
   {
      get => _targetSkewMin;
      set
      {
         _targetSkewMin = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// The type of tuning mode used. ("Single Track" or "Differential Pair")
   /// <para/>
   /// TODO: Need to create an enum with all the available modes.
   /// </summary>
   [SExprSubNode("tuning_mode")]
   public string TuningMode
   {
      get => _tuningMode;
      set
      {
         _tuningMode = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Collection of baseline coordinates.
   /// </summary>
   public BaselineModel? BaseLine
   {
      get => _baseline;
      set
      {
         _baseline = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Collection of coupled baseline coordinates.
   /// </summary>
   public BaselineCoupledModel? BaseLineCoupled
   {
      get => _baselineCoupled;
      set
      {
         _baselineCoupled = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Collection of member IDs.
   /// </summary>
   public MemberCollection? Members
   {
      get => _members;
      set
      {
         _members = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// Origin coordinates.
   /// </summary>
   public OriginModel? Origin
   {
      get => _origin;
      set
      {
         _origin = value;
         OnPropertyChanged();
      }
   }

   /// <summary>
   /// End coordinates.
   /// </summary>
   [SExprNode("end")]
   public OriginModel? End
   {
      get => _end;
      set
      {
         _end = value;
         OnPropertyChanged();
      }
   }
   #endregion
}
